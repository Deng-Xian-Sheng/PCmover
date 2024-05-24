using System;

namespace zz93
{
	// Token: 0x0200018A RID: 394
	internal class j2 : d3
	{
		// Token: 0x06000DD6 RID: 3542 RVA: 0x0009C245 File Offset: 0x0009B245
		internal j2(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x0009C254 File Offset: 0x0009B254
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				base.l().ai();
				if (base.l().t())
				{
					if (base.l().v() == 5629554)
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
							if (num == 5629554)
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
