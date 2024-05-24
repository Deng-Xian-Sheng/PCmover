using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000349 RID: 841
	internal class v2 : vm
	{
		// Token: 0x060023DE RID: 9182 RVA: 0x001534EC File Offset: 0x001524EC
		internal v2(wd A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num != 2660)
				{
					if (num != 680958428)
					{
						throw new DplxParseException("A report part element (header or footer) contains an invalid attribute.");
					}
					this.b = x5.a(A_0.ar());
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

		// Token: 0x060023DF RID: 9183 RVA: 0x00153580 File Offset: 0x00152580
		internal override string fw()
		{
			return this.a;
		}

		// Token: 0x060023E0 RID: 9184 RVA: 0x00153598 File Offset: 0x00152598
		internal override x5 fx()
		{
			return this.b;
		}

		// Token: 0x060023E1 RID: 9185 RVA: 0x001535B0 File Offset: 0x001525B0
		internal wj a()
		{
			return this.c;
		}

		// Token: 0x060023E2 RID: 9186 RVA: 0x001535C8 File Offset: 0x001525C8
		internal override wj fy()
		{
			return this.c;
		}

		// Token: 0x060023E3 RID: 9187 RVA: 0x001535E0 File Offset: 0x001525E0
		internal vq b()
		{
			return this.d;
		}

		// Token: 0x060023E4 RID: 9188 RVA: 0x001535F8 File Offset: 0x001525F8
		private void a(wd A_0)
		{
			A_0.a(true);
			this.c = new wj();
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
								throw new DplxParseException("A contentGroup element cannot be placed in a header or footer.");
							}
							if (num2 != 378606227)
							{
								goto IL_21C;
							}
							this.c.a(new we(A_0));
						}
						else
						{
							this.c.a(new v5(A_0));
						}
					}
					else if (num2 <= 699800037)
					{
						if (num2 != 403493362)
						{
							if (num2 != 699800037)
							{
								goto IL_21C;
							}
							this.c.a(new v3(A_0));
						}
						else
						{
							this.c.a(new wc(A_0));
						}
					}
					else if (num2 != 746989932)
					{
						if (num2 != 747113073)
						{
							goto IL_21C;
						}
						this.c.a(new v9(A_0));
					}
					else
					{
						this.c.a(new v4(A_0));
					}
				}
				else if (num2 <= 841762308)
				{
					if (num2 == 810295593)
					{
						throw new DplxParseException("A pageBreak element cannot be placed in a header or footer.");
					}
					if (num2 != 839258122)
					{
						if (num2 != 841762308)
						{
							goto IL_21C;
						}
						this.c.a(new wg(A_0, 1050867191));
					}
					else
					{
						this.c.a(new wf(A_0));
					}
				}
				else if (num2 <= 870766723)
				{
					if (num2 == 857004049)
					{
						throw new DplxParseException("A subReport element cannot be placed in a header or footer.");
					}
					if (num2 != 870766723)
					{
						goto IL_21C;
					}
					this.c.a(new wo(A_0));
				}
				else if (num2 != 937732022)
				{
					if (num2 != 993674142)
					{
						goto IL_21C;
					}
					this.d = new vq(A_0, 993674142);
					continue;
				}
				else
				{
					this.c.a(new vz(A_0));
				}
				A_0.aa();
				continue;
				IL_21C:
				throw new DplxParseException("Invalid report element.");
			}
		}

		// Token: 0x04000F79 RID: 3961
		private string a;

		// Token: 0x04000F7A RID: 3962
		private x5 b;

		// Token: 0x04000F7B RID: 3963
		private wj c = null;

		// Token: 0x04000F7C RID: 3964
		private vq d = null;
	}
}
