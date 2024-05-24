using System;

namespace zz93
{
	// Token: 0x020000B4 RID: 180
	internal class d4 : d3
	{
		// Token: 0x060008D4 RID: 2260 RVA: 0x00079766 File Offset: 0x00078766
		internal d4(kg A_0) : base(A_0)
		{
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00079772 File Offset: 0x00078772
		internal d4(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x00079780 File Offset: 0x00078780
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				base.l().ai();
				if (base.l().t())
				{
					if (base.l().v() == 1)
					{
						break;
					}
					this.cs(base.l().v());
					base.e(base.l().v());
				}
				else
				{
					if (base.l().u())
					{
						int num = base.l().v();
						if (num <= 1977)
						{
							if (num != 1)
							{
								if (num == 1977)
								{
									this.cs(base.l().v());
									continue;
								}
							}
							else
							{
								base.d(base.l().v());
							}
						}
						else if (num != 3418 && num != 11228793)
						{
						}
						break;
					}
					if (base.l().aa())
					{
						if (!base.k().e(1))
						{
							break;
						}
						base.r();
						base.l().e(false);
					}
				}
			}
		}
	}
}
