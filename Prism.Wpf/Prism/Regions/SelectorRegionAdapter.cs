using System;
using System.Windows.Controls.Primitives;
using Prism.Regions.Behaviors;

namespace Prism.Regions
{
	// Token: 0x02000031 RID: 49
	public class SelectorRegionAdapter : RegionAdapterBase<Selector>
	{
		// Token: 0x06000152 RID: 338 RVA: 0x000047BC File Offset: 0x000029BC
		public SelectorRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
		{
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00002222 File Offset: 0x00000422
		protected override void Adapt(IRegion region, Selector regionTarget)
		{
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000047C5 File Offset: 0x000029C5
		protected override void AttachBehaviors(IRegion region, Selector regionTarget)
		{
			if (region == null)
			{
				throw new ArgumentNullException("region");
			}
			region.Behaviors.Add(SelectorItemsSourceSyncBehavior.BehaviorKey, new SelectorItemsSourceSyncBehavior
			{
				HostControl = regionTarget
			});
			base.AttachBehaviors(region, regionTarget);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000047F9 File Offset: 0x000029F9
		protected override IRegion CreateRegion()
		{
			return new Region();
		}
	}
}
