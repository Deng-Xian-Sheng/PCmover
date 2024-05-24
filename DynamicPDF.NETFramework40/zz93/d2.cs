using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x020000B2 RID: 178
	internal class d2 : dy
	{
		// Token: 0x06000868 RID: 2152 RVA: 0x00075DDB File Offset: 0x00074DDB
		internal d2(eb A_0, kg A_1) : base(null)
		{
			this.a = A_0;
			this.b = new d4(A_1);
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x00075E18 File Offset: 0x00074E18
		internal d2(eb A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new d4(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x00075E70 File Offset: 0x00074E70
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00075E88 File Offset: 0x00074E88
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x00075EA0 File Offset: 0x00074EA0
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x00075EB8 File Offset: 0x00074EB8
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x00075EC4 File Offset: 0x00074EC4
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00075ED8 File Offset: 0x00074ED8
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x00075EF0 File Offset: 0x00074EF0
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00075EFC File Offset: 0x00074EFC
		internal override kz cm(ij A_0, kz A_1)
		{
			k4 k = new k4(this.a.b(), this.b.l().y());
			A_0.c(this.ch());
			A_0.a(k);
			n5 n = (n5)k.db();
			k.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(k);
			}
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = k.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					k = null;
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
				k.j(A_1);
				if (this.a.c() != null)
				{
					k.b(this.a.c());
				}
				if (k.c5().ay().e() != null)
				{
					k.b(mg.a(A_0, k.c5().ay().e(), A_0.e()));
				}
				if (this.a.b() != null)
				{
					A_0.a(true);
					n.a(this.a.b());
					if (n.w())
					{
						n.m()[0] = gx.b;
					}
					if (n.u())
					{
						n.a(Color.d("blue"));
					}
					if (this.a.b() != null && n.u())
					{
						iv iv = new iv();
						iv.a(new go("Blue"));
						ig a_2 = new ig(new fc[]
						{
							new fc(510035525, iv)
						});
						A_0.a(this.ch().cn(), a_2);
					}
					if (((n5)k.db()).w())
					{
						iw iw = new iw();
						iw.a(new ix[]
						{
							new ix(gx.b)
						});
						ig a_3 = new ig(new fc[]
						{
							new fc(633671921, iw)
						});
						A_0.a(this.ch().cn(), a_3);
					}
				}
				else
				{
					if (n.u())
					{
						n.a(Color.d("black"));
					}
					if (n.w())
					{
						n.m()[0] = gx.a;
					}
				}
				i3.a(k);
				i3.a(k, A_0);
				m4.a(n, k.c5(), a_);
				base.e(k, A_0);
				A_0.a(false);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return k;
		}

		// Token: 0x04000485 RID: 1157
		private new eb a = null;

		// Token: 0x04000486 RID: 1158
		private d4 b = null;

		// Token: 0x04000487 RID: 1159
		private bool c = false;

		// Token: 0x04000488 RID: 1160
		private new bool d = true;
	}
}
