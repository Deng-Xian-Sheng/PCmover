using System;
using ceTe.DynamicPDF.PageElements.BarCoding;

namespace zz93
{
	// Token: 0x020000A5 RID: 165
	internal class ds : BarCodeException
	{
		// Token: 0x060007E9 RID: 2025 RVA: 0x00071AA5 File Offset: 0x00070AA5
		public ds(string A_0) : base(A_0)
		{
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x00071AB1 File Offset: 0x00070AB1
		public ds() : base("Invalid barcode data format.")
		{
		}
	}
}
