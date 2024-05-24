using System;

namespace zz93
{
	// Token: 0x02000150 RID: 336
	internal class ig
	{
		// Token: 0x06000C63 RID: 3171 RVA: 0x0009172C File Offset: 0x0009072C
		internal ig(uint A_0, uint A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x00091745 File Offset: 0x00090745
		internal ig(fc[] A_0)
		{
			this.a = 2147483647U;
			this.b = 1000U;
			this.d = A_0;
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x00091770 File Offset: 0x00090770
		internal ic a()
		{
			return this.c;
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x00091788 File Offset: 0x00090788
		internal void a(ic A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x00091794 File Offset: 0x00090794
		internal fc[] b()
		{
			return this.d;
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x000917AC File Offset: 0x000907AC
		internal void a(fc[] A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x000917B8 File Offset: 0x000907B8
		internal uint c()
		{
			return this.a;
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x000917D0 File Offset: 0x000907D0
		internal uint d()
		{
			return this.b;
		}

		// Token: 0x06000C6B RID: 3179 RVA: 0x000917E8 File Offset: 0x000907E8
		internal void e()
		{
			this.c = null;
		}

		// Token: 0x04000666 RID: 1638
		private uint a;

		// Token: 0x04000667 RID: 1639
		private uint b;

		// Token: 0x04000668 RID: 1640
		private ic c;

		// Token: 0x04000669 RID: 1641
		private fc[] d;
	}
}
