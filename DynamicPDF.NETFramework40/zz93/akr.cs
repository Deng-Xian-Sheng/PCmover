using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000576 RID: 1398
	internal class akr
	{
		// Token: 0x06003773 RID: 14195 RVA: 0x001DF7EC File Offset: 0x001DE7EC
		internal akr(ald A_0, bool A_1)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 356812069)
				{
					if (num != 2660)
					{
						if (num != 356812069)
						{
							goto IL_C6;
						}
						if (A_1)
						{
							this.f = A_0.a5();
						}
					}
					else
					{
						this.a = A_0.a7();
					}
				}
				else if (num != 594309831)
				{
					if (num != 771506020)
					{
						if (num != 852642834)
						{
							goto IL_C6;
						}
						if (A_1)
						{
							this.g = A_0.@as();
						}
					}
					else
					{
						this.b = A_0.av();
					}
				}
				else
				{
					this.c = A_0.az();
				}
				continue;
				IL_C6:
				throw new DlexParseException("A conditional header, footer or template contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				this.a(A_0);
				A_0.aa();
			}
			A_0.aa();
		}

		// Token: 0x06003774 RID: 14196 RVA: 0x001DF8FC File Offset: 0x001DE8FC
		private void a(ald A_0)
		{
			int num = A_0.x();
			A_0.aa();
			while (A_0.x() != num)
			{
				int num2 = A_0.x();
				if (num2 <= 746989932)
				{
					if (num2 <= 378606227)
					{
						if (num2 != 11705253)
						{
							if (num2 == 225352954)
							{
								throw new DlexParseException("A contentGroup element cannot be placed in a conditional header, footer or template.");
							}
							if (num2 != 378606227)
							{
								goto IL_1DB;
							}
							this.e.a(new ale(A_0));
						}
						else
						{
							this.e.a(new ak7(A_0));
						}
					}
					else if (num2 != 403493362)
					{
						if (num2 != 699800037)
						{
							if (num2 != 746989932)
							{
								goto IL_1DB;
							}
							this.e.a(new ak6(A_0));
						}
						else
						{
							this.e.a(new ak5(A_0));
						}
					}
					else
					{
						this.e.a(new alc(A_0));
					}
				}
				else if (num2 <= 839258122)
				{
					if (num2 != 747113073)
					{
						if (num2 == 810295593)
						{
							throw new DlexParseException("A pageBreak element cannot be placed in a conditional header, footer or template.");
						}
						if (num2 != 839258122)
						{
							goto IL_1DB;
						}
						this.e.a(new alf(A_0));
					}
					else
					{
						this.e.a(new alb(A_0));
					}
				}
				else if (num2 <= 857004049)
				{
					if (num2 != 841762308)
					{
						if (num2 != 857004049)
						{
							goto IL_1DB;
						}
						throw new DlexParseException("A subReport element cannot be placed in a conditional header, footer or template.");
					}
					else
					{
						this.e.a(new alg(A_0, 1050867191));
					}
				}
				else if (num2 != 870766723)
				{
					if (num2 != 937732022)
					{
						goto IL_1DB;
					}
					this.e.a(new ak2(A_0));
				}
				else
				{
					this.e.a(new all(A_0));
				}
				A_0.aa();
				continue;
				IL_1DB:
				throw new DlexParseException("Invalid report element.");
			}
		}

		// Token: 0x06003775 RID: 14197 RVA: 0x001DFB0C File Offset: 0x001DEB0C
		internal akr a()
		{
			return this.d;
		}

		// Token: 0x06003776 RID: 14198 RVA: 0x001DFB24 File Offset: 0x001DEB24
		internal void a(akr A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06003777 RID: 14199 RVA: 0x001DFB30 File Offset: 0x001DEB30
		internal ali b()
		{
			return this.e;
		}

		// Token: 0x06003778 RID: 14200 RVA: 0x001DFB48 File Offset: 0x001DEB48
		internal bool c()
		{
			return this.b;
		}

		// Token: 0x06003779 RID: 14201 RVA: 0x001DFB60 File Offset: 0x001DEB60
		internal al7 d()
		{
			return this.c;
		}

		// Token: 0x0600377A RID: 14202 RVA: 0x001DFB78 File Offset: 0x001DEB78
		internal string e()
		{
			return this.a;
		}

		// Token: 0x0600377B RID: 14203 RVA: 0x001DFB90 File Offset: 0x001DEB90
		internal string f()
		{
			return this.f;
		}

		// Token: 0x0600377C RID: 14204 RVA: 0x001DFBA8 File Offset: 0x001DEBA8
		internal int g()
		{
			return this.g;
		}

		// Token: 0x04001A43 RID: 6723
		private string a;

		// Token: 0x04001A44 RID: 6724
		private bool b = false;

		// Token: 0x04001A45 RID: 6725
		private al7 c;

		// Token: 0x04001A46 RID: 6726
		private akr d = null;

		// Token: 0x04001A47 RID: 6727
		private ali e = new ali();

		// Token: 0x04001A48 RID: 6728
		private string f = null;

		// Token: 0x04001A49 RID: 6729
		private int g = 1;
	}
}
