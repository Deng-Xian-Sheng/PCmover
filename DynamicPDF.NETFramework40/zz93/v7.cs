using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x0200034E RID: 846
	internal class v7 : vt
	{
		// Token: 0x0600240E RID: 9230 RVA: 0x0015417C File Offset: 0x0015317C
		internal v7()
		{
		}

		// Token: 0x0600240F RID: 9231 RVA: 0x0015419C File Offset: 0x0015319C
		internal void b(wd A_0)
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
								goto IL_163;
							}
							left = A_0.ar();
						}
						else
						{
							this.a = A_0.a8();
							A_0.a(this.a);
						}
					}
					else if (num6 != 260660198)
					{
						if (num6 != 354419580)
						{
							if (num6 != 356812069)
							{
								goto IL_163;
							}
							text = A_0.a6();
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
								goto IL_163;
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
							goto IL_163;
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
				IL_163:
				throw new DplxParseException("A page contains an invalid attribute.");
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
				this.e = new PdfDocument(text).GetPage(pageNumber);
			}
			A_0.aa();
			if (A_0.x() == 836132025)
			{
				this.d = vv.b(A_0);
				A_0.b(this.d.f());
				A_0.aa();
			}
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

		// Token: 0x06002410 RID: 9232 RVA: 0x00154474 File Offset: 0x00153474
		internal wj a()
		{
			return this.b;
		}

		// Token: 0x06002411 RID: 9233 RVA: 0x0015448C File Offset: 0x0015348C
		private void a(wd A_0)
		{
			A_0.a(false);
			this.b = new wj();
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
								throw new DplxParseException("A contentGroup element cannot be placed on a page.");
							}
							if (num != 378606227)
							{
								goto IL_1E0;
							}
							this.b.a(new we(A_0));
						}
						else
						{
							this.b.a(new v5(A_0));
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
							this.b.a(new v4(A_0));
						}
						else
						{
							this.b.a(new v3(A_0));
						}
					}
					else
					{
						this.b.a(new wc(A_0));
					}
				}
				else if (num <= 839258122)
				{
					if (num != 747113073)
					{
						if (num == 810295593)
						{
							throw new DplxParseException("A pageBreak element cannot be placed on a page.");
						}
						if (num != 839258122)
						{
							goto IL_1E0;
						}
						this.b.a(new wf(A_0));
					}
					else
					{
						this.b.a(new v9(A_0));
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
						throw new DplxParseException("A subReport element cannot be placed on a page.");
					}
					else
					{
						this.b.a(new wg(A_0, 1050867191));
					}
				}
				else if (num != 870766723)
				{
					if (num != 937732022)
					{
						goto IL_1E0;
					}
					this.b.a(new vz(A_0));
				}
				else
				{
					this.b.a(new wo(A_0));
				}
				A_0.aa();
				continue;
				IL_1E0:
				throw new DplxParseException("Invalid report element.");
			}
			A_0.a(true);
		}

		// Token: 0x06002412 RID: 9234 RVA: 0x001546A4 File Offset: 0x001536A4
		internal string b()
		{
			return this.a;
		}

		// Token: 0x06002413 RID: 9235 RVA: 0x001546BC File Offset: 0x001536BC
		internal PageDimensions c()
		{
			return this.c;
		}

		// Token: 0x06002414 RID: 9236 RVA: 0x001546D4 File Offset: 0x001536D4
		internal PdfPage d()
		{
			return this.e;
		}

		// Token: 0x06002415 RID: 9237 RVA: 0x001546EC File Offset: 0x001536EC
		internal vv e()
		{
			return this.d;
		}

		// Token: 0x06002416 RID: 9238 RVA: 0x00154704 File Offset: 0x00153704
		internal override void f2(DocumentLayoutPartList A_0)
		{
			A_0.a(this);
		}

		// Token: 0x04000F9E RID: 3998
		private new string a;

		// Token: 0x04000F9F RID: 3999
		private wj b = null;

		// Token: 0x04000FA0 RID: 4000
		private PageDimensions c = null;

		// Token: 0x04000FA1 RID: 4001
		private vv d;

		// Token: 0x04000FA2 RID: 4002
		private PdfPage e = null;
	}
}
