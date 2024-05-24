using System;
using System.Linq;

namespace Prism.Regions
{
	// Token: 0x02000032 RID: 50
	public class SingleActiveRegion : Region
	{
		// Token: 0x06000156 RID: 342 RVA: 0x00004800 File Offset: 0x00002A00
		public override void Activate(object view)
		{
			object obj = this.ActiveViews.FirstOrDefault<object>();
			if (obj != null && obj != view && this.Views.Contains(obj))
			{
				base.Deactivate(obj);
			}
			base.Activate(view);
		}
	}
}
