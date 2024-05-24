using System;

namespace zz93
{
	// Token: 0x02000477 RID: 1143
	internal struct adu
	{
		// Token: 0x06002F5A RID: 12122 RVA: 0x001ADA74 File Offset: 0x001ACA74
		internal adu(adw A_0, int A_1, ref int A_2)
		{
			this.a = (ushort)A_0.e(A_2);
			A_2 += 2;
			this.b = (ushort)A_0.e(A_2);
			A_2 += 2;
			this.c = (short)(-((int)(A_0.i(A_2) * 1000) + A_1 / 2) / A_1);
			A_2 += 2;
		}

		// Token: 0x06002F5B RID: 12123 RVA: 0x001ADACE File Offset: 0x001ACACE
		internal adu(ushort A_0, ushort A_1, short A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06002F5C RID: 12124 RVA: 0x001ADAE8 File Offset: 0x001ACAE8
		internal ushort a()
		{
			return this.a;
		}

		// Token: 0x06002F5D RID: 12125 RVA: 0x001ADB00 File Offset: 0x001ACB00
		internal ushort b()
		{
			return this.b;
		}

		// Token: 0x06002F5E RID: 12126 RVA: 0x001ADB18 File Offset: 0x001ACB18
		internal float c()
		{
			return (float)this.c;
		}

		// Token: 0x0400168C RID: 5772
		private ushort a;

		// Token: 0x0400168D RID: 5773
		private ushort b;

		// Token: 0x0400168E RID: 5774
		private short c;
	}
}
