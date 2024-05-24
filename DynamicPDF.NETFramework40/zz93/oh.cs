using System;

namespace zz93
{
	// Token: 0x0200022B RID: 555
	internal class oh : d3
	{
		// Token: 0x06001A21 RID: 6689 RVA: 0x0010F8E9 File Offset: 0x0010E8E9
		internal oh(jk A_0, kg A_1, p1 A_2, ij A_3) : base(A_1, A_2, A_3)
		{
			this.a = A_0;
		}

		// Token: 0x06001A22 RID: 6690 RVA: 0x0010F908 File Offset: 0x0010E908
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				int a_ = base.l().w();
				base.l().ai();
				if (base.l().t())
				{
					int num = base.l().v();
					if (num == 1000)
					{
						base.l().f(a_);
						break;
					}
					this.cs(base.l().v());
					base.e(base.l().v());
				}
				else if (base.l().u())
				{
					if (this.a != null && this.a.cn() == base.l().v())
					{
						base.l().f(a_);
						break;
					}
					if (base.l().v() == 1000)
					{
						break;
					}
					if (base.l().v() == 1977)
					{
						this.cs(base.l().v());
					}
					base.d(base.l().v());
				}
				else if (base.l().aa())
				{
					base.r();
				}
			}
		}

		// Token: 0x04000BCD RID: 3021
		private new jk a = null;
	}
}
