using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200057B RID: 1403
	internal class akw : akv
	{
		// Token: 0x06003794 RID: 14228 RVA: 0x001E00A0 File Offset: 0x001DF0A0
		internal akw(ald A_0)
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
							throw new DlexParseException("A report part element (header or footer) contains an invalid attribute.");
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
					this.a = A_0.a7();
				}
			}
			if (!A_0.z())
			{
				this.a(A_0);
				A_0.aa();
			}
		}

		// Token: 0x06003795 RID: 14229 RVA: 0x001E0150 File Offset: 0x001DF150
		private void a(ald A_0)
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
								this.c.a(new aku(A_0));
							}
							else
							{
								this.c.a(new ak8(A_0));
							}
						}
						else
						{
							this.c.a(new ak7(A_0));
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
							this.c.a(new alc(A_0));
						}
						else
						{
							this.c.a(new ale(A_0));
						}
					}
					else if (num2 != 699800037)
					{
						if (num2 != 746989932)
						{
							goto IL_260;
						}
						this.c.a(new ak6(A_0));
					}
					else
					{
						this.c.a(new ak5(A_0));
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
							this.c.a(new ala(A_0));
						}
						else
						{
							this.c.a(new alb(A_0));
						}
					}
					else if (num2 != 839258122)
					{
						if (num2 != 841762308)
						{
							goto IL_260;
						}
						this.c.a(new alg(A_0));
					}
					else
					{
						this.c.a(new alf(A_0));
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
						this.c.a(new alj(A_0));
					}
					else
					{
						this.c.a(new alk(A_0));
					}
				}
				else if (num2 != 870766723)
				{
					if (num2 != 937732022)
					{
						goto IL_260;
					}
					this.c.a(new ak2(A_0));
				}
				else
				{
					this.c.a(new all(A_0));
				}
				A_0.aa();
				continue;
				IL_260:
				throw new DlexParseException("Invalid report element.");
			}
			A_0.a(true);
		}

		// Token: 0x06003796 RID: 14230 RVA: 0x001E03EC File Offset: 0x001DF3EC
		internal override string mv()
		{
			return this.a;
		}

		// Token: 0x06003797 RID: 14231 RVA: 0x001E0404 File Offset: 0x001DF404
		internal bool a()
		{
			return this.d;
		}

		// Token: 0x06003798 RID: 14232 RVA: 0x001E041C File Offset: 0x001DF41C
		internal override ali mw()
		{
			return this.c;
		}

		// Token: 0x06003799 RID: 14233 RVA: 0x001E0434 File Offset: 0x001DF434
		internal override x5 mx()
		{
			return this.b;
		}

		// Token: 0x04001A55 RID: 6741
		private string a;

		// Token: 0x04001A56 RID: 6742
		private x5 b;

		// Token: 0x04001A57 RID: 6743
		private ali c = new ali();

		// Token: 0x04001A58 RID: 6744
		private bool d = false;
	}
}
