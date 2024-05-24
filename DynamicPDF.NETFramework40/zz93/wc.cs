using System;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x02000353 RID: 851
	internal class wc : vr
	{
		// Token: 0x0600243D RID: 9277 RVA: 0x0015556C File Offset: 0x0015456C
		internal wc(wd A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 2660)
				{
					switch (num)
					{
					case 56:
						this.d = x5.a(A_0.ar());
						break;
					case 57:
						this.e = x5.a(A_0.ar());
						break;
					default:
						if (num != 2660)
						{
							goto IL_A8;
						}
						this.a = A_0.a8();
						break;
					}
				}
				else if (num != 680958428)
				{
					if (num != 933645608)
					{
						goto IL_A8;
					}
					this.c = x5.a(A_0.ar());
				}
				else
				{
					this.b = x5.a(A_0.ar());
				}
				continue;
				IL_A8:
				throw new DplxParseException("A placeHolder element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x0600243E RID: 9278 RVA: 0x00155658 File Offset: 0x00154658
		internal override ReportElement fz(rm A_0)
		{
			return new PlaceHolder(A_0, this);
		}

		// Token: 0x0600243F RID: 9279 RVA: 0x00155674 File Offset: 0x00154674
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x06002440 RID: 9280 RVA: 0x0015568C File Offset: 0x0015468C
		internal x5 a()
		{
			return this.d;
		}

		// Token: 0x06002441 RID: 9281 RVA: 0x001556A4 File Offset: 0x001546A4
		internal x5 b()
		{
			return this.e;
		}

		// Token: 0x06002442 RID: 9282 RVA: 0x001556BC File Offset: 0x001546BC
		internal x5 c()
		{
			return this.c;
		}

		// Token: 0x06002443 RID: 9283 RVA: 0x001556D4 File Offset: 0x001546D4
		internal x5 d()
		{
			return this.b;
		}

		// Token: 0x04000FC1 RID: 4033
		private string a;

		// Token: 0x04000FC2 RID: 4034
		private x5 b;

		// Token: 0x04000FC3 RID: 4035
		private x5 c;

		// Token: 0x04000FC4 RID: 4036
		private x5 d;

		// Token: 0x04000FC5 RID: 4037
		private x5 e;
	}
}
