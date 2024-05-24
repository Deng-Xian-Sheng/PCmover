using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x0200033A RID: 826
	internal class vn : vm
	{
		// Token: 0x06002377 RID: 9079 RVA: 0x00150C8C File Offset: 0x0014FC8C
		internal vn(wd A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num != 2660)
				{
					if (num != 555057575)
					{
						if (num != 680958428)
						{
							throw new DplxParseException("A report part element (header or footer) contains an invalid attribute.");
						}
						this.b = x5.a(A_0.ar());
					}
					else
					{
						this.d = A_0.av();
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

		// Token: 0x06002378 RID: 9080 RVA: 0x00150D3C File Offset: 0x0014FD3C
		private void a(wd A_0)
		{
			A_0.a(false);
			int num = A_0.x();
			A_0.aa();
			while (A_0.x() != num)
			{
				int num2 = A_0.x();
				if (num2 <= 746989932)
				{
					if (num2 <= 225352954)
					{
						if (num2 != 11705253)
						{
							if (num2 != 124557287)
							{
								if (num2 != 225352954)
								{
									goto IL_260;
								}
								this.c.a(new vs(A_0));
							}
							else
							{
								this.c.a(new v6(A_0));
							}
						}
						else
						{
							this.c.a(new v5(A_0));
						}
					}
					else if (num2 <= 403493362)
					{
						if (num2 != 378606227)
						{
							if (num2 != 403493362)
							{
								goto IL_260;
							}
							this.c.a(new wc(A_0));
						}
						else
						{
							this.c.a(new we(A_0));
						}
					}
					else if (num2 != 699800037)
					{
						if (num2 != 746989932)
						{
							goto IL_260;
						}
						this.c.a(new v4(A_0));
					}
					else
					{
						this.c.a(new v3(A_0));
					}
				}
				else if (num2 <= 841762308)
				{
					if (num2 <= 810295593)
					{
						if (num2 != 747113073)
						{
							if (num2 != 810295593)
							{
								goto IL_260;
							}
							this.c.a(new v8(A_0));
						}
						else
						{
							this.c.a(new v9(A_0));
						}
					}
					else if (num2 != 839258122)
					{
						if (num2 != 841762308)
						{
							goto IL_260;
						}
						this.c.a(new wg(A_0));
					}
					else
					{
						this.c.a(new wf(A_0));
					}
				}
				else if (num2 <= 863253865)
				{
					if (num2 != 857004049)
					{
						if (num2 != 863253865)
						{
							goto IL_260;
						}
						this.c.a(new wk(A_0));
					}
					else
					{
						this.c.a(new wn(A_0));
					}
				}
				else if (num2 != 870766723)
				{
					if (num2 != 937732022)
					{
						goto IL_260;
					}
					this.c.a(new vz(A_0));
				}
				else
				{
					this.c.a(new wo(A_0));
				}
				A_0.aa();
				continue;
				IL_260:
				throw new DplxParseException("Invalid report element.");
			}
			A_0.a(true);
		}

		// Token: 0x06002379 RID: 9081 RVA: 0x00150FD8 File Offset: 0x0014FFD8
		internal override string fw()
		{
			return this.a;
		}

		// Token: 0x0600237A RID: 9082 RVA: 0x00150FF0 File Offset: 0x0014FFF0
		internal override x5 fx()
		{
			return this.b;
		}

		// Token: 0x0600237B RID: 9083 RVA: 0x00151008 File Offset: 0x00150008
		internal bool a()
		{
			return this.d;
		}

		// Token: 0x0600237C RID: 9084 RVA: 0x00151020 File Offset: 0x00150020
		internal override wj fy()
		{
			return this.c;
		}

		// Token: 0x04000F3F RID: 3903
		private string a;

		// Token: 0x04000F40 RID: 3904
		private x5 b;

		// Token: 0x04000F41 RID: 3905
		private wj c = new wj();

		// Token: 0x04000F42 RID: 3906
		private bool d = false;
	}
}
