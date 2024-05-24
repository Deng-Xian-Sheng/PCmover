using System;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001E1 RID: 481
	internal class mf
	{
		// Token: 0x060014A2 RID: 5282 RVA: 0x000E6224 File Offset: 0x000E5224
		internal mf(ImageData A_0, byte[] A_1)
		{
			this.b = A_0;
			if ((long)this.b.Width <= 5L || (long)this.b.Height <= 5L)
			{
				this.c = A_1;
			}
		}

		// Token: 0x060014A3 RID: 5283 RVA: 0x000E6290 File Offset: 0x000E5290
		internal ImageData b()
		{
			return this.b;
		}

		// Token: 0x060014A4 RID: 5284 RVA: 0x000E62A8 File Offset: 0x000E52A8
		internal bool c()
		{
			return this.j;
		}

		// Token: 0x060014A5 RID: 5285 RVA: 0x000E62C0 File Offset: 0x000E52C0
		internal void a(bool A_0)
		{
			this.j = A_0;
		}

		// Token: 0x060014A6 RID: 5286 RVA: 0x000E62CC File Offset: 0x000E52CC
		internal bool d()
		{
			return this.i;
		}

		// Token: 0x060014A7 RID: 5287 RVA: 0x000E62E4 File Offset: 0x000E52E4
		internal void b(bool A_0)
		{
			this.i = A_0;
		}

		// Token: 0x060014A8 RID: 5288 RVA: 0x000E62F0 File Offset: 0x000E52F0
		internal void a(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4, x5 A_5, x5 A_6)
		{
			x5 x = A_1;
			x5 a_ = A_2;
			x5 a_2 = x5.c();
			x5 x2 = x5.c();
			x5 a_3 = x5.c();
			x5 a_4 = x5.c();
			x5 a_5 = x5.a((float)this.b.Width * 0.75f);
			x5 a_6 = x5.a((float)this.b.Height * 0.75f);
			x5 x3 = A_3;
			x5 x4 = A_4;
			while (x5.d(x2, A_6))
			{
				x4 = x5.f(x4, a_4);
				x5 x5;
				a_3 = (a_2 = (x5 = this.b(a_5, x, x5.e(A_5, a_3))));
				x5 a_7 = a_4 = this.a(a_6, a_, x5.e(A_6, x2));
				nm a_8 = this.a(x, a_, x5, a_7);
				mf.a(A_0, a_8, x3, x4);
				x = x5.c();
				x3 = x5.f(x3, a_3);
				while (x5.d(a_2, A_5))
				{
					x5 = this.b(a_5, x, x5.e(A_5, a_3));
					a_8 = this.a(x, a_, x5, a_7);
					mf.a(A_0, a_8, x3, x4);
					a_3 = x5;
					x3 = x5.f(x3, a_3);
					a_2 = x5.f(a_2, a_3);
				}
				x2 = x5.f(x2, a_4);
				x3 = A_3;
				a_3 = x5.c();
				x = A_1;
				a_ = x5.c();
			}
		}

		// Token: 0x060014A9 RID: 5289 RVA: 0x000E644C File Offset: 0x000E544C
		internal void a(lk A_0, OperatorWriter A_1, x5 A_2, x5 A_3, x5 A_4, x5 A_5)
		{
			this.d = A_0;
			if (x5.g(A_4, x5.c()) && x5.g(A_5, x5.c()))
			{
				if (this.c())
				{
					this.l(A_1, A_2, A_3, A_4, A_5);
				}
				else
				{
					this.d(A_1, A_2, A_3, A_4, A_5);
				}
			}
		}

		// Token: 0x060014AA RID: 5290 RVA: 0x000E64B8 File Offset: 0x000E54B8
		private static void a(OperatorWriter A_0, nm A_1, x5 A_2, x5 A_3)
		{
			float num = (float)A_1.a().Width * 0.75f;
			float num2 = (float)A_1.a().Height * 0.75f;
			float pdfX = A_0.Dimensions.GetPdfX(x5.b(x5.e(A_2, A_1.b())));
			float pdfY = A_0.Dimensions.GetPdfY(x5.b(x5.e(A_3, A_1.c())));
			A_0.Write_q_(false);
			A_0.a(pdfX + x5.b(A_1.b()), pdfY - x5.b(A_1.c()) - x5.b(A_1.e()), x5.b(A_1.d()), x5.b(A_1.e()));
			A_0.Write_cm(num, 0f, 0f, num2, pdfX, pdfY - num2);
			A_0.Write_Do(A_1.a());
			A_0.Write_Q(false);
		}

		// Token: 0x060014AB RID: 5291 RVA: 0x000E65A8 File Offset: 0x000E55A8
		private void a(OperatorWriter A_0, x5 A_1, ref nm A_2, x5 A_3, x5 A_4, x5 A_5, x5 A_6, ref x5 A_7, x5 A_8, ref x5 A_9, bool A_10, ref x5 A_11)
		{
			int num = 0;
			while (x5.g(A_5, x5.c()))
			{
				if (num != 0 || !A_10)
				{
					A_6 = x5.f(A_6, A_3);
				}
				num++;
				A_3 = x5.f(A_3, A_1);
				if (x5.c(A_3, A_1))
				{
					A_3 = A_1;
				}
				A_3 = x5.e(A_1, A_8);
				if (x5.c(A_3, A_5))
				{
					A_3 = A_5;
				}
				A_2 = this.a(A_8, A_9, A_3, A_4);
				if (A_2 != null)
				{
					mf.a(A_0, A_2, A_6, A_7);
				}
				A_8 = x5.f(A_8, A_3);
				if (x5.a(A_8, A_1))
				{
					A_8 = x5.c();
				}
				A_5 = x5.e(A_5, A_3);
				A_11 = A_3;
			}
		}

		// Token: 0x060014AC RID: 5292 RVA: 0x000E6690 File Offset: 0x000E5690
		private void l(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			if (this.b != null)
			{
				A_0.SetGraphicsMode();
				this.a();
				switch (this.d.ay().f())
				{
				case gl.a:
					if ((long)this.b.Width <= 5L || (long)this.b.Height <= 5L)
					{
						this.a(true, true);
					}
					this.j(A_0, A_1, A_2, A_3, A_4);
					break;
				case gl.b:
					if ((long)this.b.Width <= 5L)
					{
						this.a(true, false);
					}
					this.h(A_0, A_1, A_2, A_3, A_4);
					break;
				case gl.c:
					if ((long)this.b.Height <= 5L)
					{
						this.a(false, true);
					}
					this.f(A_0, A_1, A_2, A_3, A_4);
					break;
				case gl.d:
					this.e(A_0, A_1, A_2, A_3, A_4);
					break;
				default:
					if ((long)this.b.Width <= 5L || (long)this.b.Height <= 5L)
					{
						this.a(true, true);
					}
					this.j(A_0, A_1, A_2, A_3, A_4);
					break;
				}
			}
		}

		// Token: 0x060014AD RID: 5293 RVA: 0x000E67E4 File Offset: 0x000E57E4
		private void a(bool A_0, bool A_1)
		{
			if (!this.k)
			{
				this.k = true;
			}
		}

		// Token: 0x060014AE RID: 5294 RVA: 0x000E6808 File Offset: 0x000E5808
		private x5 b(x5 A_0, x5 A_1, x5 A_2)
		{
			x5 x = x5.e(A_0, A_1);
			if (x5.c(x, A_2))
			{
				x = A_2;
			}
			return x;
		}

		// Token: 0x060014AF RID: 5295 RVA: 0x000E6834 File Offset: 0x000E5834
		private x5 a(x5 A_0, x5 A_1, x5 A_2)
		{
			x5 x = x5.e(A_0, A_1);
			if (x5.c(x, A_2))
			{
				x = A_2;
			}
			return x;
		}

		// Token: 0x060014B0 RID: 5296 RVA: 0x000E6860 File Offset: 0x000E5860
		private void a()
		{
			switch (this.d.ay().h())
			{
			case fr.a:
				this.d.ay().a(x5.a(0f));
				this.d.ay().b(x5.a(0f));
				break;
			case fr.b:
				this.d.ay().a(x5.a(50f));
				this.d.ay().b(x5.a(0f));
				break;
			case fr.c:
				this.d.ay().a(x5.a(100f));
				this.d.ay().b(x5.a(0f));
				break;
			case fr.d:
				this.d.ay().a(x5.a(0f));
				this.d.ay().b(x5.a(50f));
				break;
			case fr.e:
				this.d.ay().a(x5.a(50f));
				this.d.ay().b(x5.a(50f));
				break;
			case fr.f:
				this.d.ay().a(x5.a(100f));
				this.d.ay().b(x5.a(50f));
				break;
			case fr.g:
				this.d.ay().a(x5.a(0f));
				this.d.ay().b(x5.a(100f));
				break;
			case fr.h:
				this.d.ay().a(x5.a(50f));
				this.d.ay().b(x5.a(100f));
				break;
			case fr.i:
				this.d.ay().a(x5.a(100f));
				this.d.ay().b(x5.a(100f));
				break;
			}
			this.d.ay().a(fr.j);
			if (this.d.ay().i().b() == i2.a)
			{
				this.d.ay().i().a(i2.b);
			}
			if (this.d.ay().i().d() == i2.a)
			{
				this.d.ay().i().b(i2.b);
			}
		}

		// Token: 0x060014B1 RID: 5297 RVA: 0x000E6B48 File Offset: 0x000E5B48
		private void a(ref x5 A_0, ref x5 A_1, i2 A_2, i2 A_3, x5 A_4, x5 A_5)
		{
			if (A_2 == i2.b)
			{
				A_0 = x5.a(x5.b(x5.a(this.d.ay().i().a(), 100)) * x5.b(A_4));
			}
			if (A_3 == i2.b)
			{
				A_1 = x5.a(x5.b(x5.a(this.d.ay().i().c(), 100)) * x5.b(A_5));
			}
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x000E6BE0 File Offset: 0x000E5BE0
		private void a(ref x5 A_0, ref x5 A_1, ref x5 A_2, ref x5 A_3, ref x5 A_4, i2 A_5)
		{
			if (A_5 == i2.b)
			{
				x5 a_;
				if (x5.d(A_2, x5.c()))
				{
					a_ = x5.e(x5.e(x5.a(100f), A_2), x5.a(100f));
				}
				else
				{
					a_ = A_2;
				}
				A_3 = x5.a(x5.a(x5.b(A_0) * x5.b(a_)), 100);
				A_4 = x5.a(x5.a(x5.b(A_1) * x5.b(a_)), 100);
				if (x5.a(A_3, A_4))
				{
					while (x5.d(A_4, A_3))
					{
						A_4 = x5.f(A_4, A_1);
					}
					A_4 = x5.e(A_4, A_3);
				}
				else
				{
					A_4 = x5.e(A_4, A_3);
				}
			}
			else if (x5.d(A_3, x5.c()))
			{
				A_3 = x5.d(A_3);
				while (x5.c(A_3, A_1))
				{
					A_3 = x5.e(A_3, A_1);
				}
				A_4 = A_3;
			}
			else
			{
				while (x5.c(A_3, A_1))
				{
					A_3 = x5.e(A_3, A_1);
				}
				A_4 = x5.e(A_1, A_3);
			}
		}

		// Token: 0x060014B3 RID: 5299 RVA: 0x000E6DD8 File Offset: 0x000E5DD8
		private void k(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			x5 a_ = x5.a((float)this.b.Width * 0.75f);
			x5 a_2 = x5.a((float)this.b.Height * 0.75f);
			x5 x = this.d.ay().k();
			x5 x2 = this.d.ay().j();
			x5 a_3 = x5.c();
			x5 a_4 = x5.c();
			if (!this.i)
			{
				this.h = A_3;
				this.a(ref A_3, ref a_, ref x2, ref x2, ref a_3, this.d.ay().i().b());
				this.a(ref A_4, ref a_2, ref x, ref x, ref a_4, this.d.ay().i().d());
				if (!this.j)
				{
					this.i = true;
				}
				this.a(A_0, a_3, a_4, A_1, A_2, A_3, A_4);
			}
			else
			{
				a_3 = this.f;
				a_4 = this.g;
			}
			if (!this.j)
			{
				A_3 = this.e;
			}
			if (!this.c())
			{
				this.f = a_3;
				this.g = a_4;
				if (x5.a(this.f, a_))
				{
					this.f = x5.e(this.f, a_);
				}
				if (x5.a(this.g, a_2))
				{
					this.g = x5.e(this.g, a_2);
				}
			}
			this.h = x5.e(this.h, this.e);
			if (x5.b(this.h, x5.a(0.01)))
			{
				this.i = false;
			}
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x000E6FAC File Offset: 0x000E5FAC
		private void j(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			fr fr = this.d.ay().h();
			if (fr == fr.j)
			{
				this.k(A_0, A_1, A_2, A_3, A_4);
			}
		}

		// Token: 0x060014B5 RID: 5301 RVA: 0x000E6FE4 File Offset: 0x000E5FE4
		private void i(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			x5 x = x5.a((float)this.b.Width * 0.75f);
			x5 x2 = x5.a((float)this.b.Height * 0.75f);
			x5 a_ = x;
			x5 x3 = x2;
			x5 x4 = x5.c();
			x5 x5 = x5.c();
			x5 x6 = this.d.ay().k();
			x5 x7 = this.d.ay().j();
			bool flag = true;
			if (!this.i)
			{
				this.h = A_3;
				if (this.d.ay().i().d() == i2.b)
				{
					if (x5.b(x6, x5.c()))
					{
						x6 = x5.f(x5.a(100f), x6);
					}
					x6 = x5.a(x5.a(x5.b(A_4) * x5.b(this.d.ay().k())), 100);
					x5 = x5.a(x5.a(x5.b(x3) * x5.b(this.d.ay().k())), 100);
					if (x5.a(x6, x5))
					{
						x6 = x5.e(x6, x5);
						x5 = x5.c();
					}
					else
					{
						x6 = x5.e(x5, x6);
					}
				}
				if (x5.a(x6, x5))
				{
					x6 = x5.e(x6, x5);
					x5 = x5.c();
					A_2 = x5.f(A_2, x6);
				}
				else
				{
					if (x5.d(x6, x5.c()))
					{
						x6 = x5.f(x6, x2);
					}
					if (x5.d(x6, x5.c()))
					{
						flag = false;
					}
					else if (x5.c(x6, x5.c()))
					{
						x5 = x5.e(x2, x6);
					}
					else
					{
						x5 = x6;
					}
				}
				if (flag)
				{
					if (this.d.ay().i().b() == i2.b)
					{
						x7 = x5.a(x5.a(x5.b(A_3) * x5.b(this.d.ay().j())), 100);
						x4 = x5.a(x5.a(x5.b(a_) * x5.b(this.d.ay().j())), 100);
						if (x5.a(x7, x4))
						{
							x7 = x5.e(x7, x4);
							x4 = x5.c();
						}
						else
						{
							x7 = x5.e(x4, x7);
						}
					}
					if (x5.a(x7, x4))
					{
						while (x5.d(x4, x7))
						{
							x4 = x5.f(x4, x);
						}
						x4 = x5.e(x4, x7);
					}
					else
					{
						while (x5.d(x7, x5.c()))
						{
							x7 = x5.f(x7, x);
						}
						x4 = x5.e(x, x7);
					}
				}
				this.i = true;
			}
			else
			{
				x4 = this.f;
				x5 = this.g;
			}
			if (flag)
			{
				if (x5.c(x3, A_4))
				{
					x3 = A_4;
					a_ = x5.e(a_, x4);
				}
				else
				{
					a_ = x5.e(a_, x4);
					x3 = x5.e(x3, x5);
					if (x5.c(x3, x5.e(A_4, x6)))
					{
						x3 = x5.e(A_4, x6);
					}
				}
			}
			if (!this.j)
			{
				A_3 = this.e;
			}
			if (flag)
			{
				this.a(A_0, x4, x5, A_1, A_2, A_3, x3);
			}
			if (!this.c())
			{
				this.f = x4;
				this.g = x5;
				if (x5.a(this.f, x))
				{
					this.f = x5.e(this.f, x);
				}
				if (x5.a(this.g, x2))
				{
					this.g = x5.e(this.g, x2);
				}
			}
			this.h = x5.e(this.h, this.e);
			if (x5.b(this.h, x5.a(0.01)))
			{
				this.i = false;
			}
		}

		// Token: 0x060014B6 RID: 5302 RVA: 0x000E747C File Offset: 0x000E647C
		private void h(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			switch (this.d.ay().h())
			{
			case fr.j:
			case fr.k:
				this.i(A_0, A_1, A_2, A_3, A_4);
				break;
			}
		}

		// Token: 0x060014B7 RID: 5303 RVA: 0x000E74C0 File Offset: 0x000E64C0
		private void g(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			x5 x = x5.a((float)this.b.Width * 0.75f);
			x5 x2 = x5.a((float)this.b.Height * 0.75f);
			x5 x3 = x;
			x5 a_ = x2;
			x5 x4 = x5.c();
			x5 x5 = x5.c();
			x5 x6 = this.d.ay().k();
			x5 x7 = this.d.ay().j();
			bool flag = true;
			if (!this.i)
			{
				if (this.d.ay().i().b() == i2.b)
				{
					x7 = x5.a(x5.a(x5.b(A_3) * x5.b(this.d.ay().j())), 100);
					x4 = x5.a(x5.a(x5.b(x3) * x5.b(this.d.ay().j())), 100);
					if (x5.a(x7, x4))
					{
						x7 = x5.e(x7, x4);
						x4 = x5.c();
					}
					else
					{
						x7 = x5.e(x4, x7);
					}
				}
				if (x5.a(x7, x4))
				{
					x7 = x5.e(x7, x4);
					x4 = x5.c();
					A_1 = x5.f(A_1, x7);
				}
				else
				{
					if (x5.d(x7, x5.c()))
					{
						x7 = x5.f(x7, x);
					}
					if (x5.d(x7, x5.c()))
					{
						flag = false;
					}
					else if (x5.c(x7, x5.c()))
					{
						x4 = x5.e(x, x7);
					}
					else
					{
						x4 = x7;
					}
				}
				if (flag)
				{
					if (this.d.ay().i().d() == i2.b)
					{
						x6 = x5.a(x5.a(x5.b(A_4) * x5.b(this.d.ay().k())), 100);
						x5 = x5.a(x5.a(x5.b(a_) * x5.b(this.d.ay().k())), 100);
						if (x5.a(x6, x5))
						{
							x6 = x5.e(x6, x5);
							x5 = x5.c();
						}
						else
						{
							x6 = x5.e(x5, x6);
						}
					}
					if (x5.a(x6, x5))
					{
						while (x5.d(x5, x6))
						{
							x5 = x5.f(x5, x2);
						}
						x5 = x5.e(x5, x6);
					}
					else
					{
						while (x5.d(x6, x5.c()))
						{
							x6 = x5.f(x6, x2);
						}
						x5 = x5.e(x2, x6);
					}
				}
				if (flag)
				{
					if (x5.c(x3, A_3))
					{
						x3 = A_3;
					}
					else
					{
						x3 = x5.e(x3, x4);
					}
					if (!x5.c(a_, A_4))
					{
						a_ = x5.e(a_, x5);
					}
				}
				this.i = true;
			}
			else
			{
				x4 = this.f;
				x5 = this.g;
			}
			if (flag)
			{
				this.a(A_0, x4, x5, A_1, A_2, x3, A_4);
			}
		}

		// Token: 0x060014B8 RID: 5304 RVA: 0x000E7850 File Offset: 0x000E6850
		private void f(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			fr fr = this.d.ay().h();
			if (fr == fr.j)
			{
				this.g(A_0, A_1, A_2, A_3, A_4);
			}
		}

		// Token: 0x060014B9 RID: 5305 RVA: 0x000E7888 File Offset: 0x000E6888
		private void e(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			x5 x = x5.a((float)this.b.Width * 0.75f);
			x5 x2 = x5.a((float)this.b.Height * 0.75f);
			nm nm = this.a(x5.c(), x5.c(), x, x2);
			x5 x3 = x5.c();
			x5 x4 = x5.c();
			fr fr = this.d.ay().h();
			if (fr != fr.j)
			{
				if (x5.c(x2, A_4) || x5.c(x, A_3))
				{
					x5 x5;
					if (x5.c(x, A_3))
					{
						x5 = A_3;
					}
					else
					{
						x5 = x;
					}
					if (x5.c(x2, A_4))
					{
					}
					if (x5.c(x5, x5.a(1f)) && x5.c(A_4, x5.a(1f)))
					{
						nm = this.a(x5.c(), x5.c(), x5, A_4);
					}
				}
			}
			else
			{
				x5 x6 = x5.c();
				x5 a_ = x5.c();
				x5 a_2 = x5.c();
				x5 a_3 = x5.c();
				x4 = this.d.ay().k();
				x3 = this.d.ay().j();
				x5 x5 = x;
				x5 x7 = x2;
				this.a(ref a_2, ref a_3, this.d.ay().i().b(), this.d.ay().i().d(), A_3, A_4);
				this.a(ref x6, ref a_, this.d.ay().i().b(), this.d.ay().i().d(), x, x2);
				if (this.d.ay().i().d() == i2.b)
				{
					x4 = x5.e(a_3, a_);
				}
				if (this.d.ay().i().b() == i2.b)
				{
					x3 = x5.e(a_2, x6);
				}
				if (x5.b(x3, A_3))
				{
					if (x5.d(x3, x5.c()))
					{
						x5 = x5.f(x3, x);
						x6 = x5.e(x, x5);
						if (x5.c(x5, A_3))
						{
							x5 = A_3;
						}
					}
					else
					{
						A_1 = x5.f(A_1, x3);
						x5 = x5.e(A_3, x3);
						if (x5.c(x5, x))
						{
							x5 = x;
						}
						x6 = x5.c();
					}
				}
				if (x5.b(x4, A_4))
				{
					if (x5.d(x4, x5.c()))
					{
						x7 = x5.f(x4, x2);
						a_ = x5.e(x2, x7);
						if (x5.c(x7, A_4))
						{
							x7 = A_4;
						}
					}
					else
					{
						A_2 = x5.f(A_2, x4);
						x7 = x5.e(A_4, x4);
						if (x5.c(x7, x2))
						{
							x7 = x2;
						}
						a_ = x5.c();
					}
				}
				nm = this.a(x6, a_, x5, x7);
			}
			if (nm != null)
			{
				mf.a(A_0, nm, A_1, A_2);
			}
		}

		// Token: 0x060014BA RID: 5306 RVA: 0x000E7BEC File Offset: 0x000E6BEC
		private void d(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			if (this.b != null)
			{
				A_0.SetGraphicsMode();
				this.a();
				switch (this.d.ay().f())
				{
				case gl.a:
					this.c(A_0, A_1, A_2, A_3, A_4);
					break;
				case gl.b:
					this.h(A_0, A_1, A_2, A_3, A_4);
					break;
				case gl.c:
					this.f(A_0, A_1, A_2, A_3, A_4);
					break;
				case gl.d:
					this.e(A_0, A_1, A_2, A_3, A_4);
					break;
				default:
					this.j(A_0, A_1, A_2, A_3, A_4);
					break;
				}
			}
		}

		// Token: 0x060014BB RID: 5307 RVA: 0x000E7C94 File Offset: 0x000E6C94
		private void c(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			fr fr = this.d.ay().h();
			if (fr == fr.j)
			{
				this.b(A_0, A_1, A_2, A_3, A_4);
			}
		}

		// Token: 0x060014BC RID: 5308 RVA: 0x000E7CCC File Offset: 0x000E6CCC
		private void b(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			x5 x = x5.a((float)this.b.Width * 0.75f);
			x5 x2 = x5.a((float)this.b.Height * 0.75f);
			x5 x3 = this.d.ay().k();
			x5 x4 = this.d.ay().j();
			x5 a_ = A_4;
			x5 a_2 = A_3;
			if (!this.i)
			{
				this.h = A_3;
				this.a(ref a_, ref a_2, this.d.ay().i().b(), this.d.ay().i().d(), A_3, A_4);
				this.a(ref x4, ref x3, this.d.ay().i().b(), this.d.ay().i().d(), x, x2);
				if (x5.c(A_3, x))
				{
					x5 x5 = x4;
					x5 x6 = x3;
					while (x5.d(x5, a_))
					{
						x5 = x5.f(x5, x);
					}
					x5 = x5.e(x5, a_);
					x5 x7 = x5;
					while (x5.d(x6, a_2))
					{
						x6 = x5.f(x6, x2);
					}
					x6 = x5.e(x6, a_2);
					x5 x8 = this.e;
					x5 x9;
					if (x5.d(A_4, x2))
					{
						x9 = A_4;
					}
					else
					{
						x9 = x5.e(x2, x6);
					}
					x5 x10 = x5.e(x, x5);
					nm nm = this.a(x5, x6, x10, x9);
					if (nm != null)
					{
						mf.a(A_0, nm, A_1, A_2);
					}
					x5 a_3 = A_1;
					x5 a_4 = A_2;
					x5 a_5 = x5.e(x8, x10);
					x5 x11 = x5.e(A_4, x9);
					x5 a_6 = x5.c();
					x5 a_7 = x6;
					int num = 0;
					if (x5.h(x11, x5.c()))
					{
						a_3 = x5.f(A_1, x10);
						this.a(A_0, x, ref nm, x10, x9, a_5, a_3, ref a_4, a_6, ref a_7, true, ref x5);
					}
					while (x5.g(x11, x5.c()))
					{
						if (num++ == 0)
						{
							this.a(A_0, x, ref nm, x10, x9, a_5, a_3, ref a_4, a_6, ref a_7, false, ref x5);
						}
						else
						{
							a_5 = x8;
							a_3 = A_1;
							a_4 = x5.f(a_4, x9);
							a_6 = x7;
							a_7 = x5.f(a_7, x9);
							if (x5.h(a_7, x2))
							{
								a_7 = x5.c();
							}
							x9 = x5.f(x9, x2);
							if (x5.c(x9, x2))
							{
								x9 = x2;
							}
							if (x5.a(x9, x11))
							{
								x9 = x11;
							}
							this.a(A_0, x, ref nm, x10, x9, a_5, a_3, ref a_4, a_6, ref a_7, true, ref x5);
							x11 = x5.e(x11, x9);
						}
					}
					this.f = x5;
					this.g = x6;
					this.i = true;
				}
				else
				{
					x5 x5 = x4;
					x5 x6 = x3;
					while (x5.d(x5, a_))
					{
						x5 = x5.f(x5, x);
					}
					x5 = x5.e(x5, a_);
					while (x5.d(x6, a_2))
					{
						x6 = x5.f(x6, x2);
					}
					x6 = x5.e(x6, a_2);
					x5 x9;
					if (x5.d(A_4, x2))
					{
						x9 = A_4;
					}
					else
					{
						x9 = x5.e(x2, x6);
					}
					nm nm = this.a(x5, x6, A_3, x9);
					mf.a(A_0, nm, A_1, A_2);
				}
			}
			else
			{
				x4 = this.f;
				x3 = this.g;
				if (x5.c(A_3, x))
				{
					x5 x5 = x4;
					x5 x6 = x3;
					x5 x12 = x5;
					x5 x8 = this.e;
					x5 x9;
					if (x5.d(A_4, x2))
					{
						x9 = A_4;
					}
					else
					{
						x9 = x5.e(x2, x6);
					}
					x5 x10 = x5.e(x, x5);
					nm nm = this.a(x5, x6, x10, x9);
					if (nm != null)
					{
						mf.a(A_0, nm, A_1, A_2);
					}
					x5 a_3 = A_1;
					x5 a_4 = A_2;
					x5 a_6 = x5.c();
					x5 a_7 = x6;
					x5 a_5 = x5.e(x8, x10);
					x5 x11 = x5.e(A_4, x9);
					int num = 0;
					if (x5.h(x11, x5.c()))
					{
						a_3 = x5.f(A_1, x10);
						this.a(A_0, x, ref nm, x10, x9, a_5, a_3, ref a_4, a_6, ref a_7, true, ref x5);
					}
					while (x5.g(x11, x5.c()))
					{
						if (num++ == 0)
						{
							this.a(A_0, x, ref nm, x10, x9, a_5, a_3, ref a_4, a_6, ref a_7, false, ref x5);
						}
						else
						{
							a_5 = x8;
							a_3 = A_1;
							a_4 = x5.f(a_4, x9);
							a_6 = x12;
							a_7 = x5.f(a_7, x9);
							if (x5.h(a_7, x2))
							{
								a_7 = x5.c();
							}
							x9 = x5.f(x9, x2);
							if (x5.c(x9, x2))
							{
								x9 = x2;
							}
							if (x5.a(x9, x11))
							{
								x9 = x11;
							}
							this.a(A_0, x, ref nm, x10, x9, a_5, a_3, ref a_4, a_6, ref a_7, true, ref x5);
							x11 = x5.e(x11, x9);
						}
					}
					this.f = x5;
					this.g = x6;
				}
				else
				{
					x5 x5 = x4;
					x5 x6 = x3;
					x5 x9;
					if (x5.d(A_4, x2))
					{
						x9 = A_4;
					}
					else
					{
						x9 = x5.e(x2, x6);
					}
					x5 a_8 = x5.a(Math.Round(x5.a(x5.f(x5, A_3))));
					if (x5.b(a_8, x))
					{
						nm nm = this.a(x5, x6, A_3, x9);
						mf.a(A_0, nm, A_1, A_2);
					}
					else
					{
						x5 x10 = x5.e(x, x5);
						nm nm = this.a(x5, x6, x10, x9);
						mf.a(A_0, nm, A_1, A_2);
						x5 = x5.c();
						while (x5.b(x5.f(x10, x), A_3))
						{
							A_1 = x5.f(A_1, x10);
							x10 = x5.f(x10, x);
							nm = this.a(x5, x6, x10, x9);
							mf.a(A_0, nm, A_1, A_2);
						}
						A_1 = x5.f(A_1, x10);
						if (x5.c(x5.f(x10, x), A_3))
						{
							x10 = x5.e(A_3, x10);
						}
						nm = this.a(x5, x6, x10, x9);
						mf.a(A_0, nm, A_1, A_2);
					}
				}
			}
			this.h = x5.e(this.h, this.e);
			if (x5.b(this.h, x5.a(0.01)))
			{
				this.i = false;
			}
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x000E83F8 File Offset: 0x000E73F8
		private void a(OperatorWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			fr fr = this.d.ay().h();
			if (fr == fr.j)
			{
				this.b(A_0, A_1, A_2, A_3, A_4);
			}
		}

		// Token: 0x060014BE RID: 5310 RVA: 0x000E8430 File Offset: 0x000E7430
		internal nm a(x5 A_0, x5 A_1, x5 A_2, x5 A_3)
		{
			return new nm(this.b, A_0, A_1, A_2, A_3);
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x000E8452 File Offset: 0x000E7452
		internal void a(x5 A_0)
		{
			this.e = A_0;
		}

		// Token: 0x040009C9 RID: 2505
		internal const uint a = 5U;

		// Token: 0x040009CA RID: 2506
		private ImageData b;

		// Token: 0x040009CB RID: 2507
		private byte[] c = null;

		// Token: 0x040009CC RID: 2508
		private lk d;

		// Token: 0x040009CD RID: 2509
		private x5 e;

		// Token: 0x040009CE RID: 2510
		private x5 f;

		// Token: 0x040009CF RID: 2511
		private x5 g;

		// Token: 0x040009D0 RID: 2512
		private x5 h;

		// Token: 0x040009D1 RID: 2513
		private bool i = false;

		// Token: 0x040009D2 RID: 2514
		private bool j = false;

		// Token: 0x040009D3 RID: 2515
		private bool k = false;
	}
}
