using System;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x02000589 RID: 1417
	internal class ala : akt
	{
		// Token: 0x06003809 RID: 14345 RVA: 0x001E2DD4 File Offset: 0x001E1DD4
		internal ala(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num != 57)
				{
					if (num != 2660)
					{
						throw new DlexParseException("A pageBreak element contains an invalid attribute.");
					}
					this.a = A_0.a7();
				}
				else
				{
					this.b = x5.a(A_0.ar());
				}
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x0600380A RID: 14346 RVA: 0x001E2E58 File Offset: 0x001E1E58
		internal override LayoutElement mt(alo A_0)
		{
			return new PageBreak(A_0, this);
		}

		// Token: 0x0600380B RID: 14347 RVA: 0x001E2E74 File Offset: 0x001E1E74
		internal x5 a()
		{
			return this.b;
		}

		// Token: 0x0600380C RID: 14348 RVA: 0x001E2E8C File Offset: 0x001E1E8C
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x04001AA2 RID: 6818
		private string a;

		// Token: 0x04001AA3 RID: 6819
		private x5 b;
	}
}
