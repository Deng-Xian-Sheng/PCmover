using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200043F RID: 1087
	internal class acd
	{
		// Token: 0x06002CEE RID: 11502 RVA: 0x001992FC File Offset: 0x001982FC
		internal acd()
		{
		}

		// Token: 0x06002CEF RID: 11503 RVA: 0x00199308 File Offset: 0x00198308
		internal acd a()
		{
			return new acd
			{
				a = this.a,
				b = this.b,
				c = this.c,
				d = this.d,
				e = this.e,
				f = this.f,
				g = this.g,
				h = this.h,
				i = this.i,
				j = this.j,
				k = this.k
			};
		}

		// Token: 0x06002CF0 RID: 11504 RVA: 0x001993A5 File Offset: 0x001983A5
		internal void b(ab5 A_0)
		{
			this.a = this.a(A_0);
		}

		// Token: 0x06002CF1 RID: 11505 RVA: 0x001993B5 File Offset: 0x001983B5
		internal void c(ab5 A_0)
		{
			this.b = this.a(A_0);
			this.g = true;
		}

		// Token: 0x06002CF2 RID: 11506 RVA: 0x001993CC File Offset: 0x001983CC
		internal void d(ab5 A_0)
		{
			this.c = this.a(A_0);
			this.h = true;
		}

		// Token: 0x06002CF3 RID: 11507 RVA: 0x001993E3 File Offset: 0x001983E3
		internal void e(ab5 A_0)
		{
			this.d = this.a(A_0);
			this.i = true;
		}

		// Token: 0x06002CF4 RID: 11508 RVA: 0x001993FA File Offset: 0x001983FA
		internal void f(ab5 A_0)
		{
			this.e = this.a(A_0);
			this.j = true;
		}

		// Token: 0x06002CF5 RID: 11509 RVA: 0x00199411 File Offset: 0x00198411
		internal void g(ab5 A_0)
		{
			this.f = this.a(A_0);
			this.k = true;
		}

		// Token: 0x06002CF6 RID: 11510 RVA: 0x00199428 File Offset: 0x00198428
		internal Dimensions a(PageBoundary A_0)
		{
			switch (A_0)
			{
			case PageBoundary.CropBox:
				break;
			case PageBoundary.BleedBox:
				if (this.h)
				{
					return this.c;
				}
				break;
			case PageBoundary.TrimBox:
				if (this.i)
				{
					return this.d;
				}
				break;
			case PageBoundary.ArtBox:
				if (this.j)
				{
					return this.e;
				}
				break;
			default:
				goto IL_7D;
			}
			if (this.g)
			{
				return this.b;
			}
			IL_7D:
			return this.a;
		}

		// Token: 0x06002CF7 RID: 11511 RVA: 0x001994BC File Offset: 0x001984BC
		internal PageDimensions b()
		{
			if (!this.g)
			{
				this.b = this.a.a();
			}
			if (!this.i)
			{
				this.d = this.b.a();
			}
			if (!this.h)
			{
				this.c = this.b.a();
			}
			if (!this.j)
			{
				this.e = this.b.a();
			}
			if (!this.k)
			{
				this.f = this.e.a();
			}
			PageDimensions result;
			if (this.a.Left != 0f || this.a.Top != 0f || this.k || this.i || this.h || this.g)
			{
				result = new ExtendedPageDimensions(this.a, this.b, this.c, this.d, this.e, this.f);
			}
			else
			{
				result = new PageDimensions(this.a, this.e);
			}
			return result;
		}

		// Token: 0x06002CF8 RID: 11512 RVA: 0x001995EC File Offset: 0x001985EC
		private Dimensions a(ab5 A_0)
		{
			float left = A_0.c().ke();
			float top = A_0.d().ke();
			float right = A_0.e().ke();
			float bottom = A_0.f().ke();
			return new Dimensions(left, top, right, bottom);
		}

		// Token: 0x06002CF9 RID: 11513 RVA: 0x0019963C File Offset: 0x0019863C
		internal void c()
		{
			if (this.a == null)
			{
				this.a = new Dimensions(0f, 0f, 0f, 0f);
			}
			if (this.a.Width <= 0f)
			{
				this.a.Width = 612f;
			}
			if (this.a.Height <= 0f)
			{
				this.a.Height = 792f;
			}
		}

		// Token: 0x04001524 RID: 5412
		private Dimensions a;

		// Token: 0x04001525 RID: 5413
		private Dimensions b;

		// Token: 0x04001526 RID: 5414
		private Dimensions c;

		// Token: 0x04001527 RID: 5415
		private Dimensions d;

		// Token: 0x04001528 RID: 5416
		private Dimensions e;

		// Token: 0x04001529 RID: 5417
		private Dimensions f;

		// Token: 0x0400152A RID: 5418
		private bool g;

		// Token: 0x0400152B RID: 5419
		private bool h;

		// Token: 0x0400152C RID: 5420
		private bool i;

		// Token: 0x0400152D RID: 5421
		private bool j;

		// Token: 0x0400152E RID: 5422
		private bool k;
	}
}
