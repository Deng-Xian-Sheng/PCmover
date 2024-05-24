using System;

namespace zz93
{
	// Token: 0x0200041F RID: 1055
	internal class abh : abg
	{
		// Token: 0x06002BEE RID: 11246 RVA: 0x0019483C File Offset: 0x0019383C
		internal abh(aba A_0, int A_1, int A_2, int A_3) : base(A_0, A_1)
		{
			this.a = A_2;
			this.b = A_3;
		}

		// Token: 0x06002BEF RID: 11247 RVA: 0x00194858 File Offset: 0x00193858
		internal override abd h0()
		{
			ag6 ag = base.m().af().m().b((long)this.a).k();
			abd result;
			if (ag != null)
			{
				result = ag.a(new abi(base.m().af()), this.b);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x040014A6 RID: 5286
		private new int a;

		// Token: 0x040014A7 RID: 5287
		private new int b;
	}
}
