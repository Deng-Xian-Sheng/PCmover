using System;

namespace zz93
{
	// Token: 0x020003C6 RID: 966
	internal class y9
	{
		// Token: 0x060028BD RID: 10429 RVA: 0x00179130 File Offset: 0x00178130
		internal y9(int A_0, int A_1, int A_2)
		{
			this.c = A_0;
			this.d = A_1;
			this.e = A_2;
			int num = A_0 * A_2;
			this.f = num / 8;
			if (num % 8 != 0)
			{
				this.f++;
			}
			this.a = new byte[this.f * A_1];
			this.b = new byte[A_0 * A_1];
		}

		// Token: 0x060028BE RID: 10430 RVA: 0x001791A4 File Offset: 0x001781A4
		internal void a(byte[] A_0)
		{
			int num = this.e;
			switch (num)
			{
			case 1:
				this.b(A_0);
				break;
			case 2:
				this.c(A_0);
				break;
			case 3:
				break;
			case 4:
				this.d(A_0);
				break;
			default:
				if (num == 8)
				{
					this.e(A_0);
				}
				break;
			}
		}

		// Token: 0x060028BF RID: 10431 RVA: 0x00179200 File Offset: 0x00178200
		internal void b(byte[] A_0)
		{
			int num = -1;
			int num2 = 0;
			bool flag = this.c % 4 != 0;
			for (int i = 0; i < this.d; i++)
			{
				for (int j = 0; j < this.c; j++)
				{
					int num3 = 7 - j % 8;
					int num4;
					if (num3 > 0)
					{
						num4 = (this.a[num] >> num3 & 1);
					}
					else
					{
						num4 = (int)(this.a[++num] & 1);
					}
					if (num4 < A_0.Length)
					{
						this.b[num2++] = A_0[num4];
					}
					else
					{
						this.b[num2++] = byte.MaxValue;
					}
				}
				if (flag)
				{
					num++;
				}
			}
		}

		// Token: 0x060028C0 RID: 10432 RVA: 0x001792E4 File Offset: 0x001782E4
		internal void c(byte[] A_0)
		{
			int num = -1;
			int num2 = 0;
			bool flag = this.c % 4 != 0;
			for (int i = 0; i < this.d; i++)
			{
				for (int j = 0; j < this.c; j++)
				{
					int num3 = 6 - j % 4 * 2;
					int num4;
					if (num3 > 0)
					{
						num4 = (this.a[num] >> num3 & 3);
					}
					else
					{
						num4 = (int)(this.a[++num] & 3);
					}
					if (num4 < A_0.Length)
					{
						this.b[num2++] = A_0[num4];
					}
					else
					{
						this.b[num2++] = byte.MaxValue;
					}
				}
				if (flag)
				{
					num++;
				}
			}
		}

		// Token: 0x060028C1 RID: 10433 RVA: 0x001793CC File Offset: 0x001783CC
		internal void d(byte[] A_0)
		{
			int num = 0;
			int num2 = 0;
			bool flag = this.c % 2 == 1;
			for (int i = 0; i < this.d; i++)
			{
				for (int j = 0; j < this.c; j++)
				{
					int num3;
					if (j % 2 == 0)
					{
						num3 = (this.a[num] >> 4 & 15);
					}
					else
					{
						num3 = (int)(this.a[num++] & 15);
					}
					if (num3 < A_0.Length)
					{
						this.b[num2++] = A_0[num3];
					}
					else
					{
						this.b[num2++] = byte.MaxValue;
					}
				}
				if (flag)
				{
					num++;
				}
			}
		}

		// Token: 0x060028C2 RID: 10434 RVA: 0x001794A4 File Offset: 0x001784A4
		internal void e(byte[] A_0)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < this.d; i++)
			{
				for (int j = 0; j < this.c; j++)
				{
					byte b = this.a[num++];
					if ((int)b < A_0.Length)
					{
						this.b[num2++] = A_0[(int)b];
					}
					else
					{
						this.b[num2++] = byte.MaxValue;
					}
				}
			}
		}

		// Token: 0x060028C3 RID: 10435 RVA: 0x00179530 File Offset: 0x00178530
		internal void f(byte[] A_0)
		{
			int num = this.f + 1;
			za za = new za();
			za.a(A_0, 0, A_0.Length);
			int num2 = 0;
			for (int i = 0; i < this.d; i++)
			{
				byte[] array = new byte[num];
				za.b(array, 0, num);
				switch (array[0])
				{
				case 0:
				{
					int j = 1;
					while (j < num)
					{
						this.a[num2++] = array[j++];
					}
					break;
				}
				case 1:
				{
					int j = 1;
					this.a[num2++] = array[j++];
					while (j < num)
					{
						this.a[num2] = array[j++] + this.a[num2++ - 1];
					}
					break;
				}
				case 2:
				{
					int j = 1;
					if (i == 0)
					{
						while (j < num)
						{
							this.a[num2++] = array[j++];
						}
					}
					else
					{
						while (j < num)
						{
							this.a[num2] = array[j++] + this.a[num2++ - this.c];
						}
					}
					break;
				}
				case 3:
				{
					int j = 1;
					if (i == 0)
					{
						this.a[num2++] = array[j++];
						while (j < num)
						{
							this.a[num2] = array[j++] + this.a[num2++ - 1] / 2;
						}
					}
					else
					{
						this.a[num2] = array[j++] + this.a[num2++ - this.c] / 2;
						while (j < num)
						{
							this.a[num2] = array[j++] + (this.a[num2 - this.c] + this.a[num2++ - 1]) / 2;
						}
					}
					break;
				}
				case 4:
				{
					int j = 1;
					if (i == 0)
					{
						this.a[num2++] = array[j++];
						while (j < num)
						{
							this.a[num2] = array[j++] + this.a(this.a[num2++ - 1], 0, 0);
						}
					}
					else
					{
						this.a[num2] = array[j++] + this.a(0, this.a[num2++ - this.c], 0);
						while (j < num)
						{
							this.a[num2] = array[j++] + this.a(this.a[num2 - 1], this.a[num2 - this.c], this.a[num2++ - this.c - 1]);
						}
					}
					break;
				}
				}
			}
		}

		// Token: 0x060028C4 RID: 10436 RVA: 0x00179860 File Offset: 0x00178860
		internal byte[] a()
		{
			return this.b;
		}

		// Token: 0x060028C5 RID: 10437 RVA: 0x00179878 File Offset: 0x00178878
		private byte a(byte A_0, byte A_1, byte A_2)
		{
			int num = (int)(A_0 + A_1 - A_2);
			int num2 = Math.Abs(num - (int)A_0);
			int num3 = Math.Abs(num - (int)A_1);
			int num4 = Math.Abs(num - (int)A_2);
			byte result;
			if (num2 <= num3 && num2 <= num4)
			{
				result = A_0;
			}
			else if (num3 <= num4)
			{
				result = A_1;
			}
			else
			{
				result = A_2;
			}
			return result;
		}

		// Token: 0x0400123F RID: 4671
		private byte[] a;

		// Token: 0x04001240 RID: 4672
		private byte[] b;

		// Token: 0x04001241 RID: 4673
		private int c;

		// Token: 0x04001242 RID: 4674
		private int d;

		// Token: 0x04001243 RID: 4675
		private int e;

		// Token: 0x04001244 RID: 4676
		private int f;
	}
}
