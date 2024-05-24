using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x02000585 RID: 1413
	internal class ak6 : akt
	{
		// Token: 0x060037E2 RID: 14306 RVA: 0x001E21A4 File Offset: 0x001E11A4
		internal ak6(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 565869349)
				{
					if (num <= 10156980)
					{
						switch (num)
						{
						case 56:
							this.l = x5.a(A_0.ar());
							break;
						case 57:
							this.m = x5.a(A_0.ar());
							break;
						default:
							if (num != 2660)
							{
								if (num != 10156980)
								{
									goto IL_1E6;
								}
								this.c = A_0.an();
							}
							else
							{
								this.a = A_0.a7();
							}
							break;
						}
					}
					else if (num != 13786676)
					{
						if (num != 565352942)
						{
							if (num != 565869349)
							{
								goto IL_1E6;
							}
							this.i = A_0.ar();
						}
						else
						{
							this.b = A_0.ai();
						}
					}
					else
					{
						this.e = A_0.a7();
					}
				}
				else if (num <= 875120369)
				{
					if (num != 649884598)
					{
						if (num != 680958428)
						{
							if (num != 875120369)
							{
								goto IL_1E6;
							}
							this.f = A_0.ad();
						}
						else
						{
							this.j = x5.a(A_0.ar());
						}
					}
					else
					{
						this.d = A_0.ar();
					}
				}
				else if (num != 889770711)
				{
					if (num != 906414665)
					{
						if (num != 933645608)
						{
							goto IL_1E6;
						}
						this.k = x5.a(A_0.ar());
					}
					else
					{
						this.h = A_0.aq();
					}
				}
				else
				{
					this.g = A_0.av();
				}
				continue;
				IL_1E6:
				throw new DlexParseException("A label element contains an invalid attribute.");
			}
		}

		// Token: 0x060037E3 RID: 14307 RVA: 0x001E23B4 File Offset: 0x001E13B4
		internal override LayoutElement mt(alo A_0)
		{
			return new Label(A_0, this);
		}

		// Token: 0x060037E4 RID: 14308 RVA: 0x001E23D0 File Offset: 0x001E13D0
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x060037E5 RID: 14309 RVA: 0x001E23E8 File Offset: 0x001E13E8
		internal TextAlign a()
		{
			return this.b;
		}

		// Token: 0x060037E6 RID: 14310 RVA: 0x001E2400 File Offset: 0x001E1400
		internal Font b()
		{
			return this.c;
		}

		// Token: 0x060037E7 RID: 14311 RVA: 0x001E2418 File Offset: 0x001E1418
		internal float c()
		{
			return this.d;
		}

		// Token: 0x060037E8 RID: 14312 RVA: 0x001E2430 File Offset: 0x001E1430
		internal string d()
		{
			return this.e;
		}

		// Token: 0x060037E9 RID: 14313 RVA: 0x001E2448 File Offset: 0x001E1448
		internal Color e()
		{
			return this.f;
		}

		// Token: 0x060037EA RID: 14314 RVA: 0x001E2460 File Offset: 0x001E1460
		internal bool f()
		{
			return this.g;
		}

		// Token: 0x060037EB RID: 14315 RVA: 0x001E2478 File Offset: 0x001E1478
		internal VAlign g()
		{
			return this.h;
		}

		// Token: 0x060037EC RID: 14316 RVA: 0x001E2490 File Offset: 0x001E1490
		internal float h()
		{
			return this.i;
		}

		// Token: 0x060037ED RID: 14317 RVA: 0x001E24A8 File Offset: 0x001E14A8
		internal x5 i()
		{
			return this.j;
		}

		// Token: 0x060037EE RID: 14318 RVA: 0x001E24C0 File Offset: 0x001E14C0
		internal x5 j()
		{
			return this.k;
		}

		// Token: 0x060037EF RID: 14319 RVA: 0x001E24D8 File Offset: 0x001E14D8
		internal x5 k()
		{
			return this.l;
		}

		// Token: 0x060037F0 RID: 14320 RVA: 0x001E24F0 File Offset: 0x001E14F0
		internal x5 l()
		{
			return this.m;
		}

		// Token: 0x04001A85 RID: 6789
		private string a;

		// Token: 0x04001A86 RID: 6790
		private TextAlign b = TextAlign.Left;

		// Token: 0x04001A87 RID: 6791
		private Font c = Font.Helvetica;

		// Token: 0x04001A88 RID: 6792
		private float d = 12f;

		// Token: 0x04001A89 RID: 6793
		private string e;

		// Token: 0x04001A8A RID: 6794
		private Color f = Grayscale.Black;

		// Token: 0x04001A8B RID: 6795
		private bool g = false;

		// Token: 0x04001A8C RID: 6796
		private VAlign h = VAlign.Top;

		// Token: 0x04001A8D RID: 6797
		private float i = 0f;

		// Token: 0x04001A8E RID: 6798
		private x5 j;

		// Token: 0x04001A8F RID: 6799
		private x5 k;

		// Token: 0x04001A90 RID: 6800
		private x5 l;

		// Token: 0x04001A91 RID: 6801
		private x5 m;
	}
}
