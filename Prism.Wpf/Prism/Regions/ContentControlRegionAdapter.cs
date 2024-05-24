using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using Prism.Properties;

namespace Prism.Regions
{
	// Token: 0x02000007 RID: 7
	public class ContentControlRegionAdapter : RegionAdapterBase<ContentControl>
	{
		// Token: 0x06000020 RID: 32 RVA: 0x000023B1 File Offset: 0x000005B1
		public ContentControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
		{
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000023BC File Offset: 0x000005BC
		protected override void Adapt(IRegion region, ContentControl regionTarget)
		{
			if (regionTarget == null)
			{
				throw new ArgumentNullException("regionTarget");
			}
			if (regionTarget.Content != null || BindingOperations.GetBinding(regionTarget, ContentControl.ContentProperty) != null)
			{
				throw new InvalidOperationException(Resources.ContentControlHasContentException);
			}
			region.ActiveViews.CollectionChanged += delegate(object <sender>, NotifyCollectionChangedEventArgs <e>)
			{
				regionTarget.Content = region.ActiveViews.FirstOrDefault<object>();
			};
			region.Views.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
			{
				if (e.Action == NotifyCollectionChangedAction.Add && region.ActiveViews.Count<object>() == 0)
				{
					region.Activate(e.NewItems[0]);
				}
			};
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000245B File Offset: 0x0000065B
		protected override IRegion CreateRegion()
		{
			return new SingleActiveRegion();
		}
	}
}
