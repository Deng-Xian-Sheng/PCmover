using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x0200035F RID: 863
	internal class wo : vr
	{
		// Token: 0x0600250D RID: 9485 RVA: 0x0015C174 File Offset: 0x0015B174
		internal wo(wd A_0)
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
							this.a = A_0.a8();
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
						this.j = A_0.a8();
					}
				}
				else
				{
					this.e = x5.a(A_0.ar());
				}
				continue;
				IL_19A:
				throw new DplxParseException("The symbol element contains an invalid attribute.");
			}
		}

		// Token: 0x0600250E RID: 9486 RVA: 0x0015C338 File Offset: 0x0015B338
		internal override ReportElement fz(rm A_0)
		{
			return new Symbol(A_0, this);
		}

		// Token: 0x0600250F RID: 9487 RVA: 0x0015C354 File Offset: 0x0015B354
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x06002510 RID: 9488 RVA: 0x0015C36C File Offset: 0x0015B36C
		internal string a()
		{
			return this.j;
		}

		// Token: 0x06002511 RID: 9489 RVA: 0x0015C384 File Offset: 0x0015B384
		internal SymbolType b()
		{
			return this.i;
		}

		// Token: 0x06002512 RID: 9490 RVA: 0x0015C39C File Offset: 0x0015B39C
		internal sv c()
		{
			return this.k;
		}

		// Token: 0x06002513 RID: 9491 RVA: 0x0015C3B4 File Offset: 0x0015B3B4
		internal Font d()
		{
			return this.b;
		}

		// Token: 0x06002514 RID: 9492 RVA: 0x0015C3CC File Offset: 0x0015B3CC
		internal float e()
		{
			return this.c;
		}

		// Token: 0x06002515 RID: 9493 RVA: 0x0015C3E4 File Offset: 0x0015B3E4
		internal Color f()
		{
			return this.d;
		}

		// Token: 0x06002516 RID: 9494 RVA: 0x0015C3FC File Offset: 0x0015B3FC
		internal x5 g()
		{
			return this.e;
		}

		// Token: 0x06002517 RID: 9495 RVA: 0x0015C414 File Offset: 0x0015B414
		internal x5 h()
		{
			return this.f;
		}

		// Token: 0x06002518 RID: 9496 RVA: 0x0015C42C File Offset: 0x0015B42C
		internal x5 i()
		{
			return this.g;
		}

		// Token: 0x06002519 RID: 9497 RVA: 0x0015C444 File Offset: 0x0015B444
		internal x5 j()
		{
			return this.h;
		}

		// Token: 0x0400102D RID: 4141
		private string a;

		// Token: 0x0400102E RID: 4142
		private Font b = Font.ZapfDingbats;

		// Token: 0x0400102F RID: 4143
		private float c = 12f;

		// Token: 0x04001030 RID: 4144
		private Color d = Grayscale.Black;

		// Token: 0x04001031 RID: 4145
		private x5 e;

		// Token: 0x04001032 RID: 4146
		private x5 f;

		// Token: 0x04001033 RID: 4147
		private x5 g;

		// Token: 0x04001034 RID: 4148
		private x5 h;

		// Token: 0x04001035 RID: 4149
		private SymbolType i = SymbolType.Check1;

		// Token: 0x04001036 RID: 4150
		private string j = "A";

		// Token: 0x04001037 RID: 4151
		private sv k;
	}
}
