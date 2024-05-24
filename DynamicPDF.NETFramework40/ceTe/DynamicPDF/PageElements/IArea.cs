using System;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x020006F2 RID: 1778
	public interface IArea : ICoordinate
	{
		// Token: 0x170003CA RID: 970
		// (get) Token: 0x060044A2 RID: 17570
		// (set) Token: 0x060044A3 RID: 17571
		float Width { get; set; }

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x060044A4 RID: 17572
		// (set) Token: 0x060044A5 RID: 17573
		float Height { get; set; }
	}
}
