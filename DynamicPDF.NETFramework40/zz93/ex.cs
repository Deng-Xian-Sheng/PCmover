using System;

namespace zz93
{
	// Token: 0x020000D1 RID: 209
	internal class ex : d3
	{
		// Token: 0x0600098F RID: 2447 RVA: 0x0007E34A File Offset: 0x0007D34A
		internal ex(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x0007E358 File Offset: 0x0007D358
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				base.l().ai();
				if (base.l().t())
				{
					if (base.l().v() == 141185593)
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
							if (num == 11228793)
							{
								break;
							}
							if (num != 141185593)
							{
								goto IL_11E;
							}
							if (base.l().ad() > 1)
							{
								kg kg2 = base.l();
								kg2.c(kg2.ad() - 1);
							}
							base.d(base.l().v());
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
