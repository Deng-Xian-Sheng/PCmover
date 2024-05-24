using System;

namespace zz93
{
	// Token: 0x0200036B RID: 875
	internal class wy
	{
		// Token: 0x06002550 RID: 9552 RVA: 0x0015D240 File Offset: 0x0015C240
		internal wy(short A_0)
		{
			this.a = A_0;
			this.e = null;
		}

		// Token: 0x06002551 RID: 9553 RVA: 0x0015D26B File Offset: 0x0015C26B
		internal wy(short A_0, wx A_1)
		{
			this.a = A_0;
			this.d = A_1;
			this.e = null;
		}

		// Token: 0x06002552 RID: 9554 RVA: 0x0015D2A0 File Offset: 0x0015C2A0
		internal x5 a()
		{
			x5 result;
			if (this.b != null && this.b.a() != null)
			{
				result = this.b.a().b7();
			}
			else
			{
				result = x5.b();
			}
			return result;
		}

		// Token: 0x06002553 RID: 9555 RVA: 0x0015D2EC File Offset: 0x0015C2EC
		internal x5 b()
		{
			x5 result;
			if (this.b != null && this.b.a() != null)
			{
				result = this.b.a().b8();
			}
			else
			{
				result = x5.b();
			}
			return result;
		}

		// Token: 0x04001065 RID: 4197
		internal short a;

		// Token: 0x04001066 RID: 4198
		internal xx b;

		// Token: 0x04001067 RID: 4199
		internal x5 c = x5.c();

		// Token: 0x04001068 RID: 4200
		internal wx d = wx.b;

		// Token: 0x04001069 RID: 4201
		internal wy e;
	}
}
