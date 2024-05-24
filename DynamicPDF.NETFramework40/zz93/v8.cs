using System;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x0200034F RID: 847
	internal class v8 : vr
	{
		// Token: 0x06002417 RID: 9239 RVA: 0x00154710 File Offset: 0x00153710
		internal v8(wd A_0)
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

		// Token: 0x06002418 RID: 9240 RVA: 0x00154794 File Offset: 0x00153794
		internal override ReportElement fz(rm A_0)
		{
			return new PageBreak(A_0, this);
		}

		// Token: 0x06002419 RID: 9241 RVA: 0x001547B0 File Offset: 0x001537B0
		internal x5 a()
		{
			return this.b;
		}

		// Token: 0x0600241A RID: 9242 RVA: 0x001547C8 File Offset: 0x001537C8
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x04000FA3 RID: 4003
		private string a;

		// Token: 0x04000FA4 RID: 4004
		private x5 b;
	}
}
