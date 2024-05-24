using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x02000357 RID: 855
	internal class wg : vr
	{
		// Token: 0x060024CA RID: 9418 RVA: 0x0015AF74 File Offset: 0x00159F74
		internal wg(wd A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 284190572)
				{
					if (num <= 2660)
					{
						switch (num)
						{
						case 56:
							this.k = x5.a(A_0.ar());
							break;
						case 57:
							this.l = x5.a(A_0.ar());
							break;
						default:
							if (num != 2660)
							{
								goto IL_1C2;
							}
							this.a = A_0.a8();
							break;
						}
					}
					else if (num != 280089144)
					{
						if (num != 283226169)
						{
							if (num != 284190572)
							{
								goto IL_1C2;
							}
							this.c = A_0.au();
						}
						else
						{
							this.d = A_0.ar();
						}
					}
					else
					{
						this.b = A_0.ad();
					}
				}
				else if (num <= 639107313)
				{
					if (num != 301285375)
					{
						if (num != 565869349)
						{
							if (num != 639107313)
							{
								goto IL_1C2;
							}
							this.f = A_0.ad();
						}
						else
						{
							this.h = A_0.ar();
						}
					}
					else
					{
						this.e = A_0.ar();
					}
				}
				else if (num != 680958428)
				{
					if (num != 933645608)
					{
						if (num != 1050867191)
						{
							goto IL_1C2;
						}
						this.g = A_0.al();
					}
					else
					{
						this.j = x5.a(A_0.ar());
					}
				}
				else
				{
					this.i = x5.a(A_0.ar());
				}
				continue;
				IL_1C2:
				throw new DplxParseException("A rectangle element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060024CB RID: 9419 RVA: 0x0015B178 File Offset: 0x0015A178
		internal wg(wd A_0, int A_1) : this(A_0)
		{
			if (A_1 == 1050867191)
			{
				this.g = AlternateRow.All;
			}
		}

		// Token: 0x060024CC RID: 9420 RVA: 0x0015B1A4 File Offset: 0x0015A1A4
		internal override ReportElement fz(rm A_0)
		{
			float num = Math.Min(x5.b(this.h()), x5.b(this.i())) / 2f;
			if (this.d() > num)
			{
				this.e = num;
			}
			return new Rectangle(A_0, this);
		}

		// Token: 0x060024CD RID: 9421 RVA: 0x0015B1F8 File Offset: 0x0015A1F8
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x060024CE RID: 9422 RVA: 0x0015B210 File Offset: 0x0015A210
		internal Color a()
		{
			return this.b;
		}

		// Token: 0x060024CF RID: 9423 RVA: 0x0015B228 File Offset: 0x0015A228
		internal LineStyle b()
		{
			return this.c;
		}

		// Token: 0x060024D0 RID: 9424 RVA: 0x0015B240 File Offset: 0x0015A240
		internal float c()
		{
			return this.d;
		}

		// Token: 0x060024D1 RID: 9425 RVA: 0x0015B258 File Offset: 0x0015A258
		internal float d()
		{
			return this.e;
		}

		// Token: 0x060024D2 RID: 9426 RVA: 0x0015B270 File Offset: 0x0015A270
		internal Color e()
		{
			return this.f;
		}

		// Token: 0x060024D3 RID: 9427 RVA: 0x0015B288 File Offset: 0x0015A288
		internal AlternateRow f()
		{
			return this.g;
		}

		// Token: 0x060024D4 RID: 9428 RVA: 0x0015B2A0 File Offset: 0x0015A2A0
		internal float g()
		{
			return this.h;
		}

		// Token: 0x060024D5 RID: 9429 RVA: 0x0015B2B8 File Offset: 0x0015A2B8
		internal x5 h()
		{
			return this.i;
		}

		// Token: 0x060024D6 RID: 9430 RVA: 0x0015B2D0 File Offset: 0x0015A2D0
		internal x5 i()
		{
			return this.j;
		}

		// Token: 0x060024D7 RID: 9431 RVA: 0x0015B2E8 File Offset: 0x0015A2E8
		internal x5 j()
		{
			return this.k;
		}

		// Token: 0x060024D8 RID: 9432 RVA: 0x0015B300 File Offset: 0x0015A300
		internal x5 k()
		{
			return this.l;
		}

		// Token: 0x04000FFB RID: 4091
		private string a;

		// Token: 0x04000FFC RID: 4092
		private Color b = Grayscale.Black;

		// Token: 0x04000FFD RID: 4093
		private LineStyle c = LineStyle.Solid;

		// Token: 0x04000FFE RID: 4094
		private float d = 1f;

		// Token: 0x04000FFF RID: 4095
		private float e = 0f;

		// Token: 0x04001000 RID: 4096
		private Color f = null;

		// Token: 0x04001001 RID: 4097
		private AlternateRow g = AlternateRow.All;

		// Token: 0x04001002 RID: 4098
		private float h = 0f;

		// Token: 0x04001003 RID: 4099
		private x5 i;

		// Token: 0x04001004 RID: 4100
		private x5 j;

		// Token: 0x04001005 RID: 4101
		private x5 k;

		// Token: 0x04001006 RID: 4102
		private x5 l;
	}
}
