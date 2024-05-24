using System;

namespace zz93
{
	// Token: 0x0200022A RID: 554
	internal class og : dy
	{
		// Token: 0x06001A1A RID: 6682 RVA: 0x0010F474 File Offset: 0x0010E474
		internal og(jk A_0, om A_1, p1 A_2, kg A_3, ij A_4) : base(null)
		{
			this.a = A_1;
			this.b = new oh(A_0, A_3, A_2, A_4);
			this.b.cq();
		}

		// Token: 0x06001A1B RID: 6683 RVA: 0x0010F4C4 File Offset: 0x0010E4C4
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001A1C RID: 6684 RVA: 0x0010F4DC File Offset: 0x0010E4DC
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001A1D RID: 6685 RVA: 0x0010F4F4 File Offset: 0x0010E4F4
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001A1E RID: 6686 RVA: 0x0010F50C File Offset: 0x0010E50C
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001A1F RID: 6687 RVA: 0x0010F518 File Offset: 0x0010E518
		internal override kz cm(ij A_0, kz A_1)
		{
			mx mx = new mx();
			this.a(A_0);
			A_0.c(this.ch());
			A_0.a(mx);
			n5 n = (n5)mx.db();
			mx.c5().c().i(n.j());
			A_0.b(mx);
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = mx.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					mx = null;
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
				mx.j(A_1);
				i3.a(mx);
				i3.a(mx, A_0);
				m4.a(n, mx.c5(), a_);
				if (n.b().b() == ok.v)
				{
					if (A_1.dg() == 2595)
					{
						if (((n5)A_1.db()).b().b() == ok.v)
						{
							switch (A_1.bc())
							{
							case 1:
								n.b().a(ok.f);
								goto IL_170;
							case 2:
								n.b().a(ok.h);
								goto IL_170;
							}
							n.b().a(ok.g);
							IL_170:;
						}
						else
						{
							n.b().a(((n5)A_1.db()).b().b());
						}
					}
				}
				if (mx.c5().ay().d() && mx.c5().ay().e() != null)
				{
					mx.b(mg.a(A_0, mx.c5().ay().e(), A_0.e()));
				}
				if (this.a.b() != -2147483648)
				{
					mx.a(this.a.b());
				}
				base.f(mx, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return mx;
		}

		// Token: 0x06001A20 RID: 6688 RVA: 0x0010F7A8 File Offset: 0x0010E7A8
		private void a(ij A_0)
		{
			if (this.a.a() != ok.i)
			{
				hq hq = new hq();
				af4 a_ = new af4(null);
				af5 a_2 = new af5(hp.b);
				af6 a_3 = new af6(ok.v);
				switch (this.a.a())
				{
				case ok.a:
				case ok.b:
				case ok.c:
				case ok.d:
				case ok.e:
				case ok.f:
				case ok.g:
				case ok.h:
					a_3 = new af6(this.a.a());
					break;
				}
				fb<f8>[] array = new fb<f8>[3];
				array[0].a(514326864);
				array[0].a(a_);
				array[1].a(389285250);
				array[1].a(a_2);
				array[2].a(430959576);
				array[2].a(a_3);
				hq.a(array);
				ig a_4 = new ig(new fc[]
				{
					new fc(6947816, hq)
				});
				A_0.a(this.ch().cn(), a_4);
				A_0.a(true);
			}
		}

		// Token: 0x04000BCA RID: 3018
		private new om a = null;

		// Token: 0x04000BCB RID: 3019
		private oh b = null;

		// Token: 0x04000BCC RID: 3020
		private bool c = true;
	}
}
