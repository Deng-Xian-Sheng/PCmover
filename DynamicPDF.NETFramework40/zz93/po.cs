using System;

namespace zz93
{
	// Token: 0x02000256 RID: 598
	internal class po : dy
	{
		// Token: 0x06001B45 RID: 6981 RVA: 0x00119E74 File Offset: 0x00118E74
		internal po(pp A_0)
		{
			this.a = A_0;
			this.c = new kl(this.a.cn());
		}

		// Token: 0x06001B46 RID: 6982 RVA: 0x00119ECC File Offset: 0x00118ECC
		internal po(pp A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.c = new kl(A_2, A_1, A_3);
			this.c.cq();
		}

		// Token: 0x06001B47 RID: 6983 RVA: 0x00119F28 File Offset: 0x00118F28
		internal po(ns A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.b = A_0;
			this.c = new kl(A_2, A_1, A_3);
			this.c.cq();
		}

		// Token: 0x06001B48 RID: 6984 RVA: 0x00119F84 File Offset: 0x00118F84
		internal override d3 cg()
		{
			return this.c;
		}

		// Token: 0x06001B49 RID: 6985 RVA: 0x00119F9C File Offset: 0x00118F9C
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001B4A RID: 6986 RVA: 0x00119FB4 File Offset: 0x00118FB4
		internal override bool ci()
		{
			return this.d;
		}

		// Token: 0x06001B4B RID: 6987 RVA: 0x00119FCC File Offset: 0x00118FCC
		internal override void cj(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001B4C RID: 6988 RVA: 0x00119FD8 File Offset: 0x00118FD8
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x06001B4D RID: 6989 RVA: 0x00119FEC File Offset: 0x00118FEC
		internal override bool ck()
		{
			return this.e;
		}

		// Token: 0x06001B4E RID: 6990 RVA: 0x0011A004 File Offset: 0x00119004
		internal override void cl(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001B4F RID: 6991 RVA: 0x0011A010 File Offset: 0x00119010
		internal override kz cm(ij A_0, kz A_1)
		{
			no no = new no();
			if (this.ch() != null)
			{
				A_0.c(this.ch());
			}
			else
			{
				A_0.c(this.b);
			}
			A_0.a(no);
			n5 n = (n5)no.db();
			no.c5().c().i(n.j());
			if (this.e)
			{
				A_0.b(no);
			}
			bool flag = true;
			bool a_ = false;
			lk lk = no.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					no = null;
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
				no.j(A_1);
				i3.a(no);
				i3.a(no, A_0);
				m4.a(n, lk, a_);
				if (lk.ay().e() != null)
				{
					no.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				switch (n.m()[0])
				{
				case gx.a:
					if (n.w())
					{
						n.m()[0] = gx.d;
					}
					break;
				case gx.b:
				case gx.c:
					break;
				default:
					n.m()[0] = gx.d;
					break;
				}
				base.e(no, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return no;
		}

		// Token: 0x04000C52 RID: 3154
		private new pp a = null;

		// Token: 0x04000C53 RID: 3155
		private ns b = null;

		// Token: 0x04000C54 RID: 3156
		private kl c = null;

		// Token: 0x04000C55 RID: 3157
		private new bool d = false;

		// Token: 0x04000C56 RID: 3158
		private new bool e = true;
	}
}
