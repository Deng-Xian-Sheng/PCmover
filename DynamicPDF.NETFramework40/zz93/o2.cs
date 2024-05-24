using System;

namespace zz93
{
	// Token: 0x02000240 RID: 576
	internal class o2 : d3
	{
		// Token: 0x06001AA4 RID: 6820 RVA: 0x00115607 File Offset: 0x00114607
		internal o2(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06001AA5 RID: 6821 RVA: 0x00115618 File Offset: 0x00114618
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				int a_ = base.l().w();
				base.l().ai();
				if (base.l().t())
				{
					if (!base.b(base.l().v(), a_))
					{
						this.cs(base.l().v());
					}
					else if (base.l().v() == 423471123 || base.l().v() == 506042859)
					{
						break;
					}
				}
				else if (base.l().u())
				{
					if (base.l().v() == 423471123)
					{
						base.d(base.l().v());
						break;
					}
					break;
				}
				else
				{
					base.r();
					base.a(new pl());
				}
			}
		}
	}
}
