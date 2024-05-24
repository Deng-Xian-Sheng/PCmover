using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000590 RID: 1424
	internal class alh : aky
	{
		// Token: 0x060038B9 RID: 14521 RVA: 0x001E8FD0 File Offset: 0x001E7FD0
		internal alh()
		{
		}

		// Token: 0x060038BA RID: 14522 RVA: 0x001E9048 File Offset: 0x001E8048
		internal void a(ald A_0)
		{
			float num = 50f;
			float left = 50f;
			float top = 50f;
			float num2 = 50f;
			float num3 = 792f;
			float num4 = 612f;
			PageOrientation orientation = PageOrientation.Portrait;
			int num5 = -1;
			string text = null;
			int pageNumber = 1;
			while (A_0.y())
			{
				int num6 = A_0.u();
				if (num6 <= 356812069)
				{
					if (num6 <= 234053289)
					{
						if (num6 <= 224139107)
						{
							if (num6 != 2660)
							{
								if (num6 != 224139107)
								{
									goto IL_287;
								}
								left = A_0.ar();
							}
							else
							{
								this.a = A_0.a7();
								A_0.a(this.a);
							}
						}
						else if (num6 != 227335798)
						{
							if (num6 != 234053289)
							{
								goto IL_287;
							}
							this.i = A_0.ar();
						}
						else
						{
							akq akq = (akq)A_0.aw();
							if (akq != akq.a)
							{
								if (akq != akq.b)
								{
									if (akq != akq.c)
									{
									}
									this.k = akq.c;
								}
								else
								{
									this.k = akq.b;
								}
							}
							else
							{
								this.k = akq.a;
							}
						}
					}
					else if (num6 <= 322039639)
					{
						if (num6 != 260660198)
						{
							if (num6 != 322039639)
							{
								goto IL_287;
							}
							this.j = A_0.ar();
						}
						else
						{
							num = A_0.ar();
						}
					}
					else if (num6 != 354419580)
					{
						if (num6 != 356812069)
						{
							goto IL_287;
						}
						text = A_0.a5();
					}
					else
					{
						num3 = A_0.ar();
					}
				}
				else if (num6 <= 807416959)
				{
					if (num6 <= 603109653)
					{
						if (num6 != 599705310)
						{
							if (num6 != 603109653)
							{
								goto IL_287;
							}
							orientation = A_0.ag();
						}
						else
						{
							this.h = A_0.@as();
						}
					}
					else if (num6 != 612717355)
					{
						if (num6 != 807416959)
						{
							goto IL_287;
						}
						num4 = A_0.ar();
					}
					else
					{
						this.l = A_0.a7();
					}
				}
				else if (num6 <= 852642834)
				{
					if (num6 != 814016502)
					{
						if (num6 != 852642834)
						{
							goto IL_287;
						}
						pageNumber = A_0.@as();
					}
					else
					{
						num5 = A_0.aw();
					}
				}
				else if (num6 != 880113935)
				{
					if (num6 != 1059148787)
					{
						goto IL_287;
					}
					num2 = A_0.ar();
				}
				else
				{
					top = A_0.ar();
				}
				continue;
				IL_287:
				throw new DlexParseException("The report element contains an invalid attribute.");
			}
			A_0.aa();
			if (A_0.x() == 882163977)
			{
				this.b = new alm(A_0);
				A_0.aa();
			}
			if (num5 == 601308418)
			{
				Dimensions dimensions = new Dimensions(num4, num3);
				Dimensions marginDimensions = new Dimensions(left, top, num4 - num2, num3 - num);
				this.f = new PageDimensions(dimensions, marginDimensions);
			}
			else
			{
				Dimensions dimensions = new Dimensions(base.a(num5), orientation);
				Dimensions marginDimensions = new Dimensions(left, top, dimensions.Right - num2, dimensions.Bottom - num);
				this.f = new PageDimensions(dimensions, marginDimensions);
			}
			if (text != null)
			{
				this.g = new PdfDocument(text).GetPage(pageNumber);
			}
			if (A_0.x() != 680925463)
			{
				throw new DlexParseException("The Report's header element was not found.");
			}
			this.c = new ak3(A_0);
			A_0.aa();
			if (A_0.x() != 613894213)
			{
				throw new DlexParseException("The Report's detail element was not found.");
			}
			this.d = new akw(A_0);
			A_0.aa();
			if (A_0.x() != 650050839)
			{
				throw new DlexParseException("The Report's footer element was not found.");
			}
			this.e = new ak0(A_0);
			A_0.aa();
			A_0.a(null);
		}

		// Token: 0x060038BB RID: 14523 RVA: 0x001E9461 File Offset: 0x001E8461
		internal override void my(DocumentLayoutPartList A_0)
		{
			A_0.a(this);
		}

		// Token: 0x060038BC RID: 14524 RVA: 0x001E946C File Offset: 0x001E846C
		internal string a()
		{
			return this.a;
		}

		// Token: 0x060038BD RID: 14525 RVA: 0x001E9484 File Offset: 0x001E8484
		internal PageDimensions b()
		{
			return this.f;
		}

		// Token: 0x060038BE RID: 14526 RVA: 0x001E949C File Offset: 0x001E849C
		internal PdfPage c()
		{
			return this.g;
		}

		// Token: 0x060038BF RID: 14527 RVA: 0x001E94B4 File Offset: 0x001E84B4
		internal ak3 d()
		{
			return this.c;
		}

		// Token: 0x060038C0 RID: 14528 RVA: 0x001E94CC File Offset: 0x001E84CC
		internal akw e()
		{
			return this.d;
		}

		// Token: 0x060038C1 RID: 14529 RVA: 0x001E94E4 File Offset: 0x001E84E4
		internal string f()
		{
			return this.l;
		}

		// Token: 0x060038C2 RID: 14530 RVA: 0x001E94FC File Offset: 0x001E84FC
		internal int g()
		{
			return this.h;
		}

		// Token: 0x060038C3 RID: 14531 RVA: 0x001E9514 File Offset: 0x001E8514
		internal x5 h()
		{
			return x5.a(this.i);
		}

		// Token: 0x060038C4 RID: 14532 RVA: 0x001E9534 File Offset: 0x001E8534
		internal x5 i()
		{
			return x5.a(this.j);
		}

		// Token: 0x060038C5 RID: 14533 RVA: 0x001E9554 File Offset: 0x001E8554
		internal akq j()
		{
			return this.k;
		}

		// Token: 0x060038C6 RID: 14534 RVA: 0x001E956C File Offset: 0x001E856C
		internal ak0 k()
		{
			return this.e;
		}

		// Token: 0x060038C7 RID: 14535 RVA: 0x001E9584 File Offset: 0x001E8584
		internal alm l()
		{
			return this.b;
		}

		// Token: 0x04001AF9 RID: 6905
		private new string a = null;

		// Token: 0x04001AFA RID: 6906
		private alm b = null;

		// Token: 0x04001AFB RID: 6907
		private ak3 c = null;

		// Token: 0x04001AFC RID: 6908
		private akw d = null;

		// Token: 0x04001AFD RID: 6909
		private ak0 e = null;

		// Token: 0x04001AFE RID: 6910
		private PageDimensions f = null;

		// Token: 0x04001AFF RID: 6911
		private PdfPage g = null;

		// Token: 0x04001B00 RID: 6912
		private int h = 1;

		// Token: 0x04001B01 RID: 6913
		private float i = 0f;

		// Token: 0x04001B02 RID: 6914
		private float j = 0f;

		// Token: 0x04001B03 RID: 6915
		private akq k = akq.c;

		// Token: 0x04001B04 RID: 6916
		private string l = null;
	}
}
