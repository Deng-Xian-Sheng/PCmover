using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000360 RID: 864
	internal class wp
	{
		// Token: 0x0600251A RID: 9498 RVA: 0x0015C45C File Offset: 0x0015B45C
		internal wp(wd A_0)
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
							throw new DplxParseException("A template contains an invalid attribute.");
						}
						this.c = A_0.@as();
					}
					else
					{
						this.b = A_0.a6();
					}
				}
				else
				{
					this.a = A_0.a8();
				}
			}
			if (!A_0.z())
			{
				this.a(A_0);
				A_0.aa();
			}
		}

		// Token: 0x0600251B RID: 9499 RVA: 0x0015C514 File Offset: 0x0015B514
		internal string a()
		{
			return this.a;
		}

		// Token: 0x0600251C RID: 9500 RVA: 0x0015C52C File Offset: 0x0015B52C
		internal wj b()
		{
			return this.d;
		}

		// Token: 0x0600251D RID: 9501 RVA: 0x0015C544 File Offset: 0x0015B544
		internal vq c()
		{
			return this.e;
		}

		// Token: 0x0600251E RID: 9502 RVA: 0x0015C55C File Offset: 0x0015B55C
		internal int d()
		{
			return this.c;
		}

		// Token: 0x0600251F RID: 9503 RVA: 0x0015C574 File Offset: 0x0015B574
		internal string e()
		{
			return this.b;
		}

		// Token: 0x06002520 RID: 9504 RVA: 0x0015C58C File Offset: 0x0015B58C
		private void a(wd A_0)
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
								throw new DplxParseException("A contentGroup element cannot be placed in a template.");
							}
							if (num2 != 378606227)
							{
								goto IL_209;
							}
							this.d.a(new we(A_0));
						}
						else
						{
							this.d.a(new v5(A_0));
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
							this.d.a(new v3(A_0));
						}
						else
						{
							this.d.a(new wc(A_0));
						}
					}
					else if (num2 != 746989932)
					{
						if (num2 != 747113073)
						{
							goto IL_209;
						}
						this.d.a(new v9(A_0));
					}
					else
					{
						this.d.a(new v4(A_0));
					}
				}
				else if (num2 <= 841762308)
				{
					if (num2 == 810295593)
					{
						throw new DplxParseException("A pageBreak element cannot be placed in a template.");
					}
					if (num2 != 839258122)
					{
						if (num2 != 841762308)
						{
							goto IL_209;
						}
						this.d.a(new wg(A_0, 1050867191));
					}
					else
					{
						this.d.a(new wf(A_0));
					}
				}
				else if (num2 <= 870766723)
				{
					if (num2 == 857004049)
					{
						throw new DplxParseException("A subReport element cannot be placed in a template.");
					}
					if (num2 != 870766723)
					{
						goto IL_209;
					}
					this.d.a(new wo(A_0));
				}
				else if (num2 != 937732022)
				{
					if (num2 != 1006130397)
					{
						goto IL_209;
					}
					this.e = new vq(A_0, 1006130397);
					break;
				}
				else
				{
					this.d.a(new vz(A_0));
				}
				A_0.aa();
				continue;
				IL_209:
				throw new DplxParseException("Invalid report element.");
			}
		}

		// Token: 0x04001038 RID: 4152
		private string a;

		// Token: 0x04001039 RID: 4153
		private string b = null;

		// Token: 0x0400103A RID: 4154
		private int c = 1;

		// Token: 0x0400103B RID: 4155
		private wj d = new wj();

		// Token: 0x0400103C RID: 4156
		private vq e = null;
	}
}
