using System;

namespace Prism.Regions
{
	// Token: 0x0200000E RID: 14
	public interface IRegionBehavior
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000044 RID: 68
		// (set) Token: 0x06000045 RID: 69
		IRegion Region { get; set; }

		// Token: 0x06000046 RID: 70
		void Attach();
	}
}
