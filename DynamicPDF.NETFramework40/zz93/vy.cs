using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000345 RID: 837
	internal class vy : vm
	{
		// Token: 0x060023BB RID: 9147 RVA: 0x001526B0 File Offset: 0x001516B0
		internal vy(wd A_0)
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

		// Token: 0x060023BC RID: 9148 RVA: 0x00152744 File Offset: 0x00151744
		internal override string fw()
		{
			return this.a;
		}

		// Token: 0x060023BD RID: 9149 RVA: 0x0015275C File Offset: 0x0015175C
		internal override x5 fx()
		{
			return this.b;
		}

		// Token: 0x060023BE RID: 9150 RVA: 0x00152774 File Offset: 0x00151774
		internal wj a()
		{
			return this.c;
		}

		// Token: 0x060023BF RID: 9151 RVA: 0x0015278C File Offset: 0x0015178C
		internal override wj fy()
		{
			return this.c;
		}

		// Token: 0x060023C0 RID: 9152 RVA: 0x001527A4 File Offset: 0x001517A4
		internal vq b()
		{
			return this.d;
		}

		// Token: 0x060023C1 RID: 9153 RVA: 0x001527BC File Offset: 0x001517BC
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
					if (num2 != 990044174)
					{
						goto IL_21C;
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
				IL_21C:
				throw new DplxParseException("Invalid report element.");
			}
		}

		// Token: 0x04000F64 RID: 3940
		private string a;

		// Token: 0x04000F65 RID: 3941
		private x5 b;

		// Token: 0x04000F66 RID: 3942
		private wj c = null;

		// Token: 0x04000F67 RID: 3943
		private vq d = null;
	}
}
