using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x0200034C RID: 844
	internal class v5 : vr
	{
		// Token: 0x060023FE RID: 9214 RVA: 0x00153DE4 File Offset: 0x00152DE4
		internal v5(wd A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 3698)
				{
					if (num != 2660)
					{
						switch (num)
						{
						case 3633:
							this.b = x5.a(A_0.ar());
							break;
						case 3634:
							this.c = x5.a(A_0.ar());
							break;
						default:
							switch (num)
							{
							case 3697:
								this.d = x5.a(A_0.ar());
								break;
							case 3698:
								this.e = x5.a(A_0.ar());
								break;
							default:
								goto IL_15C;
							}
							break;
						}
					}
					else
					{
						this.a = A_0.a8();
					}
				}
				else if (num <= 599706610)
				{
					if (num != 145520)
					{
						if (num != 599706610)
						{
							goto IL_15C;
						}
						this.h = A_0.ad();
					}
					else
					{
						this.g = A_0.af();
					}
				}
				else if (num != 869505829)
				{
					if (num != 933645608)
					{
						goto IL_15C;
					}
					this.f = x5.a(A_0.ar());
				}
				else
				{
					this.i = A_0.au();
				}
				continue;
				IL_15C:
				throw new DplxParseException("A line element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060023FF RID: 9215 RVA: 0x00153F84 File Offset: 0x00152F84
		internal override ReportElement fz(rm A_0)
		{
			return new Line(A_0, this);
		}

		// Token: 0x06002400 RID: 9216 RVA: 0x00153FA0 File Offset: 0x00152FA0
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x06002401 RID: 9217 RVA: 0x00153FB8 File Offset: 0x00152FB8
		internal LineStyle a()
		{
			return this.i;
		}

		// Token: 0x06002402 RID: 9218 RVA: 0x00153FD0 File Offset: 0x00152FD0
		internal x5 b()
		{
			return this.b;
		}

		// Token: 0x06002403 RID: 9219 RVA: 0x00153FE8 File Offset: 0x00152FE8
		internal x5 c()
		{
			return this.c;
		}

		// Token: 0x06002404 RID: 9220 RVA: 0x00154000 File Offset: 0x00153000
		internal x5 d()
		{
			return this.d;
		}

		// Token: 0x06002405 RID: 9221 RVA: 0x00154018 File Offset: 0x00153018
		internal x5 e()
		{
			return this.e;
		}

		// Token: 0x06002406 RID: 9222 RVA: 0x00154030 File Offset: 0x00153030
		internal x5 f()
		{
			return this.f;
		}

		// Token: 0x06002407 RID: 9223 RVA: 0x00154048 File Offset: 0x00153048
		internal LineCap g()
		{
			return this.g;
		}

		// Token: 0x06002408 RID: 9224 RVA: 0x00154060 File Offset: 0x00153060
		internal Color h()
		{
			return this.h;
		}

		// Token: 0x04000F92 RID: 3986
		private string a;

		// Token: 0x04000F93 RID: 3987
		private x5 b;

		// Token: 0x04000F94 RID: 3988
		private x5 c;

		// Token: 0x04000F95 RID: 3989
		private x5 d;

		// Token: 0x04000F96 RID: 3990
		private x5 e;

		// Token: 0x04000F97 RID: 3991
		private x5 f = x5.a(1f);

		// Token: 0x04000F98 RID: 3992
		private LineCap g = LineCap.ProjectedSquare;

		// Token: 0x04000F99 RID: 3993
		private Color h = Grayscale.Black;

		// Token: 0x04000F9A RID: 3994
		private LineStyle i = LineStyle.Solid;
	}
}
