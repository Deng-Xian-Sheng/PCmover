using System;

namespace zz93
{
	// Token: 0x02000180 RID: 384
	internal class js : d3
	{
		// Token: 0x06000D9A RID: 3482 RVA: 0x00099F69 File Offset: 0x00098F69
		internal js(jk A_0, kg A_1, p1 A_2, ij A_3) : base(A_1, A_2, A_3)
		{
			this.a = A_0;
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x00099F88 File Offset: 0x00098F88
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

		// Token: 0x040006E0 RID: 1760
		private new jk a = null;
	}
}
