using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200057F RID: 1407
	internal class ak0 : akv
	{
		// Token: 0x060037AA RID: 14250 RVA: 0x001E0B08 File Offset: 0x001DFB08
		internal ak0(ald A_0)
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

		// Token: 0x060037AB RID: 14251 RVA: 0x001E0B9C File Offset: 0x001DFB9C
		internal override string mv()
		{
			return this.a;
		}

		// Token: 0x060037AC RID: 14252 RVA: 0x001E0BB4 File Offset: 0x001DFBB4
		internal override x5 mx()
		{
			return this.b;
		}

		// Token: 0x060037AD RID: 14253 RVA: 0x001E0BCC File Offset: 0x001DFBCC
		internal ali a()
		{
			return this.c;
		}

		// Token: 0x060037AE RID: 14254 RVA: 0x001E0BE4 File Offset: 0x001DFBE4
		internal override ali mw()
		{
			return this.c;
		}

		// Token: 0x060037AF RID: 14255 RVA: 0x001E0BFC File Offset: 0x001DFBFC
		internal aks b()
		{
			return this.d;
		}

		// Token: 0x060037B0 RID: 14256 RVA: 0x001E0C14 File Offset: 0x001DFC14
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
					if (num2 != 990044174)
					{
						goto IL_214;
					}
					this.d = new aks(A_0, 990044174);
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

		// Token: 0x04001A61 RID: 6753
		private string a;

		// Token: 0x04001A62 RID: 6754
		private x5 b;

		// Token: 0x04001A63 RID: 6755
		private ali c = null;

		// Token: 0x04001A64 RID: 6756
		private aks d = null;
	}
}
