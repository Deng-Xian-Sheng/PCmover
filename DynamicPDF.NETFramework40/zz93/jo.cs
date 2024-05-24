using System;

namespace zz93
{
	// Token: 0x0200017C RID: 380
	internal class jo : d3
	{
		// Token: 0x06000D8B RID: 3467 RVA: 0x000998C0 File Offset: 0x000988C0
		internal jo(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x000998D0 File Offset: 0x000988D0
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				base.l().ai();
				if (base.l().t())
				{
					if (base.l().v() == 95221)
					{
						kg kg = base.l();
						kg.c(kg.ad() + 1);
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
									goto IL_11E;
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
							if (num == 95221)
							{
								if (base.l().ad() > 1)
								{
									kg kg2 = base.l();
									kg2.c(kg2.ad() - 1);
								}
								base.d(base.l().v());
								break;
							}
							if (num != 11228793)
							{
								goto IL_11E;
							}
							break;
						}
						continue;
						IL_11E:
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
