using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x0200058A RID: 1418
	internal class alb : akt
	{
		// Token: 0x0600380D RID: 14349 RVA: 0x001E2EA4 File Offset: 0x001E1EA4
		internal alb(ald A_0)
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
							this.n = x5.a(A_0.ar());
							break;
						case 57:
							this.o = x5.a(A_0.ar());
							break;
						default:
							if (num != 2660)
							{
								if (num != 10156980)
								{
									goto IL_249;
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
					else if (num <= 371015739)
					{
						if (num != 13786676)
						{
							if (num != 371015739)
							{
								goto IL_249;
							}
							this.e = A_0.@as();
						}
						else
						{
							this.g = A_0.a7();
						}
					}
					else if (num != 565352942)
					{
						if (num != 565869349)
						{
							goto IL_249;
						}
						this.k = A_0.ar();
					}
					else
					{
						this.b = A_0.ai();
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
								goto IL_249;
							}
							this.h = A_0.ad();
						}
						else
						{
							this.l = x5.a(A_0.ar());
						}
					}
					else
					{
						this.d = A_0.ar();
					}
				}
				else if (num <= 906414665)
				{
					if (num != 889770711)
					{
						if (num != 906414665)
						{
							goto IL_249;
						}
						this.j = A_0.aq();
					}
					else
					{
						this.i = A_0.av();
					}
				}
				else if (num != 933645608)
				{
					if (num != 969890607)
					{
						goto IL_249;
					}
					this.f = A_0.@as();
				}
				else
				{
					this.m = x5.a(A_0.ar());
				}
				continue;
				IL_249:
				throw new DlexParseException("A pageNumberingLabel element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x0600380E RID: 14350 RVA: 0x001E3130 File Offset: 0x001E2130
		internal override LayoutElement mt(alo A_0)
		{
			return new PageNumberingLabel(A_0, this);
		}

		// Token: 0x0600380F RID: 14351 RVA: 0x001E314C File Offset: 0x001E214C
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x06003810 RID: 14352 RVA: 0x001E3164 File Offset: 0x001E2164
		internal TextAlign a()
		{
			return this.b;
		}

		// Token: 0x06003811 RID: 14353 RVA: 0x001E317C File Offset: 0x001E217C
		internal Font b()
		{
			return this.c;
		}

		// Token: 0x06003812 RID: 14354 RVA: 0x001E3194 File Offset: 0x001E2194
		internal float c()
		{
			return this.d;
		}

		// Token: 0x06003813 RID: 14355 RVA: 0x001E31AC File Offset: 0x001E21AC
		internal string d()
		{
			return this.g;
		}

		// Token: 0x06003814 RID: 14356 RVA: 0x001E31C4 File Offset: 0x001E21C4
		internal Color e()
		{
			return this.h;
		}

		// Token: 0x06003815 RID: 14357 RVA: 0x001E31DC File Offset: 0x001E21DC
		internal bool f()
		{
			return this.i;
		}

		// Token: 0x06003816 RID: 14358 RVA: 0x001E31F4 File Offset: 0x001E21F4
		internal VAlign g()
		{
			return this.j;
		}

		// Token: 0x06003817 RID: 14359 RVA: 0x001E320C File Offset: 0x001E220C
		internal float h()
		{
			return this.k;
		}

		// Token: 0x06003818 RID: 14360 RVA: 0x001E3224 File Offset: 0x001E2224
		internal x5 i()
		{
			return this.l;
		}

		// Token: 0x06003819 RID: 14361 RVA: 0x001E323C File Offset: 0x001E223C
		internal x5 j()
		{
			return this.m;
		}

		// Token: 0x0600381A RID: 14362 RVA: 0x001E3254 File Offset: 0x001E2254
		internal x5 k()
		{
			return this.n;
		}

		// Token: 0x0600381B RID: 14363 RVA: 0x001E326C File Offset: 0x001E226C
		internal x5 l()
		{
			return this.o;
		}

		// Token: 0x0600381C RID: 14364 RVA: 0x001E3284 File Offset: 0x001E2284
		internal int m()
		{
			return this.e;
		}

		// Token: 0x0600381D RID: 14365 RVA: 0x001E329C File Offset: 0x001E229C
		internal int n()
		{
			return this.f;
		}

		// Token: 0x04001AA4 RID: 6820
		private string a;

		// Token: 0x04001AA5 RID: 6821
		private TextAlign b = TextAlign.Left;

		// Token: 0x04001AA6 RID: 6822
		private Font c = Font.Helvetica;

		// Token: 0x04001AA7 RID: 6823
		private float d = 12f;

		// Token: 0x04001AA8 RID: 6824
		private int e = 0;

		// Token: 0x04001AA9 RID: 6825
		private int f = 0;

		// Token: 0x04001AAA RID: 6826
		private string g;

		// Token: 0x04001AAB RID: 6827
		private Color h = Grayscale.Black;

		// Token: 0x04001AAC RID: 6828
		private bool i = false;

		// Token: 0x04001AAD RID: 6829
		private VAlign j = VAlign.Top;

		// Token: 0x04001AAE RID: 6830
		private float k = 0f;

		// Token: 0x04001AAF RID: 6831
		private x5 l;

		// Token: 0x04001AB0 RID: 6832
		private x5 m;

		// Token: 0x04001AB1 RID: 6833
		private x5 n;

		// Token: 0x04001AB2 RID: 6834
		private x5 o;
	}
}
