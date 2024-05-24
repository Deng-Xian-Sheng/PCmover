using System;
using System.Collections.Generic;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200024E RID: 590
	internal class pg : dy
	{
		// Token: 0x06001AEE RID: 6894 RVA: 0x00117534 File Offset: 0x00116534
		internal pg(pi A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new ph(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001AEF RID: 6895 RVA: 0x00117584 File Offset: 0x00116584
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001AF0 RID: 6896 RVA: 0x0011759C File Offset: 0x0011659C
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001AF1 RID: 6897 RVA: 0x001175B4 File Offset: 0x001165B4
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001AF2 RID: 6898 RVA: 0x001175CC File Offset: 0x001165CC
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001AF3 RID: 6899 RVA: 0x001175D8 File Offset: 0x001165D8
		private void d(k0 A_0, ij A_1)
		{
			if (this.cg() == null || this.cg().h() == 0)
			{
				pl a_ = new pl();
				this.b.a(a_);
				base.e(A_0, A_1);
				this.a(A_0);
			}
			else
			{
				switch (this.a.d())
				{
				case false:
					if (this.a.a() > 1)
					{
						this.a(A_0, A_1);
					}
					else
					{
						this.c(A_0, A_1);
					}
					break;
				case true:
					this.b(A_0, A_1);
					break;
				}
			}
		}

		// Token: 0x06001AF4 RID: 6900 RVA: 0x00117688 File Offset: 0x00116688
		private void c(k0 A_0, ij A_1)
		{
			x5 x = x5.c();
			ms ms = null;
			mt mt = null;
			ms ms2 = null;
			ms ms3 = null;
			for (int i = 0; i < this.cg().h(); i++)
			{
				this.a(i, this.a.a(), A_0);
				k0 k = (k0)this.cg().b(i).cm(A_1, A_0);
				if (k != null)
				{
					if (x5.d(x, x5.f(x5.f(k.c5().am().Value, k.c5().a1()), k.c5().a0())))
					{
						x = x5.f(x5.f(k.c5().am().Value, k.c5().a1()), k.c5().a0());
					}
					if (ms == null)
					{
						ms = new ms(k);
					}
					int num = k.dg();
					if (num != 423471123)
					{
						if (num == 506042859)
						{
							mt mt2 = k.n();
							if (mt2 != null)
							{
								mu mu = mt2.c();
								m6 m = (m6)mu.a().l().a().b();
								if (m != null)
								{
									if (m.a())
									{
										ms2 = new ms(k);
									}
									if (!m.b() && ms3 == null)
									{
										if (!((m7)k).b())
										{
											ms3 = new ms(k);
										}
									}
								}
							}
						}
					}
					else
					{
						if (((m6)k).a())
						{
							ms2 = new ms(k);
						}
						if (!((m6)k).b() && ms3 == null)
						{
							if (!this.a.c())
							{
								ms3 = new ms(k);
							}
						}
					}
				}
			}
			if (ms2 != null)
			{
				mt = new mt(ms2);
			}
			else if (ms3 != null)
			{
				mt = new mt(ms3);
			}
			else if (ms != null)
			{
				mt = new mt(ms);
			}
			if (this.a(mt.c().a()))
			{
				this.b(A_0);
			}
			A_0.c(mt);
			if (A_0.c5().am() == null)
			{
				A_0.c5().j(new x5?(x));
				A_0.c5().d(i2.d);
			}
			else
			{
				x = x5.f(x5.f(A_0.c5().am().Value, A_0.c5().a1()), A_0.c5().a0());
			}
			this.a(A_0.n(), x);
		}

		// Token: 0x06001AF5 RID: 6901 RVA: 0x001179A0 File Offset: 0x001169A0
		private bool a(ms A_0)
		{
			bool result = false;
			k0 k = (k0)A_0.l().a().b();
			int num = k.dg();
			if (num != 423471123)
			{
				if (num == 506042859)
				{
					if (((m7)k).b())
					{
						result = true;
					}
					else if (((m6)k.n().c().a().l().a().b()).b())
					{
						result = true;
					}
				}
			}
			else if (((m6)k).b())
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06001AF6 RID: 6902 RVA: 0x00117A4C File Offset: 0x00116A4C
		private void b(k0 A_0)
		{
			A_0.c5().c().c(Color.d("#BFBFBF"));
			A_0.c5().c().d(Color.d("#BFBFBF"));
			A_0.c5().c().a(Color.d("#BFBFBF"));
			A_0.c5().c().b(Color.d("#BFBFBF"));
		}

		// Token: 0x06001AF7 RID: 6903 RVA: 0x00117AC8 File Offset: 0x00116AC8
		private void b(k0 A_0, ij A_1)
		{
			x5? x = ((n5)A_0.db()).p();
			int num = 0;
			x5 x2 = x5.c();
			x5 x3 = x5.c();
			mt mt = null;
			int num2 = this.a.a();
			this.a(0, num2, A_0);
			k0 k = (k0)this.cg().b(0).cm(A_1, A_0);
			if (k != null)
			{
				k.aw(x5.a((float)this.cg().h()));
				ms ms = new ms(k);
				ms.e(true);
				mt = new mt(ms);
				num += k.n().f();
				num2 -= num;
				x3 = k.c5().am().Value;
				if (x5.d(x2, x3))
				{
					x2 = x3;
				}
			}
			for (int i = 1; i < this.cg().h(); i++)
			{
				this.a(i, num2, A_0);
				k = (k0)this.cg().b(i).cm(A_1, A_0);
				if (k != null)
				{
					k.aw(x5.a((float)this.cg().h()));
					x3 = k.c5().am().Value;
					if (x5.d(x2, x3))
					{
						x2 = x3;
					}
					if (num < this.a.a())
					{
						ms ms = new ms(k);
						num += k.n().f();
						ms.e(true);
						mt.c(ms);
					}
					num2 -= num;
				}
			}
			if (mt != null && x != null)
			{
				mt.c().a().k(x.Value);
			}
			A_0.c(mt);
			A_0.c5().j(new x5?(x2));
			A_0.c5().d(i2.d);
			this.a(A_0.n(), x2);
		}

		// Token: 0x06001AF8 RID: 6904 RVA: 0x00117D04 File Offset: 0x00116D04
		private void a(k0 A_0, ij A_1)
		{
			x5 x = x5.c();
			x5 x2 = x5.c();
			List<o3> list = new List<o3>();
			for (int i = 0; i < this.cg().h(); i++)
			{
				this.a(i, this.a.a(), A_0);
				bool a_ = false;
				k0 k = (k0)this.cg().b(i).cm(A_1, A_0);
				x2 = k.c5().am().Value;
				if (x5.d(x, x2))
				{
					x = x2;
				}
				int num = k.dg();
				if (num != 423471123)
				{
					if (num == 506042859)
					{
						a_ = ((m7)k).a();
					}
				}
				else
				{
					a_ = ((m6)k).a();
				}
				list.Add(new o3(k, a_));
			}
			A_0.c5().j(new x5?(x));
			A_0.c5().d(i2.d);
			int num2 = this.b(list);
			if (num2 <= this.a.a())
			{
				ms a_2 = new ms(list[0].a());
				mt mt = new mt(a_2);
				for (int i = 1; i < list.Count; i++)
				{
					a_2 = new ms(list[i].a());
					mt.c(a_2);
				}
				A_0.c(mt);
			}
			else
			{
				A_0.c(this.a(list, num2));
			}
			this.a(A_0.n(), x);
		}

		// Token: 0x06001AF9 RID: 6905 RVA: 0x00117EB0 File Offset: 0x00116EB0
		private mt a(List<o3> A_0, int A_1)
		{
			int num = this.a.a();
			int num2 = this.a(A_0);
			mt mt;
			if (num2 == -1 || (num2 == 0 && A_0[0].a().dg() == 423471123))
			{
				mt = this.a(A_0, 0, 0);
			}
			else
			{
				int num3 = A_0[num2].c();
				if (num3 == num)
				{
					ms a_ = new ms(A_0[num2].a());
					mt = new mt(a_);
				}
				else if (num3 > num)
				{
					k0 a_2 = this.a(A_0[num2].a(), num, false);
					ms a_ = new ms(a_2);
					mt = new mt(a_);
				}
				else if (num2 + 1 == A_0.Count)
				{
					ms a_ = new ms(A_0[num2].a());
					mt = new mt(a_);
					int num4 = num3;
					int i = num2 - 1;
					while (i > -1)
					{
						int num5 = A_0[i].c();
						if (num4 + num5 < num)
						{
							num4 += num5;
							mt.d(new ms(A_0[i].a()));
							i--;
						}
						else
						{
							if (num4 + num5 == num)
							{
								num4 += num5;
								mt.d(new ms(A_0[i].a()));
								break;
							}
							k0 a_2 = this.a(A_0[i].a(), num - num4, true);
							mt.d(new ms(a_2));
							break;
						}
					}
				}
				else if (num2 == 0)
				{
					int num6 = this.a(A_0[0].a().n());
					if (A_1 - num6 < num)
					{
						int num7 = num - (A_1 - num6);
						num6 -= num7;
					}
					mt = this.a(A_0, num6, num2);
				}
				else
				{
					int num6 = this.a(A_1, ref num2, num, A_0);
					mt = this.a(A_0, num6, num2);
				}
			}
			return mt;
		}

		// Token: 0x06001AFA RID: 6906 RVA: 0x00118108 File Offset: 0x00117108
		private mt a(List<o3> A_0, int A_1, int A_2)
		{
			k0 k = this.a(A_1, A_0[A_2].a());
			ms a_ = new ms(k);
			mt mt = new mt(a_);
			int num = k.n().f();
			int num2 = this.a.a();
			bool flag = true;
			for (int i = A_2 + 1; i < A_0.Count; i++)
			{
				if (num >= num2 || !flag)
				{
					break;
				}
				int num3 = A_0[i].a().dg();
				if (num3 != 423471123)
				{
					if (num3 == 506042859)
					{
						if (num + A_0[i].c() <= num2)
						{
							a_ = new ms(A_0[i].a());
						}
						else
						{
							a_ = new ms(this.a(A_0[i].a(), num2 - num));
							flag = false;
						}
						mt.c(a_);
					}
				}
				else
				{
					a_ = new ms(A_0[i].a());
					mt.c(a_);
				}
				num += A_0[i].c();
			}
			return mt;
		}

		// Token: 0x06001AFB RID: 6907 RVA: 0x00118250 File Offset: 0x00117250
		private int a(int A_0, ref int A_1, int A_2, List<o3> A_3)
		{
			int num = this.a(A_3[A_1].a().n());
			int num2 = num;
			for (int i = 0; i < A_1; i++)
			{
				num2 += A_3[i].c();
			}
			while (A_0 - num2 < A_2)
			{
				if (A_0 - num2 + num != A_2)
				{
					if (A_0 - num2 + num < A_2)
					{
						num2 -= num;
						A_1--;
						if (A_1 < 0)
						{
							A_1++;
							break;
						}
						int num3 = A_2 - (A_0 - num2);
						if (A_3[A_1].c() == num3)
						{
							return 0;
						}
						num2 -= A_3[A_1].c();
						num = 0;
					}
					continue;
				}
				return 0;
			}
			return A_2 - (A_0 - num2);
		}

		// Token: 0x06001AFC RID: 6908 RVA: 0x00118348 File Offset: 0x00117348
		private k0 a(int A_0, k0 A_1)
		{
			mt mt = A_1.n();
			mu mu = mt.c(A_0);
			mt mt2 = new mt(mu.a());
			for (mu = mu.b(); mu != null; mu = mu.b())
			{
				mt2.c(mu.a());
			}
			A_1.c(mt2);
			return A_1;
		}

		// Token: 0x06001AFD RID: 6909 RVA: 0x001183AC File Offset: 0x001173AC
		private k0 a(k0 A_0, int A_1)
		{
			mt mt = A_0.n();
			mu mu = mt.c();
			int num = 0;
			mt mt2 = new mt(mu.a());
			num++;
			for (mu = mu.b(); mu != null; mu = mu.b())
			{
				if (num >= A_1)
				{
					break;
				}
				mt2.c(mu.a());
				num++;
			}
			A_0.c(mt2);
			return A_0;
		}

		// Token: 0x06001AFE RID: 6910 RVA: 0x00118430 File Offset: 0x00117430
		private k0 a(k0 A_0, int A_1, bool A_2)
		{
			mt mt = A_0.n();
			int num = 0;
			int a_ = mt.f() - A_1;
			mu mu = mt.c(a_);
			this.a(mu.a().l().a().b(), A_2);
			mt mt2 = new mt(mu.a());
			num++;
			for (mu = mu.b(); mu != null; mu = mu.b())
			{
				this.a(mu.a().l().a().b(), A_2);
				mt2.c(mu.a());
				num++;
			}
			A_0.c(mt2);
			return A_0;
		}

		// Token: 0x06001AFF RID: 6911 RVA: 0x001184E8 File Offset: 0x001174E8
		private void a(kz A_0, bool A_1)
		{
			if (A_1)
			{
				if (A_0.dg() == 423471123 && A_0.c5().ay().c())
				{
					A_0.c5().ay().a(null);
					A_0.c5().ay().a(false);
				}
			}
		}

		// Token: 0x06001B00 RID: 6912 RVA: 0x00118550 File Offset: 0x00117550
		private int b(List<o3> A_0)
		{
			int num = 0;
			foreach (o3 o in A_0)
			{
				num += o.c();
			}
			return num;
		}

		// Token: 0x06001B01 RID: 6913 RVA: 0x001185B4 File Offset: 0x001175B4
		private int a(List<o3> A_0)
		{
			int result = -1;
			int num = 0;
			foreach (o3 o in A_0)
			{
				if (o.b())
				{
					result = num;
				}
				num++;
			}
			return result;
		}

		// Token: 0x06001B02 RID: 6914 RVA: 0x00118624 File Offset: 0x00117624
		private int a(mt A_0)
		{
			mu mu = A_0.c();
			int num = 0;
			int num2 = 0;
			while (mu != null)
			{
				kz kz = mu.a().l().a().b();
				if (kz.dg() == 423471123 && ((m6)kz).a())
				{
					if (num < num2)
					{
						num = num2;
					}
				}
				num2++;
				mu = mu.b();
			}
			return num;
		}

		// Token: 0x06001B03 RID: 6915 RVA: 0x001186AC File Offset: 0x001176AC
		private void a(int A_0, int A_1, kz A_2)
		{
			int num = this.cg().b(A_0).ch().cn();
			if (num != 423471123)
			{
				if (num == 506042859)
				{
					((oy)this.cg().b(A_0)).a(this.a.d());
					switch (this.a.d())
					{
					case false:
						((oy)this.cg().b(A_0)).a(this.a.a());
						break;
					case true:
						if (this.a.b())
						{
							((oy)this.cg().b(A_0)).a(A_1);
						}
						else if (A_2.c5().v() != null)
						{
							((oy)this.cg().b(A_0)).a(int.MaxValue);
						}
						else
						{
							((oy)this.cg().b(A_0)).a(A_1);
						}
						break;
					}
				}
			}
			else
			{
				((o1)this.cg().b(A_0)).a(this.a.d());
				((o1)this.cg().b(A_0)).a(this.a.a());
			}
		}

		// Token: 0x06001B04 RID: 6916 RVA: 0x00118818 File Offset: 0x00117818
		private void a(mt A_0, x5 A_1)
		{
			for (mu mu = A_0.c(); mu != null; mu = mu.b())
			{
				mr mr = mu.a().l().a();
				lk lk = mr.b().c5();
				lk.j(new x5?(x5.e(x5.e(A_1, lk.a1()), lk.a0())));
				int num = mr.b().dg();
				if (num == 506042859)
				{
					this.a(((k0)mr.b()).n(), lk.am().Value);
				}
				lk.d(i2.d);
			}
		}

		// Token: 0x06001B05 RID: 6917 RVA: 0x001188D4 File Offset: 0x001178D4
		private void a(ng A_0)
		{
			switch (A_0.c5().g())
			{
			case false:
			{
				m8 m = new m8();
				m.a(this.a().a());
				A_0.c5().a(m);
				A_0.c5().b(true);
				break;
			}
			case true:
				if (!A_0.c5().f().i())
				{
					A_0.c5().f().d(x5.a(0.75));
				}
				if (!A_0.c5().f().j())
				{
					A_0.c5().f().b(x5.a(0.75));
				}
				if (!A_0.c5().f().k())
				{
					A_0.c5().f().a(x5.a(0.75));
				}
				if (!A_0.c5().f().l())
				{
					A_0.c5().f().c(x5.a(0.75));
				}
				break;
			}
			if (!A_0.c5().d())
			{
				lf lf = new lf();
				x5 a_ = x5.a(0.75);
				string a_2 = "#707070";
				lf.a(this.a(a_, a_2).a());
				lf.n(true);
				A_0.c5().a(lf);
				A_0.c5().a(true);
			}
		}

		// Token: 0x06001B06 RID: 6918 RVA: 0x00118A74 File Offset: 0x00117A74
		private hx a()
		{
			hx hx = new hx();
			ge ge = new ge(x5.a(0.75));
			ge.a(i2.d);
			hx.a()[0] = new fb<ge>(136794, ge);
			hx.a()[1] = new fb<ge>(426354259, ge);
			hx.a()[2] = new fb<ge>(7021096, ge);
			hx.a()[3] = new fb<ge>(448574430, ge);
			return hx;
		}

		// Token: 0x06001B07 RID: 6919 RVA: 0x00118B1C File Offset: 0x00117B1C
		private fg a(x5 A_0, string A_1)
		{
			fg fg = new fg();
			fv a_ = new fv(ft.h);
			fx a_2 = new fx(A_1);
			fw fw = new fw(A_0);
			fw.a(i2.d);
			fg.a()[0] = new fb<fu>(548864878, a_);
			fg.a()[1] = new fb<fu>(663309508, fw);
			fg.a()[2] = new fb<fu>(83960424, a_2);
			fg.a()[3] = new fb<fu>(1274012590, a_);
			fg.a()[4] = new fb<fu>(789921929, fw);
			fg.a()[5] = new fb<fu>(704614712, a_2);
			fg.a()[6] = new fb<fu>(1304279675, a_);
			fg.a()[7] = new fb<fu>(1930785673, fw);
			fg.a()[8] = new fb<fu>(1235296202, a_2);
			fg.a()[9] = new fb<fu>(758017896, a_);
			fg.a()[10] = new fb<fu>(1656587748, fw);
			fg.a()[11] = new fb<fu>(10890914, a_2);
			return fg;
		}

		// Token: 0x06001B08 RID: 6920 RVA: 0x00118CA8 File Offset: 0x00117CA8
		private void a(k0 A_0)
		{
			if (A_0.c5().am() == null)
			{
				if (A_0.n() != null && A_0.n().c() != null)
				{
					n3 n = (n3)A_0.n().c().a().l().a().b();
					Font font = n.j().e();
					char[] array = new char[n.ba()];
					Array.Copy(n.d(), n.h(), array, 0, n.ba());
					float textWidth = font.GetTextWidth(array, x5.b(((n5)A_0.db()).a().i()));
					A_0.c5().j(new x5?(x5.a(textWidth)));
					n.c5().j(A_0.c5().am());
				}
				A_0.c5().d(i2.d);
			}
		}

		// Token: 0x06001B09 RID: 6921 RVA: 0x00118DB0 File Offset: 0x00117DB0
		internal override kz cm(ij A_0, kz A_1)
		{
			ng ng = new ng();
			A_0.c(this.ch());
			A_0.a(ng);
			n5 n = (n5)ng.db();
			ng.c5().c().i(n.j());
			A_0.b(ng);
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = ng.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					ng = null;
					flag = false;
					A_0.a(false);
					break;
				case g2.c:
					a_ = true;
					break;
				}
			}
			if (flag)
			{
				ng.j(A_1);
				ng.a(this.a.a());
				ng.a(this.a.c());
				i3.a(ng);
				i3.a(ng, A_0);
				m4.a(n, ng.c5(), a_);
				if (ng.c5().ay().d() && ng.c5().ay().e() != null)
				{
					ng.b(mg.a(A_0, ng.c5().ay().e(), A_0.e()));
				}
				this.a(ng);
				this.d(ng, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return ng;
		}

		// Token: 0x04000C3A RID: 3130
		private new pi a = null;

		// Token: 0x04000C3B RID: 3131
		private ph b = null;

		// Token: 0x04000C3C RID: 3132
		private bool c = false;
	}
}
