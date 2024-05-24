using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x0200033B RID: 827
	internal class vo : vm
	{
		// Token: 0x0600237D RID: 9085 RVA: 0x00151038 File Offset: 0x00150038
		internal vo(wd A_0)
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
						this.c = A_0.av();
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

		// Token: 0x0600237E RID: 9086 RVA: 0x001510E4 File Offset: 0x001500E4
		internal override string fw()
		{
			return this.a;
		}

		// Token: 0x0600237F RID: 9087 RVA: 0x001510FC File Offset: 0x001500FC
		internal override x5 fx()
		{
			return this.b;
		}

		// Token: 0x06002380 RID: 9088 RVA: 0x00151114 File Offset: 0x00150114
		internal bool a()
		{
			return this.c;
		}

		// Token: 0x06002381 RID: 9089 RVA: 0x0015112C File Offset: 0x0015012C
		internal override wj fy()
		{
			return this.d;
		}

		// Token: 0x06002382 RID: 9090 RVA: 0x00151144 File Offset: 0x00150144
		private void a(wd A_0)
		{
			A_0.a(false);
			this.d = new wj();
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
							if (num2 != 225352954)
							{
								if (num2 != 378606227)
								{
									goto IL_23C;
								}
								this.d.a(new we(A_0));
							}
							else
							{
								this.d.a(new vs(A_0));
							}
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
								goto IL_23C;
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
							goto IL_23C;
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
					if (num2 != 810295593)
					{
						if (num2 != 839258122)
						{
							if (num2 != 841762308)
							{
								goto IL_23C;
							}
							this.d.a(new wg(A_0));
						}
						else
						{
							this.d.a(new wf(A_0));
						}
					}
					else
					{
						this.d.a(new v8(A_0));
					}
				}
				else if (num2 <= 863253865)
				{
					if (num2 != 857004049)
					{
						if (num2 != 863253865)
						{
							goto IL_23C;
						}
						this.d.a(new wk(A_0));
					}
					else
					{
						this.d.a(new wn(A_0));
					}
				}
				else if (num2 != 870766723)
				{
					if (num2 != 937732022)
					{
						goto IL_23C;
					}
					this.d.a(new vz(A_0));
				}
				else
				{
					this.d.a(new wo(A_0));
				}
				A_0.aa();
				continue;
				IL_23C:
				throw new DplxParseException("Invalid report element.");
			}
			A_0.a(true);
		}

		// Token: 0x04000F43 RID: 3907
		private string a;

		// Token: 0x04000F44 RID: 3908
		private x5 b;

		// Token: 0x04000F45 RID: 3909
		private bool c = false;

		// Token: 0x04000F46 RID: 3910
		private wj d = null;
	}
}
