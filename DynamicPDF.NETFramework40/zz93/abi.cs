using System;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000420 RID: 1056
	internal class abi
	{
		// Token: 0x06002BF0 RID: 11248 RVA: 0x001948B4 File Offset: 0x001938B4
		internal abi(PdfDocument A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002BF1 RID: 11249 RVA: 0x001948C8 File Offset: 0x001938C8
		internal PdfDocument b()
		{
			return this.a;
		}

		// Token: 0x06002BF2 RID: 11250 RVA: 0x001948E0 File Offset: 0x001938E0
		internal virtual int h1(byte[] A_0, int A_1, int A_2)
		{
			return 0;
		}

		// Token: 0x06002BF3 RID: 11251 RVA: 0x001948F4 File Offset: 0x001938F4
		internal virtual bool h2()
		{
			return false;
		}

		// Token: 0x040014A8 RID: 5288
		private PdfDocument a;
	}
}
