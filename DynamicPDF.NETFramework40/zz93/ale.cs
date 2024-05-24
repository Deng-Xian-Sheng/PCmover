using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x0200058D RID: 1421
	internal class ale : akt
	{
		// Token: 0x0600387D RID: 14461 RVA: 0x001E8128 File Offset: 0x001E7128
		internal ale(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 649884598)
				{
					if (num <= 23405387)
					{
						if (num <= 2660)
						{
							switch (num)
							{
							case 56:
								this.s = x5.a(A_0.ar());
								break;
							case 57:
								this.t = x5.a(A_0.ar());
								break;
							default:
								if (num != 2660)
								{
									goto IL_305;
								}
								this.a = A_0.a7();
								break;
							}
						}
						else if (num != 10156980)
						{
							if (num != 23405387)
							{
								goto IL_305;
							}
							this.e = A_0.av();
						}
						else
						{
							this.g = A_0.an();
						}
					}
					else if (num <= 121954641)
					{
						if (num != 72417669)
						{
							if (num != 121954641)
							{
								goto IL_305;
							}
							this.f = A_0.av();
						}
						else
						{
							this.c = A_0.av();
						}
					}
					else if (num != 565352942)
					{
						if (num != 565869349)
						{
							if (num != 649884598)
							{
								goto IL_305;
							}
							this.h = A_0.ar();
						}
						else
						{
							this.p = A_0.ar();
						}
					}
					else
					{
						this.b = A_0.ai();
					}
				}
				else if (num <= 847648829)
				{
					if (num <= 747796954)
					{
						if (num != 680958428)
						{
							if (num != 747796954)
							{
								goto IL_305;
							}
							this.j = A_0.ar();
						}
						else
						{
							this.q = x5.a(A_0.ar());
						}
					}
					else if (num != 748032654)
					{
						if (num != 847648829)
						{
							goto IL_305;
						}
						this.k = A_0.ar();
					}
					else
					{
						this.i = A_0.ar();
					}
				}
				else if (num <= 875120369)
				{
					if (num != 858022136)
					{
						if (num != 875120369)
						{
							goto IL_305;
						}
						this.m = A_0.ad();
					}
					else
					{
						this.d = A_0.av();
					}
				}
				else if (num != 889770711)
				{
					if (num != 906414665)
					{
						if (num != 933645608)
						{
							goto IL_305;
						}
						this.r = x5.a(A_0.ar());
					}
					else
					{
						this.o = A_0.aq();
					}
				}
				else
				{
					this.n = A_0.av();
				}
				continue;
				IL_305:
				throw new DlexParseException("A recordArea element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				if (A_0.x() == 13786676)
				{
					this.l = A_0.ax();
					A_0.aa();
				}
				A_0.aa();
			}
		}

		// Token: 0x0600387E RID: 14462 RVA: 0x001E8498 File Offset: 0x001E7498
		internal override LayoutElement mt(alo A_0)
		{
			return new RecordArea(A_0, this);
		}

		// Token: 0x0600387F RID: 14463 RVA: 0x001E84B4 File Offset: 0x001E74B4
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x06003880 RID: 14464 RVA: 0x001E84CC File Offset: 0x001E74CC
		internal TextAlign a()
		{
			return this.b;
		}

		// Token: 0x06003881 RID: 14465 RVA: 0x001E84E4 File Offset: 0x001E74E4
		internal bool b()
		{
			return this.c;
		}

		// Token: 0x06003882 RID: 14466 RVA: 0x001E84FC File Offset: 0x001E74FC
		internal bool c()
		{
			return this.d;
		}

		// Token: 0x06003883 RID: 14467 RVA: 0x001E8514 File Offset: 0x001E7514
		internal bool d()
		{
			return this.e;
		}

		// Token: 0x06003884 RID: 14468 RVA: 0x001E852C File Offset: 0x001E752C
		internal bool e()
		{
			return this.f;
		}

		// Token: 0x06003885 RID: 14469 RVA: 0x001E8544 File Offset: 0x001E7544
		internal Font f()
		{
			return this.g;
		}

		// Token: 0x06003886 RID: 14470 RVA: 0x001E855C File Offset: 0x001E755C
		internal float g()
		{
			return this.h;
		}

		// Token: 0x06003887 RID: 14471 RVA: 0x001E8574 File Offset: 0x001E7574
		internal float h()
		{
			return this.i;
		}

		// Token: 0x06003888 RID: 14472 RVA: 0x001E858C File Offset: 0x001E758C
		internal float i()
		{
			return this.j;
		}

		// Token: 0x06003889 RID: 14473 RVA: 0x001E85A4 File Offset: 0x001E75A4
		internal float j()
		{
			return this.k;
		}

		// Token: 0x0600388A RID: 14474 RVA: 0x001E85BC File Offset: 0x001E75BC
		internal air k()
		{
			return this.l;
		}

		// Token: 0x0600388B RID: 14475 RVA: 0x001E85D4 File Offset: 0x001E75D4
		internal Color l()
		{
			return this.m;
		}

		// Token: 0x0600388C RID: 14476 RVA: 0x001E85EC File Offset: 0x001E75EC
		internal bool m()
		{
			return this.n;
		}

		// Token: 0x0600388D RID: 14477 RVA: 0x001E8604 File Offset: 0x001E7604
		internal VAlign n()
		{
			return this.o;
		}

		// Token: 0x0600388E RID: 14478 RVA: 0x001E861C File Offset: 0x001E761C
		internal float o()
		{
			return this.p;
		}

		// Token: 0x0600388F RID: 14479 RVA: 0x001E8634 File Offset: 0x001E7634
		internal x5 p()
		{
			return this.q;
		}

		// Token: 0x06003890 RID: 14480 RVA: 0x001E864C File Offset: 0x001E764C
		internal x5 q()
		{
			return this.r;
		}

		// Token: 0x06003891 RID: 14481 RVA: 0x001E8664 File Offset: 0x001E7664
		internal x5 r()
		{
			return this.s;
		}

		// Token: 0x06003892 RID: 14482 RVA: 0x001E867C File Offset: 0x001E767C
		internal x5 s()
		{
			return this.t;
		}

		// Token: 0x04001AC4 RID: 6852
		private string a;

		// Token: 0x04001AC5 RID: 6853
		private TextAlign b = TextAlign.Left;

		// Token: 0x04001AC6 RID: 6854
		private bool c = true;

		// Token: 0x04001AC7 RID: 6855
		private bool d = true;

		// Token: 0x04001AC8 RID: 6856
		private bool e = false;

		// Token: 0x04001AC9 RID: 6857
		private bool f = false;

		// Token: 0x04001ACA RID: 6858
		private Font g = Font.Helvetica;

		// Token: 0x04001ACB RID: 6859
		private float h = 12f;

		// Token: 0x04001ACC RID: 6860
		private float i = 14f;

		// Token: 0x04001ACD RID: 6861
		private float j = 0f;

		// Token: 0x04001ACE RID: 6862
		private float k = 0f;

		// Token: 0x04001ACF RID: 6863
		private air l;

		// Token: 0x04001AD0 RID: 6864
		private Color m = Grayscale.Black;

		// Token: 0x04001AD1 RID: 6865
		private bool n = false;

		// Token: 0x04001AD2 RID: 6866
		private VAlign o = VAlign.Top;

		// Token: 0x04001AD3 RID: 6867
		private float p = 0f;

		// Token: 0x04001AD4 RID: 6868
		private x5 q;

		// Token: 0x04001AD5 RID: 6869
		private x5 r;

		// Token: 0x04001AD6 RID: 6870
		private x5 s;

		// Token: 0x04001AD7 RID: 6871
		private x5 t;
	}
}
