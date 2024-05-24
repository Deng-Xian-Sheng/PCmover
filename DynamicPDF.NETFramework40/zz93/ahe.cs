using System;

namespace zz93
{
	// Token: 0x020004F9 RID: 1273
	internal class ahe : ag7
	{
		// Token: 0x060033FF RID: 13311 RVA: 0x001CD93D File Offset: 0x001CC93D
		internal ahe(byte[] A_0, int A_1, int A_2, int A_3, abe A_4, abe A_5) : base(A_3, A_4, A_5, 0)
		{
			this.a = new byte[base.d()];
			this.b = new aa4();
			this.b.a(A_0, A_1, A_2);
		}

		// Token: 0x06003400 RID: 13312 RVA: 0x001CD97C File Offset: 0x001CC97C
		protected override byte[] ls()
		{
			this.b.b(this.a, 0, this.a.Length);
			for (int i = 2; i < this.a.Length; i++)
			{
				byte[] array = this.a;
				int num = i;
				array[num] += this.a[i - 1];
			}
			return this.a;
		}

		// Token: 0x0400191B RID: 6427
		private new byte[] a;

		// Token: 0x0400191C RID: 6428
		private aa4 b;
	}
}
