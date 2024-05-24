using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200019E RID: 414
	internal class km : dy
	{
		// Token: 0x06000E82 RID: 3714 RVA: 0x000AD510 File Offset: 0x000AC510
		internal km(kp A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.d = A_2;
			this.b = new kn(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000E83 RID: 3715 RVA: 0x000AD56C File Offset: 0x000AC56C
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x000AD584 File Offset: 0x000AC584
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000E85 RID: 3717 RVA: 0x000AD59C File Offset: 0x000AC59C
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000E86 RID: 3718 RVA: 0x000AD5B4 File Offset: 0x000AC5B4
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000E87 RID: 3719 RVA: 0x000AD5C0 File Offset: 0x000AC5C0
		private kz e(ij A_0, kz A_1)
		{
			ml ml = new ml();
			ml.a(this.a.b());
			ml.d0(this.a.a());
			this.a(ml, A_0, A_1);
			bool flag = true;
			g2 valueOrDefault = ml.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				if (valueOrDefault == g2.a)
				{
					flag = false;
				}
			}
			kz result;
			if (flag)
			{
				ml.a(A_0.c().a((n5)ml.db(), A_0));
				if (this.a.d() != null && this.a.a() != ko.b)
				{
					qd qd = new qd(this.d.x(), this.a.e(), this.a.d().Length, this.b.k().b());
					if (this.a.a() == ko.b)
					{
						for (int i = this.a.e(); i < this.a.e() + this.a.d().Length; i++)
						{
							this.d.x()[i] = '●';
						}
					}
					qd.c(true);
					this.b.a(qd);
				}
				else
				{
					qd qd = new qd(new char[]
					{
						' '
					}, 0, 1, this.b.k());
					qd.c(true);
					this.b.a(qd);
				}
				if (this.a.g())
				{
					((n5)ml.db()).a(Color.d("#A0A0A0"));
				}
				kz kz = this.a(ml, A_0, true);
				int a_ = this.b.h() - 1;
				this.b.c(a_);
				result = kz;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000E88 RID: 3720 RVA: 0x000AD7D4 File Offset: 0x000AC7D4
		private kz d(ij A_0, kz A_1)
		{
			mh mh = new mh();
			mh.d0(this.a.a());
			this.a(mh, A_0, A_1);
			bool flag = true;
			g2 valueOrDefault = mh.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				if (valueOrDefault == g2.a)
				{
					flag = false;
				}
			}
			kz result;
			if (flag)
			{
				mh.a(A_0.c().a((n5)mh.db(), A_0));
				if (this.a.d() != null)
				{
					qd qd = new qd(this.d.x(), this.a.e(), this.a.d().Length, this.b.k().b());
					qd.c(true);
					this.b.a(qd);
				}
				else
				{
					switch (this.a.a())
					{
					case ko.d:
					{
						char[] array = new char[]
						{
							'R',
							'e',
							's',
							'e',
							't'
						};
						qd qd = new qd(array, 0, array.Length, this.b.k().b());
						qd.c(true);
						this.b.a(qd);
						break;
					}
					case ko.e:
					{
						char[] array2 = new char[]
						{
							'S',
							'u',
							'b',
							'm',
							'i',
							't',
							' ',
							'Q',
							'u',
							'e',
							'r',
							'y'
						};
						qd qd = new qd(array2, 0, array2.Length, this.b.k().b());
						qd.c(true);
						this.b.a(qd);
						break;
					}
					default:
					{
						qd qd2 = new qd(new char[]
						{
							' '
						}, 0, 1, this.b.k());
						qd2.c(true);
						this.b.a(qd2);
						break;
					}
					}
				}
				if (this.a.g())
				{
					((n5)mh.db()).a(Color.d("#A0A0A0"));
				}
				kz kz = this.a(mh, A_0, true);
				int a_ = this.b.h() - 1;
				this.b.c(a_);
				result = kz;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x000ADA1C File Offset: 0x000ACA1C
		private kz c(ij A_0, kz A_1)
		{
			mj mj = new mj();
			mj.d0(this.a.a());
			mj.j(A_1);
			ml ml = new ml();
			ml.a(this.a.b());
			ml.d0(this.a.a());
			this.a(ml, A_0, mj);
			bool flag = true;
			g2 valueOrDefault = ml.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				if (valueOrDefault == g2.a)
				{
					flag = false;
				}
			}
			x5 x = x5.c();
			kz result;
			if (flag)
			{
				ml.a(A_0.c().a((n5)ml.db(), A_0));
				mj.a(ml.b());
				qd qd = new qd(new char[]
				{
					' '
				}, 0, 1, this.b.k());
				qd.c(true);
				this.b.a(qd);
				if (this.a.g())
				{
					((n5)ml.db()).a(Color.d("#A0A0A0"));
				}
				ms ms = new ms(this.a(ml, A_0, false));
				x = x5.f(x5.f(ml.c5().am().Value, ml.c5().a1()), ml.c5().a0());
				n3 n = new n3(new char[]
				{
					' '
				}, 0, 1, A_0);
				n.j(mj);
				n.a(new lk());
				n.c5().j(new x5?(x5.a(3.001)));
				n.c5().d(i2.d);
				n.e(true);
				ms.l().a(n);
				x = x5.f(x, n.c5().am().Value);
				mh mh = new mh();
				mh.d0(this.a.a());
				this.a(mh, A_0, mj);
				mh.a(A_0.c().a((n5)mh.db(), A_0));
				this.a(mh, A_0);
				ms.l().a(mh);
				x = x5.f(x, x5.f(x5.f(mh.c5().am().Value, mh.c5().a1()), mh.c5().a0()));
				mt a_ = new mt(ms);
				mj.c(a_);
				mj.c5().j(new x5?(x));
				mj.c5().d(i2.d);
				int a_2 = this.b.h() - 1;
				this.b.c(a_2);
				result = mj;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x000ADD28 File Offset: 0x000ACD28
		private kz b(ij A_0, kz A_1)
		{
			mi mi = new mi();
			mi.d0(this.a.a());
			this.a(mi, A_0, A_1);
			bool flag = true;
			g2 valueOrDefault = mi.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				if (valueOrDefault == g2.a)
				{
					mi = null;
					flag = false;
				}
			}
			if (flag)
			{
				ml ml = new ml();
				ml.d0(this.a.a());
				ml.j(mi);
				ml.a(l2.a());
				mi.a(ml.b());
				this.a(ml);
				if (this.a.h())
				{
					qd qd = new qd(new char[]
					{
						'4'
					}, 0, 1, this.b.k());
					qd.c(true);
					this.b.a(qd);
					if (this.a.g())
					{
						mi.a(true);
					}
				}
				else
				{
					qd qd = new qd(new char[]
					{
						' '
					}, 0, 1, this.b.k());
					qd.c(true);
					this.b.a(qd);
				}
				ms a_ = new ms(this.a(ml, A_0, true));
				mt a_2 = new mt(a_);
				mi.c(a_2);
				int a_3 = this.b.h() - 1;
				this.b.c(a_3);
			}
			return mi;
		}

		// Token: 0x06000E8B RID: 3723 RVA: 0x000ADED0 File Offset: 0x000ACED0
		private kz a(ij A_0, kz A_1)
		{
			mk mk = new mk();
			mk.d0(this.a.a());
			this.a(mk, A_0, A_1);
			bool flag = true;
			g2 valueOrDefault = mk.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					mk = null;
					flag = false;
					break;
				}
			}
			if (flag)
			{
				ml ml = new ml();
				ml.d0(this.a.a());
				ml.j(mk);
				ml.a(l2.a());
				mk.a(ml.b());
				this.a(ml);
				qd qd = new qd(new char[]
				{
					' '
				}, 0, 1, this.b.k());
				qd.c(true);
				this.b.a(qd);
				if (this.a.h())
				{
					mk.b(true);
					if (!this.a.g())
					{
						if (mk.w() != null)
						{
							((n5)ml.db()).a(Color.d("black"));
						}
						else
						{
							((n5)ml.db()).a(Color.d("#28A2D1"));
						}
					}
					else
					{
						((n5)ml.db()).a(Color.d("#B9B9B9"));
						mk.a(true);
					}
				}
				else if (!this.a.g())
				{
					((n5)ml.db()).a(Color.d("#C5C8CC"));
				}
				else
				{
					((n5)ml.db()).a(Color.d("#D5D8DC"));
					mk.a(true);
				}
				ms a_ = new ms(this.a(ml, A_0, true));
				mt a_2 = new mt(a_);
				mk.c(a_2);
			}
			return mk;
		}

		// Token: 0x06000E8C RID: 3724 RVA: 0x000AE0F8 File Offset: 0x000AD0F8
		private void a(k0 A_0, ij A_1)
		{
			char[] array = new char[]
			{
				'B',
				'r',
				'o',
				'w',
				's',
				'e',
				'.',
				'.',
				'.'
			};
			qd qd = new qd(array, 0, array.Length, this.b.k().b());
			qd.c(true);
			this.b.a(qd);
			kz kz = qd.cm(A_1, A_0);
			ms a_ = new ms(kz);
			kz.dc(A_0.db());
			A_0.c(new mt(a_));
			this.b(A_0);
			int a_2 = this.b.h() - 1;
			this.b.c(a_2);
		}

		// Token: 0x06000E8D RID: 3725 RVA: 0x000AE198 File Offset: 0x000AD198
		private void a(k0 A_0, ij A_1, kz A_2)
		{
			A_0.j(A_2);
			A_1.c(this.ch());
			A_1.a(A_0);
			A_1.b(A_0);
			bool a_ = false;
			g2? g = A_0.c5().t();
			g2 valueOrDefault = g.GetValueOrDefault();
			if (g != null)
			{
				if (valueOrDefault == g2.c)
				{
					a_ = true;
				}
			}
			i3.a(A_0);
			i3.a(A_0, A_1);
			n5 n = (n5)A_0.db();
			switch (this.a.a())
			{
			case ko.f:
			case ko.g:
				n = new n5();
				n.a(new l4());
				n.a().a(x5.a(6f));
				A_0.dc(n);
				if (A_0.c5().ay().d() && A_0.c5().ay().e() != null)
				{
					A_0.b(mg.a(A_1, A_0.c5().ay().e(), A_1.e()));
				}
				break;
			default:
				if (A_0.c5().ay().d() && A_0.c5().ay().e() != null)
				{
					A_0.b(mg.a(A_1, A_0.c5().ay().e(), A_1.e()));
				}
				this.a(A_0);
				break;
			}
			m4.a(n, A_0.c5(), a_);
			g = A_0.c5().t();
			if (g == g2.b)
			{
				this.c = true;
			}
		}

		// Token: 0x06000E8E RID: 3726 RVA: 0x000AE354 File Offset: 0x000AD354
		private kz a(k0 A_0, ij A_1, bool A_2)
		{
			base.e(A_0, A_1);
			if (A_2 && A_1.i().b() > 0)
			{
				A_1.b().a(A_1.i().b(), A_1);
				A_1.i().l(A_1.i().b());
				ik ik = A_1.i();
				ik.j(ik.b() - 1);
			}
			if (this.b.h() > 0 && A_0.n().c() != null)
			{
				A_0.n().c().a().l().a().b().dc(A_0.db());
			}
			int a_ = this.a.b();
			switch (this.a.a())
			{
			case ko.a:
			case ko.b:
			case ko.i:
				this.a(A_0, a_);
				this.c(A_0);
				break;
			case ko.c:
			case ko.d:
			case ko.e:
			{
				int num = (this.a.d() != null) ? this.a.d().Length : 1;
				this.b(A_0);
				this.c(A_0);
				break;
			}
			case ko.f:
			case ko.g:
			{
				a_ = 2;
				bool flag = false;
				nk nk = null;
				n3 n = null;
				if (A_0.n().c().a().l().a().b().dg() == 102)
				{
					flag = true;
					nk = (nk)A_0.n().c().a().l().a().b();
					nk.a(((ml)A_0).b());
				}
				else
				{
					n = (n3)A_0.n().c().a().l().a().b();
					n.a(((ml)A_0).b());
				}
				if (this.a.a() == ko.g && A_0.c5().am() == null)
				{
					A_0.c5().j(A_0.dr().c5().am());
					A_0.c5().d(A_0.dr().c5().ap());
				}
				this.a(A_0, a_);
				x5? x;
				x5 a_2;
				if (flag)
				{
					lk lk = nk.c5();
					x = lk.am();
					a_2 = x5.a(2f);
					lk.j((x != null) ? new x5?(x5.f(x.GetValueOrDefault(), a_2)) : null);
				}
				else
				{
					lk lk2 = n.c5();
					x = lk2.am();
					a_2 = x5.a(2f);
					lk2.j((x != null) ? new x5?(x5.f(x.GetValueOrDefault(), a_2)) : null);
				}
				lk lk3 = A_0.c5();
				x = lk3.am();
				a_2 = x5.a(2f);
				lk3.j((x != null) ? new x5?(x5.f(x.GetValueOrDefault(), a_2)) : null);
				if (A_0.dr().c5().v() == null)
				{
					this.c(A_0);
					lk lk4 = A_0.dr().c5();
					x = lk4.v();
					a_2 = x5.f(A_0.c5().a2(), A_0.c5().a3());
					lk4.i((x != null) ? new x5?(x5.f(x.GetValueOrDefault(), a_2)) : null);
				}
				break;
			}
			}
			return A_0;
		}

		// Token: 0x06000E8F RID: 3727 RVA: 0x000AE754 File Offset: 0x000AD754
		private void a(k0 A_0, int A_1)
		{
			if (A_0.c5().am() == null)
			{
				Font a_ = ((ml)A_0).b().e();
				if (A_0.n() != null && A_0.n().c() != null && !(A_0.n().c().a().l().a().b() is nk))
				{
					n3 n = (n3)A_0.n().c().a().l().a().b();
					A_1--;
					A_0.c5().j(new x5?(this.a(A_0, a_, A_1)));
					n.c5().j(A_0.c5().am());
				}
				else
				{
					A_1 -= 2;
					A_0.c5().j(new x5?(this.a(A_0, a_, A_1)));
				}
				A_0.c5().d(i2.d);
			}
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x000AE860 File Offset: 0x000AD860
		private void c(k0 A_0)
		{
			if (A_0.c5().v() == null)
			{
				Font a_ = null;
				switch (A_0.dz())
				{
				case ko.a:
				case ko.b:
				case ko.f:
				case ko.g:
					a_ = ((ml)A_0).b().e();
					break;
				case ko.c:
				case ko.d:
				case ko.e:
					a_ = ((mh)A_0).a().e();
					break;
				case ko.i:
					a_ = ((ml)A_0).b().e();
					break;
				}
				n5 n = (n5)A_0.db();
				if (A_0.n() != null)
				{
					switch (A_0.dz())
					{
					case ko.a:
					case ko.b:
					case ko.c:
					case ko.d:
					case ko.e:
						A_0.c5().i(new x5?(n4.a(a_, x5.b(n.a().i()), n.n().a(), n.n().c())));
						A_0.c5().a(i2.d);
						break;
					case ko.f:
					case ko.g:
						A_0.c5().i(new x5?(n4.a(a_, x5.b(n.a().i()), n.n().a(), mw.e)));
						A_0.c5().a(i2.d);
						A_0.dr().c5().i(A_0.c5().v());
						A_0.dr().c5().a(i2.d);
						break;
					case ko.i:
						if (A_0.dr().c5().v() == null)
						{
							A_0.c5().i(new x5?(n4.a(a_, x5.b(n.a().i()), n.n().a(), mw.e)));
							A_0.c5().a(i2.d);
							A_0.dr().c5().i(A_0.c5().v());
							A_0.dr().c5().a(i2.d);
						}
						break;
					}
				}
			}
		}

		// Token: 0x06000E91 RID: 3729 RVA: 0x000AEAA0 File Offset: 0x000ADAA0
		private void b(k0 A_0)
		{
			lk lk = A_0.c5();
			if (lk.am() == null)
			{
				Font font = ((mh)A_0).a().e();
				switch (A_0.n().c().a().l().a().b().dg())
				{
				case 100:
				{
					n3 n = (n3)A_0.n().c().a().l().a().b();
					A_0.c5().j(new x5?(x5.a(font.a(n.d(), n.h(), n.ba(), x5.b(((n5)n.db()).a().i())))));
					n.c5().j(A_0.c5().am());
					break;
				}
				case 102:
				{
					nk nk = (nk)A_0.n().c().a().l().a().b();
					A_0.c5().j(new x5?(x5.a(font.a(nk.a(), 0, nk.ba(), x5.b(((n5)A_0.db()).a().i())))));
					nk.c5().j(A_0.c5().am());
					break;
				}
				}
				lk.d(i2.d);
			}
			else
			{
				lk lk2 = lk;
				x5? x = lk2.am();
				x5 a_ = x5.f(x5.f(x5.f(lk.f().d(), lk.f().b()), lk.c().n()), lk.c().r());
				lk2.j((x != null) ? new x5?(x5.e(x.GetValueOrDefault(), a_)) : null);
			}
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x000AECBC File Offset: 0x000ADCBC
		private x5 a(k0 A_0, Font A_1, int A_2)
		{
			ko ko = this.a.a();
			char[] text;
			if (ko != ko.f)
			{
				text = new char[]
				{
					'n'
				};
			}
			else
			{
				text = new char[]
				{
					'4'
				};
			}
			float textWidth = A_1.GetTextWidth(text, x5.b(((n5)A_0.db()).a().i()));
			return x5.a(textWidth * (float)A_2);
		}

		// Token: 0x06000E93 RID: 3731 RVA: 0x000AED38 File Offset: 0x000ADD38
		private void a(k0 A_0)
		{
			x5[] array = new x5[2];
			switch (this.a.a())
			{
			case ko.a:
			case ko.b:
			{
				x5 a_ = x5.a(1.5);
				string a_2 = "#E3E3E3";
				if (this.a.g())
				{
					a_2 = "#A0A0A0";
				}
				array[0] = x5.a(0.75);
				array[1] = x5.a(0.75);
				string a_3 = "Times New Roman";
				x5 a_4 = x5.a(12f);
				this.a(A_0, a_3, a_4);
				this.b(A_0, array);
				this.a(A_0, a_, a_2);
				this.a("white", A_0);
				break;
			}
			case ko.c:
			case ko.d:
			case ko.e:
			{
				string a_5 = "#D8D8D8";
				x5 a_ = x5.a(0.75);
				string a_2 = "#707070";
				if (this.a.g())
				{
					a_2 = "#A0A0A0";
					a_5 = "#F0F0F0";
				}
				array[0] = x5.a(4.5);
				array[1] = x5.c();
				this.b(A_0, array);
				this.a(A_0, a_, a_2);
				this.a(a_5, A_0);
				break;
			}
			case ko.f:
			case ko.g:
			{
				string a_6 = "#F0F0F0";
				x5 a_ = x5.a(0.5);
				string a_2;
				if (this.a.a() == ko.f)
				{
					if (this.a.g())
					{
						a_2 = "#BFBFBF";
					}
					else
					{
						a_2 = "#8E8F8F";
					}
				}
				else
				{
					a_2 = "#8E8F8F";
				}
				array[0] = x5.a(2.25);
				array[1] = x5.a(2.25);
				bool a_7 = !A_0.dr().c5().g();
				this.b((k0)A_0.dr(), array);
				A_0.dr().c5().b(true);
				lk lk = new lk();
				A_0.c5().a(false);
				this.a(A_0, a_, a_2);
				lk.a(A_0.c5().c());
				lk.a(true);
				A_0.c5().a(null);
				this.a(a_6, A_0);
				lk.a(A_0.c5().ay());
				this.a((k0)A_0.dr(), lk, a_7);
				A_0.a(lk);
				A_0.dc(A_0.dr().db());
				break;
			}
			case ko.i:
			{
				string a_3 = "Courier";
				x5 a_4 = x5.a(12f);
				this.a(A_0, a_3, a_4);
				x5 a_ = x5.a(0.75);
				string a_2;
				if (A_0 is ml)
				{
					a_2 = "#E3E3E3";
				}
				else
				{
					a_2 = "#707070";
				}
				this.a(A_0, a_, a_2);
				string a_6 = "#D8D8D8";
				this.a(a_6, A_0);
				break;
			}
			}
		}

		// Token: 0x06000E94 RID: 3732 RVA: 0x000AF08C File Offset: 0x000AE08C
		private void a(k0 A_0, lk A_1, bool A_2)
		{
			if (A_0.c5().ay().e() != null)
			{
				if (A_0.c5().v() != null && A_0.c5().am() != null)
				{
					bool flag = false;
					if (this.a.a() == ko.g)
					{
						flag = true;
					}
					x5 x = x5.f(A_1.c().n(), A_1.c().r());
					x5 x2 = x5.f(A_1.c().f(), A_1.c().j());
					x5 x3 = x5.f(A_0.c5().f().a(), A_0.c5().f().c());
					x5 x4 = x5.f(A_0.c5().f().d(), A_0.c5().f().b());
					x5? x5 = A_0.c5().v();
					x5? x6 = A_0.c5().am();
					x5 a_;
					if ((x5 != null & x6 != null) && x5.d(x5.GetValueOrDefault(), x6.GetValueOrDefault()))
					{
						x5 = A_0.c5().v();
						a_ = x2;
						A_1.i((x5 != null) ? new x5?(x5.e(x5.GetValueOrDefault(), a_)) : null);
						A_1.a(A_0.c5().ah());
						A_1.j(A_0.c5().ac());
						x5 = A_0.c5().v();
						a_ = x;
						A_1.j((x5 != null) ? new x5?(x5.e(x5.GetValueOrDefault(), a_)) : null);
						A_1.d(A_0.c5().ah());
						A_1.o(A_0.c5().ac());
					}
					else
					{
						x5 = A_0.c5().am();
						a_ = x2;
						A_1.i((x5 != null) ? new x5?(x5.e(x5.GetValueOrDefault(), a_)) : null);
						A_1.a(A_0.c5().ap());
						A_1.j(A_0.c5().ao());
						x5 = A_0.c5().am();
						a_ = x;
						A_1.j((x5 != null) ? new x5?(x5.e(x5.GetValueOrDefault(), a_)) : null);
						A_1.d(A_0.c5().ap());
						A_1.o(A_0.c5().ao());
					}
					if (flag && A_2)
					{
						x5 = A_1.v();
						a_ = x3;
						A_1.i((x5 != null) ? new x5?(x5.e(x5.GetValueOrDefault(), a_)) : null);
						x5 = A_1.am();
						a_ = x4;
						A_1.j((x5 != null) ? new x5?(x5.e(x5.GetValueOrDefault(), a_)) : null);
					}
					x5 = A_1.am();
					a_ = x5.a(2f);
					A_1.j((x5 != null) ? new x5?(x5.e(x5.GetValueOrDefault(), a_)) : null);
					((n5)A_0.db()).a().a(x5.e(A_1.v().Value, x));
					if (this.a.g())
					{
						((n5)A_0.db()).a(Color.d("#BFBFBF"));
					}
					else
					{
						((n5)A_0.db()).a(RgbColor.Black);
					}
				}
			}
			else if (!this.a.g())
			{
				((n5)A_0.db()).a(Color.d("#4C6198"));
			}
			else
			{
				((n5)A_0.db()).a(Color.d("#BFBFBF"));
			}
		}

		// Token: 0x06000E95 RID: 3733 RVA: 0x000AF508 File Offset: 0x000AE508
		private void a(k0 A_0, string A_1, x5 A_2)
		{
			if (!A_0.dy())
			{
				l4 l = new l4();
				hd hd = new hd();
				hd.a()[0] = new fb<f5>(2163680, new af0(A_2));
				hd.a()[1] = new fb<f5>(675106854, new afy(A_1));
				l.a(hd.a());
				((n5)A_0.db()).a(l);
			}
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x000AF590 File Offset: 0x000AE590
		private void b(k0 A_0, x5[] A_1)
		{
			switch (A_0.c5().g())
			{
			case false:
			{
				m8 m = new m8();
				m.a(this.a(A_1).a());
				A_0.c5().a(m);
				A_0.c5().b(true);
				break;
			}
			case true:
				if (!A_0.c5().f().i())
				{
					A_0.c5().f().d(A_1[0]);
				}
				if (!A_0.c5().f().j())
				{
					A_0.c5().f().b(A_1[0]);
				}
				if (!A_0.c5().f().k())
				{
					A_0.c5().f().a(A_1[1]);
				}
				if (!A_0.c5().f().l())
				{
					A_0.c5().f().c(A_1[1]);
				}
				break;
			}
		}

		// Token: 0x06000E97 RID: 3735 RVA: 0x000AF6B8 File Offset: 0x000AE6B8
		private void a(k0 A_0, x5 A_1, string A_2)
		{
			if (!A_0.c5().d())
			{
				lf lf = new lf();
				lf.a(this.a(A_1, A_2).a());
				lf.n(true);
				A_0.c5().a(lf);
				A_0.c5().a(true);
			}
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x000AF714 File Offset: 0x000AE714
		private void a(k0 A_0, x5[] A_1)
		{
			if (!A_0.c5().a7())
			{
				m2 m = new m2();
				m.a(this.b(A_1).a());
				A_0.c5().a(m);
				A_0.c5().p(true);
			}
			else
			{
				if (A_0.c5().e().k())
				{
					A_0.c5().e().d(A_1[0]);
				}
				if (A_0.c5().e().l())
				{
					A_0.c5().e().b(A_1[0]);
				}
				if (A_0.c5().e().i())
				{
					A_0.c5().e().a(A_1[0]);
				}
				if (A_0.c5().e().j())
				{
					A_0.c5().e().c(A_1[0]);
				}
			}
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x000AF840 File Offset: 0x000AE840
		private void a(string A_0, k0 A_1)
		{
			if (A_1.c5().ay() != null)
			{
				if (!A_1.c5().ay().b())
				{
					A_1.c5().ay().a(Color.d(A_0));
				}
			}
			else
			{
				fe fe = new fe();
				fb<fs>[] array = new fb<fs>[5];
				array[0] = new fb<fs>(510035525, new afu(A_0));
				fe.a(array);
				k8 k = new k8();
				k.a(array);
				A_1.c5().a(k);
			}
		}

		// Token: 0x06000E9A RID: 3738 RVA: 0x000AF8E0 File Offset: 0x000AE8E0
		private hr b(x5[] A_0)
		{
			hr hr = new hr();
			f9 f = new f9(A_0[0]);
			f9 f2 = new f9(A_0[1]);
			f.a(i2.d);
			f2.a(i2.d);
			hr.a()[0] = new fb<f9>(136794, f2);
			hr.a()[1] = new fb<f9>(426354259, f2);
			hr.a()[2] = new fb<f9>(7021096, f);
			hr.a()[3] = new fb<f9>(448574430, f);
			return hr;
		}

		// Token: 0x06000E9B RID: 3739 RVA: 0x000AF9A0 File Offset: 0x000AE9A0
		private hx a(x5[] A_0)
		{
			hx hx = new hx();
			ge ge = new ge(A_0[0]);
			ge ge2 = new ge(A_0[1]);
			ge.a(i2.d);
			ge2.a(i2.d);
			hx.a()[0] = new fb<ge>(136794, ge2);
			hx.a()[1] = new fb<ge>(426354259, ge2);
			hx.a()[2] = new fb<ge>(7021096, ge);
			hx.a()[3] = new fb<ge>(448574430, ge);
			return hx;
		}

		// Token: 0x06000E9C RID: 3740 RVA: 0x000AFA60 File Offset: 0x000AEA60
		private fg a(x5 A_0, string A_1)
		{
			fg fg = new fg();
			fv a_ = new fv(ft.h);
			fx a_2 = new fx(A_1);
			fw a_3 = new fw(A_0);
			fg.a()[0] = new fb<fu>(548864878, a_);
			fg.a()[1] = new fb<fu>(663309508, a_3);
			fg.a()[2] = new fb<fu>(83960424, a_2);
			fg.a()[3] = new fb<fu>(1274012590, a_);
			fg.a()[4] = new fb<fu>(789921929, a_3);
			fg.a()[5] = new fb<fu>(704614712, a_2);
			fg.a()[6] = new fb<fu>(1304279675, a_);
			fg.a()[7] = new fb<fu>(1930785673, a_3);
			fg.a()[8] = new fb<fu>(1235296202, a_2);
			fg.a()[9] = new fb<fu>(758017896, a_);
			fg.a()[10] = new fb<fu>(1656587748, a_3);
			fg.a()[11] = new fb<fu>(10890914, a_2);
			return fg;
		}

		// Token: 0x06000E9D RID: 3741 RVA: 0x000AFBE4 File Offset: 0x000AEBE4
		internal override kz cm(ij A_0, kz A_1)
		{
			switch (this.a.a())
			{
			case ko.a:
			case ko.b:
				return this.e(A_0, A_1);
			case ko.c:
			case ko.d:
			case ko.e:
				return this.d(A_0, A_1);
			case ko.f:
				return this.b(A_0, A_1);
			case ko.g:
				return this.a(A_0, A_1);
			case ko.h:
			{
				kk kk = new kk();
				kk.b(this.a.f());
				kk.a(this.a.i());
				kj kj = new kj(kk, this.b.k());
				this.b.a(kj);
				A_0.c(this.ch());
				return kj.cm(A_0, A_1);
			}
			case ko.i:
				return this.c(A_0, A_1);
			}
			A_0.a(false);
			return null;
		}

		// Token: 0x04000723 RID: 1827
		private new kp a = null;

		// Token: 0x04000724 RID: 1828
		private kn b = null;

		// Token: 0x04000725 RID: 1829
		private bool c = false;

		// Token: 0x04000726 RID: 1830
		private new kg d = null;
	}
}
