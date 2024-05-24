using System;

namespace zz93
{
	// Token: 0x020002C4 RID: 708
	internal class sg
	{
		// Token: 0x06002063 RID: 8291 RVA: 0x0013F14C File Offset: 0x0013E14C
		internal sg(bool A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002064 RID: 8292 RVA: 0x0013F160 File Offset: 0x0013E160
		internal void a()
		{
			if (this.a)
			{
				this.b = new byte[3];
				this.b[0] = 1;
				this.b[1] = 1;
				this.b[2] = byte.MaxValue;
			}
		}

		// Token: 0x06002065 RID: 8293 RVA: 0x0013F1A8 File Offset: 0x0013E1A8
		internal bool b()
		{
			return this.a;
		}

		// Token: 0x06002066 RID: 8294 RVA: 0x0013F1C0 File Offset: 0x0013E1C0
		internal byte[] c()
		{
			this.a();
			return this.b;
		}

		// Token: 0x04000E21 RID: 3617
		private bool a;

		// Token: 0x04000E22 RID: 3618
		private byte[] b;
	}
}
