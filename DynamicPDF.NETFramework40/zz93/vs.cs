using System;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x0200033F RID: 831
	internal class vs : vr
	{
		// Token: 0x06002396 RID: 9110 RVA: 0x00151894 File Offset: 0x00150894
		internal vs(wd A_0)
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
						this.a = A_0.a8();
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
				throw new DplxParseException("A rectangle element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				this.a(A_0);
				A_0.aa();
			}
		}

		// Token: 0x06002397 RID: 9111 RVA: 0x001519A4 File Offset: 0x001509A4
		internal override ReportElement fz(rm A_0)
		{
			return new ContentGroup(A_0, this);
		}

		// Token: 0x06002398 RID: 9112 RVA: 0x001519C0 File Offset: 0x001509C0
		private void a(wd A_0)
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
								this.g.a(new we(A_0));
							}
							else
							{
								this.g.a(new vs(A_0));
							}
						}
						else
						{
							this.g.a(new v5(A_0));
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
							this.g.a(new v4(A_0));
						}
						else
						{
							this.g.a(new v3(A_0));
						}
					}
					else
					{
						this.g.a(new wc(A_0));
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
							this.g.a(new wg(A_0));
						}
						else
						{
							this.g.a(new wf(A_0));
						}
					}
					else
					{
						this.g.a(new v9(A_0));
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
						this.g.a(new vz(A_0));
					}
					else
					{
						this.g.a(new wo(A_0));
					}
				}
				else
				{
					this.g.a(new wn(A_0));
				}
				A_0.aa();
				continue;
				IL_1CB:
				throw new DplxParseException("Invalid report element.");
			}
		}

		// Token: 0x06002399 RID: 9113 RVA: 0x00151BC0 File Offset: 0x00150BC0
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x0600239A RID: 9114 RVA: 0x00151BD8 File Offset: 0x00150BD8
		internal x5 a()
		{
			return this.b;
		}

		// Token: 0x0600239B RID: 9115 RVA: 0x00151BF0 File Offset: 0x00150BF0
		internal bool b()
		{
			return this.f;
		}

		// Token: 0x0600239C RID: 9116 RVA: 0x00151C08 File Offset: 0x00150C08
		internal wj c()
		{
			return this.g;
		}

		// Token: 0x0600239D RID: 9117 RVA: 0x00151C20 File Offset: 0x00150C20
		internal x5 d()
		{
			return this.c;
		}

		// Token: 0x0600239E RID: 9118 RVA: 0x00151C38 File Offset: 0x00150C38
		internal x5 e()
		{
			return this.d;
		}

		// Token: 0x0600239F RID: 9119 RVA: 0x00151C50 File Offset: 0x00150C50
		internal x5 f()
		{
			return this.e;
		}

		// Token: 0x04000F52 RID: 3922
		private string a;

		// Token: 0x04000F53 RID: 3923
		private x5 b;

		// Token: 0x04000F54 RID: 3924
		private x5 c;

		// Token: 0x04000F55 RID: 3925
		private x5 d;

		// Token: 0x04000F56 RID: 3926
		private x5 e;

		// Token: 0x04000F57 RID: 3927
		private bool f;

		// Token: 0x04000F58 RID: 3928
		private wj g = new wj();
	}
}
