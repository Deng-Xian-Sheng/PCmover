using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000580 RID: 1408
	internal class ak1 : akv
	{
		// Token: 0x060037B1 RID: 14257 RVA: 0x001E0E5C File Offset: 0x001DFE5C
		internal ak1(ald A_0)
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

		// Token: 0x060037B2 RID: 14258 RVA: 0x001E0EF0 File Offset: 0x001DFEF0
		internal override string mv()
		{
			return this.a;
		}

		// Token: 0x060037B3 RID: 14259 RVA: 0x001E0F08 File Offset: 0x001DFF08
		internal override x5 mx()
		{
			return this.b;
		}

		// Token: 0x060037B4 RID: 14260 RVA: 0x001E0F20 File Offset: 0x001DFF20
		internal ali a()
		{
			return this.c;
		}

		// Token: 0x060037B5 RID: 14261 RVA: 0x001E0F38 File Offset: 0x001DFF38
		internal override ali mw()
		{
			return this.c;
		}

		// Token: 0x060037B6 RID: 14262 RVA: 0x001E0F50 File Offset: 0x001DFF50
		internal aks b()
		{
			return this.d;
		}

		// Token: 0x060037B7 RID: 14263 RVA: 0x001E0F68 File Offset: 0x001DFF68
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
					if (num2 != 990044174)
					{
						goto IL_21C;
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
				IL_21C:
				throw new DlexParseException("Invalid report element.");
			}
		}

		// Token: 0x04001A65 RID: 6757
		private string a;

		// Token: 0x04001A66 RID: 6758
		private x5 b;

		// Token: 0x04001A67 RID: 6759
		private ali c = null;

		// Token: 0x04001A68 RID: 6760
		private aks d = null;
	}
}
