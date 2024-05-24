using System;
using ceTe.DynamicPDF.PageElements.BarCoding;

namespace zz93
{
	// Token: 0x020000A7 RID: 167
	internal class dt : BarCodeException
	{
		// Token: 0x060007EC RID: 2028 RVA: 0x00071ACD File Offset: 0x00070ACD
		public dt(string A_0) : base(A_0)
		{
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x00071AD9 File Offset: 0x00070AD9
		public dt() : base("Invalid barcode size.")
		{
		}
	}
}
