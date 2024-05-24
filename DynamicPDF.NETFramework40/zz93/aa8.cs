using System;

namespace zz93
{
	// Token: 0x02000416 RID: 1046
	internal class aa8
	{
		// Token: 0x06002BA3 RID: 11171 RVA: 0x001936A0 File Offset: 0x001926A0
		internal int a(int A_0)
		{
			if (this.e < A_0)
			{
				if (this.b == this.c)
				{
					return -1;
				}
				this.d |= (uint)((uint)((int)(this.a[this.b++] & byte.MaxValue) | (int)(this.a[this.b++] & byte.MaxValue) << 8) << this.e);
				this.e += 16;
			}
			return (int)((ulong)this.d & (ulong)((long)((1 << A_0) - 1)));
		}

		// Token: 0x06002BA4 RID: 11172 RVA: 0x00193758 File Offset: 0x00192758
		internal void b(int A_0)
		{
			this.d >>= A_0;
			this.e -= A_0;
		}

		// Token: 0x06002BA5 RID: 11173 RVA: 0x0019377C File Offset: 0x0019277C
		internal int a()
		{
			return this.e;
		}

		// Token: 0x06002BA6 RID: 11174 RVA: 0x00193794 File Offset: 0x00192794
		internal int b()
		{
			return this.c - this.b + (this.e >> 3);
		}

		// Token: 0x06002BA7 RID: 11175 RVA: 0x001937BC File Offset: 0x001927BC
		internal void c()
		{
			this.d >>= (this.e & 7);
			this.e &= -8;
		}

		// Token: 0x06002BA8 RID: 11176 RVA: 0x001937E8 File Offset: 0x001927E8
		internal bool d()
		{
			return this.b == this.c;
		}

		// Token: 0x06002BA9 RID: 11177 RVA: 0x00193808 File Offset: 0x00192808
		internal int a(byte[] A_0, int A_1, int A_2)
		{
			if (A_2 < 0)
			{
				throw new ArgumentOutOfRangeException("length negative");
			}
			if ((this.e & 7) != 0)
			{
				throw new InvalidOperationException("Bit buffer is not aligned!");
			}
			int num = 0;
			while (this.e > 0 && A_2 > 0)
			{
				A_0[A_1++] = (byte)this.d;
				this.d >>= 8;
				this.e -= 8;
				A_2--;
				num++;
			}
			int result;
			if (A_2 == 0)
			{
				result = num;
			}
			else
			{
				int num2 = this.c - this.b;
				if (A_2 > num2)
				{
					A_2 = num2;
				}
				Array.Copy(this.a, this.b, A_0, A_1, A_2);
				this.b += A_2;
				if ((this.b - this.c & 1) != 0)
				{
					this.d = (uint)(this.a[this.b++] & byte.MaxValue);
					this.e = 8;
				}
				result = num + A_2;
			}
			return result;
		}

		// Token: 0x06002BAA RID: 11178 RVA: 0x00193937 File Offset: 0x00192937
		internal aa8()
		{
		}

		// Token: 0x06002BAB RID: 11179 RVA: 0x00193960 File Offset: 0x00192960
		internal void b(byte[] A_0, int A_1, int A_2)
		{
			if (this.b < this.c)
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			int num = A_1 + A_2;
			if (0 > A_1 || A_1 > num || num > A_0.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			if ((A_2 & 1) != 0)
			{
				this.d |= (uint)((uint)(A_0[A_1++] & byte.MaxValue) << this.e);
				this.e += 8;
			}
			this.a = A_0;
			this.b = A_1;
			this.c = num;
		}

		// Token: 0x04001491 RID: 5265
		private byte[] a;

		// Token: 0x04001492 RID: 5266
		private int b = 0;

		// Token: 0x04001493 RID: 5267
		private int c = 0;

		// Token: 0x04001494 RID: 5268
		private uint d = 0U;

		// Token: 0x04001495 RID: 5269
		private int e = 0;
	}
}
