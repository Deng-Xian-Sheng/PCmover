using System;

namespace zz93
{
	// Token: 0x02000436 RID: 1078
	internal class ab4
	{
		// Token: 0x06002CAB RID: 11435 RVA: 0x00197E14 File Offset: 0x00196E14
		internal ab4(aba A_0, abj A_1)
		{
			for (abk abk = (A_1 != null) ? A_1.l() : null; abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 111619316)
				{
					abd abd = abk.c().h6();
					if (abd != null)
					{
						if (abd.hy() == ag9.g)
						{
							this.a = new ab3((abj)abk.c().h6());
							this.a.b(A_0);
						}
					}
					break;
				}
			}
		}

		// Token: 0x06002CAC RID: 11436 RVA: 0x00197EC8 File Offset: 0x00196EC8
		internal ab3 a()
		{
			return this.a;
		}

		// Token: 0x040014FD RID: 5373
		private ab3 a = null;
	}
}
