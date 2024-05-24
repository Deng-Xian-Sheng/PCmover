using System;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x02000587 RID: 1415
	internal class ak8 : akt
	{
		// Token: 0x060037FC RID: 14332 RVA: 0x001E279C File Offset: 0x001E179C
		internal ak8(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num != 2660)
				{
					if (num != 216048)
					{
						if (num != 582962434)
						{
							throw new DlexParseException("A pageBreak element contains an invalid attribute.");
						}
						this.c = x5.a(A_0.ar());
					}
					else
					{
						this.b = x5.a(A_0.ar());
					}
				}
				else
				{
					this.a = A_0.a7();
				}
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060037FD RID: 14333 RVA: 0x001E283C File Offset: 0x001E183C
		internal override LayoutElement mt(alo A_0)
		{
			return new NoSplitZone(A_0, this);
		}

		// Token: 0x060037FE RID: 14334 RVA: 0x001E2858 File Offset: 0x001E1858
		internal x5 a()
		{
			return this.b;
		}

		// Token: 0x060037FF RID: 14335 RVA: 0x001E2870 File Offset: 0x001E1870
		internal x5 b()
		{
			return this.c;
		}

		// Token: 0x06003800 RID: 14336 RVA: 0x001E2888 File Offset: 0x001E1888
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x04001A9B RID: 6811
		private string a;

		// Token: 0x04001A9C RID: 6812
		private x5 b;

		// Token: 0x04001A9D RID: 6813
		private x5 c;
	}
}
