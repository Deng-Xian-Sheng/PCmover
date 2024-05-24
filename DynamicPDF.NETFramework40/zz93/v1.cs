using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000348 RID: 840
	internal class v1 : vm
	{
		// Token: 0x060023D7 RID: 9175 RVA: 0x00153198 File Offset: 0x00152198
		internal v1(wd A_0)
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

		// Token: 0x060023D8 RID: 9176 RVA: 0x0015322C File Offset: 0x0015222C
		internal override string fw()
		{
			return this.a;
		}

		// Token: 0x060023D9 RID: 9177 RVA: 0x00153244 File Offset: 0x00152244
		internal override x5 fx()
		{
			return this.b;
		}

		// Token: 0x060023DA RID: 9178 RVA: 0x0015325C File Offset: 0x0015225C
		internal vq a()
		{
			return this.d;
		}

		// Token: 0x060023DB RID: 9179 RVA: 0x00153274 File Offset: 0x00152274
		internal wj b()
		{
			return this.c;
		}

		// Token: 0x060023DC RID: 9180 RVA: 0x0015328C File Offset: 0x0015228C
		internal override wj fy()
		{
			return this.c;
		}

		// Token: 0x060023DD RID: 9181 RVA: 0x001532A4 File Offset: 0x001522A4
		private void a(wd A_0)
		{
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
								goto IL_214;
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
								goto IL_214;
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
							goto IL_214;
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
							goto IL_214;
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
						goto IL_214;
					}
					this.c.a(new wo(A_0));
				}
				else if (num2 != 937732022)
				{
					if (num2 != 993674142)
					{
						goto IL_214;
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
				IL_214:
				throw new DplxParseException("Invalid report element.");
			}
		}

		// Token: 0x04000F75 RID: 3957
		private string a;

		// Token: 0x04000F76 RID: 3958
		private x5 b;

		// Token: 0x04000F77 RID: 3959
		private wj c = null;

		// Token: 0x04000F78 RID: 3960
		private vq d = null;
	}
}
