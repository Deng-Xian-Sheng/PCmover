using System;

namespace zz93
{
	// Token: 0x020001A9 RID: 425
	internal class kx : d3
	{
		// Token: 0x06000ED9 RID: 3801 RVA: 0x000B10F0 File Offset: 0x000B00F0
		internal kx(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x000B1100 File Offset: 0x000B0100
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				int a_ = base.l().w();
				base.l().ai();
				if (base.l().t())
				{
					this.cs(base.l().v());
					base.e(base.l().v());
				}
				else if (base.l().u())
				{
					if (base.b(base.l().v(), a_))
					{
						base.s();
						break;
					}
					if (base.l().v() == 673419368)
					{
						base.d(base.l().v());
						base.l().c(false);
						break;
					}
					if (base.l().v() != 1977)
					{
						break;
					}
					this.cs(base.l().v());
				}
				else if (base.l().aa())
				{
					base.r();
					base.l().e(false);
				}
			}
		}
	}
}
