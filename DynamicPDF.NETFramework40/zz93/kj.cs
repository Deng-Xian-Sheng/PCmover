using System;
using System.IO;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200019B RID: 411
	internal class kj : dy
	{
		// Token: 0x06000E6B RID: 3691 RVA: 0x000AC538 File Offset: 0x000AB538
		internal kj(kk A_0, p1 A_1) : base(A_1)
		{
			this.a = A_0;
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x000AC559 File Offset: 0x000AB559
		internal kj(kk A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000E6D RID: 3693 RVA: 0x000AC57C File Offset: 0x000AB57C
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000E6E RID: 3694 RVA: 0x000AC594 File Offset: 0x000AB594
		internal override bool ci()
		{
			return this.b;
		}

		// Token: 0x06000E6F RID: 3695 RVA: 0x000AC5AC File Offset: 0x000AB5AC
		internal override void cj(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06000E70 RID: 3696 RVA: 0x000AC5B8 File Offset: 0x000AB5B8
		private void a(me A_0, lk A_1)
		{
			if (this.a.a() != null)
			{
				A_0.a(this.a.a());
				A_0.a(Font.Helvetica);
			}
			switch (this.a.c())
			{
			case ea.b:
				if (!A_1.m())
				{
					A_1.a(g3.a);
				}
				break;
			case ea.c:
				if (!A_1.m())
				{
					A_1.a(g3.b);
				}
				break;
			case ea.d:
				if (A_0.c() == gs.a)
				{
					A_0.a(gs.g);
					A_0.a(x5.c());
				}
				break;
			case ea.e:
				if (A_0.c() == gs.a)
				{
					A_0.a(gs.e);
					A_0.a(x5.c());
				}
				break;
			case ea.f:
				if (A_0.c() == gs.a)
				{
					A_0.a(gs.h);
					A_0.a(x5.c());
				}
				break;
			}
			if (A_1.am() == null && this.a.g().a().a() != 0f)
			{
				A_1.j(new x5?(new f9(m4.a(this.a.g())).c()));
				A_1.d(this.a.g().a().b());
			}
			if (A_1.v() == null)
			{
				if (this.a.e().a().a() != 0f)
				{
					A_1.i(new x5?(new f9(m4.a(this.a.e())).c()));
					A_1.a(this.a.e().a().b());
				}
				else if (this.a.f())
				{
					A_1.i(new x5?(x5.a(0.75)));
					A_1.a(this.a.e().a().b());
				}
			}
			if (!A_1.d() && this.a.d() != -2147483648)
			{
				fg fg = new fg();
				fv a_ = new fv(ft.h);
				fw a_2 = new fw(x5.a((float)this.a.d()));
				fg.a()[0] = new fb<fu>(548864878, a_);
				fg.a()[1] = new fb<fu>(663309508, a_2);
				fg.a()[2] = new fb<fu>(1274012590, a_);
				fg.a()[3] = new fb<fu>(789921929, a_2);
				fg.a()[4] = new fb<fu>(1304279675, a_);
				fg.a()[5] = new fb<fu>(1930785673, a_2);
				fg.a()[6] = new fb<fu>(758017896, a_);
				fg.a()[7] = new fb<fu>(1656587748, a_2);
				lf lf = new lf();
				lf.a(fg.a());
				A_1.a(lf);
			}
		}

		// Token: 0x06000E71 RID: 3697 RVA: 0x000AC994 File Offset: 0x000AB994
		internal override kz cm(ij A_0, kz A_1)
		{
			md md = new md();
			if (A_1.dg() != 445520207)
			{
				A_0.c(this.a);
			}
			A_0.a(md);
			me me = (me)md.db();
			md.c5().c().i(me.f());
			A_0.b(md);
			bool flag = true;
			bool a_ = false;
			lk lk = md.c5();
			g2? g = md.c5().t();
			g2 valueOrDefault = g.GetValueOrDefault();
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					md = null;
					flag = false;
					break;
				case g2.c:
					a_ = true;
					break;
				}
			}
			if (flag)
			{
				md.j(A_1);
				if (md.ch())
				{
					md.ab(A_1.ci());
					md.aa(A_1.ch());
					md.ay(A_1.ck());
				}
				A_0.a(false);
				try
				{
					if (this.a.b() != null)
					{
						bool flag2 = false;
						if (this.a.b().Contains("base64"))
						{
							md.a(A_0, this.a.b(), null);
							flag2 = true;
						}
						else if (A_0.d() == null)
						{
							Uri uri = new Uri(this.a.b());
							if (uri.IsFile)
							{
								A_0.a(new Uri(Path.GetDirectoryName(this.a.b())));
							}
							else
							{
								A_0.a(uri);
							}
						}
						if (!flag2)
						{
							md.a(A_0, this.a.b(), A_0.e());
						}
					}
				}
				catch (Exception)
				{
				}
				n5 a_2 = (n5)A_1.db();
				m4.a(a_2, md.c5(), a_);
				if (md.c5().ay().e() != null)
				{
					md.a(mg.a(A_0, md.c5().ay().e(), A_0.e()));
				}
				this.a((me)md.db(), md.c5());
				g6 g2 = lk.q();
				if (g2 != g6.c)
				{
					switch (lk.n())
					{
					case g3.a:
					case g3.b:
						goto IL_2B9;
					}
					g = lk.t();
					valueOrDefault = g.GetValueOrDefault();
					if (g != null)
					{
						switch (valueOrDefault)
						{
						case g2.b:
							this.b = true;
							break;
						}
					}
					IL_2B9:;
				}
			}
			A_0.a(false);
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return md;
		}

		// Token: 0x04000719 RID: 1817
		private new kk a = null;

		// Token: 0x0400071A RID: 1818
		private bool b = false;
	}
}
