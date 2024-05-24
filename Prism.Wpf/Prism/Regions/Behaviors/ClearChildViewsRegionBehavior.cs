using System;
using System.ComponentModel;
using System.Windows;

namespace Prism.Regions.Behaviors
{
	// Token: 0x0200003B RID: 59
	public class ClearChildViewsRegionBehavior : RegionBehavior
	{
		// Token: 0x06000192 RID: 402 RVA: 0x000051B9 File Offset: 0x000033B9
		public static bool GetClearChildViews(DependencyObject target)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			return (bool)target.GetValue(ClearChildViewsRegionBehavior.ClearChildViewsProperty);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x000051D9 File Offset: 0x000033D9
		public static void SetClearChildViews(DependencyObject target, bool value)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			target.SetValue(ClearChildViewsRegionBehavior.ClearChildViewsProperty, value);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000051FA File Offset: 0x000033FA
		protected override void OnAttach()
		{
			base.Region.PropertyChanged += this.Region_PropertyChanged;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00005214 File Offset: 0x00003414
		private static void ClearChildViews(IRegion region)
		{
			foreach (object obj in region.Views)
			{
				DependencyObject dependencyObject = obj as DependencyObject;
				if (dependencyObject != null && ClearChildViewsRegionBehavior.GetClearChildViews(dependencyObject))
				{
					dependencyObject.ClearValue(RegionManager.RegionManagerProperty);
				}
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00005278 File Offset: 0x00003478
		private void Region_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "RegionManager" && base.Region.RegionManager == null)
			{
				ClearChildViewsRegionBehavior.ClearChildViews(base.Region);
			}
		}

		// Token: 0x0400004D RID: 77
		public const string BehaviorKey = "ClearChildViews";

		// Token: 0x0400004E RID: 78
		public static readonly DependencyProperty ClearChildViewsProperty = DependencyProperty.RegisterAttached("ClearChildViews", typeof(bool), typeof(ClearChildViewsRegionBehavior), new PropertyMetadata(false));
	}
}
