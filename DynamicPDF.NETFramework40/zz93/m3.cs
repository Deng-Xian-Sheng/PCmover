using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001F9 RID: 505
	internal class m3 : k0
	{
		// Token: 0x060016C8 RID: 5832 RVA: 0x000F7AA0 File Offset: 0x000F6AA0
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060016C9 RID: 5833 RVA: 0x000F7AB8 File Offset: 0x000F6AB8
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060016CA RID: 5834 RVA: 0x000F7AC8 File Offset: 0x000F6AC8
		internal override int dg()
		{
			return 594666565;
		}

		// Token: 0x060016CB RID: 5835 RVA: 0x000F7AE0 File Offset: 0x000F6AE0
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x060016CC RID: 5836 RVA: 0x000F7AF8 File Offset: 0x000F6AF8
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060016CD RID: 5837 RVA: 0x000F7B04 File Offset: 0x000F6B04
		internal override k0 dd()
		{
			m3 m = new m3();
			m.ab(base.ci());
			m.ax(base.ck());
			m.ay(base.ck());
			return m;
		}

		// Token: 0x060016CE RID: 5838 RVA: 0x000F7B44 File Offset: 0x000F6B44
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060016CF RID: 5839 RVA: 0x000F7B63 File Offset: 0x000F6B63
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060016D0 RID: 5840 RVA: 0x000F7B70 File Offset: 0x000F6B70
		internal override kz dj(x5 A_0, x5 A_1)
		{
			base.ah(A_0);
			if (this.dr().dg() == 11228793)
			{
				bool flag;
				if (base.bx() > 0)
				{
					x5 a_ = A_1;
					x5? x = base.c5().v();
					flag = (x == null || !x5.d(a_, x.GetValueOrDefault()));
				}
				else
				{
					flag = true;
				}
				if (!flag)
				{
					A_1 = x5.c();
				}
			}
			kz result;
			switch (this.de())
			{
			case false:
				result = base.c(A_0, A_1);
				break;
			case true:
				result = base.f(A_0, A_1);
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x060016D1 RID: 5841 RVA: 0x000F7C18 File Offset: 0x000F6C18
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			switch (this.de())
			{
			case false:
				base.c(A_0, A_1, A_2);
				break;
			case true:
				base.d(A_0, A_1, A_2);
				break;
			}
		}

		// Token: 0x060016D2 RID: 5842 RVA: 0x000F7C58 File Offset: 0x000F6C58
		internal override kz dm()
		{
			m3 m = new m3();
			m.j(this.dr());
			m.dc(this.db().du());
			m.a((lk)base.c5().du());
			m.df(this.b);
			m.c(base.n().p());
			return m;
		}

		// Token: 0x04000A7D RID: 2685
		private new n5 a = new n5();

		// Token: 0x04000A7E RID: 2686
		private new bool b = true;
	}
}
