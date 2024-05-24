using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000582 RID: 1410
	internal class ak3 : akv
	{
		// Token: 0x060037CA RID: 14282 RVA: 0x001E18BC File Offset: 0x001E08BC
		internal ak3(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num != 2660)
				{
					if (num != 680958428)
					{
						throw new DlexParseException("A report part element (header or footer) contains an invalid attribute.");
					}
					this.b = x5.a(A_0.ar());
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

		// Token: 0x060037CB RID: 14283 RVA: 0x001E1950 File Offset: 0x001E0950
		internal override string mv()
		{
			return this.a;
		}

		// Token: 0x060037CC RID: 14284 RVA: 0x001E1968 File Offset: 0x001E0968
		internal override x5 mx()
		{
			return this.b;
		}

		// Token: 0x060037CD RID: 14285 RVA: 0x001E1980 File Offset: 0x001E0980
		internal aks a()
		{
			return this.d;
		}

		// Token: 0x060037CE RID: 14286 RVA: 0x001E1998 File Offset: 0x001E0998
		internal ali b()
		{
			return this.c;
		}

		// Token: 0x060037CF RID: 14287 RVA: 0x001E19B0 File Offset: 0x001E09B0
		internal override ali mw()
		{
			return this.c;
		}

		// Token: 0x060037D0 RID: 14288 RVA: 0x001E19C8 File Offset: 0x001E09C8
		private void a(ald A_0)
		{
			this.c = new ali();
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
								throw new DlexParseException("A contentGroup element cannot be placed in a header or footer.");
							}
							if (num2 != 378606227)
							{
								goto IL_214;
							}
							this.c.a(new ale(A_0));
						}
						else
						{
							this.c.a(new ak7(A_0));
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
							this.c.a(new ak5(A_0));
						}
						else
						{
							this.c.a(new alc(A_0));
						}
					}
					else if (num2 != 746989932)
					{
						if (num2 != 747113073)
						{
							goto IL_214;
						}
						this.c.a(new alb(A_0));
					}
					else
					{
						this.c.a(new ak6(A_0));
					}
				}
				else if (num2 <= 841762308)
				{
					if (num2 == 810295593)
					{
						throw new DlexParseException("A pageBreak element cannot be placed in a header or footer.");
					}
					if (num2 != 839258122)
					{
						if (num2 != 841762308)
						{
							goto IL_214;
						}
						this.c.a(new alg(A_0, 1050867191));
					}
					else
					{
						this.c.a(new alf(A_0));
					}
				}
				else if (num2 <= 870766723)
				{
					if (num2 == 857004049)
					{
						throw new DlexParseException("A subReport element cannot be placed in a header or footer.");
					}
					if (num2 != 870766723)
					{
						goto IL_214;
					}
					this.c.a(new all(A_0));
				}
				else if (num2 != 937732022)
				{
					if (num2 != 993674142)
					{
						goto IL_214;
					}
					this.d = new aks(A_0, 993674142);
					continue;
				}
				else
				{
					this.c.a(new ak2(A_0));
				}
				A_0.aa();
				continue;
				IL_214:
				throw new DlexParseException("Invalid report element.");
			}
		}

		// Token: 0x04001A75 RID: 6773
		private string a;

		// Token: 0x04001A76 RID: 6774
		private x5 b;

		// Token: 0x04001A77 RID: 6775
		private ali c = null;

		// Token: 0x04001A78 RID: 6776
		private aks d = null;
	}
}
