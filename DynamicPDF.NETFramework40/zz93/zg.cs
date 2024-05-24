using System;

namespace zz93
{
	// Token: 0x020003CD RID: 973
	internal class zg
	{
		// Token: 0x060028FD RID: 10493 RVA: 0x0017DF68 File Offset: 0x0017CF68
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

		// Token: 0x060028FE RID: 10494 RVA: 0x0017E020 File Offset: 0x0017D020
		internal void b(int A_0)
		{
			this.d >>= A_0;
			this.e -= A_0;
		}

		// Token: 0x060028FF RID: 10495 RVA: 0x0017E044 File Offset: 0x0017D044
		internal int a()
		{
			return this.e;
		}

		// Token: 0x06002900 RID: 10496 RVA: 0x0017E05C File Offset: 0x0017D05C
		internal int b()
		{
			return this.c - this.b + (this.e >> 3);
		}

		// Token: 0x06002901 RID: 10497 RVA: 0x0017E084 File Offset: 0x0017D084
		internal void c()
		{
			this.d >>= (this.e & 7);
			this.e &= -8;
		}

		// Token: 0x06002902 RID: 10498 RVA: 0x0017E0B0 File Offset: 0x0017D0B0
		internal bool d()
		{
			return this.b == this.c;
		}

		// Token: 0x06002903 RID: 10499 RVA: 0x0017E0D0 File Offset: 0x0017D0D0
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

		// Token: 0x06002904 RID: 10500 RVA: 0x0017E1FF File Offset: 0x0017D1FF
		internal zg()
		{
		}

		// Token: 0x06002905 RID: 10501 RVA: 0x0017E228 File Offset: 0x0017D228
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

		// Token: 0x0400128F RID: 4751
		private byte[] a;

		// Token: 0x04001290 RID: 4752
		private int b = 0;

		// Token: 0x04001291 RID: 4753
		private int c = 0;

		// Token: 0x04001292 RID: 4754
		private uint d = 0U;

		// Token: 0x04001293 RID: 4755
		private int e = 0;
	}
}
