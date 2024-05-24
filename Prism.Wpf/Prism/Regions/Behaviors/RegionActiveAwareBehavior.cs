using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using Prism.Common;

namespace Prism.Regions.Behaviors
{
	// Token: 0x0200003E RID: 62
	public class RegionActiveAwareBehavior : IRegionBehavior
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x000054AA File Offset: 0x000036AA
		// (set) Token: 0x060001A9 RID: 425 RVA: 0x000054B2 File Offset: 0x000036B2
		public IRegion Region { get; set; }

		// Token: 0x060001AA RID: 426 RVA: 0x000054BC File Offset: 0x000036BC
		public void Attach()
		{
			INotifyCollectionChanged collection = this.GetCollection();
			if (collection != null)
			{
				collection.CollectionChanged += this.OnCollectionChanged;
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x000054E8 File Offset: 0x000036E8
		public void Detach()
		{
			INotifyCollectionChanged collection = this.GetCollection();
			if (collection != null)
			{
				collection.CollectionChanged -= this.OnCollectionChanged;
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00005514 File Offset: 0x00003714
		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				using (IEnumerator enumerator = e.NewItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						Action<IActiveAware> action = delegate(IActiveAware activeAware)
						{
							activeAware.IsActive = true;
						};
						MvvmHelpers.ViewAndViewModelAction<IActiveAware>(obj, action);
						this.InvokeOnSynchronizedActiveAwareChildren(obj, action);
					}
					return;
				}
			}
			if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach (object obj2 in e.OldItems)
				{
					Action<IActiveAware> action2 = delegate(IActiveAware activeAware)
					{
						activeAware.IsActive = false;
					};
					MvvmHelpers.ViewAndViewModelAction<IActiveAware>(obj2, action2);
					this.InvokeOnSynchronizedActiveAwareChildren(obj2, action2);
				}
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00005614 File Offset: 0x00003814
		private void InvokeOnSynchronizedActiveAwareChildren(object item, Action<IActiveAware> invocation)
		{
			DependencyObject dependencyObject = item as DependencyObject;
			if (dependencyObject != null)
			{
				IRegionManager regionManager = RegionManager.GetRegionManager(dependencyObject);
				if (regionManager == null || regionManager == this.Region.RegionManager)
				{
					return;
				}
				foreach (object view in regionManager.Regions.SelectMany((IRegion e) => e.ActiveViews).Where(new Func<object, bool>(this.ShouldSyncActiveState)))
				{
					MvvmHelpers.ViewAndViewModelAction<IActiveAware>(view, invocation);
				}
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000056B8 File Offset: 0x000038B8
		private bool ShouldSyncActiveState(object view)
		{
			if (Attribute.IsDefined(view.GetType(), typeof(SyncActiveStateAttribute)))
			{
				return true;
			}
			FrameworkElement frameworkElement = view as FrameworkElement;
			if (frameworkElement != null)
			{
				object dataContext = frameworkElement.DataContext;
				return dataContext != null && Attribute.IsDefined(dataContext.GetType(), typeof(SyncActiveStateAttribute));
			}
			return false;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000570B File Offset: 0x0000390B
		private INotifyCollectionChanged GetCollection()
		{
			return this.Region.ActiveViews;
		}

		// Token: 0x04000053 RID: 83
		public const string BehaviorKey = "ActiveAware";
	}
}
