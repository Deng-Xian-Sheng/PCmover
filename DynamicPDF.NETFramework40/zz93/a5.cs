using System;
using System.Collections;
using System.Text;

namespace zz93
{
	// Token: 0x0200003C RID: 60
	internal class a5
	{
		// Token: 0x0600024A RID: 586 RVA: 0x0003AA84 File Offset: 0x00039A84
		internal a5(string A_0, float A_1, bool A_2, bool A_3)
		{
			this.e = A_2;
			this.d = A_1;
			this.b = A_0.Replace(" ", "");
			this.b = this.b.Replace("-", "");
			if (A_3)
			{
				this.c = new byte[this.b.Length + 1];
			}
			else
			{
				this.c = new byte[this.b.Length];
			}
			Encoding.ASCII.GetBytes(this.b).CopyTo(this.c, 0);
			if (A_3)
			{
				this.a(this.c);
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0003AB48 File Offset: 0x00039B48
		internal float b()
		{
			return ((float)this.a() - 0.5f) * this.d;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0003AB70 File Offset: 0x00039B70
		internal float c()
		{
			return (float)(this.a() * 2 - 1) * this.d;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0003AB94 File Offset: 0x00039B94
		internal BitArray d()
		{
			this.a = new BitArray(this.a() * 3, true);
			int num = 0;
			if (this.e)
			{
				this.d(ref num);
			}
			foreach (byte a_ in this.c)
			{
				this.a(a_, ref num);
			}
			if (this.e)
			{
				this.b(ref num);
			}
			return this.a(this.a, ref num);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0003AC30 File Offset: 0x00039C30
		private int a()
		{
			int num = this.c.Length;
			num *= 4;
			if (this.e)
			{
				num += 2;
			}
			return num;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0003AC64 File Offset: 0x00039C64
		private BitArray a(BitArray A_0, ref int A_1)
		{
			BitArray bitArray = new BitArray(A_1 * 2);
			int num = A_1 / 3;
			int num2 = num * 2 - 1;
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < num2; i++)
			{
				if (i % 2 == 0)
				{
					for (int j = 0; j < 3; j++)
					{
						bitArray[num4] = A_0[num3];
						num3++;
						num4++;
					}
				}
				else
				{
					for (int j = 0; j < 3; j++)
					{
						bitArray[num4] = true;
						num4++;
						A_1++;
					}
				}
			}
			A_0 = bitArray;
			bitArray = new BitArray(A_1);
			num3 = 0;
			for (int i = 0; i < A_1 / num2; i++)
			{
				num4 = i;
				for (int j = 0; j < num2; j++)
				{
					bitArray[num3] = A_0[num4];
					num3++;
					num4 += A_1 / num2;
				}
			}
			return bitArray;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0003AD88 File Offset: 0x00039D88
		private void a(byte A_0, ref int A_1)
		{
			switch (A_0)
			{
			case 48:
				this.a(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				this.b(ref A_1);
				return;
			case 49:
				this.a(ref A_1);
				this.c(ref A_1);
				this.d(ref A_1);
				this.b(ref A_1);
				return;
			case 50:
				this.a(ref A_1);
				this.c(ref A_1);
				this.b(ref A_1);
				this.d(ref A_1);
				return;
			case 51:
				this.c(ref A_1);
				this.a(ref A_1);
				this.d(ref A_1);
				this.b(ref A_1);
				return;
			case 52:
				this.c(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				this.d(ref A_1);
				return;
			case 53:
				this.c(ref A_1);
				this.c(ref A_1);
				this.d(ref A_1);
				this.d(ref A_1);
				return;
			case 54:
				this.a(ref A_1);
				this.d(ref A_1);
				this.c(ref A_1);
				this.b(ref A_1);
				return;
			case 55:
				this.a(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				return;
			case 56:
				this.a(ref A_1);
				this.b(ref A_1);
				this.c(ref A_1);
				this.d(ref A_1);
				return;
			case 57:
				this.c(ref A_1);
				this.d(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				return;
			case 65:
				this.c(ref A_1);
				this.d(ref A_1);
				this.c(ref A_1);
				this.d(ref A_1);
				return;
			case 66:
				this.c(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				this.d(ref A_1);
				return;
			case 67:
				this.a(ref A_1);
				this.d(ref A_1);
				this.b(ref A_1);
				this.c(ref A_1);
				return;
			case 68:
				this.a(ref A_1);
				this.b(ref A_1);
				this.d(ref A_1);
				this.c(ref A_1);
				return;
			case 69:
				this.a(ref A_1);
				this.b(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				return;
			case 70:
				this.c(ref A_1);
				this.d(ref A_1);
				this.d(ref A_1);
				this.c(ref A_1);
				return;
			case 71:
				this.c(ref A_1);
				this.d(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				return;
			case 72:
				this.c(ref A_1);
				this.b(ref A_1);
				this.d(ref A_1);
				this.a(ref A_1);
				return;
			case 73:
				this.d(ref A_1);
				this.a(ref A_1);
				this.c(ref A_1);
				this.b(ref A_1);
				return;
			case 74:
				this.d(ref A_1);
				this.c(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				return;
			case 75:
				this.d(ref A_1);
				this.c(ref A_1);
				this.c(ref A_1);
				this.d(ref A_1);
				return;
			case 76:
				this.b(ref A_1);
				this.a(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				return;
			case 77:
				this.b(ref A_1);
				this.a(ref A_1);
				this.c(ref A_1);
				this.d(ref A_1);
				return;
			case 78:
				this.b(ref A_1);
				this.c(ref A_1);
				this.a(ref A_1);
				this.d(ref A_1);
				return;
			case 79:
				this.d(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				this.c(ref A_1);
				return;
			case 80:
				this.d(ref A_1);
				this.c(ref A_1);
				this.d(ref A_1);
				this.c(ref A_1);
				return;
			case 81:
				this.d(ref A_1);
				this.c(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				return;
			case 82:
				this.b(ref A_1);
				this.a(ref A_1);
				this.d(ref A_1);
				this.c(ref A_1);
				return;
			case 83:
				this.b(ref A_1);
				this.a(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				return;
			case 84:
				this.b(ref A_1);
				this.c(ref A_1);
				this.d(ref A_1);
				this.a(ref A_1);
				return;
			case 85:
				this.d(ref A_1);
				this.d(ref A_1);
				this.c(ref A_1);
				this.c(ref A_1);
				return;
			case 86:
				this.d(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				this.c(ref A_1);
				return;
			case 87:
				this.d(ref A_1);
				this.b(ref A_1);
				this.c(ref A_1);
				this.a(ref A_1);
				return;
			case 88:
				this.b(ref A_1);
				this.d(ref A_1);
				this.a(ref A_1);
				this.c(ref A_1);
				return;
			case 89:
				this.b(ref A_1);
				this.d(ref A_1);
				this.c(ref A_1);
				this.a(ref A_1);
				return;
			case 90:
				this.b(ref A_1);
				this.b(ref A_1);
				this.a(ref A_1);
				this.a(ref A_1);
				return;
			}
			throw new ap("Invalid RM4SCC character.");
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0003B388 File Offset: 0x0003A388
		private void d(ref int A_0)
		{
			for (int i = 0; i < 2; i++)
			{
				this.a[A_0] = false;
				A_0++;
			}
			for (int i = 0; i < 1; i++)
			{
				this.a[A_0] = true;
				A_0++;
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0003B3E4 File Offset: 0x0003A3E4
		private void c(ref int A_0)
		{
			for (int i = 0; i < 1; i++)
			{
				this.a[A_0] = true;
				A_0++;
			}
			for (int i = 0; i < 2; i++)
			{
				this.a[A_0] = false;
				A_0++;
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0003B440 File Offset: 0x0003A440
		private void b(ref int A_0)
		{
			for (int i = 0; i < 3; i++)
			{
				this.a[A_0] = false;
				A_0++;
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0003B478 File Offset: 0x0003A478
		private void a(ref int A_0)
		{
			for (int i = 0; i < 1; i++)
			{
				this.a[A_0] = true;
				A_0++;
			}
			for (int i = 0; i < 1; i++)
			{
				this.a[A_0] = false;
				A_0++;
			}
			for (int i = 0; i < 1; i++)
			{
				this.a[A_0] = true;
				A_0++;
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0003B4FC File Offset: 0x0003A4FC
		private void a(byte[] A_0)
		{
			int num = 0;
			int num2 = 0;
			int i = 0;
			while (i < A_0.Length - 1)
			{
				switch (A_0[i])
				{
				case 48:
					num++;
					num2++;
					break;
				case 49:
					num++;
					num2 += 2;
					break;
				case 50:
					num++;
					num2 += 3;
					break;
				case 51:
					num++;
					num2 += 4;
					break;
				case 52:
					num++;
					num2 += 5;
					break;
				case 53:
					num++;
					num2 += 6;
					break;
				case 54:
					num += 2;
					num2++;
					break;
				case 55:
					num += 2;
					num2 += 2;
					break;
				case 56:
					num += 2;
					num2 += 3;
					break;
				case 57:
					num += 2;
					num2 += 4;
					break;
				case 65:
					num += 2;
					num2 += 5;
					break;
				case 66:
					num += 2;
					num2 += 6;
					break;
				case 67:
					num += 3;
					num2++;
					break;
				case 68:
					num += 3;
					num2 += 2;
					break;
				case 69:
					num += 3;
					num2 += 3;
					break;
				case 70:
					num += 3;
					num2 += 4;
					break;
				case 71:
					num += 3;
					num2 += 5;
					break;
				case 72:
					num += 3;
					num2 += 6;
					break;
				case 73:
					num += 4;
					num2++;
					break;
				case 74:
					num += 4;
					num2 += 2;
					break;
				case 75:
					num += 4;
					num2 += 3;
					break;
				case 76:
					num += 4;
					num2 += 4;
					break;
				case 77:
					num += 4;
					num2 += 5;
					break;
				case 78:
					num += 4;
					num2 += 6;
					break;
				case 79:
					num += 5;
					num2++;
					break;
				case 80:
					num += 5;
					num2 += 2;
					break;
				case 81:
					num += 5;
					num2 += 3;
					break;
				case 82:
					num += 5;
					num2 += 4;
					break;
				case 83:
					num += 5;
					num2 += 5;
					break;
				case 84:
					num += 5;
					num2 += 6;
					break;
				case 85:
					num += 6;
					num2++;
					break;
				case 86:
					num += 6;
					num2 += 2;
					break;
				case 87:
					num += 6;
					num2 += 3;
					break;
				case 88:
					num += 6;
					num2 += 4;
					break;
				case 89:
					num += 6;
					num2 += 5;
					break;
				case 90:
					num += 6;
					num2 += 6;
					break;
				}
				IL_27B:
				i++;
				continue;
				goto IL_27B;
			}
			int a_ = num % 6;
			int a_2 = num2 % 6;
			A_0[i] = this.a(a_, a_2);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0003B7B0 File Offset: 0x0003A7B0
		private byte a(int A_0, int A_1)
		{
			byte result;
			switch (A_0)
			{
			case 1:
				if (A_1 == 0)
				{
					result = 53;
				}
				else
				{
					result = (byte)(47 + A_1);
				}
				break;
			case 2:
				switch (A_1)
				{
				case 1:
					return 54;
				case 2:
					return 55;
				case 3:
					return 56;
				case 4:
					return 57;
				case 5:
					return 65;
				}
				result = 66;
				break;
			case 3:
				if (A_1 == 0)
				{
					result = 72;
				}
				else
				{
					result = (byte)(66 + A_1);
				}
				break;
			case 4:
				if (A_1 == 0)
				{
					result = 78;
				}
				else
				{
					result = (byte)(72 + A_1);
				}
				break;
			case 5:
				if (A_1 == 0)
				{
					result = 84;
				}
				else
				{
					result = (byte)(78 + A_1);
				}
				break;
			default:
				if (A_1 == 0)
				{
					result = 90;
				}
				else
				{
					result = (byte)(84 + A_1);
				}
				break;
			}
			return result;
		}

		// Token: 0x0400018D RID: 397
		private BitArray a;

		// Token: 0x0400018E RID: 398
		private string b;

		// Token: 0x0400018F RID: 399
		private byte[] c;

		// Token: 0x04000190 RID: 400
		private float d;

		// Token: 0x04000191 RID: 401
		private bool e;
	}
}
