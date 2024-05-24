using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200057C RID: 1404
	internal class akx : akv
	{
		// Token: 0x0600379A RID: 14234 RVA: 0x001E044C File Offset: 0x001DF44C
		internal akx(ald A_0)
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
						this.c = A_0.av();
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

		// Token: 0x0600379B RID: 14235 RVA: 0x001E04F8 File Offset: 0x001DF4F8
		internal override string mv()
		{
			return this.a;
		}

		// Token: 0x0600379C RID: 14236 RVA: 0x001E0510 File Offset: 0x001DF510
		internal bool a()
		{
			return this.c;
		}

		// Token: 0x0600379D RID: 14237 RVA: 0x001E0528 File Offset: 0x001DF528
		internal override ali mw()
		{
			return this.d;
		}

		// Token: 0x0600379E RID: 14238 RVA: 0x001E0540 File Offset: 0x001DF540
		internal override x5 mx()
		{
			return this.b;
		}

		// Token: 0x0600379F RID: 14239 RVA: 0x001E0558 File Offset: 0x001DF558
		private void a(ald A_0)
		{
			A_0.a(false);
			this.d = new ali();
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
								this.d.a(new ale(A_0));
							}
							else
							{
								this.d.a(new aku(A_0));
							}
						}
						else
						{
							this.d.a(new ak7(A_0));
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
							this.d.a(new ak5(A_0));
						}
						else
						{
							this.d.a(new alc(A_0));
						}
					}
					else if (num2 != 746989932)
					{
						if (num2 != 747113073)
						{
							goto IL_23C;
						}
						this.d.a(new alb(A_0));
					}
					else
					{
						this.d.a(new ak6(A_0));
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
							this.d.a(new alg(A_0));
						}
						else
						{
							this.d.a(new alf(A_0));
						}
					}
					else
					{
						this.d.a(new ala(A_0));
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
						this.d.a(new alj(A_0));
					}
					else
					{
						this.d.a(new alk(A_0));
					}
				}
				else if (num2 != 870766723)
				{
					if (num2 != 937732022)
					{
						goto IL_23C;
					}
					this.d.a(new ak2(A_0));
				}
				else
				{
					this.d.a(new all(A_0));
				}
				A_0.aa();
				continue;
				IL_23C:
				throw new DlexParseException("Invalid report element.");
			}
			A_0.a(true);
		}

		// Token: 0x04001A59 RID: 6745
		private string a;

		// Token: 0x04001A5A RID: 6746
		private x5 b;

		// Token: 0x04001A5B RID: 6747
		private bool c = false;

		// Token: 0x04001A5C RID: 6748
		private ali d = null;
	}
}
