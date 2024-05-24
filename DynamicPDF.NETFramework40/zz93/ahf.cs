using System;

namespace zz93
{
	// Token: 0x020004FA RID: 1274
	internal class ahf : ag7
	{
		// Token: 0x06003401 RID: 13313 RVA: 0x001CD9EB File Offset: 0x001CC9EB
		internal ahf(byte[] A_0, int A_1, int A_2, abe A_3, abe A_4) : base(A_2, A_3, A_4, 0)
		{
			this.a = new byte[base.d()];
			this.b = A_0;
			this.c = A_1;
		}

		// Token: 0x06003402 RID: 13314 RVA: 0x001CDA1C File Offset: 0x001CCA1C
		protected override byte[] ls()
		{
			Array.Copy(this.b, this.c, this.a, 0, this.a.Length);
			this.c += this.a.Length;
			return this.a;
		}

		// Token: 0x0400191D RID: 6429
		private new byte[] a;

		// Token: 0x0400191E RID: 6430
		private byte[] b;

		// Token: 0x0400191F RID: 6431
		private int c;
	}
}
