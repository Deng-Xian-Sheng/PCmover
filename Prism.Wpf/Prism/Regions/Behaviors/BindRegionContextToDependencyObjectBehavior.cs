using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using Prism.Common;

namespace Prism.Regions.Behaviors
{
	// Token: 0x0200003A RID: 58
	public class BindRegionContextToDependencyObjectBehavior : IRegionBehavior
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00004F43 File Offset: 0x00003143
		// (set) Token: 0x06000189 RID: 393 RVA: 0x00004F4B File Offset: 0x0000314B
		public IRegion Region { get; set; }

		// Token: 0x0600018A RID: 394 RVA: 0x00004F54 File Offset: 0x00003154
		public void Attach()
		{
			this.Region.Views.CollectionChanged += this.Views_CollectionChanged;
			this.Region.PropertyChanged += this.Region_PropertyChanged;
			BindRegionContextToDependencyObjectBehavior.SetContextToViews(this.Region.Views, this.Region.Context);
			this.AttachNotifyChangeEvent(this.Region.Views);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00004FC0 File Offset: 0x000031C0
		private static void SetContextToViews(IEnumerable views, object context)
		{
			foreach (object obj in views)
			{
				DependencyObject dependencyObject = obj as DependencyObject;
				if (dependencyObject != null)
				{
					RegionContext.GetObservableContext(dependencyObject).Value = context;
				}
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000501C File Offset: 0x0000321C
		private void AttachNotifyChangeEvent(IEnumerable views)
		{
			foreach (object obj in views)
			{
				DependencyObject dependencyObject = obj as DependencyObject;
				if (dependencyObject != null)
				{
					RegionContext.GetObservableContext(dependencyObject).PropertyChanged += this.ViewRegionContext_OnPropertyChangedEvent;
				}
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00005084 File Offset: 0x00003284
		private void DetachNotifyChangeEvent(IEnumerable views)
		{
			foreach (object obj in views)
			{
				DependencyObject dependencyObject = obj as DependencyObject;
				if (dependencyObject != null)
				{
					RegionContext.GetObservableContext(dependencyObject).PropertyChanged -= this.ViewRegionContext_OnPropertyChangedEvent;
				}
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x000050EC File Offset: 0x000032EC
		private void ViewRegionContext_OnPropertyChangedEvent(object sender, PropertyChangedEventArgs args)
		{
			if (args.PropertyName == "Value")
			{
				ObservableObject<object> observableObject = (ObservableObject<object>)sender;
				this.Region.Context = observableObject.Value;
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00005124 File Offset: 0x00003324
		private void Views_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				BindRegionContextToDependencyObjectBehavior.SetContextToViews(e.NewItems, this.Region.Context);
				this.AttachNotifyChangeEvent(e.NewItems);
				return;
			}
			if (e.Action == NotifyCollectionChangedAction.Remove && this.Region.Context != null)
			{
				this.DetachNotifyChangeEvent(e.OldItems);
				BindRegionContextToDependencyObjectBehavior.SetContextToViews(e.OldItems, null);
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000518A File Offset: 0x0000338A
		private void Region_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Context")
			{
				BindRegionContextToDependencyObjectBehavior.SetContextToViews(this.Region.Views, this.Region.Context);
			}
		}

		// Token: 0x0400004B RID: 75
		public const string BehaviorKey = "ContextToDependencyObject";
	}
}
