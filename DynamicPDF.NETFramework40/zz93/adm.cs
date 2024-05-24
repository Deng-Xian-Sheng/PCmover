using System;
using System.IO;

namespace zz93
{
	// Token: 0x0200046F RID: 1135
	internal class adm : sa
	{
		// Token: 0x06002F23 RID: 12067 RVA: 0x001AC952 File Offset: 0x001AB952
		internal adm(Stream A_0, byte[] A_1, int A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06002F24 RID: 12068 RVA: 0x001AC960 File Offset: 0x001AB960
		internal void a(ad8 A_0)
		{
			A_0.b();
			A_0.a(4, base.p().Length);
			A_0.a(base.p());
		}
	}
}
