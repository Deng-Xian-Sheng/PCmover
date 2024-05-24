using System;
using System.Collections.Generic;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000213 RID: 531
	internal class nt : k0
	{
		// Token: 0x0600184B RID: 6219 RVA: 0x00101610 File Offset: 0x00100610
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600184C RID: 6220 RVA: 0x00101628 File Offset: 0x00100628
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x0600184D RID: 6221 RVA: 0x00101638 File Offset: 0x00100638
		internal override nw dv()
		{
			return this.b;
		}

		// Token: 0x0600184E RID: 6222 RVA: 0x00101650 File Offset: 0x00100650
		internal override void dw(nw A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600184F RID: 6223 RVA: 0x0010165C File Offset: 0x0010065C
		internal override int dg()
		{
			return 3418;
		}

		// Token: 0x06001850 RID: 6224 RVA: 0x00101674 File Offset: 0x00100674
		internal override bool de()
		{
			return true;
		}

		// Token: 0x06001851 RID: 6225 RVA: 0x00101688 File Offset: 0x00100688
		internal ja g()
		{
			return this.e;
		}

		// Token: 0x06001852 RID: 6226 RVA: 0x001016A0 File Offset: 0x001006A0
		internal void a(ja A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001853 RID: 6227 RVA: 0x001016AC File Offset: 0x001006AC
		internal override k0 dd()
		{
			nt nt = new nt();
			nt.dw(this.dv());
			nt.c = this.c;
			nt.ab(base.ci());
			nt.aa(base.ch());
			nt.a7(this.dn());
			nt.a8(this.dp());
			return nt;
		}

		// Token: 0x06001854 RID: 6228 RVA: 0x00101714 File Offset: 0x00100714
		internal int h()
		{
			return this.c;
		}

		// Token: 0x06001855 RID: 6229 RVA: 0x0010172C File Offset: 0x0010072C
		internal void a(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001856 RID: 6230 RVA: 0x00101738 File Offset: 0x00100738
		internal int i()
		{
			return this.d;
		}

		// Token: 0x06001857 RID: 6231 RVA: 0x00101750 File Offset: 0x00100750
		internal void b(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001858 RID: 6232 RVA: 0x0010175C File Offset: 0x0010075C
		internal x5 j()
		{
			return this.f;
		}

		// Token: 0x06001859 RID: 6233 RVA: 0x00101774 File Offset: 0x00100774
		private void b(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			if (this.b.h() != il.b)
			{
				if (base.c5().c().o() != ft.a && base.c5().c().o() != ft.j)
				{
					A_3 = x5.e(A_3, base.c5().c().n());
					A_1 = x5.f(A_1, base.c5().c().n());
				}
				if (base.c5().c().s() != ft.a && base.c5().c().s() != ft.j)
				{
					A_3 = x5.e(A_3, base.c5().c().r());
				}
				if (base.c5().c().g() != ft.a && base.c5().c().g() != ft.j)
				{
					A_4 = x5.e(A_4, base.c5().c().f());
					A_2 = x5.f(A_2, base.c5().c().f());
				}
				if (base.c5().c().k() != ft.a && base.c5().c().k() != ft.j)
				{
					A_4 = x5.e(A_4, base.c5().c().j());
				}
			}
			else
			{
				if (base.c5().c().ac() != ft.a && base.c5().c().ac() != ft.j)
				{
					A_3 = x5.e(A_3, base.c5().c().ab());
					A_1 = x5.f(A_1, base.c5().c().ab());
				}
				if (base.c5().c().af() != ft.a && base.c5().c().af() != ft.j)
				{
					A_3 = x5.e(A_3, base.c5().c().ae());
				}
				if (base.c5().c().w() != ft.a && base.c5().c().w() != ft.j)
				{
					A_4 = x5.e(A_4, base.c5().c().v());
					A_2 = x5.f(A_2, base.c5().c().v());
				}
				if (base.c5().c().z() != ft.a && base.c5().c().z() != ft.j)
				{
					A_4 = x5.e(A_4, base.c5().c().y());
				}
			}
			this.a(A_0, A_1, A_2, A_3, A_4);
			if (base.w() != null)
			{
				base.w().a(base.c5(), A_0, A_1, A_2, A_3, A_4);
			}
		}

		// Token: 0x0600185A RID: 6234 RVA: 0x00101A78 File Offset: 0x00100A78
		private void a(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3, x5 A_4)
		{
			Color color = base.c5().ay().a();
			kz kz = this.dr();
			while (color == null && kz != null)
			{
				if (kz.dg() == 144937050)
				{
					List<kz> list = ((nv)kz).g();
					if (list != null)
					{
						int num = 0;
						for (int i = 0; i < list.Count; i++)
						{
							if (i == this.c)
							{
								color = list[this.c].c5().ay().a();
								break;
							}
							if (num == this.c)
							{
								color = list[i].c5().ay().a();
								break;
							}
							int num2 = ((n5)list[i].db()).y();
							if (num2 > 1 && i < this.c && num2 + i > this.c)
							{
								color = list[i].c5().ay().a();
								break;
							}
							num += num2;
						}
					}
					break;
				}
				color = kz.c5().ay().a();
				kz = kz.dr();
			}
			if (color != null)
			{
				A_0.SetGraphicsMode();
				A_0.SetFillColor(color);
				A_0.Write_re(x5.b(A_1), x5.b(A_2), x5.b(A_3), x5.b(A_4));
				A_0.Write_f();
			}
		}

		// Token: 0x0600185B RID: 6235 RVA: 0x00101C40 File Offset: 0x00100C40
		private void b(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3, Color A_4)
		{
			if (x5.c(A_3, x5.c()) && A_4 != null)
			{
				A_0.SetGraphicsMode();
				A_0.SetFillColor(A_4);
				A_0.SetLineStyle(LineStyle.Solid);
				A_0.SetLineWidth(0.1f);
				A_0.Write_re(x5.b(A_1) + 0.2f, x5.b(A_2), x5.b(A_3) - 0.5f, x5.b(base.ar()) + 1f);
				A_0.Write_f();
			}
		}

		// Token: 0x0600185C RID: 6236 RVA: 0x00101CD8 File Offset: 0x00100CD8
		private void a(PageWriter A_0, x5 A_1, x5 A_2, x5 A_3, Color A_4)
		{
			if (x5.g(A_3, x5.c()) && A_4 != null)
			{
				A_0.SetGraphicsMode();
				A_0.SetFillColor(A_4);
				A_0.SetLineWidth(0.1f);
				A_0.SetLineStyle(LineStyle.Solid);
				A_0.Write_re(x5.b(A_1), x5.b(A_2) + 0.2f, x5.b(base.aq()) + 0.5f, x5.b(A_3) - 0.5f);
				A_0.Write_f();
			}
		}

		// Token: 0x0600185D RID: 6237 RVA: 0x00101D70 File Offset: 0x00100D70
		private void a(PageWriter A_0, x5 A_1)
		{
			List<li> list = this.c8().b();
			for (int i = 0; i < list.Count; i++)
			{
				int num = list[i].a().dg();
				if (num != 46415)
				{
					list[i].a().dk(A_0, x5.f(A_1, list[i].a().an()), list[i].a().ao());
				}
				else
				{
					((md)list[i].a()).dk(A_0, x5.f(A_1, list[i].a().an()), x5.f(list[i].a().ao(), list[i].a().ar()));
				}
			}
		}

		// Token: 0x0600185E RID: 6238 RVA: 0x00101E74 File Offset: 0x00100E74
		private Color f()
		{
			Color color = null;
			kz kz = this.dr();
			while (color == null && kz != null)
			{
				color = kz.c5().ay().a();
				kz = kz.dr();
			}
			return color;
		}

		// Token: 0x0600185F RID: 6239 RVA: 0x00101EC0 File Offset: 0x00100EC0
		private void a(ms A_0)
		{
			mr a_ = A_0.l().a();
			x5 a_2 = this.e();
			x5 x = A_0.r();
			switch (this.a.r())
			{
			case gn.b:
				x = x5.e(x5.e(base.aq(), a_2), x);
				this.a(a_, x);
				break;
			case gn.c:
				x = x5.e(x5.e(base.aq(), a_2), x);
				x = x5.a(x, 2);
				x = x5.f(x, this.b());
				this.a(a_, x);
				break;
			}
		}

		// Token: 0x06001860 RID: 6240 RVA: 0x00101F60 File Offset: 0x00100F60
		private void a(mr A_0, x5 A_1)
		{
			while (A_0 != null && A_0.b() != null)
			{
				switch (A_0.b().dg())
				{
				case 100:
				case 101:
				case 102:
					A_0.b().au(A_1);
					break;
				default:
				{
					kz kz = A_0.b();
					kz.au(x5.f(kz.cc(), A_1));
					break;
				}
				}
				A_0 = A_0.c();
			}
		}

		// Token: 0x06001861 RID: 6241 RVA: 0x00101FE0 File Offset: 0x00100FE0
		private x5 b(mu A_0)
		{
			x5 x = this.a(A_0);
			x5 result = x5.c();
			if (!base.t())
			{
				x5 a_ = x5.f(this.d(), this.c());
				if (this.a.h() == gs.a)
				{
					this.a.a(((n5)this.dr().db()).h());
					this.a.b(((n5)this.dr().db()).i());
				}
				switch (this.a.h())
				{
				case gs.b:
				case gs.c:
				case gs.d:
				case gs.f:
				case gs.i:
				case gs.j:
				case gs.k:
					goto IL_11A;
				case gs.e:
					goto IL_11A;
				case gs.h:
					x = x5.e(x5.e(base.ar(), a_), x);
					result = x;
					goto IL_11A;
				}
				x = x5.e(x5.e(base.ar(), a_), x);
				if (x5.c(x, x5.c()))
				{
					x = x5.a(x, 2);
				}
				result = x;
				IL_11A:;
			}
			return result;
		}

		// Token: 0x06001862 RID: 6242 RVA: 0x00102110 File Offset: 0x00101110
		private x5 a(mu A_0)
		{
			x5 x = x5.c();
			x5 a_ = x5.c();
			x5 a_2 = x5.c();
			x5 a_3 = x5.c();
			if (A_0 != null && A_0.a() != null)
			{
				a_ = A_0.a().ag();
			}
			while (A_0 != null && A_0.a() != null)
			{
				if (A_0.b() == null || A_0.b().a() == null)
				{
					a_2 = A_0.a().ag();
					a_3 = A_0.a().n();
				}
				A_0 = A_0.b();
			}
			return x5.f(x5.e(a_2, a_), a_3);
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x001021D0 File Offset: 0x001011D0
		private x5 e()
		{
			return x5.f(this.b(), this.a());
		}

		// Token: 0x06001864 RID: 6244 RVA: 0x001021F4 File Offset: 0x001011F4
		private x5 d()
		{
			x5 result;
			if (this.b.h() != il.b)
			{
				result = x5.f(x5.f(base.c5().c().f(), base.c5().e().a()), base.c5().f().a());
			}
			else if (!base.s())
			{
				result = x5.f(x5.f(base.c5().c().v(), base.c5().e().a()), base.c5().f().a());
			}
			else
			{
				result = x5.c();
			}
			return result;
		}

		// Token: 0x06001865 RID: 6245 RVA: 0x001022A4 File Offset: 0x001012A4
		private x5 c()
		{
			x5 result;
			if (this.b.h() != il.b)
			{
				result = x5.f(x5.f(base.c5().c().j(), base.c5().e().c()), base.c5().f().c());
			}
			else
			{
				result = x5.f(x5.f(base.c5().c().y(), base.c5().e().c()), base.c5().f().c());
			}
			return result;
		}

		// Token: 0x06001866 RID: 6246 RVA: 0x00102344 File Offset: 0x00101344
		private x5 b()
		{
			x5 result;
			if (this.b.h() != il.b)
			{
				result = x5.f(x5.f(base.c5().c().n(), base.c5().e().d()), base.c5().f().d());
			}
			else
			{
				result = x5.f(x5.f(base.c5().c().ab(), base.c5().e().d()), base.c5().f().d());
			}
			return result;
		}

		// Token: 0x06001867 RID: 6247 RVA: 0x001023E4 File Offset: 0x001013E4
		private x5 a()
		{
			x5 result;
			if (this.b.h() != il.b)
			{
				result = x5.f(x5.f(base.c5().c().r(), base.c5().e().b()), base.c5().f().b());
			}
			else
			{
				result = x5.f(x5.f(base.c5().c().ae(), base.c5().e().b()), base.c5().f().b());
			}
			return result;
		}

		// Token: 0x06001868 RID: 6248 RVA: 0x00102484 File Offset: 0x00101484
		internal x5 k()
		{
			return x5.f(x5.f(base.c5().c().f(), base.c5().c().j()), x5.e(x5.e(base.ar(), base.c5().c().v()), base.c5().c().y()));
		}

		// Token: 0x06001869 RID: 6249 RVA: 0x001024F0 File Offset: 0x001014F0
		internal x5 l()
		{
			return x5.f(x5.f(base.c5().c().n(), base.c5().c().r()), this.f);
		}

		// Token: 0x0600186A RID: 6250 RVA: 0x00102534 File Offset: 0x00101534
		internal nt m()
		{
			nt nt = new nt();
			nt.u(true);
			nt.a(base.c5());
			nt.dc(this.db().du());
			nt.dw(this.dv());
			nt.j(this.dr());
			nt.a8(this.dp());
			nt.a7(this.dn());
			nt.a(this.c);
			nt.d2(this.d1());
			nt.b(base.w());
			return nt;
		}

		// Token: 0x0600186B RID: 6251 RVA: 0x001025D0 File Offset: 0x001015D0
		internal void a(x5 A_0)
		{
			this.f = A_0;
			if (this.b != null && this.b.h() == il.b)
			{
				if (this.a.z() == 1)
				{
					this.f = x5.e(this.f, base.c5().c().ab());
					this.f = x5.e(this.f, base.c5().c().ae());
				}
				else
				{
					if (x5.c(base.c5().c().n(), base.c5().c().ab()))
					{
						this.f = x5.e(this.f, base.c5().c().n());
					}
					else
					{
						this.f = x5.e(this.f, base.c5().c().ab());
					}
					if (x5.c(base.c5().c().r(), base.c5().c().ae()))
					{
						this.f = x5.e(this.f, base.c5().c().r());
					}
					else
					{
						this.f = x5.e(this.f, base.c5().c().ae());
					}
				}
			}
		}

		// Token: 0x0600186C RID: 6252 RVA: 0x0010274C File Offset: 0x0010174C
		internal override x5 dh()
		{
			x5 x = x5.c();
			x5 a_ = base.al();
			bool flag = true;
			bool flag2 = false;
			x5 x2 = x5.c();
			x5 a_2 = x5.c();
			x5 x3 = x5.c();
			if (base.n() != null)
			{
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					mr mr = ms.l().a();
					while (mr != null && mr.b() != null)
					{
						x3 = mr.b().dh();
						bool flag3 = mr.b().b0();
						if (mr.b().c5().u())
						{
							g2 valueOrDefault = mr.b().c5().t().GetValueOrDefault();
							g2? g;
							if (g == null)
							{
								goto IL_1AE;
							}
							if (valueOrDefault != g2.c)
							{
								goto IL_1AE;
							}
							if (flag)
							{
								if (!flag2 && !flag3)
								{
									if (mr.b().dg() == 46415)
									{
										x2 = x5.f(x2, x3);
									}
									else
									{
										x2 = x5.f(x2, mr.b().b2());
										if (x5.d(x2, x3))
										{
											x2 = x3;
										}
									}
								}
								else
								{
									if (x5.c(x2, x3) && x5.c(x2, x))
									{
										x = x2;
									}
									x2 = x3;
								}
							}
							else
							{
								if (x5.c(x2, x3) && x5.c(x2, x))
								{
									x = x2;
								}
								x2 = x3;
								flag = true;
							}
							goto IL_309;
							IL_1AE:
							if (x5.d(a_2, x3))
							{
								a_2 = x3;
							}
							flag = false;
						}
						else
						{
							switch (flag)
							{
							case false:
								if (!mr.b().de())
								{
									if (x5.c(x2, x3) && x5.c(x2, x))
									{
										x = x2;
									}
									x2 = x3;
									flag = true;
								}
								else
								{
									if (x5.d(a_2, x3))
									{
										a_2 = x3;
									}
									flag = false;
								}
								break;
							case true:
								if (!mr.b().de())
								{
									if (!flag2 && !flag3)
									{
										if (mr.b().dg() == 46415)
										{
											x2 = x5.f(x2, x3);
										}
										else
										{
											x2 = x5.f(x2, mr.b().b2());
											if (x5.d(x2, x3))
											{
												x2 = x3;
											}
										}
									}
									else
									{
										if (x5.c(x2, x3) && x5.c(x2, x))
										{
											x = x2;
										}
										x2 = x3;
									}
								}
								else
								{
									if (x5.d(a_2, x3))
									{
										a_2 = x3;
									}
									flag = false;
								}
								break;
							}
						}
						IL_309:
						flag2 = (mr.b().dg() == 46415 || mr.b().b1());
						mr = mr.c();
					}
					mu = mu.b();
					flag2 = true;
				}
			}
			if (x5.h(x, x5.c()))
			{
				x = x5.a(0.001);
			}
			if (x5.c(x2, x))
			{
				x = x2;
			}
			if (x5.c(a_2, x))
			{
				this.a8(x5.f(a_2, a_));
			}
			else
			{
				this.a8(x5.f(x, a_));
			}
			if (base.c5().am() != null && !base.c5().ao() && x5.c(base.c5().am().Value, this.dp()))
			{
				this.a8(base.c5().am().Value);
			}
			return this.dp();
		}

		// Token: 0x0600186D RID: 6253 RVA: 0x00102BC0 File Offset: 0x00101BC0
		internal override void di()
		{
			base.ak();
			if (base.c5().am() != null && !base.c5().ao() && x5.c(base.c5().am().Value, this.dn()))
			{
				this.a7(base.c5().am().Value);
			}
			if (base.ch() && !base.ci())
			{
				this.a8(this.dn());
			}
		}

		// Token: 0x0600186E RID: 6254 RVA: 0x00102C60 File Offset: 0x00101C60
		internal override kz dj(x5 A_0, x5 A_1)
		{
			base.l(A_0);
			base.ah(A_0);
			base.c5().j(new x5?(A_0));
			base.c5().d(i2.d);
			base.c5().o(false);
			return base.f(A_0, A_1);
		}

		// Token: 0x0600186F RID: 6255 RVA: 0x00102CB8 File Offset: 0x00101CB8
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c5().c().g(base.s());
			base.c5().c().h(base.t());
			base.a(base.c5());
			x5 x = x5.c();
			x5 a_ = x5.c();
			x5 a_2 = x5.c();
			x5 a_3 = x5.c();
			x5 x2 = x5.f(A_2, base.c5().e().a());
			x5 x3 = x5.e(x5.e(base.ar(), base.c5().e().a()), base.c5().e().c());
			x5 x4 = x5.e(x5.e(base.aq(), base.c5().e().d()), base.c5().e().b());
			x5 x5 = A_2;
			if (base.n() != null)
			{
				this.b(A_0, A_1, x2, x4, x3);
				x5 a_4 = base.c5().f().d();
				if (this.b.h() != il.b)
				{
					if (base.c5().c().o() != ft.a)
					{
						x = base.c5().c().n();
					}
					if (base.c5().c().g() != ft.a)
					{
						a_2 = base.c5().c().f();
					}
					if (base.c5().c().s() != ft.a)
					{
						a_ = base.c5().c().r();
					}
					if (base.c5().c().k() != ft.a)
					{
						a_3 = base.c5().c().j();
					}
					base.c5().c().a(A_0, A_1, x2, x4, x3);
				}
				else
				{
					if (base.c5().c().ac() != ft.a)
					{
						x = base.c5().c().ab();
					}
					if (base.c5().c().w() != ft.a)
					{
						a_2 = base.c5().c().v();
					}
				}
				mu mu = base.n().c();
				x5 a_5 = x5.c();
				if (this.c8().b().Count == 0)
				{
					a_5 = this.b(mu);
				}
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					switch (base.c5().az())
					{
					case g9.b:
					case g9.c:
						ms.m(true);
						break;
					default:
						ms.m(false);
						break;
					}
					if (ms.l() != null)
					{
						this.a(ms);
						x5 = x5.f(A_2, a_5);
						if (this.a.r() == gn.a || this.a.r() == gn.e)
						{
							ms.a(A_0, x5.f(x5.f(A_1, a_4), x), x5);
						}
						else
						{
							ms.a(A_0, A_1, x5);
						}
					}
					mu = mu.b();
				}
				this.a(A_0, A_1);
			}
			else
			{
				this.b(A_0, A_1, x2, x4, x3);
				if (this.b.h() != il.b)
				{
					if (base.c5().c().o() != ft.a)
					{
						x = base.c5().c().n();
					}
					if (base.c5().c().g() != ft.a)
					{
						a_2 = base.c5().c().f();
					}
					if (base.c5().c().s() != ft.a)
					{
						a_ = base.c5().c().r();
					}
					if (base.c5().c().k() != ft.a)
					{
						a_3 = base.c5().c().j();
					}
					base.c5().c().a(A_0, x5.f(A_1, x5.a(x5.b(x) / 2f)), x5.f(x2, x5.a(x5.b(a_2) / 2f)), x5.e(x5.e(x4, x5.a(x5.b(x) / 2f)), x5.a(x5.b(a_) / 2f)), x5.e(x3, x5.a(x5.b(a_3) / 2f)));
				}
			}
			base.i(A_1);
			base.j(x5);
		}

		// Token: 0x06001870 RID: 6256 RVA: 0x001031A0 File Offset: 0x001021A0
		internal override kz dm()
		{
			nt nt = new nt();
			nt.j(this.dr());
			nt.dc(this.db().du());
			nt.a((lk)base.c5().du());
			nt.dw((nw)this.dv().du());
			nt.c = this.c;
			nt.b(this.d);
			nt.a(this.e);
			if (base.n() != null)
			{
				nt.c(base.n().p());
			}
			return nt;
		}

		// Token: 0x04000AE6 RID: 2790
		private new n5 a = new n5();

		// Token: 0x04000AE7 RID: 2791
		private new nw b = null;

		// Token: 0x04000AE8 RID: 2792
		private new int c = 0;

		// Token: 0x04000AE9 RID: 2793
		private new int d = 0;

		// Token: 0x04000AEA RID: 2794
		private new ja e = null;

		// Token: 0x04000AEB RID: 2795
		private new x5 f = x5.c();
	}
}
