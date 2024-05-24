using System;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Data;
using Prism.Properties;

namespace Prism.Regions
{
	// Token: 0x0200001B RID: 27
	public class ItemsControlRegionAdapter : RegionAdapterBase<ItemsControl>
	{
		// Token: 0x0600008C RID: 140 RVA: 0x00002631 File Offset: 0x00000831
		public ItemsControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
		{
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000263C File Offset: 0x0000083C
		protected override void Adapt(IRegion region, ItemsControl regionTarget)
		{
			if (region == null)
			{
				throw new ArgumentNullException("region");
			}
			if (regionTarget == null)
			{
				throw new ArgumentNullException("regionTarget");
			}
			if (regionTarget.ItemsSource != null || BindingOperations.GetBinding(regionTarget, ItemsControl.ItemsSourceProperty) != null)
			{
				throw new InvalidOperationException(Resources.ItemsControlHasItemsSourceException);
			}
			if (regionTarget.Items.Count > 0)
			{
				foreach (object view in ((IEnumerable)regionTarget.Items))
				{
					region.Add(view);
				}
				regionTarget.Items.Clear();
			}
			regionTarget.ItemsSource = region.Views;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000026FC File Offset: 0x000008FC
		protected override IRegion CreateRegion()
		{
			return new AllActiveRegion();
		}
	}
}
