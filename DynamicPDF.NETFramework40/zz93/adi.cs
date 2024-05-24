using System;
using System.IO;

namespace zz93
{
	// Token: 0x0200046B RID: 1131
	internal class adi : sa
	{
		// Token: 0x06002F0A RID: 12042 RVA: 0x001AC664 File Offset: 0x001AB664
		internal adi(Stream A_0, byte[] A_1, int A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06002F0B RID: 12043 RVA: 0x001AC672 File Offset: 0x001AB672
		internal void a(ad8 A_0)
		{
			A_0.b();
			A_0.a(3, base.p().Length);
			A_0.a(base.p());
		}
	}
}
