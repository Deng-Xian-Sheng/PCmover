using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using Prism.Common;

namespace Prism.Regions.Behaviors
{
	// Token: 0x02000041 RID: 65
	public class RegionMemberLifetimeBehavior : RegionBehavior
	{
		// Token: 0x060001C2 RID: 450 RVA: 0x000058D8 File Offset: 0x00003AD8
		protected override void OnAttach()
		{
			base.Region.ActiveViews.CollectionChanged += this.OnActiveViewsChanged;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000058F8 File Offset: 0x00003AF8
		private void OnActiveViewsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action != NotifyCollectionChangedAction.Remove)
			{
				return;
			}
			foreach (object obj in e.OldItems)
			{
				if (!RegionMemberLifetimeBehavior.ShouldKeepAlive(obj) && base.Region.Views.Contains(obj))
				{
					base.Region.Remove(obj);
				}
			}
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00005978 File Offset: 0x00003B78
		private static bool ShouldKeepAlive(object inactiveView)
		{
			IRegionMemberLifetime implementerFromViewOrViewModel = MvvmHelpers.GetImplementerFromViewOrViewModel<IRegionMemberLifetime>(inactiveView);
			if (implementerFromViewOrViewModel != null)
			{
				return implementerFromViewOrViewModel.KeepAlive;
			}
			RegionMemberLifetimeAttribute itemOrContextLifetimeAttribute = RegionMemberLifetimeBehavior.GetItemOrContextLifetimeAttribute(inactiveView);
			return itemOrContextLifetimeAttribute == null || itemOrContextLifetimeAttribute.KeepAlive;
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x000059A8 File Offset: 0x00003BA8
		private static RegionMemberLifetimeAttribute GetItemOrContextLifetimeAttribute(object inactiveView)
		{
			RegionMemberLifetimeAttribute regionMemberLifetimeAttribute = RegionMemberLifetimeBehavior.GetCustomAttributes<RegionMemberLifetimeAttribute>(inactiveView.GetType()).FirstOrDefault<RegionMemberLifetimeAttribute>();
			if (regionMemberLifetimeAttribute != null)
			{
				return regionMemberLifetimeAttribute;
			}
			FrameworkElement frameworkElement = inactiveView as FrameworkElement;
			if (frameworkElement != null && frameworkElement.DataContext != null)
			{
				return RegionMemberLifetimeBehavior.GetCustomAttributes<RegionMemberLifetimeAttribute>(frameworkElement.DataContext.GetType()).FirstOrDefault<RegionMemberLifetimeAttribute>();
			}
			return null;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x000059F4 File Offset: 0x00003BF4
		private static IEnumerable<T> GetCustomAttributes<T>(Type type)
		{
			return type.GetCustomAttributes(typeof(T), true).OfType<T>();
		}

		// Token: 0x04000059 RID: 89
		public const string BehaviorKey = "RegionMemberLifetimeBehavior";
	}
}
