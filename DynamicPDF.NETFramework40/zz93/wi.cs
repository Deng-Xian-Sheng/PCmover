using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000359 RID: 857
	internal class wi : vt
	{
		// Token: 0x060024DC RID: 9436 RVA: 0x0015B3C8 File Offset: 0x0015A3C8
		internal wi()
		{
		}

		// Token: 0x060024DD RID: 9437 RVA: 0x0015B438 File Offset: 0x0015A438
		internal void a(wd A_0)
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
				if (num6 <= 354419580)
				{
					if (num6 <= 227335798)
					{
						if (num6 != 2660)
						{
							if (num6 != 224139107)
							{
								if (num6 != 227335798)
								{
									goto IL_25C;
								}
								rk rk = (rk)A_0.aw();
								if (rk != rk.a)
								{
									if (rk != rk.b)
									{
										if (rk != rk.c)
										{
										}
										this.l = rk.c;
									}
									else
									{
										this.l = rk.b;
									}
								}
								else
								{
									this.l = rk.a;
								}
							}
							else
							{
								left = A_0.ar();
							}
						}
						else
						{
							this.a = A_0.a8();
							A_0.a(this.a);
						}
					}
					else if (num6 <= 260660198)
					{
						if (num6 != 234053289)
						{
							if (num6 != 260660198)
							{
								goto IL_25C;
							}
							num = A_0.ar();
						}
						else
						{
							this.j = A_0.ar();
						}
					}
					else if (num6 != 322039639)
					{
						if (num6 != 354419580)
						{
							goto IL_25C;
						}
						num3 = A_0.ar();
					}
					else
					{
						this.k = A_0.ar();
					}
				}
				else if (num6 <= 807416959)
				{
					if (num6 <= 599705310)
					{
						if (num6 != 356812069)
						{
							if (num6 != 599705310)
							{
								goto IL_25C;
							}
							this.i = A_0.@as();
						}
						else
						{
							text = A_0.a6();
						}
					}
					else if (num6 != 603109653)
					{
						if (num6 != 807416959)
						{
							goto IL_25C;
						}
						num4 = A_0.ar();
					}
					else
					{
						orientation = A_0.ag();
					}
				}
				else if (num6 <= 852642834)
				{
					if (num6 != 814016502)
					{
						if (num6 != 852642834)
						{
							goto IL_25C;
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
						goto IL_25C;
					}
					num2 = A_0.ar();
				}
				else
				{
					top = A_0.ar();
				}
				continue;
				IL_25C:
				throw new DplxParseException("The report element contains an invalid attribute.");
			}
			A_0.aa();
			if (A_0.x() != 836132025)
			{
				throw new DplxParseException("The Report's query element was not found.");
			}
			this.g = vv.b(A_0);
			A_0.b(this.g.f());
			A_0.aa();
			if (A_0.x() == 882163977)
			{
				this.b = new wp(A_0);
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
				this.h = new PdfDocument(text).GetPage(pageNumber);
			}
			if (A_0.x() != 680925463)
			{
				throw new DplxParseException("The Report's header element was not found.");
			}
			this.c = new v1(A_0);
			A_0.aa();
			if (A_0.x() != 613894213)
			{
				throw new DplxParseException("The Report's detail element was not found.");
			}
			this.d = new vn(A_0);
			A_0.aa();
			if (A_0.x() != 650050839)
			{
				throw new DplxParseException("The Report's footer element was not found.");
			}
			this.e = new vx(A_0);
			A_0.aa();
		}

		// Token: 0x060024DE RID: 9438 RVA: 0x0015B861 File Offset: 0x0015A861
		internal override void f2(DocumentLayoutPartList A_0)
		{
			A_0.a(this);
		}

		// Token: 0x060024DF RID: 9439 RVA: 0x0015B86C File Offset: 0x0015A86C
		internal string a()
		{
			return this.a;
		}

		// Token: 0x060024E0 RID: 9440 RVA: 0x0015B884 File Offset: 0x0015A884
		internal PageDimensions b()
		{
			return this.f;
		}

		// Token: 0x060024E1 RID: 9441 RVA: 0x0015B89C File Offset: 0x0015A89C
		internal PdfPage c()
		{
			return this.h;
		}

		// Token: 0x060024E2 RID: 9442 RVA: 0x0015B8B4 File Offset: 0x0015A8B4
		internal vv d()
		{
			return this.g;
		}

		// Token: 0x060024E3 RID: 9443 RVA: 0x0015B8CC File Offset: 0x0015A8CC
		internal v1 e()
		{
			return this.c;
		}

		// Token: 0x060024E4 RID: 9444 RVA: 0x0015B8E4 File Offset: 0x0015A8E4
		internal vn f()
		{
			return this.d;
		}

		// Token: 0x060024E5 RID: 9445 RVA: 0x0015B8FC File Offset: 0x0015A8FC
		internal int g()
		{
			return this.i;
		}

		// Token: 0x060024E6 RID: 9446 RVA: 0x0015B914 File Offset: 0x0015A914
		internal x5 h()
		{
			return x5.a(this.j);
		}

		// Token: 0x060024E7 RID: 9447 RVA: 0x0015B934 File Offset: 0x0015A934
		internal x5 i()
		{
			return x5.a(this.k);
		}

		// Token: 0x060024E8 RID: 9448 RVA: 0x0015B954 File Offset: 0x0015A954
		internal rk j()
		{
			return this.l;
		}

		// Token: 0x060024E9 RID: 9449 RVA: 0x0015B96C File Offset: 0x0015A96C
		internal vx k()
		{
			return this.e;
		}

		// Token: 0x060024EA RID: 9450 RVA: 0x0015B984 File Offset: 0x0015A984
		internal wp l()
		{
			return this.b;
		}

		// Token: 0x04001008 RID: 4104
		private new string a = null;

		// Token: 0x04001009 RID: 4105
		private wp b = null;

		// Token: 0x0400100A RID: 4106
		private v1 c = null;

		// Token: 0x0400100B RID: 4107
		private vn d = null;

		// Token: 0x0400100C RID: 4108
		private vx e = null;

		// Token: 0x0400100D RID: 4109
		private PageDimensions f = null;

		// Token: 0x0400100E RID: 4110
		private vv g;

		// Token: 0x0400100F RID: 4111
		private PdfPage h = null;

		// Token: 0x04001010 RID: 4112
		private int i = 1;

		// Token: 0x04001011 RID: 4113
		private float j = 0f;

		// Token: 0x04001012 RID: 4114
		private float k = 0f;

		// Token: 0x04001013 RID: 4115
		private rk l = rk.c;
	}
}
