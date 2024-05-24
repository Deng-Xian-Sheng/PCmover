using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x02000586 RID: 1414
	internal class ak7 : akt
	{
		// Token: 0x060037F1 RID: 14321 RVA: 0x001E2508 File Offset: 0x001E1508
		internal ak7(ald A_0)
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
						this.a = A_0.a7();
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
				throw new DlexParseException("A line element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060037F2 RID: 14322 RVA: 0x001E26A8 File Offset: 0x001E16A8
		internal override LayoutElement mt(alo A_0)
		{
			return new Line(A_0, this);
		}

		// Token: 0x060037F3 RID: 14323 RVA: 0x001E26C4 File Offset: 0x001E16C4
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x060037F4 RID: 14324 RVA: 0x001E26DC File Offset: 0x001E16DC
		internal LineStyle a()
		{
			return this.i;
		}

		// Token: 0x060037F5 RID: 14325 RVA: 0x001E26F4 File Offset: 0x001E16F4
		internal x5 b()
		{
			return this.b;
		}

		// Token: 0x060037F6 RID: 14326 RVA: 0x001E270C File Offset: 0x001E170C
		internal x5 c()
		{
			return this.c;
		}

		// Token: 0x060037F7 RID: 14327 RVA: 0x001E2724 File Offset: 0x001E1724
		internal x5 d()
		{
			return this.d;
		}

		// Token: 0x060037F8 RID: 14328 RVA: 0x001E273C File Offset: 0x001E173C
		internal x5 e()
		{
			return this.e;
		}

		// Token: 0x060037F9 RID: 14329 RVA: 0x001E2754 File Offset: 0x001E1754
		internal x5 f()
		{
			return this.f;
		}

		// Token: 0x060037FA RID: 14330 RVA: 0x001E276C File Offset: 0x001E176C
		internal LineCap g()
		{
			return this.g;
		}

		// Token: 0x060037FB RID: 14331 RVA: 0x001E2784 File Offset: 0x001E1784
		internal Color h()
		{
			return this.h;
		}

		// Token: 0x04001A92 RID: 6802
		private string a;

		// Token: 0x04001A93 RID: 6803
		private x5 b;

		// Token: 0x04001A94 RID: 6804
		private x5 c;

		// Token: 0x04001A95 RID: 6805
		private x5 d;

		// Token: 0x04001A96 RID: 6806
		private x5 e;

		// Token: 0x04001A97 RID: 6807
		private x5 f = x5.a(1f);

		// Token: 0x04001A98 RID: 6808
		private LineCap g = LineCap.ProjectedSquare;

		// Token: 0x04001A99 RID: 6809
		private Color h = Grayscale.Black;

		// Token: 0x04001A9A RID: 6810
		private LineStyle i = LineStyle.Solid;
	}
}
