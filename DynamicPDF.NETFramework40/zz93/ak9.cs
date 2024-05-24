using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000588 RID: 1416
	internal class ak9 : aky
	{
		// Token: 0x06003801 RID: 14337 RVA: 0x001E28A0 File Offset: 0x001E18A0
		internal ak9()
		{
		}

		// Token: 0x06003802 RID: 14338 RVA: 0x001E28C0 File Offset: 0x001E18C0
		internal void b(ald A_0)
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
					if (num6 <= 224139107)
					{
						if (num6 != 2660)
						{
							if (num6 != 224139107)
							{
								goto IL_158;
							}
							left = A_0.ar();
						}
						else
						{
							this.a = A_0.a7();
							A_0.a(null);
						}
					}
					else if (num6 != 260660198)
					{
						if (num6 != 354419580)
						{
							if (num6 != 356812069)
							{
								goto IL_158;
							}
							text = A_0.a5();
						}
						else
						{
							num3 = A_0.ar();
						}
					}
					else
					{
						num = A_0.ar();
					}
				}
				else if (num6 <= 814016502)
				{
					if (num6 != 603109653)
					{
						if (num6 != 807416959)
						{
							if (num6 != 814016502)
							{
								goto IL_158;
							}
							num5 = A_0.aw();
						}
						else
						{
							num4 = A_0.ar();
						}
					}
					else
					{
						orientation = A_0.ag();
					}
				}
				else if (num6 != 852642834)
				{
					if (num6 != 880113935)
					{
						if (num6 != 1059148787)
						{
							goto IL_158;
						}
						num2 = A_0.ar();
					}
					else
					{
						top = A_0.ar();
					}
				}
				else
				{
					pageNumber = A_0.@as();
				}
				continue;
				IL_158:
				throw new DlexParseException("A page contains an invalid attribute.");
			}
			if (num5 == 601308418)
			{
				Dimensions dimensions = new Dimensions(num4, num3);
				Dimensions marginDimensions = new Dimensions(left, top, num4 - num2, num3 - num);
				this.c = new PageDimensions(dimensions, marginDimensions);
			}
			else
			{
				Dimensions dimensions = new Dimensions(base.a(num5), orientation);
				Dimensions marginDimensions = new Dimensions(left, top, dimensions.Right - num2, dimensions.Bottom - num);
				this.c = new PageDimensions(dimensions, marginDimensions);
			}
			if (text != null)
			{
				this.d = new PdfDocument(text).GetPage(pageNumber);
			}
			A_0.aa();
			if (!A_0.z() && A_0.x() != 848759750 && A_0.x() != 12720613)
			{
				this.a(A_0);
				A_0.aa();
				A_0.aa();
			}
			else if (A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x06003803 RID: 14339 RVA: 0x001E2B50 File Offset: 0x001E1B50
		internal ali a()
		{
			return this.b;
		}

		// Token: 0x06003804 RID: 14340 RVA: 0x001E2B68 File Offset: 0x001E1B68
		private void a(ald A_0)
		{
			A_0.a(false);
			this.b = new ali();
			while (!A_0.z())
			{
				int num = A_0.x();
				if (num <= 746989932)
				{
					if (num <= 378606227)
					{
						if (num != 11705253)
						{
							if (num == 225352954)
							{
								throw new DlexParseException("A contentGroup element cannot be placed on a page.");
							}
							if (num != 378606227)
							{
								goto IL_1E0;
							}
							this.b.a(new ale(A_0));
						}
						else
						{
							this.b.a(new ak7(A_0));
						}
					}
					else if (num != 403493362)
					{
						if (num != 699800037)
						{
							if (num != 746989932)
							{
								goto IL_1E0;
							}
							this.b.a(new ak6(A_0));
						}
						else
						{
							this.b.a(new ak5(A_0));
						}
					}
					else
					{
						this.b.a(new alc(A_0));
					}
				}
				else if (num <= 839258122)
				{
					if (num != 747113073)
					{
						if (num == 810295593)
						{
							throw new DlexParseException("A pageBreak element cannot be placed on a page.");
						}
						if (num != 839258122)
						{
							goto IL_1E0;
						}
						this.b.a(new alf(A_0));
					}
					else
					{
						this.b.a(new alb(A_0));
					}
				}
				else if (num <= 857004049)
				{
					if (num != 841762308)
					{
						if (num != 857004049)
						{
							goto IL_1E0;
						}
						throw new DlexParseException("A subReport element cannot be placed on a page.");
					}
					else
					{
						this.b.a(new alg(A_0, 1050867191));
					}
				}
				else if (num != 870766723)
				{
					if (num != 937732022)
					{
						goto IL_1E0;
					}
					this.b.a(new ak2(A_0));
				}
				else
				{
					this.b.a(new all(A_0));
				}
				A_0.aa();
				continue;
				IL_1E0:
				throw new DlexParseException("Invalid report element.");
			}
			A_0.a(true);
		}

		// Token: 0x06003805 RID: 14341 RVA: 0x001E2D80 File Offset: 0x001E1D80
		internal string b()
		{
			return this.a;
		}

		// Token: 0x06003806 RID: 14342 RVA: 0x001E2D98 File Offset: 0x001E1D98
		internal PageDimensions c()
		{
			return this.c;
		}

		// Token: 0x06003807 RID: 14343 RVA: 0x001E2DB0 File Offset: 0x001E1DB0
		internal PdfPage d()
		{
			return this.d;
		}

		// Token: 0x06003808 RID: 14344 RVA: 0x001E2DC8 File Offset: 0x001E1DC8
		internal override void my(DocumentLayoutPartList A_0)
		{
			A_0.a(this);
		}

		// Token: 0x04001A9E RID: 6814
		private new string a;

		// Token: 0x04001A9F RID: 6815
		private ali b = null;

		// Token: 0x04001AA0 RID: 6816
		private PageDimensions c = null;

		// Token: 0x04001AA1 RID: 6817
		private PdfPage d = null;
	}
}
