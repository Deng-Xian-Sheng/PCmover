using System;
using System.Reflection;

namespace zz93
{
	// Token: 0x02000289 RID: 649
	[DefaultMember("Item")]
	internal class q2
	{
		// Token: 0x06001D33 RID: 7475 RVA: 0x0012B229 File Offset: 0x0012A229
		internal q2()
		{
			this.a = new r2.a[1];
		}

		// Token: 0x06001D34 RID: 7476 RVA: 0x0012B24E File Offset: 0x0012A24E
		internal q2(int A_0)
		{
			this.a = new r2.a[A_0];
		}

		// Token: 0x06001D35 RID: 7477 RVA: 0x0012B274 File Offset: 0x0012A274
		internal void a(r2.a A_0, int A_1)
		{
			if (this.b == this.a.Length)
			{
				r2.a[] array = new r2.a[this.a.Length * 2];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			if (this.a.Length > A_1)
			{
				this.a[A_1] = A_0;
			}
			else
			{
				r2.a[] array = new r2.a[A_1 + 1];
				this.a.CopyTo(array, 0);
				this.a = array;
				this.a[A_1] = A_0;
			}
			this.b++;
		}

		// Token: 0x06001D36 RID: 7478 RVA: 0x0012B318 File Offset: 0x0012A318
		internal r2.a a(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x06001D37 RID: 7479 RVA: 0x0012B334 File Offset: 0x0012A334
		internal int a()
		{
			return this.a.Length;
		}

		// Token: 0x04000D29 RID: 3369
		private r2.a[] a = null;

		// Token: 0x04000D2A RID: 3370
		private int b = 0;
	}
}
