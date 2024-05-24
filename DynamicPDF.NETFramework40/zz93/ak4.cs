using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000583 RID: 1411
	internal class ak4 : akv
	{
		// Token: 0x060037D1 RID: 14289 RVA: 0x001E1C10 File Offset: 0x001E0C10
		internal ak4(ald A_0)
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

		// Token: 0x060037D2 RID: 14290 RVA: 0x001E1CA4 File Offset: 0x001E0CA4
		internal override string mv()
		{
			return this.a;
		}

		// Token: 0x060037D3 RID: 14291 RVA: 0x001E1CBC File Offset: 0x001E0CBC
		internal override x5 mx()
		{
			return this.b;
		}

		// Token: 0x060037D4 RID: 14292 RVA: 0x001E1CD4 File Offset: 0x001E0CD4
		internal ali a()
		{
			return this.c;
		}

		// Token: 0x060037D5 RID: 14293 RVA: 0x001E1CEC File Offset: 0x001E0CEC
		internal override ali mw()
		{
			return this.c;
		}

		// Token: 0x060037D6 RID: 14294 RVA: 0x001E1D04 File Offset: 0x001E0D04
		internal aks b()
		{
			return this.d;
		}

		// Token: 0x060037D7 RID: 14295 RVA: 0x001E1D1C File Offset: 0x001E0D1C
		private void a(ald A_0)
		{
			A_0.a(true);
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
								goto IL_21C;
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
								goto IL_21C;
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
							goto IL_21C;
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
							goto IL_21C;
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
						goto IL_21C;
					}
					this.c.a(new all(A_0));
				}
				else if (num2 != 937732022)
				{
					if (num2 != 993674142)
					{
						goto IL_21C;
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
				IL_21C:
				throw new DlexParseException("Invalid report element.");
			}
		}

		// Token: 0x04001A79 RID: 6777
		private string a;

		// Token: 0x04001A7A RID: 6778
		private x5 b;

		// Token: 0x04001A7B RID: 6779
		private ali c = null;

		// Token: 0x04001A7C RID: 6780
		private aks d = null;
	}
}
