using System;

namespace zz93
{
	// Token: 0x02000144 RID: 324
	internal class h4
	{
		// Token: 0x06000C2F RID: 3119 RVA: 0x00090BCA File Offset: 0x0008FBCA
		internal h4()
		{
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x00090BEF File Offset: 0x0008FBEF
		private void b()
		{
			this.c = this.b;
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x00090C00 File Offset: 0x0008FC00
		private void a()
		{
			ij[] destinationArray = new ij[this.a.Length + 1];
			Array.Copy(this.a, 0, destinationArray, 0, this.a.Length);
			this.a = destinationArray;
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x00090C3C File Offset: 0x0008FC3C
		internal void a(ij A_0)
		{
			if (this.b >= this.a.Length)
			{
				this.a();
			}
			this.a[this.b] = A_0;
			this.b++;
			this.c = this.b;
		}

		// Token: 0x04000649 RID: 1609
		private ij[] a = new ij[3];

		// Token: 0x0400064A RID: 1610
		private int b = 0;

		// Token: 0x0400064B RID: 1611
		private int c = 0;
	}
}
