using System;

namespace zz93
{
	// Token: 0x0200022D RID: 557
	internal class oj : d3
	{
		// Token: 0x06001A2E RID: 6702 RVA: 0x00111057 File Offset: 0x00110057
		internal oj(jk A_0, kg A_1, p1 A_2, ij A_3) : base(A_1, A_2, A_3)
		{
			this.a = A_0;
			this.b = A_3;
		}

		// Token: 0x06001A2F RID: 6703 RVA: 0x0011107C File Offset: 0x0011007C
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				base.l().ai();
				if (base.l().t())
				{
					this.cs(base.l().v());
					base.e(base.l().v());
				}
				else if (base.l().u())
				{
					if (base.l().v() == this.a.cn())
					{
						base.l().ax();
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

		// Token: 0x06001A30 RID: 6704 RVA: 0x0011118C File Offset: 0x0011018C
		protected internal override void cs(int A_0)
		{
			if (A_0 != 1000)
			{
				if (A_0 != 1717)
				{
					if (A_0 != 3445)
					{
						base.cs(A_0);
					}
					else
					{
						base.a(this.a, new jf(base.l(), this.b));
					}
				}
				else
				{
					base.a(this.a, new jt(base.l(), this.b));
				}
			}
			else
			{
				base.a(this.a, new om(base.l(), this.b));
			}
		}

		// Token: 0x04000BD1 RID: 3025
		private new jk a = null;

		// Token: 0x04000BD2 RID: 3026
		private new ij b;
	}
}
