using System;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x0200035B RID: 859
	internal class wk : vr
	{
		// Token: 0x060024EF RID: 9455 RVA: 0x0015BA44 File Offset: 0x0015AA44
		internal wk(wd A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num != 57)
				{
					if (num != 2660)
					{
						throw new DplxParseException("A pageBreak element contains an invalid attribute.");
					}
					this.a = A_0.a8();
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

		// Token: 0x060024F0 RID: 9456 RVA: 0x0015BAC8 File Offset: 0x0015AAC8
		internal override ReportElement fz(rm A_0)
		{
			return new SoftBreak(A_0, this);
		}

		// Token: 0x060024F1 RID: 9457 RVA: 0x0015BAE4 File Offset: 0x0015AAE4
		internal x5 a()
		{
			return this.b;
		}

		// Token: 0x060024F2 RID: 9458 RVA: 0x0015BAFC File Offset: 0x0015AAFC
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x04001017 RID: 4119
		private string a;

		// Token: 0x04001018 RID: 4120
		private x5 b;
	}
}
