using System;

namespace zz93
{
	// Token: 0x02000172 RID: 370
	internal class je : d3
	{
		// Token: 0x06000D62 RID: 3426 RVA: 0x0009887E File Offset: 0x0009787E
		internal je(jk A_0, kg A_1, p1 A_2, ij A_3) : base(A_1, A_2, A_3)
		{
			this.a = A_0;
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x0009889C File Offset: 0x0009789C
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				int a_ = base.l().w();
				base.l().ai();
				if (base.l().t())
				{
					if (base.l().v() == 1717 || base.l().v() == 3445)
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
					if (base.l().v() == 1717 || base.l().v() == 3445)
					{
						break;
					}
					base.d(base.l().v());
				}
				else if (base.l().aa())
				{
					base.r();
				}
			}
		}

		// Token: 0x040006CF RID: 1743
		private new jk a = null;
	}
}
