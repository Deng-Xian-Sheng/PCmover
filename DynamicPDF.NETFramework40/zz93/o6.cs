using System;

namespace zz93
{
	// Token: 0x02000244 RID: 580
	internal class o6 : d3
	{
		// Token: 0x06001AB8 RID: 6840 RVA: 0x00115D0A File Offset: 0x00114D0A
		internal o6(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06001AB9 RID: 6841 RVA: 0x00115D18 File Offset: 0x00114D18
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				int a_ = base.l().w();
				base.l().ai();
				if (base.l().t())
				{
					if (base.b(base.l().v(), a_))
					{
						break;
					}
					this.cs(base.l().v());
					base.e(base.l().v());
				}
				else if (base.l().u())
				{
					int num = base.l().v();
					if (num <= 1977)
					{
						if (num == 33)
						{
							base.d(33);
							break;
						}
						if (num != 1977)
						{
							goto IL_EC;
						}
						this.cs(base.l().v());
					}
					else
					{
						if (num != 3418 && num != 11228793)
						{
							goto IL_EC;
						}
						break;
					}
					continue;
					IL_EC:
					if (base.k().e(base.l().v()))
					{
						base.d(base.l().v());
					}
					else
					{
						if (base.b(base.l().v(), a_))
						{
							break;
						}
						base.d(base.l().v());
					}
				}
				else if (base.l().aa())
				{
					base.r();
				}
			}
		}
	}
}
