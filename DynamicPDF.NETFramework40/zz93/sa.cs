using System;
using System.IO;

namespace zz93
{
	// Token: 0x020002BE RID: 702
	internal abstract class sa
	{
		// Token: 0x06002038 RID: 8248 RVA: 0x0013E17C File Offset: 0x0013D17C
		internal sa(Stream A_0, byte[] A_1, int A_2)
		{
			this.b = A_1;
			int num = this.a(A_1, A_2 + 8);
			int num2 = this.a(A_1, A_2 + 12);
			this.a = new byte[num2];
			A_0.Seek((long)num, SeekOrigin.Begin);
			A_0.Read(this.a, 0, num2);
		}

		// Token: 0x06002039 RID: 8249 RVA: 0x0013E1D5 File Offset: 0x0013D1D5
		protected void o()
		{
			this.a = null;
		}

		// Token: 0x0600203A RID: 8250 RVA: 0x0013E1E0 File Offset: 0x0013D1E0
		protected byte[] p()
		{
			return this.a;
		}

		// Token: 0x0600203B RID: 8251 RVA: 0x0013E1F8 File Offset: 0x0013D1F8
		protected void a(byte[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600203C RID: 8252 RVA: 0x0013E204 File Offset: 0x0013D204
		internal int a(byte[] A_0, int A_1)
		{
			int num = (int)A_0[A_1++];
			num *= 256;
			num += (int)A_0[A_1++];
			num *= 256;
			num += (int)A_0[A_1++];
			num *= 256;
			return num + (int)A_0[A_1];
		}

		// Token: 0x0600203D RID: 8253 RVA: 0x0013E254 File Offset: 0x0013D254
		internal int d(int A_0)
		{
			return this.a(this.a, A_0);
		}

		// Token: 0x0600203E RID: 8254 RVA: 0x0013E274 File Offset: 0x0013D274
		internal int e(int A_0)
		{
			return (int)this.a[A_0++] << 8 | (int)this.a[A_0];
		}

		// Token: 0x0600203F RID: 8255 RVA: 0x0013E2A0 File Offset: 0x0013D2A0
		internal int f(int A_0)
		{
			return (int)this.a[A_0++] << 8 | (int)this.a[A_0];
		}

		// Token: 0x06002040 RID: 8256 RVA: 0x0013E2CC File Offset: 0x0013D2CC
		internal int g(int A_0)
		{
			return (int)this.a[A_0++];
		}

		// Token: 0x06002041 RID: 8257 RVA: 0x0013E2EC File Offset: 0x0013D2EC
		internal float h(int A_0)
		{
			int num = (int)this.a[A_0++];
			if (num > 127)
			{
				num -= 256;
			}
			num *= 256;
			num += (int)this.a[A_0++];
			num *= 256;
			num += (int)this.a[A_0++];
			num *= 256;
			num += (int)this.a[A_0];
			return (float)(num / 65536);
		}

		// Token: 0x06002042 RID: 8258 RVA: 0x0013E36C File Offset: 0x0013D36C
		internal short i(int A_0)
		{
			short num = (short)this.a[A_0++];
			if (num > 127)
			{
				num -= 256;
			}
			num *= 256;
			return num + (short)this.a[A_0];
		}

		// Token: 0x04000DF8 RID: 3576
		private byte[] a;

		// Token: 0x04000DF9 RID: 3577
		private byte[] b;
	}
}
