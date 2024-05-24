using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x0200058F RID: 1423
	internal class alg : akt
	{
		// Token: 0x060038AA RID: 14506 RVA: 0x001E8C2C File Offset: 0x001E7C2C
		internal alg(ald A_0)
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
							this.a = A_0.a7();
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
				throw new DlexParseException("A rectangle element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060038AB RID: 14507 RVA: 0x001E8E30 File Offset: 0x001E7E30
		internal alg(ald A_0, int A_1) : this(A_0)
		{
			if (A_1 == 1050867191)
			{
				this.g = AlternateRow.All;
			}
		}

		// Token: 0x060038AC RID: 14508 RVA: 0x001E8E5C File Offset: 0x001E7E5C
		internal override LayoutElement mt(alo A_0)
		{
			float num = Math.Min(x5.b(this.h()), x5.b(this.i())) / 2f;
			if (this.d() > num)
			{
				this.e = num;
			}
			return new Rectangle(A_0, this);
		}

		// Token: 0x060038AD RID: 14509 RVA: 0x001E8EB0 File Offset: 0x001E7EB0
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x060038AE RID: 14510 RVA: 0x001E8EC8 File Offset: 0x001E7EC8
		internal Color a()
		{
			return this.b;
		}

		// Token: 0x060038AF RID: 14511 RVA: 0x001E8EE0 File Offset: 0x001E7EE0
		internal LineStyle b()
		{
			return this.c;
		}

		// Token: 0x060038B0 RID: 14512 RVA: 0x001E8EF8 File Offset: 0x001E7EF8
		internal float c()
		{
			return this.d;
		}

		// Token: 0x060038B1 RID: 14513 RVA: 0x001E8F10 File Offset: 0x001E7F10
		internal float d()
		{
			return this.e;
		}

		// Token: 0x060038B2 RID: 14514 RVA: 0x001E8F28 File Offset: 0x001E7F28
		internal Color e()
		{
			return this.f;
		}

		// Token: 0x060038B3 RID: 14515 RVA: 0x001E8F40 File Offset: 0x001E7F40
		internal AlternateRow f()
		{
			return this.g;
		}

		// Token: 0x060038B4 RID: 14516 RVA: 0x001E8F58 File Offset: 0x001E7F58
		internal float g()
		{
			return this.h;
		}

		// Token: 0x060038B5 RID: 14517 RVA: 0x001E8F70 File Offset: 0x001E7F70
		internal x5 h()
		{
			return this.i;
		}

		// Token: 0x060038B6 RID: 14518 RVA: 0x001E8F88 File Offset: 0x001E7F88
		internal x5 i()
		{
			return this.j;
		}

		// Token: 0x060038B7 RID: 14519 RVA: 0x001E8FA0 File Offset: 0x001E7FA0
		internal x5 j()
		{
			return this.k;
		}

		// Token: 0x060038B8 RID: 14520 RVA: 0x001E8FB8 File Offset: 0x001E7FB8
		internal x5 k()
		{
			return this.l;
		}

		// Token: 0x04001AED RID: 6893
		private string a;

		// Token: 0x04001AEE RID: 6894
		private Color b = Grayscale.Black;

		// Token: 0x04001AEF RID: 6895
		private LineStyle c = LineStyle.Solid;

		// Token: 0x04001AF0 RID: 6896
		private float d = 1f;

		// Token: 0x04001AF1 RID: 6897
		private float e = 0f;

		// Token: 0x04001AF2 RID: 6898
		private Color f = null;

		// Token: 0x04001AF3 RID: 6899
		private AlternateRow g = AlternateRow.All;

		// Token: 0x04001AF4 RID: 6900
		private float h = 0f;

		// Token: 0x04001AF5 RID: 6901
		private x5 i;

		// Token: 0x04001AF6 RID: 6902
		private x5 j;

		// Token: 0x04001AF7 RID: 6903
		private x5 k;

		// Token: 0x04001AF8 RID: 6904
		private x5 l;
	}
}
