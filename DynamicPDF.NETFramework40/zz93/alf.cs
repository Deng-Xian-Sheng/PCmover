using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x0200058E RID: 1422
	internal class alf : akt
	{
		// Token: 0x06003893 RID: 14483 RVA: 0x001E8694 File Offset: 0x001E7694
		internal alf(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 612717355)
				{
					if (num <= 72417669)
					{
						if (num <= 2660)
						{
							switch (num)
							{
							case 56:
								this.t = x5.a(A_0.ar());
								break;
							case 57:
								this.u = x5.a(A_0.ar());
								break;
							default:
								if (num != 2660)
								{
									goto IL_341;
								}
								this.a = A_0.a7();
								break;
							}
						}
						else if (num != 10156980)
						{
							if (num != 23405387)
							{
								if (num != 72417669)
								{
									goto IL_341;
								}
								this.c = A_0.av();
							}
							else
							{
								this.e = A_0.av();
							}
						}
						else
						{
							this.g = A_0.an();
						}
					}
					else if (num <= 189632562)
					{
						if (num != 121954641)
						{
							if (num != 189632562)
							{
								goto IL_341;
							}
							this.o = A_0.a7();
						}
						else
						{
							this.f = A_0.av();
						}
					}
					else if (num != 565352942)
					{
						if (num != 565869349)
						{
							if (num != 612717355)
							{
								goto IL_341;
							}
							this.p = A_0.a0();
						}
						else
						{
							this.q = A_0.ar();
						}
					}
					else
					{
						this.b = A_0.ai();
					}
				}
				else if (num <= 847648829)
				{
					if (num <= 680958428)
					{
						if (num != 649884598)
						{
							if (num != 680958428)
							{
								goto IL_341;
							}
							this.r = x5.a(A_0.ar());
						}
						else
						{
							this.h = A_0.ar();
						}
					}
					else if (num != 747796954)
					{
						if (num != 748032654)
						{
							if (num != 847648829)
							{
								goto IL_341;
							}
							this.k = A_0.ar();
						}
						else
						{
							this.i = A_0.ar();
						}
					}
					else
					{
						this.j = A_0.ar();
					}
				}
				else if (num <= 875120369)
				{
					if (num != 858022136)
					{
						if (num != 875120369)
						{
							goto IL_341;
						}
						this.l = A_0.ad();
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
							goto IL_341;
						}
						this.s = x5.a(A_0.ar());
					}
					else
					{
						this.n = A_0.aq();
					}
				}
				else
				{
					this.m = A_0.av();
				}
				continue;
				IL_341:
				throw new DlexParseException("A recordBox element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x06003894 RID: 14484 RVA: 0x001E8A18 File Offset: 0x001E7A18
		internal override LayoutElement mt(alo A_0)
		{
			return new RecordBox(A_0, this);
		}

		// Token: 0x06003895 RID: 14485 RVA: 0x001E8A34 File Offset: 0x001E7A34
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x06003896 RID: 14486 RVA: 0x001E8A4C File Offset: 0x001E7A4C
		internal TextAlign a()
		{
			return this.b;
		}

		// Token: 0x06003897 RID: 14487 RVA: 0x001E8A64 File Offset: 0x001E7A64
		internal float b()
		{
			return this.q;
		}

		// Token: 0x06003898 RID: 14488 RVA: 0x001E8A7C File Offset: 0x001E7A7C
		internal bool c()
		{
			return this.c;
		}

		// Token: 0x06003899 RID: 14489 RVA: 0x001E8A94 File Offset: 0x001E7A94
		internal bool d()
		{
			return this.d;
		}

		// Token: 0x0600389A RID: 14490 RVA: 0x001E8AAC File Offset: 0x001E7AAC
		internal akn e()
		{
			return this.p;
		}

		// Token: 0x0600389B RID: 14491 RVA: 0x001E8AC4 File Offset: 0x001E7AC4
		internal bool f()
		{
			return this.e;
		}

		// Token: 0x0600389C RID: 14492 RVA: 0x001E8ADC File Offset: 0x001E7ADC
		internal Font g()
		{
			return this.g;
		}

		// Token: 0x0600389D RID: 14493 RVA: 0x001E8AF4 File Offset: 0x001E7AF4
		internal float h()
		{
			return this.h;
		}

		// Token: 0x0600389E RID: 14494 RVA: 0x001E8B0C File Offset: 0x001E7B0C
		internal float i()
		{
			return this.i;
		}

		// Token: 0x0600389F RID: 14495 RVA: 0x001E8B24 File Offset: 0x001E7B24
		internal float j()
		{
			return this.j;
		}

		// Token: 0x060038A0 RID: 14496 RVA: 0x001E8B3C File Offset: 0x001E7B3C
		internal float k()
		{
			return this.k;
		}

		// Token: 0x060038A1 RID: 14497 RVA: 0x001E8B54 File Offset: 0x001E7B54
		internal bool l()
		{
			return this.f;
		}

		// Token: 0x060038A2 RID: 14498 RVA: 0x001E8B6C File Offset: 0x001E7B6C
		internal Color m()
		{
			return this.l;
		}

		// Token: 0x060038A3 RID: 14499 RVA: 0x001E8B84 File Offset: 0x001E7B84
		internal bool n()
		{
			return this.m;
		}

		// Token: 0x060038A4 RID: 14500 RVA: 0x001E8B9C File Offset: 0x001E7B9C
		internal VAlign o()
		{
			return this.n;
		}

		// Token: 0x060038A5 RID: 14501 RVA: 0x001E8BB4 File Offset: 0x001E7BB4
		internal string p()
		{
			return this.o;
		}

		// Token: 0x060038A6 RID: 14502 RVA: 0x001E8BCC File Offset: 0x001E7BCC
		internal x5 q()
		{
			return this.r;
		}

		// Token: 0x060038A7 RID: 14503 RVA: 0x001E8BE4 File Offset: 0x001E7BE4
		internal x5 r()
		{
			return this.s;
		}

		// Token: 0x060038A8 RID: 14504 RVA: 0x001E8BFC File Offset: 0x001E7BFC
		internal x5 s()
		{
			return this.t;
		}

		// Token: 0x060038A9 RID: 14505 RVA: 0x001E8C14 File Offset: 0x001E7C14
		internal x5 t()
		{
			return this.u;
		}

		// Token: 0x04001AD8 RID: 6872
		private string a;

		// Token: 0x04001AD9 RID: 6873
		private TextAlign b = TextAlign.Left;

		// Token: 0x04001ADA RID: 6874
		private bool c = true;

		// Token: 0x04001ADB RID: 6875
		private bool d = true;

		// Token: 0x04001ADC RID: 6876
		private bool e = false;

		// Token: 0x04001ADD RID: 6877
		private bool f = false;

		// Token: 0x04001ADE RID: 6878
		private Font g = Font.Helvetica;

		// Token: 0x04001ADF RID: 6879
		private float h = 12f;

		// Token: 0x04001AE0 RID: 6880
		private float i = 14f;

		// Token: 0x04001AE1 RID: 6881
		private float j = 0f;

		// Token: 0x04001AE2 RID: 6882
		private float k = 0f;

		// Token: 0x04001AE3 RID: 6883
		private Color l = Grayscale.Black;

		// Token: 0x04001AE4 RID: 6884
		private bool m = false;

		// Token: 0x04001AE5 RID: 6885
		private VAlign n = VAlign.Top;

		// Token: 0x04001AE6 RID: 6886
		private string o = null;

		// Token: 0x04001AE7 RID: 6887
		private akn p;

		// Token: 0x04001AE8 RID: 6888
		private float q = 0f;

		// Token: 0x04001AE9 RID: 6889
		private x5 r;

		// Token: 0x04001AEA RID: 6890
		private x5 s;

		// Token: 0x04001AEB RID: 6891
		private x5 t;

		// Token: 0x04001AEC RID: 6892
		private x5 u;
	}
}
