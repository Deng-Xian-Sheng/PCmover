using System;

namespace zz93
{
	// Token: 0x02000410 RID: 1040
	internal class aa2
	{
		// Token: 0x06002B7A RID: 11130 RVA: 0x00191DD7 File Offset: 0x00190DD7
		internal aa2() : this(4096)
		{
		}

		// Token: 0x06002B7B RID: 11131 RVA: 0x00191DE7 File Offset: 0x00190DE7
		internal aa2(int A_0)
		{
			this.a = new byte[A_0];
		}

		// Token: 0x06002B7C RID: 11132 RVA: 0x00191E00 File Offset: 0x00190E00
		internal void a()
		{
			this.b = (this.c = (this.e = 0));
		}

		// Token: 0x06002B7D RID: 11133 RVA: 0x00191E28 File Offset: 0x00190E28
		internal void a(int A_0)
		{
			this.a[this.c++] = (byte)A_0;
			this.a[this.c++] = (byte)(A_0 >> 8);
		}

		// Token: 0x06002B7E RID: 11134 RVA: 0x00191E6C File Offset: 0x00190E6C
		internal void a(byte[] A_0, int A_1, int A_2)
		{
			Array.Copy(A_0, A_1, this.a, this.c, A_2);
			this.c += A_2;
		}

		// Token: 0x06002B7F RID: 11135 RVA: 0x00191E94 File Offset: 0x00190E94
		internal int b()
		{
			return this.e;
		}

		// Token: 0x06002B80 RID: 11136 RVA: 0x00191EAC File Offset: 0x00190EAC
		internal void c()
		{
			if (this.e > 0)
			{
				this.a[this.c++] = (byte)this.d;
				if (this.e > 8)
				{
					this.a[this.c++] = (byte)(this.d >> 8);
				}
			}
			this.d = 0U;
			this.e = 0;
		}

		// Token: 0x06002B81 RID: 11137 RVA: 0x00191F2C File Offset: 0x00190F2C
		internal void a(int A_0, int A_1)
		{
			this.d |= (uint)((uint)A_0 << this.e);
			this.e += A_1;
			if (this.e >= 16)
			{
				this.a[this.c++] = (byte)this.d;
				this.a[this.c++] = (byte)(this.d >> 8);
				this.d >>= 16;
				this.e -= 16;
			}
		}

		// Token: 0x06002B82 RID: 11138 RVA: 0x00191FD0 File Offset: 0x00190FD0
		internal void b(int A_0)
		{
			this.a[this.c++] = (byte)(A_0 >> 8);
			this.a[this.c++] = (byte)A_0;
		}

		// Token: 0x06002B83 RID: 11139 RVA: 0x00192014 File Offset: 0x00191014
		internal bool d()
		{
			return this.c == 0;
		}

		// Token: 0x06002B84 RID: 11140 RVA: 0x00192030 File Offset: 0x00191030
		internal int b(byte[] A_0, int A_1, int A_2)
		{
			if (this.e >= 8)
			{
				this.a[this.c++] = (byte)this.d;
				this.d >>= 8;
				this.e -= 8;
			}
			if (A_2 > this.c - this.b)
			{
				A_2 = this.c - this.b;
				Array.Copy(this.a, this.b, A_0, A_1, A_2);
				this.b = 0;
				this.c = 0;
			}
			else
			{
				Array.Copy(this.a, this.b, A_0, A_1, A_2);
				this.b += A_2;
			}
			return A_2;
		}

		// Token: 0x0400144E RID: 5198
		protected byte[] a;

		// Token: 0x0400144F RID: 5199
		private int b;

		// Token: 0x04001450 RID: 5200
		private int c;

		// Token: 0x04001451 RID: 5201
		private uint d;

		// Token: 0x04001452 RID: 5202
		private int e;
	}
}
