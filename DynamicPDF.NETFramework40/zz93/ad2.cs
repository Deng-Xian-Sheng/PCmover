using System;
using System.IO;

namespace zz93
{
	// Token: 0x0200047F RID: 1151
	internal class ad2 : sa
	{
		// Token: 0x06002F99 RID: 12185 RVA: 0x001AED95 File Offset: 0x001ADD95
		internal ad2(short A_0, Stream A_1, byte[] A_2, int A_3) : base(A_1, A_2, A_3)
		{
			this.a = (short)(((float)base.e(16) * 1000f + (float)(A_0 / 2)) / (float)A_0);
			base.o();
		}

		// Token: 0x06002F9A RID: 12186 RVA: 0x001AEDCC File Offset: 0x001ADDCC
		internal short a()
		{
			return this.a;
		}

		// Token: 0x040016AA RID: 5802
		private new short a;
	}
}
