using System;

namespace zz93
{
	// Token: 0x02000246 RID: 582
	internal class o8 : d3
	{
		// Token: 0x06001AC1 RID: 6849 RVA: 0x001166D1 File Offset: 0x001156D1
		internal o8(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06001AC2 RID: 6850 RVA: 0x001166E0 File Offset: 0x001156E0
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				base.l().ai();
				if (base.l().t())
				{
					if (base.l().v() == 34721)
					{
						kg kg = base.l();
						kg.c(kg.ad() + 1);
					}
					this.cs(base.l().v());
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
									goto IL_10E;
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
							if (num == 34721)
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
								goto IL_10E;
							}
							break;
						}
						continue;
						IL_10E:
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
