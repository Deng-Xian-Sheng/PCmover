using System;

namespace zz93
{
	// Token: 0x020003CB RID: 971
	internal class ze
	{
		// Token: 0x060028E9 RID: 10473 RVA: 0x0017AF10 File Offset: 0x00179F10
		internal void a(int A_0)
		{
			if (this.e++ == ze.a)
			{
				throw new InvalidOperationException("Window full");
			}
			this.c[this.d++] = (byte)A_0;
			this.d &= ze.b;
		}

		// Token: 0x060028EA RID: 10474 RVA: 0x0017AF78 File Offset: 0x00179F78
		private void a(int A_0, int A_1)
		{
			while (A_1-- > 0)
			{
				this.c[this.d++] = this.c[A_0++];
				this.d &= ze.b;
				A_0 &= ze.b;
			}
		}

		// Token: 0x060028EB RID: 10475 RVA: 0x0017AFD8 File Offset: 0x00179FD8
		internal void b(int A_0, int A_1)
		{
			if ((this.e += A_0) > ze.a)
			{
				throw new InvalidOperationException("Window full");
			}
			int num = this.d - A_1 & ze.b;
			int num2 = ze.a - A_0;
			if (num <= num2 && this.d < num2)
			{
				if (A_0 <= A_1)
				{
					Array.Copy(this.c, num, this.c, this.d, A_0);
					this.d += A_0;
				}
				else
				{
					while (A_0-- > 0)
					{
						this.c[this.d++] = this.c[num++];
					}
				}
			}
			else
			{
				this.a(num, A_0);
			}
		}

		// Token: 0x060028EC RID: 10476 RVA: 0x0017B0BC File Offset: 0x0017A0BC
		internal int a(zg A_0, int A_1)
		{
			A_1 = Math.Min(Math.Min(A_1, ze.a - this.e), A_0.b());
			int num = ze.a - this.d;
			int num2;
			if (A_1 > num)
			{
				num2 = A_0.a(this.c, this.d, num);
				if (num2 == num)
				{
					num2 += A_0.a(this.c, 0, A_1 - num);
				}
			}
			else
			{
				num2 = A_0.a(this.c, this.d, A_1);
			}
			this.d = (this.d + num2 & ze.b);
			this.e += num2;
			return num2;
		}

		// Token: 0x060028ED RID: 10477 RVA: 0x0017B178 File Offset: 0x0017A178
		internal int a()
		{
			return ze.a - this.e;
		}

		// Token: 0x060028EE RID: 10478 RVA: 0x0017B198 File Offset: 0x0017A198
		internal int b()
		{
			return this.e;
		}

		// Token: 0x060028EF RID: 10479 RVA: 0x0017B1B0 File Offset: 0x0017A1B0
		internal int a(byte[] A_0, int A_1, int A_2)
		{
			int num = this.d;
			if (A_2 > this.e)
			{
				A_2 = this.e;
			}
			else
			{
				num = (this.d - this.e + A_2 & ze.b);
			}
			int num2 = A_2;
			int num3 = A_2 - num;
			if (num3 > 0)
			{
				Array.Copy(this.c, ze.a - num3, A_0, A_1, num3);
				A_1 += num3;
				A_2 = num;
			}
			Array.Copy(this.c, num - A_2, A_0, A_1, A_2);
			this.e -= num2;
			if (this.e < 0)
			{
				throw new InvalidOperationException();
			}
			return num2;
		}

		// Token: 0x04001288 RID: 4744
		private static int a = 32768;

		// Token: 0x04001289 RID: 4745
		private static int b = ze.a - 1;

		// Token: 0x0400128A RID: 4746
		private byte[] c = new byte[ze.a];

		// Token: 0x0400128B RID: 4747
		private int d = 0;

		// Token: 0x0400128C RID: 4748
		private int e = 0;
	}
}
