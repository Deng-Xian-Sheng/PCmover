using System;
using System.IO;

namespace zz93
{
	// Token: 0x02000482 RID: 1154
	internal class ad5 : sa
	{
		// Token: 0x06002FA8 RID: 12200 RVA: 0x001AF64C File Offset: 0x001AE64C
		internal ad5(Stream A_0, byte[] A_1, int A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06002FA9 RID: 12201 RVA: 0x001AF65A File Offset: 0x001AE65A
		internal void a(ad8 A_0)
		{
			A_0.b();
			A_0.a(6, base.p().Length);
			A_0.a(base.p());
		}
	}
}
