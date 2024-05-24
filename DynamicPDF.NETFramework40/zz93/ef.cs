using System;

namespace zz93
{
	// Token: 0x020000BF RID: 191
	internal class ef : d3
	{
		// Token: 0x0600090A RID: 2314 RVA: 0x0007AA31 File Offset: 0x00079A31
		internal ef(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x0007AA40 File Offset: 0x00079A40
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				base.l().ai();
				if (base.l().t())
				{
					if (base.l().v() == 46574465)
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
							if (num == 1977)
							{
								this.cs(base.l().v());
								continue;
							}
							if (num != 3418)
							{
								goto IL_12B;
							}
						}
						else if (num != 11228793)
						{
							if (num != 46574465)
							{
								goto IL_12B;
							}
							if (base.l().ad() == 1)
							{
								base.s();
							}
							else
							{
								kg kg2 = base.l();
								kg2.c(kg2.ad() - 1);
								base.d(base.l().v());
							}
						}
						break;
						IL_12B:
						base.d(base.l().v());
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
