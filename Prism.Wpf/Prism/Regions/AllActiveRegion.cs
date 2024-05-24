using System;
using Prism.Properties;

namespace Prism.Regions
{
	// Token: 0x02000006 RID: 6
	public class AllActiveRegion : Region
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00002395 File Offset: 0x00000595
		public override IViewsCollection ActiveViews
		{
			get
			{
				return this.Views;
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000239D File Offset: 0x0000059D
		public override void Deactivate(object view)
		{
			throw new InvalidOperationException(Resources.DeactiveNotPossibleException);
		}
	}
}
