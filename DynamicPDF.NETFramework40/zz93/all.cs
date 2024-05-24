using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x02000594 RID: 1428
	internal class all : akt
	{
		// Token: 0x060038DF RID: 14559 RVA: 0x001E9B2C File Offset: 0x001E8B2C
		internal all(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 477746588)
				{
					if (num <= 2660)
					{
						switch (num)
						{
						case 56:
							this.g = x5.a(A_0.ar());
							break;
						case 57:
							this.h = x5.a(A_0.ar());
							break;
						default:
							if (num != 2660)
							{
								goto IL_19A;
							}
							this.a = A_0.a7();
							break;
						}
					}
					else if (num != 13541029)
					{
						if (num != 248366747)
						{
							if (num != 477746588)
							{
								goto IL_19A;
							}
							this.k = A_0.a2();
						}
						else
						{
							this.b = A_0.an();
						}
					}
					else
					{
						this.c = A_0.ar();
					}
				}
				else if (num <= 599706610)
				{
					if (num != 531973258)
					{
						if (num != 599706610)
						{
							goto IL_19A;
						}
						this.d = A_0.ad();
					}
					else
					{
						this.i = A_0.ah();
					}
				}
				else if (num != 680958428)
				{
					if (num != 794229807)
					{
						if (num != 933645608)
						{
							goto IL_19A;
						}
						this.f = x5.a(A_0.ar());
					}
					else
					{
						this.j = A_0.a7();
					}
				}
				else
				{
					this.e = x5.a(A_0.ar());
				}
				continue;
				IL_19A:
				throw new DlexParseException("The symbol element contains an invalid attribute.");
			}
		}

		// Token: 0x060038E0 RID: 14560 RVA: 0x001E9CF0 File Offset: 0x001E8CF0
		internal override LayoutElement mt(alo A_0)
		{
			return new Symbol(A_0, this);
		}

		// Token: 0x060038E1 RID: 14561 RVA: 0x001E9D0C File Offset: 0x001E8D0C
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x060038E2 RID: 14562 RVA: 0x001E9D24 File Offset: 0x001E8D24
		internal string a()
		{
			return this.j;
		}

		// Token: 0x060038E3 RID: 14563 RVA: 0x001E9D3C File Offset: 0x001E8D3C
		internal SymbolType b()
		{
			return this.i;
		}

		// Token: 0x060038E4 RID: 14564 RVA: 0x001E9D54 File Offset: 0x001E8D54
		internal ahm c()
		{
			return this.k;
		}

		// Token: 0x060038E5 RID: 14565 RVA: 0x001E9D6C File Offset: 0x001E8D6C
		internal Font d()
		{
			return this.b;
		}

		// Token: 0x060038E6 RID: 14566 RVA: 0x001E9D84 File Offset: 0x001E8D84
		internal float e()
		{
			return this.c;
		}

		// Token: 0x060038E7 RID: 14567 RVA: 0x001E9D9C File Offset: 0x001E8D9C
		internal Color f()
		{
			return this.d;
		}

		// Token: 0x060038E8 RID: 14568 RVA: 0x001E9DB4 File Offset: 0x001E8DB4
		internal x5 g()
		{
			return this.e;
		}

		// Token: 0x060038E9 RID: 14569 RVA: 0x001E9DCC File Offset: 0x001E8DCC
		internal x5 h()
		{
			return this.f;
		}

		// Token: 0x060038EA RID: 14570 RVA: 0x001E9DE4 File Offset: 0x001E8DE4
		internal x5 i()
		{
			return this.g;
		}

		// Token: 0x060038EB RID: 14571 RVA: 0x001E9DFC File Offset: 0x001E8DFC
		internal x5 j()
		{
			return this.h;
		}

		// Token: 0x04001B17 RID: 6935
		private string a;

		// Token: 0x04001B18 RID: 6936
		private Font b = Font.ZapfDingbats;

		// Token: 0x04001B19 RID: 6937
		private float c = 12f;

		// Token: 0x04001B1A RID: 6938
		private Color d = Grayscale.Black;

		// Token: 0x04001B1B RID: 6939
		private x5 e;

		// Token: 0x04001B1C RID: 6940
		private x5 f;

		// Token: 0x04001B1D RID: 6941
		private x5 g;

		// Token: 0x04001B1E RID: 6942
		private x5 h;

		// Token: 0x04001B1F RID: 6943
		private SymbolType i = SymbolType.Check1;

		// Token: 0x04001B20 RID: 6944
		private string j = "A";

		// Token: 0x04001B21 RID: 6945
		private ahm k;
	}
}
