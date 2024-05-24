using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000344 RID: 836
	internal class vx : vm
	{
		// Token: 0x060023B4 RID: 9140 RVA: 0x0015235C File Offset: 0x0015135C
		internal vx(wd A_0)
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

		// Token: 0x060023B5 RID: 9141 RVA: 0x001523F0 File Offset: 0x001513F0
		internal override string fw()
		{
			return this.a;
		}

		// Token: 0x060023B6 RID: 9142 RVA: 0x00152408 File Offset: 0x00151408
		internal override x5 fx()
		{
			return this.b;
		}

		// Token: 0x060023B7 RID: 9143 RVA: 0x00152420 File Offset: 0x00151420
		internal wj a()
		{
			return this.c;
		}

		// Token: 0x060023B8 RID: 9144 RVA: 0x00152438 File Offset: 0x00151438
		internal override wj fy()
		{
			return this.c;
		}

		// Token: 0x060023B9 RID: 9145 RVA: 0x00152450 File Offset: 0x00151450
		internal vq b()
		{
			return this.d;
		}

		// Token: 0x060023BA RID: 9146 RVA: 0x00152468 File Offset: 0x00151468
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
					if (num2 != 990044174)
					{
						goto IL_214;
					}
					this.d = new vq(A_0, 990044174);
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

		// Token: 0x04000F60 RID: 3936
		private string a;

		// Token: 0x04000F61 RID: 3937
		private x5 b;

		// Token: 0x04000F62 RID: 3938
		private wj c = null;

		// Token: 0x04000F63 RID: 3939
		private vq d = null;
	}
}
