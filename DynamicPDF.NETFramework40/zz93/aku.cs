using System;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x02000579 RID: 1401
	internal class aku : akt
	{
		// Token: 0x06003786 RID: 14214 RVA: 0x001DFCC4 File Offset: 0x001DECC4
		internal aku(ald A_0)
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
							goto IL_CC;
						}
						this.a = A_0.a7();
						break;
					}
				}
				else if (num != 121954641)
				{
					if (num != 680958428)
					{
						if (num != 933645608)
						{
							goto IL_CC;
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
					this.f = A_0.av();
				}
				continue;
				IL_CC:
				throw new DlexParseException("A rectangle element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				this.a(A_0);
				A_0.aa();
			}
		}

		// Token: 0x06003787 RID: 14215 RVA: 0x001DFDD4 File Offset: 0x001DEDD4
		internal override LayoutElement mt(alo A_0)
		{
			return new ContentGroup(A_0, this);
		}

		// Token: 0x06003788 RID: 14216 RVA: 0x001DFDF0 File Offset: 0x001DEDF0
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
							if (num2 != 225352954)
							{
								if (num2 != 378606227)
								{
									goto IL_1CB;
								}
								this.g.a(new ale(A_0));
							}
							else
							{
								this.g.a(new aku(A_0));
							}
						}
						else
						{
							this.g.a(new ak7(A_0));
						}
					}
					else if (num2 != 403493362)
					{
						if (num2 != 699800037)
						{
							if (num2 != 746989932)
							{
								goto IL_1CB;
							}
							this.g.a(new ak6(A_0));
						}
						else
						{
							this.g.a(new ak5(A_0));
						}
					}
					else
					{
						this.g.a(new alc(A_0));
					}
				}
				else if (num2 <= 841762308)
				{
					if (num2 != 747113073)
					{
						if (num2 != 839258122)
						{
							if (num2 != 841762308)
							{
								goto IL_1CB;
							}
							this.g.a(new alg(A_0));
						}
						else
						{
							this.g.a(new alf(A_0));
						}
					}
					else
					{
						this.g.a(new alb(A_0));
					}
				}
				else if (num2 != 857004049)
				{
					if (num2 != 870766723)
					{
						if (num2 != 937732022)
						{
							goto IL_1CB;
						}
						this.g.a(new ak2(A_0));
					}
					else
					{
						this.g.a(new all(A_0));
					}
				}
				else
				{
					this.g.a(new alk(A_0));
				}
				A_0.aa();
				continue;
				IL_1CB:
				throw new DlexParseException("Invalid report element.");
			}
		}

		// Token: 0x06003789 RID: 14217 RVA: 0x001DFFF0 File Offset: 0x001DEFF0
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x0600378A RID: 14218 RVA: 0x001E0008 File Offset: 0x001DF008
		internal x5 a()
		{
			return this.b;
		}

		// Token: 0x0600378B RID: 14219 RVA: 0x001E0020 File Offset: 0x001DF020
		internal bool b()
		{
			return this.f;
		}

		// Token: 0x0600378C RID: 14220 RVA: 0x001E0038 File Offset: 0x001DF038
		internal ali c()
		{
			return this.g;
		}

		// Token: 0x0600378D RID: 14221 RVA: 0x001E0050 File Offset: 0x001DF050
		internal x5 d()
		{
			return this.c;
		}

		// Token: 0x0600378E RID: 14222 RVA: 0x001E0068 File Offset: 0x001DF068
		internal x5 e()
		{
			return this.d;
		}

		// Token: 0x0600378F RID: 14223 RVA: 0x001E0080 File Offset: 0x001DF080
		internal x5 f()
		{
			return this.e;
		}

		// Token: 0x04001A4E RID: 6734
		private string a;

		// Token: 0x04001A4F RID: 6735
		private x5 b;

		// Token: 0x04001A50 RID: 6736
		private x5 c;

		// Token: 0x04001A51 RID: 6737
		private x5 d;

		// Token: 0x04001A52 RID: 6738
		private x5 e;

		// Token: 0x04001A53 RID: 6739
		private bool f;

		// Token: 0x04001A54 RID: 6740
		private ali g = new ali();
	}
}
