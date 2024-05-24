using System;

namespace zz93
{
	// Token: 0x020000C9 RID: 201
	internal class ep : d3
	{
		// Token: 0x06000945 RID: 2373 RVA: 0x0007C4BA File Offset: 0x0007B4BA
		internal ep(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0007C4C8 File Offset: 0x0007B4C8
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				base.l().ai();
				if (base.l().t())
				{
					if (base.l().v() == 426354867)
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
						if (num <= 3418)
						{
							if (num != 1977)
							{
								if (num != 3418)
								{
									goto IL_D8;
								}
								break;
							}
							else
							{
								this.cs(base.l().v());
							}
						}
						else
						{
							if (num == 11228793)
							{
								break;
							}
							if (num != 426354867)
							{
								goto IL_D8;
							}
							base.s();
							break;
						}
						continue;
						IL_D8:
						base.d(base.l().v());
						continue;
						break;
					}
					if (base.l().aa())
					{
						base.r();
					}
				}
			}
		}
	}
}
