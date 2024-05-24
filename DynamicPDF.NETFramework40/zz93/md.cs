using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x020001DF RID: 479
	internal class md : kz
	{
		// Token: 0x06001474 RID: 5236 RVA: 0x000E36C4 File Offset: 0x000E26C4
		internal md()
		{
		}

		// Token: 0x06001475 RID: 5237 RVA: 0x000E373C File Offset: 0x000E273C
		internal md(ij A_0, string A_1, string A_2)
		{
			try
			{
				mf mf = mg.a(A_0, A_1, A_2);
				if (mf != null)
				{
					this.e = new nm(mf.b(), x5.c(), x5.c(), x5.c(), x5.c());
					this.c = A_2;
					this.d = A_1;
					this.g = A_0;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x000E381C File Offset: 0x000E281C
		internal override int dg()
		{
			return 46415;
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x000E3834 File Offset: 0x000E2834
		internal override bool de()
		{
			return this.n;
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x000E384C File Offset: 0x000E284C
		internal override void df(bool A_0)
		{
			this.n = A_0;
		}

		// Token: 0x06001479 RID: 5241 RVA: 0x000E3858 File Offset: 0x000E2858
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600147A RID: 5242 RVA: 0x000E3870 File Offset: 0x000E2870
		internal override void dc(lj A_0)
		{
			this.a = (me)A_0;
		}

		// Token: 0x0600147B RID: 5243 RVA: 0x000E3880 File Offset: 0x000E2880
		internal mf a()
		{
			return this.b;
		}

		// Token: 0x0600147C RID: 5244 RVA: 0x000E3898 File Offset: 0x000E2898
		internal void a(mf A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600147D RID: 5245 RVA: 0x000E38A4 File Offset: 0x000E28A4
		internal override bool dx()
		{
			return false;
		}

		// Token: 0x0600147E RID: 5246 RVA: 0x000E38B8 File Offset: 0x000E28B8
		internal bool b()
		{
			return this.h;
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x000E38D0 File Offset: 0x000E28D0
		internal void a(bool A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x000E38DC File Offset: 0x000E28DC
		internal nm c()
		{
			return this.e;
		}

		// Token: 0x06001481 RID: 5249 RVA: 0x000E38F4 File Offset: 0x000E28F4
		private x5 c(x5 A_0)
		{
			x5 x = x5.c();
			kz kz = this.dr();
			bool flag = false;
			while (x5.h(x, x5.c()) && kz != null)
			{
				if (kz.c5().v() != null)
				{
					x = kz.c5().v().Value;
				}
				else
				{
					x = x5.c();
				}
				kz = kz.dr();
				if (kz != null && kz.dg() == 1946)
				{
					flag = true;
					break;
				}
			}
			if (x5.h(x, x5.c()))
			{
				if (flag)
				{
					x = A_0;
				}
				else
				{
					x = base.bl();
				}
			}
			return x;
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x000E39CC File Offset: 0x000E29CC
		private void a(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			base.c5().ay().a(A_0, A_1, A_2, A_3, A_4);
			if (this.b != null)
			{
				switch (base.c5().ay().f())
				{
				case gl.b:
				case gl.d:
				case gl.e:
					A_3 = base.aq();
					A_4 = base.ar();
					break;
				}
				this.b.a(base.c5(), A_0, A_1, A_2, A_3, A_4);
			}
		}

		// Token: 0x06001483 RID: 5251 RVA: 0x000E3A60 File Offset: 0x000E2A60
		private void a(x5 A_0, x5 A_1, bool A_2, bool A_3)
		{
			x5 x = x5.c();
			x5 x2 = x5.c();
			bool a_ = false;
			if (base.c5().ax() == i2.j && base.c5().av() == i2.j)
			{
				base.c5().b(new x5?(x));
				base.c5().h(new x5?(x2));
				a_ = A_2;
			}
			else if (base.c5().ax() != i2.j && base.c5().av() == i2.j)
			{
				x = base.c5().b().Value;
				if (A_3)
				{
					base.l(x5.e(base.aq(), x));
				}
				base.c5().h(new x5?(x2));
			}
			else if (base.c5().ax() == i2.j && base.c5().av() != i2.j)
			{
				base.c5().b(new x5?(x));
				x2 = base.c5().s().Value;
				if (A_3)
				{
					base.l(x5.e(base.aq(), x2));
				}
			}
			else
			{
				this.b(A_1);
				x = base.c5().b().Value;
				x2 = base.c5().s().Value;
			}
			if (base.c5().n() == g3.c)
			{
				this.a(A_0, A_1, x, x2, a_);
			}
		}

		// Token: 0x06001484 RID: 5252 RVA: 0x000E3C10 File Offset: 0x000E2C10
		private void a(x5 A_0, x5 A_1, x5 A_2, x5 A_3, bool A_4)
		{
			x5 a_ = x5.c();
			if (base.c5().e().h() == i2.j && base.c5().e().f() == i2.j)
			{
				if (x5.g(A_0, x5.c()) && !A_4)
				{
					a_ = x5.e(A_1, x5.f(x5.f(A_0, A_2), A_3));
					a_ = x5.a(a_, 2);
					if (x5.c(a_, x5.c()))
					{
						base.c5().e().d(a_);
						base.c5().e().b(a_);
					}
				}
			}
			else if (base.c5().e().h() != i2.j && base.c5().e().f() == i2.j)
			{
				base.c5().e().b(x5.c());
			}
			else if (base.c5().e().h() == i2.j && base.c5().e().f() != i2.j)
			{
				base.c5().e().d(x5.c());
			}
		}

		// Token: 0x06001485 RID: 5253 RVA: 0x000E3D64 File Offset: 0x000E2D64
		private void b(x5 A_0)
		{
			if (base.c5().ax() == i2.b && base.c5().av() == i2.b)
			{
				base.c5().b(new x5?(x5.a(x5.b(A_0) * x5.b(base.c5().b().Value) / 100f)));
				base.c5().h(new x5?(x5.a(x5.b(A_0) * x5.b(base.c5().s().Value) / 100f)));
			}
			else if (base.c5().ax() == i2.b && base.c5().av() != i2.b)
			{
				base.c5().b(new x5?(x5.a(x5.b(A_0) * x5.b(base.c5().b().Value) / 100f)));
			}
			else if (base.c5().ax() != i2.b && base.c5().av() == i2.b)
			{
				base.c5().b(new x5?(x5.a(x5.b(A_0) * x5.b(base.c5().b().Value) / 100f)));
			}
		}

		// Token: 0x06001486 RID: 5254 RVA: 0x000E3EEC File Offset: 0x000E2EEC
		private void a(x5 A_0)
		{
			if (base.c5().au() == i2.b && base.c5().aw() == i2.b)
			{
				base.c5().a(new x5?(x5.a(x5.b(A_0) * x5.b(base.c5().a().Value) / 100f)));
				base.c5().c(new x5?(x5.a(x5.b(A_0) * x5.b(base.c5().h().Value) / 100f)));
			}
			else if (base.c5().au() == i2.b && base.c5().aw() != i2.b)
			{
				base.c5().a(new x5?(x5.a(x5.b(A_0) * x5.b(base.c5().a().Value) / 100f)));
			}
			else if (base.c5().au() != i2.b && base.c5().aw() == i2.b)
			{
				base.c5().c(new x5?(x5.a(x5.b(A_0) * x5.b(base.c5().h().Value) / 100f)));
			}
		}

		// Token: 0x06001487 RID: 5255 RVA: 0x000E4074 File Offset: 0x000E3074
		internal void a(ij A_0, string A_1, string A_2)
		{
			mf mf = mg.a(A_0, A_1, A_2);
			this.c = A_2;
			this.d = A_1;
			this.g = A_0;
			if (mf != null)
			{
				this.e = new nm(mf.b(), x5.c(), x5.c(), x5.c(), x5.c());
			}
			else
			{
				this.e = new nm(null, x5.c(), x5.c(), x5.c(), x5.c());
			}
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x000E40F3 File Offset: 0x000E30F3
		internal override void di()
		{
			this.a7(this.d());
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x000E4104 File Offset: 0x000E3104
		internal override x5 dh()
		{
			base.r(false);
			this.a8(this.d());
			return this.dp();
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x000E4134 File Offset: 0x000E3134
		internal x5 d()
		{
			x5? x = base.c5().am();
			if (this.e != null)
			{
				if (this.e.a() != null && x == null)
				{
					this.i = (float)this.e.a().Width * 0.75f;
					this.j = (float)this.e.a().Height * 0.75f;
					x = new x5?(x5.a(this.i));
					if (base.c5().ap() == i2.b)
					{
						base.y(true);
					}
					else if (base.c5().ap() == i2.j)
					{
						if (base.c5().ah() != i2.j)
						{
							if (base.c5().ah() == i2.b)
							{
								base.y(true);
							}
							else
							{
								float num = x5.b(base.c5().v().Value);
								this.k = num / this.j;
								x = new x5?(x5.a(this.i * this.k));
							}
						}
					}
					else if (base.c5().ap() != i2.j && base.c5().ah() == i2.j)
					{
						x = new x5?(base.c5().am().Value);
					}
					x5? x2 = x;
					x5 a_ = x5.f(base.c5().a1(), base.c5().a0());
					x = ((x2 != null) ? new x5?(x5.f(x2.GetValueOrDefault(), a_)) : null);
				}
				else if (this.e.a() == null && x == null)
				{
					this.i = 30f;
					x = new x5?(x5.a(this.i));
				}
			}
			return (x != null) ? x.Value : x5.c();
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x000E4374 File Offset: 0x000E3374
		internal override kz dj(x5 A_0, x5 A_1)
		{
			this.e(A_0);
			if (this.e != null && this.e.a() != null)
			{
				base.ad(base.ar());
				base.y(base.ar());
				base.ac(base.ar());
				if (base.ci() && x5.d(base.ck(), base.ar()))
				{
					if (x5.g(base.ck(), x5.c()))
					{
						this.d(base.ck());
						base.ad(base.ar());
						base.y(base.ar());
						base.ac(base.ar());
					}
					return null;
				}
				if (x5.c(base.ar(), A_1))
				{
					base.an(false);
					this.am(false);
					this.a.a(false);
					if (x5.c(base.aq(), A_0))
					{
						return null;
					}
					this.a.a(false);
					return this;
				}
				else if (x5.c(base.aq(), A_0))
				{
					base.an(false);
					this.aj(false);
					return null;
				}
			}
			else
			{
				if (this.a.a() != null)
				{
					this.o = x5.b(n4.a(this.a.a().ToCharArray(), 0, this.a.a().Length, 0f, 0f, this.a.b(), 11f));
					base.m(n4.a(this.a.b(), 11f, null, mw.e));
				}
				if (base.c5().am() == null)
				{
					base.l(x5.a(10f));
				}
				if (base.c5().v() == null)
				{
					base.m(x5.a(10f));
				}
				base.ad(base.ar());
				base.y(base.ar());
				base.ac(base.ar());
				if (x5.c(base.ar(), A_1))
				{
					base.an(false);
					this.am(false);
					this.a.a(false);
					return this;
				}
				if (x5.c(base.aq(), A_0))
				{
					this.aj(false);
					base.an(false);
					return null;
				}
			}
			return null;
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x000E4640 File Offset: 0x000E3640
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			if (!base.c5().az().Equals(g9.b) && !base.c5().az().Equals(g9.c))
			{
				A_0.SetGraphicsMode();
				if (base.c5().n() == g3.c && !this.c3() && base.c5().q() == g6.a)
				{
					A_1 = x5.f(A_1, base.cc());
					A_1 = x5.f(A_1, this.dc());
				}
				x5 x = x5.f(base.c5().e().a(), base.c5().e().c());
				x5 x2 = x5.f(base.c5().e().d(), base.c5().e().b());
				x5 x3;
				if (x5.a(x5.e(A_2, base.ar()), x5.c()))
				{
					x3 = x5.f(x5.e(A_2, base.ar()), x5.a(x5.b(base.c5().a2()) / 2f));
				}
				else
				{
					x3 = A_2;
				}
				x5 a_ = A_1;
				if (base.c5().q() == g6.c)
				{
					a_ = x5.f(A_1, base.@as());
				}
				base.c5().c().h(this.m);
				base.c5().c().g(this.l);
				base.c5().c().a(A_0, A_1, x3, x5.e(base.aq(), x2), x5.e(base.ar(), x));
				this.a(A_0, x5.f(x5.f(a_, base.c5().e().d()), base.c5().c().n()), x5.f(x5.f(x3, base.c5().e().a()), base.c5().c().f()), x5.e(base.aq(), x2), x5.e(base.ar(), x));
				switch (base.c5().q())
				{
				case g6.b:
				case g6.c:
					A_2 = x5.e(A_2, base.c5().a2());
					break;
				}
				float num = x5.b(base.c5().a3());
				g3 g = base.c5().n();
				if (g != g3.b)
				{
					A_1 = x5.f(A_1, base.c5().a1());
				}
				else
				{
					A_1 = x5.f(A_1, base.c5().a0());
				}
				A_2 = x5.f(A_2, base.c5().a2());
				float pdfX = A_0.Dimensions.GetPdfX(x5.b(A_1));
				float pdfY = A_0.Dimensions.GetPdfY(x5.b(A_2) - num);
				PageXObjectList pageXObjectList = new PageXObjectList();
				float num2 = x5.b(base.aq());
				float num3 = x5.b(base.ar());
				if (this.e != null && this.e.a() != null)
				{
					num2 -= x5.b(x5.f(base.c5().a1(), base.c5().a0()));
					num3 -= x5.b(x5.f(base.c5().a2(), base.c5().a3()));
					if (this.f == null)
					{
						this.f = new float?(num3);
					}
					float num4 = x5.c(this.e.e(), x5.c()) ? x5.b(this.e.e()) : this.f.Value;
					pageXObjectList.a(this.e.a());
					A_0.Write_q_(false);
					if (base.c5().p() != null)
					{
						float num5 = x5.b(x5.e(base.c5().p().c(), base.c5().p().a()));
						if (num5 > x5.b(this.e.c()))
						{
							if (num5 > num3)
							{
								num5 = num3 - x5.b(base.c5().p().a());
							}
							A_0.a(pdfX + x5.b(base.c5().p().d()), pdfY + (num4 - num5 - x5.b(base.c5().p().a())), x5.b(x5.e(base.c5().p().b(), base.c5().p().d())), num5);
						}
						else
						{
							A_0.a(pdfX + x5.b(base.c5().p().d()), pdfY + (num4 - num5 - x5.b(base.c5().p().a())), 0f, 0f);
						}
					}
					A_0.Write_cm(num2, 0f, 0f, this.f.Value, pdfX, pdfY - (this.f.Value - num4) + x5.b(this.e.c()));
					A_0.Write_Do(this.e.a());
					A_0.Write_Q(false);
				}
				else
				{
					A_2 = x5.e(A_2, x5.a(num3));
					x5 x4 = m4.a(new h2(new i4(i2.c, 28f)));
					x5 x5 = m4.a(new h2(new i4(i2.c, 30f)));
					A_0.SetLineWidth(0.5f);
					A_0.SetLineStyle(LineStyle.Solid);
					A_0.SetStrokeColor(Grayscale.DarkGray);
					num3 -= x5.b(x);
					num2 -= x5.b(x2);
					if (!this.l && !this.m)
					{
						A_0.Write_re(x5.b(A_1), x5.b(A_2), num2, num3);
						A_0.Write_S();
					}
					else
					{
						if (!this.l)
						{
							A_0.Write_m_(x5.b(A_1), x5.b(A_2));
							A_0.Write_l_(x5.b(A_1) + num2, x5.b(A_2));
						}
						A_0.Write_m_(x5.b(A_1), x5.b(A_2));
						A_0.Write_l_(x5.b(A_1), x5.b(A_2) + num3);
						if (!this.m)
						{
							A_0.Write_m_(x5.b(A_1), x5.b(A_2) + num3);
							A_0.Write_l_(x5.b(A_1) + num2, x5.b(A_2) + num3);
						}
						A_0.Write_m_(x5.b(A_1) + num2, x5.b(A_2));
						A_0.Write_l_(x5.b(A_1) + num2, x5.b(A_2) + num3);
						A_0.Write_S();
					}
					if (!this.l && x5.a(x5.a(num3), x5))
					{
						A_0.Write_re(x5.b(A_1) + 5f, x5.b(A_2) + 5f, x5.b(x4) - 10f, x5.b(x5) - 10f);
						A_0.Write_S();
						A_0.SetStrokeColor(RgbColor.Red);
						A_0.SetLineCap(LineCap.Round);
						A_0.SetLineWidth(2f);
						A_0.Write_m_(x5.b(A_1) + 8f, x5.b(A_2) + 8f);
						A_0.Write_l_(x5.b(x5.f(A_1, x4)) - 8f, x5.b(x5.f(A_2, x5)) - 8f);
						A_0.Write_S();
						A_0.Write_m_(x5.b(x5.f(A_1, x4)) - 8f, x5.b(A_2) + 8f);
						A_0.Write_l_(x5.b(A_1) + 8f, x5.b(x5.f(A_2, x5)) - 8f);
						A_0.Write_S();
					}
					A_1 = x5.f(A_1, x4);
					if (this.a.a() != null)
					{
						A_0.Write_q_();
						A_0.Write_re(x5.b(A_1), x5.b(A_2), this.o, num3);
						A_0.Write_W();
						A_0.Write_n();
						TextLineList textLines = this.a.b().GetTextLines(this.a.a().ToCharArray(), this.o, num3, 10f);
						textLines.Draw(A_0, x5.b(A_1), x5.b(A_2), TextAlign.Left, RgbColor.Black, false, false);
						A_0.Write_Q();
					}
				}
			}
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x000E4F94 File Offset: 0x000E3F94
		internal override x5 dy(x5 A_0, x5 A_1, x5 A_2)
		{
			switch (base.c5().n())
			{
			case g3.a:
				base.i(A_1);
				A_1 = x5.f(A_1, base.aq());
				break;
			case g3.b:
				if (this.bv().c().Count >= 1)
				{
					x5 a_ = this.bv().b(A_2, A_0);
					if (x5.h(a_, x5.c()))
					{
						a_ = A_0;
					}
					base.i(x5.e(a_, base.aq()));
				}
				else
				{
					base.i(x5.e(A_0, base.aq()));
				}
				break;
			}
			base.j(A_2);
			this.bv().a(this);
			return A_1;
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x000E5058 File Offset: 0x000E4058
		internal override void da()
		{
			int num = this.dg();
			if (num != 3034 && num != 3418)
			{
				k0 k = (k0)this.dr();
				if (x5.b(x5.e(k.aq(), k.aa()), base.aq()) || !this.de() || !this.c3())
				{
					this.dr().am(this.c0());
				}
			}
			else if (((n5)this.db()).z() == 1)
			{
				this.dr().am(this.c0());
			}
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x000E5104 File Offset: 0x000E4104
		internal md d(x5 A_0)
		{
			md md = new md();
			md.dc(this.db().du());
			md.a((lk)base.c5().du());
			md.j(this.dr());
			md.dc(this.a);
			md.c = this.c;
			switch (base.c5().q())
			{
			case g6.b:
			case g6.c:
				switch (base.c5().r())
				{
				case g7.c:
				case g7.d:
					if (base.c5().a() != null)
					{
						md.c5().a(new x5?(x5.c()));
					}
					break;
				}
				break;
			}
			if (this.f == null)
			{
				this.f = new float?(x5.b(base.ar()));
			}
			md.e = new nm(this.e.a(), x5.c(), x5.f(this.e.c(), A_0), base.aq(), x5.e(base.ar(), A_0));
			md.f = this.f;
			lk lk = md.c5();
			x5 value;
			md.l(value = base.aq());
			lk.j(new x5?(value));
			md.c5().d(i2.d);
			lk lk2 = md.c5();
			md.m(value = x5.e(base.ar(), A_0));
			lk2.i(new x5?(value));
			md.c5().a(i2.d);
			md.i = this.i;
			md.j = this.j;
			md.k = this.k;
			base.m(A_0);
			this.e = new nm(this.e.a(), this.e.b(), this.e.c(), base.aq(), base.ar());
			md.d = this.d;
			md.l = true;
			this.m = true;
			this.am(true);
			base.an(true);
			return md;
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x000E534C File Offset: 0x000E434C
		internal void e(x5 A_0)
		{
			if ((!this.a.e() && this.e != null) || x5.h(base.ar(), x5.c()))
			{
				if (this.e != null && this.e.a() != null)
				{
					this.i = (float)this.e.a().Width * 0.75f;
					this.j = (float)this.e.a().Height * 0.75f;
					if (base.c5().ap() == i2.j && base.c5().ah() == i2.j)
					{
						base.l(x5.a(this.i));
						base.m(x5.a(this.j));
						g6 g = base.c5().q();
						if (g != g6.c)
						{
							this.a(base.aq(), A_0, false, true);
						}
						else
						{
							this.a(base.aq(), A_0, true, true);
						}
						base.c5().d(i2.d);
						base.c5().a(i2.d);
					}
					else if (base.c5().ap() == i2.j && base.c5().ah() != i2.j)
					{
						if (base.c5().ah() == i2.b)
						{
							x5 a_ = this.c(x5.a(this.j));
							base.m(x5.a(x5.b(a_) * (x5.b(base.c5().v().Value) / 100f)));
							base.c5().i(new x5?(base.ar()));
							base.c5().a(i2.d);
						}
						else if (base.c5().v() != null)
						{
							base.m(base.c5().v().Value);
						}
						float num = 0f;
						if (base.c5().v() != null)
						{
							num = x5.b(base.c5().v().Value);
						}
						this.k = num / this.j;
						base.l(x5.a(this.i * this.k));
					}
					else if (base.c5().ap() != i2.j && base.c5().ah() == i2.j)
					{
						if (base.c5().ap() == i2.b)
						{
							base.l(x5.a(x5.b(base.bi()) * (x5.b(base.c5().am().Value) / 100f)));
							base.c5().j(new x5?(base.aq()));
							base.c5().d(i2.d);
						}
						else
						{
							base.l(base.c5().am().Value);
						}
						float num2 = x5.b(base.c5().am().Value);
						this.k = num2 / this.i;
						base.m(x5.a(this.j * this.k));
						base.l(base.c5().am().Value);
						g6 g = base.c5().q();
						if (g != g6.c)
						{
							this.a(base.aq(), A_0, false, true);
						}
						else
						{
							this.a(base.aq(), A_0, true, true);
						}
					}
					else
					{
						if (base.c5().ap() == i2.b && base.c5().ah() == i2.b)
						{
							base.l(x5.a(x5.b(base.bi()) * x5.b(base.c5().am().Value) / 100f));
							x5 a_ = this.c(x5.a(this.j));
							base.m(x5.a(x5.b(a_) * x5.b(base.c5().v().Value) / 100f));
						}
						else if (base.c5().ap() == i2.b && base.c5().ah() != i2.b)
						{
							base.l(x5.a(x5.b(base.bi()) * x5.b(base.c5().am().Value) / 100f));
							base.m(base.c5().v().Value);
						}
						else if (base.c5().ap() != i2.b && base.c5().ah() == i2.b)
						{
							base.l(base.c5().am().Value);
							x5 a_ = this.c(x5.a(this.j));
							base.m(x5.a(x5.b(a_) * x5.b(base.c5().v().Value) / 100f));
						}
						else
						{
							if (base.c5().am() != null && x5.g(base.c5().am().Value, x5.c()))
							{
								base.l(base.c5().am().Value);
							}
							else if (base.c5().v() != null && x5.g(base.c5().v().Value, x5.c()))
							{
								float num3 = x5.b(base.c5().v().Value) / this.j;
								base.l(x5.a(this.i * num3));
							}
							else
							{
								base.l(x5.a(this.i));
							}
							if (base.c5().v() != null && x5.g(base.c5().v().Value, x5.c()))
							{
								base.m(base.c5().v().Value);
							}
							else if (base.c5().am() != null && x5.g(base.c5().am().Value, x5.c()))
							{
								float num4 = x5.b(base.aq()) / this.i;
								base.m(x5.a(this.j * num4));
							}
							else
							{
								base.m(x5.a(this.j));
							}
						}
						g6 g = base.c5().q();
						if (g != g6.c)
						{
							this.a(base.aq(), A_0, false, true);
						}
						else
						{
							this.a(base.aq(), A_0, true, true);
						}
					}
					base.l(x5.f(base.aq(), x5.f(base.c5().a1(), base.c5().a0())));
					base.m(x5.f(base.ar(), x5.f(base.c5().a2(), base.c5().a3())));
				}
				else if (base.c5().am() != null && x5.g(base.c5().am().Value, x5.c()))
				{
					if (base.c5().ap() == i2.b)
					{
						base.l(x5.a(x5.b(base.bi()) * (x5.b(base.c5().am().Value) / 100f)));
						base.c5().j(new x5?(base.aq()));
						base.c5().d(i2.d);
					}
					else
					{
						base.l(base.c5().am().Value);
					}
					if (base.c5().v() == null)
					{
						if (base.c5().ap() != i2.b)
						{
							base.c5().i(new x5?(base.aq()));
							base.c5().a(i2.d);
						}
					}
					base.m(base.c5().v().Value);
				}
				else if (base.c5().v() != null && x5.g(base.c5().v().Value, x5.c()))
				{
					if (base.c5().ap() == i2.b)
					{
						base.l(x5.a(x5.b(base.bi()) * (x5.b(base.c5().am().Value) / 100f)));
						base.c5().j(new x5?(base.aq()));
						base.c5().d(i2.d);
					}
					else
					{
						base.m(base.c5().v().Value);
					}
					if (base.c5().am() == null)
					{
						if (base.c5().ah() == i2.c)
						{
							base.c5().j(new x5?(base.ar()));
							base.c5().d(i2.c);
						}
					}
					base.l(base.c5().am().Value);
				}
				else
				{
					this.i = 30f;
					this.j = 30f;
					base.l(x5.a(this.i));
					base.m(x5.a(this.j));
				}
				this.a.a(true);
			}
		}

		// Token: 0x06001491 RID: 5265 RVA: 0x000E5E80 File Offset: 0x000E4E80
		internal override kz dm()
		{
			md md = new md();
			md.a(this.g, this.d, this.g.e());
			md.dc(this.db().du());
			md.a((lk)base.c5().du());
			md.j(this.dr());
			return md;
		}

		// Token: 0x040009B4 RID: 2484
		private me a = new me();

		// Token: 0x040009B5 RID: 2485
		private mf b = null;

		// Token: 0x040009B6 RID: 2486
		private string c = null;

		// Token: 0x040009B7 RID: 2487
		private string d = null;

		// Token: 0x040009B8 RID: 2488
		private nm e = null;

		// Token: 0x040009B9 RID: 2489
		private float? f = null;

		// Token: 0x040009BA RID: 2490
		private ij g = null;

		// Token: 0x040009BB RID: 2491
		private bool h = false;

		// Token: 0x040009BC RID: 2492
		private float i;

		// Token: 0x040009BD RID: 2493
		private float j;

		// Token: 0x040009BE RID: 2494
		private float k;

		// Token: 0x040009BF RID: 2495
		private bool l = false;

		// Token: 0x040009C0 RID: 2496
		private bool m = false;

		// Token: 0x040009C1 RID: 2497
		private bool n = false;

		// Token: 0x040009C2 RID: 2498
		private float o = 0f;
	}
}
