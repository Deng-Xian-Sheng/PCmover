using System;

namespace zz93
{
	// Token: 0x0200026D RID: 621
	internal class qb : d3
	{
		// Token: 0x06001BFC RID: 7164 RVA: 0x00120CA6 File Offset: 0x0011FCA6
		internal qb(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06001BFD RID: 7165 RVA: 0x00120CB4 File Offset: 0x0011FCB4
		protected internal override void cq()
		{
			base.l().f(true);
			while (!base.l().af())
			{
				base.l().ai();
				if (base.l().u() && base.l().v() == 23684646)
				{
					base.d(base.l().v());
					break;
				}
				int num = base.l().v();
				if (num != 23684646)
				{
					if (!base.l().u())
					{
						base.l().f(base.l().w() - (base.l().ae() + 1));
					}
				}
				base.l().c(this);
			}
		}
	}
}
