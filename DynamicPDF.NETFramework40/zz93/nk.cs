using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200020A RID: 522
	internal class nk : kz
	{
		// Token: 0x060017D9 RID: 6105 RVA: 0x000FF614 File Offset: 0x000FE614
		internal char[] a()
		{
			return this.a;
		}

		// Token: 0x060017DA RID: 6106 RVA: 0x000FF62C File Offset: 0x000FE62C
		internal void a(char[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060017DB RID: 6107 RVA: 0x000FF638 File Offset: 0x000FE638
		internal l2 b()
		{
			return this.d;
		}

		// Token: 0x060017DC RID: 6108 RVA: 0x000FF650 File Offset: 0x000FE650
		internal void a(l2 A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060017DD RID: 6109 RVA: 0x000FF65C File Offset: 0x000FE65C
		internal x5 c()
		{
			x5 x = this.c.a().i();
			if (x5.h(x, x5.c()))
			{
				this.c.a().a(x5.a(12f));
				x = x5.a(12f);
			}
			return x;
		}

		// Token: 0x060017DE RID: 6110 RVA: 0x000FF6BC File Offset: 0x000FE6BC
		internal override lj db()
		{
			return this.dr().db();
		}

		// Token: 0x060017DF RID: 6111 RVA: 0x000FF6D9 File Offset: 0x000FE6D9
		internal override void dc(lj A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060017E0 RID: 6112 RVA: 0x000FF6E4 File Offset: 0x000FE6E4
		internal ij d()
		{
			return this.e;
		}

		// Token: 0x060017E1 RID: 6113 RVA: 0x000FF6FC File Offset: 0x000FE6FC
		internal void a(ij A_0)
		{
			this.e = A_0;
		}

		// Token: 0x060017E2 RID: 6114 RVA: 0x000FF708 File Offset: 0x000FE708
		internal l2 e()
		{
			l2 result;
			if (this.d == null)
			{
				result = ((this.e == null) ? l2.c() : this.e.c().a(this.c, this.e));
			}
			else
			{
				result = this.d;
			}
			return result;
		}

		// Token: 0x060017E3 RID: 6115 RVA: 0x000FF760 File Offset: 0x000FE760
		internal override void di()
		{
			x5 a_;
			this.a7(a_ = base.aq());
			this.a8(a_);
		}

		// Token: 0x060017E4 RID: 6116 RVA: 0x000FF788 File Offset: 0x000FE788
		internal override x5 dh()
		{
			return this.dp();
		}

		// Token: 0x060017E5 RID: 6117 RVA: 0x000FF7A0 File Offset: 0x000FE7A0
		internal override int dg()
		{
			return 102;
		}

		// Token: 0x060017E6 RID: 6118 RVA: 0x000FF7B4 File Offset: 0x000FE7B4
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
		}

		// Token: 0x060017E7 RID: 6119 RVA: 0x000FF7BC File Offset: 0x000FE7BC
		internal nk()
		{
			this.a(new char[]
			{
				' '
			});
			base.h(1);
		}

		// Token: 0x060017E8 RID: 6120 RVA: 0x000FF808 File Offset: 0x000FE808
		internal override kz dj(x5 A_0, x5 A_1)
		{
			this.d = this.e();
			float fontSize = x5.b(this.c.a().i());
			base.w(x5.a(this.d.e().GetAscender(fontSize)));
			base.x(x5.d(x5.a(this.d.e().GetDescender(fontSize))));
			this.dr().w(base.a1());
			this.dr().x(base.a2());
			base.m(n4.a(this.d.e()));
			base.l(n4.a(this.a(), this.d.e(), this.c()));
			return null;
		}

		// Token: 0x060017E9 RID: 6121 RVA: 0x000FF8E0 File Offset: 0x000FE8E0
		internal override kz dm()
		{
			nk nk = new nk();
			nk.j(this.dr());
			nk.dc(this.db().du());
			nk.a((lk)base.c5().du());
			nk.a(this.d);
			nk.a(this.a());
			return nk;
		}

		// Token: 0x04000AC5 RID: 2757
		private char[] a;

		// Token: 0x04000AC6 RID: 2758
		private lj b;

		// Token: 0x04000AC7 RID: 2759
		private n5 c = new n5();

		// Token: 0x04000AC8 RID: 2760
		private l2 d = null;

		// Token: 0x04000AC9 RID: 2761
		private ij e = null;
	}
}
