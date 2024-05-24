using System;

namespace zz93
{
	// Token: 0x020003D6 RID: 982
	internal class zp
	{
		// Token: 0x0600294F RID: 10575 RVA: 0x00183512 File Offset: 0x00182512
		internal zp(int A_0)
		{
			this.a = new byte[A_0];
		}

		// Token: 0x06002950 RID: 10576 RVA: 0x00183530 File Offset: 0x00182530
		internal int a()
		{
			return this.b;
		}

		// Token: 0x06002951 RID: 10577 RVA: 0x00183548 File Offset: 0x00182548
		internal void a(byte[] A_0, int A_1, int A_2)
		{
			Array.Copy(A_0, A_1, this.a, this.b, A_2);
			this.b += A_2;
		}

		// Token: 0x06002952 RID: 10578 RVA: 0x00183570 File Offset: 0x00182570
		internal byte[] b()
		{
			return this.a;
		}

		// Token: 0x040012AE RID: 4782
		private byte[] a;

		// Token: 0x040012AF RID: 4783
		private int b = 0;
	}
}
