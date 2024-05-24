using System;

namespace zz93
{
	// Token: 0x02000415 RID: 1045
	internal class aa7
	{
		// Token: 0x06002B9A RID: 11162 RVA: 0x00193304 File Offset: 0x00192304
		internal void a(int A_0)
		{
			if (this.e++ == aa7.a)
			{
				throw new InvalidOperationException("Window full");
			}
			this.c[this.d++] = (byte)A_0;
			this.d &= aa7.b;
		}

		// Token: 0x06002B9B RID: 11163 RVA: 0x0019336C File Offset: 0x0019236C
		private void a(int A_0, int A_1)
		{
			while (A_1-- > 0)
			{
				this.c[this.d++] = this.c[A_0++];
				this.d &= aa7.b;
				A_0 &= aa7.b;
			}
		}

		// Token: 0x06002B9C RID: 11164 RVA: 0x001933CC File Offset: 0x001923CC
		internal void b(int A_0, int A_1)
		{
			if ((this.e += A_0) > aa7.a)
			{
				throw new InvalidOperationException("Window full");
			}
			int num = this.d - A_1 & aa7.b;
			int num2 = aa7.a - A_0;
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

		// Token: 0x06002B9D RID: 11165 RVA: 0x001934B0 File Offset: 0x001924B0
		internal int a(aa8 A_0, int A_1)
		{
			A_1 = Math.Min(Math.Min(A_1, aa7.a - this.e), A_0.b());
			int num = aa7.a - this.d;
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
			this.d = (this.d + num2 & aa7.b);
			this.e += num2;
			return num2;
		}

		// Token: 0x06002B9E RID: 11166 RVA: 0x0019356C File Offset: 0x0019256C
		internal int a()
		{
			return aa7.a - this.e;
		}

		// Token: 0x06002B9F RID: 11167 RVA: 0x0019358C File Offset: 0x0019258C
		internal int b()
		{
			return this.e;
		}

		// Token: 0x06002BA0 RID: 11168 RVA: 0x001935A4 File Offset: 0x001925A4
		internal int a(byte[] A_0, int A_1, int A_2)
		{
			int num = this.d;
			if (A_2 > this.e)
			{
				A_2 = this.e;
			}
			else
			{
				num = (this.d - this.e + A_2 & aa7.b);
			}
			int num2 = A_2;
			int num3 = A_2 - num;
			if (num3 > 0)
			{
				Array.Copy(this.c, aa7.a - num3, A_0, A_1, num3);
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

		// Token: 0x0400148C RID: 5260
		private static int a = 32768;

		// Token: 0x0400148D RID: 5261
		private static int b = aa7.a - 1;

		// Token: 0x0400148E RID: 5262
		private byte[] c = new byte[aa7.a];

		// Token: 0x0400148F RID: 5263
		private int d = 0;

		// Token: 0x04001490 RID: 5264
		private int e = 0;
	}
}
