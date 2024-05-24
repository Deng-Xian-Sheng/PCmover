using System;

namespace zz93
{
	// Token: 0x02000185 RID: 389
	internal class jx : d3
	{
		// Token: 0x06000DB6 RID: 3510 RVA: 0x0009B204 File Offset: 0x0009A204
		internal jx(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06000DB7 RID: 3511 RVA: 0x0009B214 File Offset: 0x0009A214
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				base.l().ai();
				if (base.l().t())
				{
					if (base.l().v() == 899925938)
					{
						kg kg = base.l();
						kg.c(kg.ad() + 1);
					}
					this.cs(base.l().v());
					base.e(base.l().v());
				}
				else if (base.l().u())
				{
					int num = base.l().v();
					if (num != 1977)
					{
						if (num == 899925938)
						{
							if (base.l().ad() > 1)
							{
								kg kg2 = base.l();
								kg2.c(kg2.ad() - 1);
							}
							base.d(base.l().v());
							break;
						}
						base.d(base.l().v());
					}
					else
					{
						this.cs(base.l().v());
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
