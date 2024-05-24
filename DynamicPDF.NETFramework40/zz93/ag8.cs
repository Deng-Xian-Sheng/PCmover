using System;

namespace zz93
{
	// Token: 0x020004F3 RID: 1267
	internal class ag8 : ag7
	{
		// Token: 0x060033D0 RID: 13264 RVA: 0x001CBCB4 File Offset: 0x001CACB4
		internal ag8(byte[] A_0, int A_1, int A_2, int A_3, abe A_4, abe A_5) : base(A_3, A_4, A_5, 0)
		{
			this.a = new byte[base.d()];
			this.b = new aa4();
			this.b.a(A_0, A_1, A_2);
		}

		// Token: 0x060033D1 RID: 13265 RVA: 0x001CBCF4 File Offset: 0x001CACF4
		protected override byte[] ls()
		{
			this.b.b(this.a, 0, this.a.Length);
			return this.a;
		}

		// Token: 0x040018BB RID: 6331
		private new byte[] a;

		// Token: 0x040018BC RID: 6332
		private aa4 b;
	}
}
