using System;
using System.IO;

namespace zz93
{
	// Token: 0x02000473 RID: 1139
	internal class adq : sa
	{
		// Token: 0x06002F3A RID: 12090 RVA: 0x001AD148 File Offset: 0x001AC148
		internal adq(short A_0, Stream A_1, byte[] A_2, int A_3) : base(A_1, A_2, A_3)
		{
			this.a = (short)(((float)base.i(4) * 1000f + (float)(A_0 / 2)) / (float)A_0);
			this.b = (short)(((float)base.i(6) * 1000f - (float)(A_0 / 2)) / (float)A_0);
			this.c = (short)(((float)base.i(8) * 1000f - (float)(A_0 / 2)) / (float)A_0);
			this.d = base.e(34);
		}

		// Token: 0x06002F3B RID: 12091 RVA: 0x001AD1C7 File Offset: 0x001AC1C7
		internal void a(ad8 A_0)
		{
			A_0.b();
			A_0.a(1, base.p().Length);
			A_0.a(base.p());
		}

		// Token: 0x06002F3C RID: 12092 RVA: 0x001AD1F0 File Offset: 0x001AC1F0
		internal short a()
		{
			return this.a;
		}

		// Token: 0x06002F3D RID: 12093 RVA: 0x001AD208 File Offset: 0x001AC208
		internal short b()
		{
			return this.b;
		}

		// Token: 0x06002F3E RID: 12094 RVA: 0x001AD220 File Offset: 0x001AC220
		internal short c()
		{
			return this.c;
		}

		// Token: 0x06002F3F RID: 12095 RVA: 0x001AD238 File Offset: 0x001AC238
		internal int d()
		{
			return this.d;
		}

		// Token: 0x0400167C RID: 5756
		private new short a;

		// Token: 0x0400167D RID: 5757
		private short b;

		// Token: 0x0400167E RID: 5758
		private short c;

		// Token: 0x0400167F RID: 5759
		private new int d;
	}
}
