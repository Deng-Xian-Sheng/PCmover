using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x0200033C RID: 828
	internal class vp
	{
		// Token: 0x06002383 RID: 9091 RVA: 0x001513BC File Offset: 0x001503BC
		internal vp(wd A_0, bool A_1)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 356812069)
				{
					if (num != 2660)
					{
						if (num != 356812069)
						{
							goto IL_C6;
						}
						if (A_1)
						{
							this.f = A_0.a6();
						}
					}
					else
					{
						this.a = A_0.a8();
					}
				}
				else if (num != 594309831)
				{
					if (num != 771506020)
					{
						if (num != 852642834)
						{
							goto IL_C6;
						}
						if (A_1)
						{
							this.g = A_0.@as();
						}
					}
					else
					{
						this.b = A_0.av();
					}
				}
				else
				{
					this.c = A_0.az();
				}
				continue;
				IL_C6:
				throw new DplxParseException("A conditional header, footer or template contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				this.a(A_0);
				A_0.aa();
			}
			A_0.aa();
		}

		// Token: 0x06002384 RID: 9092 RVA: 0x001514CC File Offset: 0x001504CC
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
							if (num2 == 225352954)
							{
								throw new DplxParseException("A contentGroup element cannot be placed in a conditional header, footer or template.");
							}
							if (num2 != 378606227)
							{
								goto IL_1DB;
							}
							this.e.a(new we(A_0));
						}
						else
						{
							this.e.a(new v5(A_0));
						}
					}
					else if (num2 != 403493362)
					{
						if (num2 != 699800037)
						{
							if (num2 != 746989932)
							{
								goto IL_1DB;
							}
							this.e.a(new v4(A_0));
						}
						else
						{
							this.e.a(new v3(A_0));
						}
					}
					else
					{
						this.e.a(new wc(A_0));
					}
				}
				else if (num2 <= 839258122)
				{
					if (num2 != 747113073)
					{
						if (num2 == 810295593)
						{
							throw new DplxParseException("A pageBreak element cannot be placed in a conditional header, footer or template.");
						}
						if (num2 != 839258122)
						{
							goto IL_1DB;
						}
						this.e.a(new wf(A_0));
					}
					else
					{
						this.e.a(new v9(A_0));
					}
				}
				else if (num2 <= 857004049)
				{
					if (num2 != 841762308)
					{
						if (num2 != 857004049)
						{
							goto IL_1DB;
						}
						throw new DplxParseException("A subReport element cannot be placed in a conditional header, footer or template.");
					}
					else
					{
						this.e.a(new wg(A_0, 1050867191));
					}
				}
				else if (num2 != 870766723)
				{
					if (num2 != 937732022)
					{
						goto IL_1DB;
					}
					this.e.a(new vz(A_0));
				}
				else
				{
					this.e.a(new wo(A_0));
				}
				A_0.aa();
				continue;
				IL_1DB:
				throw new DplxParseException("Invalid report element.");
			}
		}

		// Token: 0x06002385 RID: 9093 RVA: 0x001516DC File Offset: 0x001506DC
		internal vp a()
		{
			return this.d;
		}

		// Token: 0x06002386 RID: 9094 RVA: 0x001516F4 File Offset: 0x001506F4
		internal void a(vp A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06002387 RID: 9095 RVA: 0x00151700 File Offset: 0x00150700
		internal wj b()
		{
			return this.e;
		}

		// Token: 0x06002388 RID: 9096 RVA: 0x00151718 File Offset: 0x00150718
		internal bool c()
		{
			return this.b;
		}

		// Token: 0x06002389 RID: 9097 RVA: 0x00151730 File Offset: 0x00150730
		internal w6 d()
		{
			return this.c;
		}

		// Token: 0x0600238A RID: 9098 RVA: 0x00151748 File Offset: 0x00150748
		internal string e()
		{
			return this.a;
		}

		// Token: 0x0600238B RID: 9099 RVA: 0x00151760 File Offset: 0x00150760
		internal string f()
		{
			return this.f;
		}

		// Token: 0x0600238C RID: 9100 RVA: 0x00151778 File Offset: 0x00150778
		internal int g()
		{
			return this.g;
		}

		// Token: 0x04000F47 RID: 3911
		private string a;

		// Token: 0x04000F48 RID: 3912
		private bool b = false;

		// Token: 0x04000F49 RID: 3913
		private w6 c;

		// Token: 0x04000F4A RID: 3914
		private vp d = null;

		// Token: 0x04000F4B RID: 3915
		private wj e = new wj();

		// Token: 0x04000F4C RID: 3916
		private string f = null;

		// Token: 0x04000F4D RID: 3917
		private int g = 1;
	}
}
