using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003E9 RID: 1001
	internal class z8 : zq
	{
		// Token: 0x060029F7 RID: 10743 RVA: 0x00186E0C File Offset: 0x00185E0C
		internal z8(byte[] A_0, int A_1, int A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x060029F8 RID: 10744 RVA: 0x00186E2C File Offset: 0x00185E2C
		internal override void g7(Stream A_0)
		{
			A_0.Write(this.a, this.b, this.c);
		}

		// Token: 0x060029F9 RID: 10745 RVA: 0x00186E48 File Offset: 0x00185E48
		internal override int g8()
		{
			return this.c;
		}

		// Token: 0x0400132F RID: 4911
		private byte[] a;

		// Token: 0x04001330 RID: 4912
		private int b;

		// Token: 0x04001331 RID: 4913
		private int c;
	}
}
