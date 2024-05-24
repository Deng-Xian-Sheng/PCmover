using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000595 RID: 1429
	internal class alm
	{
		// Token: 0x060038EC RID: 14572 RVA: 0x001E9E14 File Offset: 0x001E8E14
		internal alm(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num != 2660)
				{
					if (num != 356812069)
					{
						if (num != 852642834)
						{
							throw new DlexParseException("A template contains an invalid attribute.");
						}
						this.c = A_0.@as();
					}
					else
					{
						this.b = A_0.a5();
					}
				}
				else
				{
					this.a = A_0.a7();
				}
			}
			if (!A_0.z())
			{
				this.a(A_0);
				A_0.aa();
			}
		}

		// Token: 0x060038ED RID: 14573 RVA: 0x001E9ECC File Offset: 0x001E8ECC
		internal string a()
		{
			return this.a;
		}

		// Token: 0x060038EE RID: 14574 RVA: 0x001E9EE4 File Offset: 0x001E8EE4
		internal ali b()
		{
			return this.d;
		}

		// Token: 0x060038EF RID: 14575 RVA: 0x001E9EFC File Offset: 0x001E8EFC
		internal aks c()
		{
			return this.e;
		}

		// Token: 0x060038F0 RID: 14576 RVA: 0x001E9F14 File Offset: 0x001E8F14
		internal int d()
		{
			return this.c;
		}

		// Token: 0x060038F1 RID: 14577 RVA: 0x001E9F2C File Offset: 0x001E8F2C
		internal string e()
		{
			return this.b;
		}

		// Token: 0x060038F2 RID: 14578 RVA: 0x001E9F44 File Offset: 0x001E8F44
		private void a(ald A_0)
		{
			int num = A_0.x();
			A_0.aa();
			while (A_0.x() != num)
			{
				int num2 = A_0.x();
				if (num2 <= 747113073)
				{
					if (num2 <= 378606227)
					{
						if (num2 != 11705253)
						{
							if (num2 == 225352954)
							{
								throw new DlexParseException("A contentGroup element cannot be placed in a template.");
							}
							if (num2 != 378606227)
							{
								goto IL_209;
							}
							this.d.a(new ale(A_0));
						}
						else
						{
							this.d.a(new ak7(A_0));
						}
					}
					else if (num2 <= 699800037)
					{
						if (num2 != 403493362)
						{
							if (num2 != 699800037)
							{
								goto IL_209;
							}
							this.d.a(new ak5(A_0));
						}
						else
						{
							this.d.a(new alc(A_0));
						}
					}
					else if (num2 != 746989932)
					{
						if (num2 != 747113073)
						{
							goto IL_209;
						}
						this.d.a(new alb(A_0));
					}
					else
					{
						this.d.a(new ak6(A_0));
					}
				}
				else if (num2 <= 841762308)
				{
					if (num2 == 810295593)
					{
						throw new DlexParseException("A pageBreak element cannot be placed in a template.");
					}
					if (num2 != 839258122)
					{
						if (num2 != 841762308)
						{
							goto IL_209;
						}
						this.d.a(new alg(A_0, 1050867191));
					}
					else
					{
						this.d.a(new alf(A_0));
					}
				}
				else if (num2 <= 870766723)
				{
					if (num2 == 857004049)
					{
						throw new DlexParseException("A subReport element cannot be placed in a template.");
					}
					if (num2 != 870766723)
					{
						goto IL_209;
					}
					this.d.a(new all(A_0));
				}
				else if (num2 != 937732022)
				{
					if (num2 != 1006130397)
					{
						goto IL_209;
					}
					this.e = new aks(A_0, 1006130397);
					break;
				}
				else
				{
					this.d.a(new ak2(A_0));
				}
				A_0.aa();
				continue;
				IL_209:
				throw new DlexParseException("Invalid report element.");
			}
		}

		// Token: 0x04001B22 RID: 6946
		private string a;

		// Token: 0x04001B23 RID: 6947
		private string b = null;

		// Token: 0x04001B24 RID: 6948
		private int c = 1;

		// Token: 0x04001B25 RID: 6949
		private ali d = new ali();

		// Token: 0x04001B26 RID: 6950
		private aks e = null;
	}
}
