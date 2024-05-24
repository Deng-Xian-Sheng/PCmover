using System;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x0200034D RID: 845
	internal class v6 : vr
	{
		// Token: 0x06002409 RID: 9225 RVA: 0x00154078 File Offset: 0x00153078
		internal v6(wd A_0)
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
							throw new DplxParseException("A pageBreak element contains an invalid attribute.");
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
					this.a = A_0.a8();
				}
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x0600240A RID: 9226 RVA: 0x00154118 File Offset: 0x00153118
		internal override ReportElement fz(rm A_0)
		{
			return new NoSplitZone(A_0, this);
		}

		// Token: 0x0600240B RID: 9227 RVA: 0x00154134 File Offset: 0x00153134
		internal x5 a()
		{
			return this.b;
		}

		// Token: 0x0600240C RID: 9228 RVA: 0x0015414C File Offset: 0x0015314C
		internal x5 b()
		{
			return this.c;
		}

		// Token: 0x0600240D RID: 9229 RVA: 0x00154164 File Offset: 0x00153164
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x04000F9B RID: 3995
		private string a;

		// Token: 0x04000F9C RID: 3996
		private x5 b;

		// Token: 0x04000F9D RID: 3997
		private x5 c;
	}
}
