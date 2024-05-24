using System;
using System.IO;

namespace zz93
{
	// Token: 0x02000472 RID: 1138
	internal class adp : sa
	{
		// Token: 0x06002F32 RID: 12082 RVA: 0x001ACFA8 File Offset: 0x001ABFA8
		internal adp(Stream A_0, byte[] A_1, int A_2) : base(A_0, A_1, A_2)
		{
			this.a = (short)base.e(18);
			this.b = (short)(((float)base.i(36) * 1000f - (float)(this.a / 2)) / (float)this.a);
			this.c = (short)(((float)base.i(38) * 1000f - (float)(this.a / 2)) / (float)this.a);
			this.d = (short)(((float)base.i(40) * 1000f + (float)(this.a / 2)) / (float)this.a);
			this.e = (short)(((float)base.i(42) * 1000f + (float)(this.a / 2)) / (float)this.a);
			if (base.e(50) == 0)
			{
				this.f = false;
			}
		}

		// Token: 0x06002F33 RID: 12083 RVA: 0x001AD090 File Offset: 0x001AC090
		internal void a(ad8 A_0)
		{
			A_0.b();
			A_0.a(0, base.p().Length);
			A_0.a(base.p());
		}

		// Token: 0x06002F34 RID: 12084 RVA: 0x001AD0B8 File Offset: 0x001AC0B8
		internal short a()
		{
			return this.a;
		}

		// Token: 0x06002F35 RID: 12085 RVA: 0x001AD0D0 File Offset: 0x001AC0D0
		internal short b()
		{
			return this.b;
		}

		// Token: 0x06002F36 RID: 12086 RVA: 0x001AD0E8 File Offset: 0x001AC0E8
		internal short c()
		{
			return this.c;
		}

		// Token: 0x06002F37 RID: 12087 RVA: 0x001AD100 File Offset: 0x001AC100
		internal short d()
		{
			return this.d;
		}

		// Token: 0x06002F38 RID: 12088 RVA: 0x001AD118 File Offset: 0x001AC118
		internal short e()
		{
			return this.e;
		}

		// Token: 0x06002F39 RID: 12089 RVA: 0x001AD130 File Offset: 0x001AC130
		internal bool f()
		{
			return this.f;
		}

		// Token: 0x04001676 RID: 5750
		private new short a;

		// Token: 0x04001677 RID: 5751
		private short b;

		// Token: 0x04001678 RID: 5752
		private short c;

		// Token: 0x04001679 RID: 5753
		private new short d;

		// Token: 0x0400167A RID: 5754
		private new short e;

		// Token: 0x0400167B RID: 5755
		private new bool f = true;
	}
}
