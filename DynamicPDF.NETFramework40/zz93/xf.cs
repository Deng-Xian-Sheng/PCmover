using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200037C RID: 892
	internal class xf
	{
		// Token: 0x060025EF RID: 9711 RVA: 0x00162543 File Offset: 0x00161543
		internal xf()
		{
		}

		// Token: 0x060025F0 RID: 9712 RVA: 0x00162558 File Offset: 0x00161558
		internal xx h()
		{
			return this.a;
		}

		// Token: 0x060025F1 RID: 9713 RVA: 0x00162570 File Offset: 0x00161570
		internal void a(xx A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060025F2 RID: 9714 RVA: 0x0016257C File Offset: 0x0016157C
		internal x2 i()
		{
			return this.c;
		}

		// Token: 0x060025F3 RID: 9715 RVA: 0x00162594 File Offset: 0x00161594
		internal void a(x2 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060025F4 RID: 9716 RVA: 0x001625A0 File Offset: 0x001615A0
		internal x2 j()
		{
			return this.d;
		}

		// Token: 0x060025F5 RID: 9717 RVA: 0x001625B8 File Offset: 0x001615B8
		internal void b(x2 A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060025F6 RID: 9718 RVA: 0x001625C4 File Offset: 0x001615C4
		internal x1 k()
		{
			return this.e;
		}

		// Token: 0x060025F7 RID: 9719 RVA: 0x001625DC File Offset: 0x001615DC
		internal void a(x1 A_0)
		{
			this.e = A_0;
		}

		// Token: 0x060025F8 RID: 9720 RVA: 0x001625E8 File Offset: 0x001615E8
		internal bool a(xc A_0)
		{
			bool result;
			if (this.c != null && this.c.b())
			{
				result = true;
			}
			else
			{
				if (A_0.e().e())
				{
					for (xx xx = this.a; xx != null; xx = xx.b())
					{
						if (xx.a().cb() == 239)
						{
							xs xs = (xs)xx.a();
							for (xg xg = xs.e().e(); xg != null; xg = xg.e())
							{
								if (xg.a(xs.f()))
								{
									return true;
								}
							}
						}
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x060025F9 RID: 9721 RVA: 0x001626C4 File Offset: 0x001616C4
		internal x5 a(xc A_0, x5 A_1)
		{
			x5 x = x5.b();
			if (this.c != null && this.c.b())
			{
				x = x5.f(this.c.c(), A_1);
			}
			if (A_0.e().e())
			{
				xx xx = this.a;
				x5 x2 = x5.b();
				x5 x3 = x5.b();
				xs xs = null;
				xg xg = null;
				while (xx != null)
				{
					if (xx.a().cb() == 239)
					{
						xs xs2 = (xs)xx.a();
						xg xg2 = xs2.e().e();
						x5 x4 = x5.a(xs2.f().Header.Height + xs2.f().Footer.Height);
						while (xg2 != null)
						{
							if (xg2.a(xs2.f()))
							{
								x3 = x5.f(x5.f(xg2.a(xs2.f(), xs2.b7()), x4), A_1);
								break;
							}
							x4 = x5.f(x4, xg2.d());
							xg2 = xg2.e();
						}
						if (x5.d(x3, x2))
						{
							x2 = x3;
							if (xg != null)
							{
								xg.i().d();
							}
							xg = xg2;
							xs = xs2;
						}
					}
					xx = xx.b();
				}
				if (x5.d(x2, x))
				{
					if (this.c != null && x5.g(x, x5.b()))
					{
						this.c.d();
					}
					xs.a(true);
					x = x2;
				}
				else if (xg != null)
				{
					xg.c.d();
				}
			}
			return x;
		}

		// Token: 0x060025FA RID: 9722 RVA: 0x001628CC File Offset: 0x001618CC
		internal void b(xx A_0)
		{
			if (this.a == null)
			{
				this.b = A_0;
				this.a = A_0;
			}
			else
			{
				xx xx = this.b;
				this.b = A_0;
				xx.a(A_0);
			}
			this.f++;
		}

		// Token: 0x060025FB RID: 9723 RVA: 0x00162924 File Offset: 0x00161924
		internal void a(PageElement A_0)
		{
			if (this.a == null)
			{
				this.a = (this.b = new xx(A_0));
			}
			else
			{
				this.b.a(this.b = new xx(A_0));
			}
			this.f++;
		}

		// Token: 0x060025FC RID: 9724 RVA: 0x00162988 File Offset: 0x00161988
		internal void a(PageWriter A_0)
		{
			for (xx xx = this.a; xx != null; xx = xx.b())
			{
				xx.a().Draw(A_0);
			}
		}

		// Token: 0x060025FD RID: 9725 RVA: 0x001629C0 File Offset: 0x001619C0
		internal virtual void f9(PageWriter A_0, x5 A_1, x5 A_2)
		{
			xx xx = this.h();
			A_0.SetDimensionsShift(x5.b(A_1), x5.b(A_2), A_0.Dimensions.Body.Width, A_0.Dimensions.Body.Height);
			while (xx != null)
			{
				xx.a().Draw(A_0);
				xx = xx.b();
			}
			A_0.ResetDimensions();
		}

		// Token: 0x060025FE RID: 9726 RVA: 0x00162A34 File Offset: 0x00161A34
		internal virtual void ga(PageWriter A_0, x5 A_1)
		{
			xx xx = this.h();
			A_0.SetDimensionsShift(0f, x5.b(A_1), A_0.Dimensions.Body.Width, A_0.Dimensions.Body.Height);
			while (xx != null)
			{
				xx.a().Draw(A_0);
				xx = xx.b();
			}
			A_0.ResetDimensions();
		}

		// Token: 0x060025FF RID: 9727 RVA: 0x00162AA8 File Offset: 0x00161AA8
		internal virtual void gb(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3)
		{
			xx xx = this.h();
			A_0.SetDimensionsShift(x5.b(A_1), x5.b(A_2), x5.b(A_3), A_0.Dimensions.Body.Height);
			while (xx != null)
			{
				xx.a().Draw(A_0);
				xx = xx.b();
			}
			A_0.ResetDimensions();
		}

		// Token: 0x0400109B RID: 4251
		private xx a;

		// Token: 0x0400109C RID: 4252
		private xx b;

		// Token: 0x0400109D RID: 4253
		private x2 c;

		// Token: 0x0400109E RID: 4254
		private x2 d;

		// Token: 0x0400109F RID: 4255
		private x1 e;

		// Token: 0x040010A0 RID: 4256
		private int f = 0;
	}
}
