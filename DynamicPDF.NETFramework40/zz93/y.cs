using System;

namespace zz93
{
	// Token: 0x0200001B RID: 27
	internal class y : r
	{
		// Token: 0x06000120 RID: 288 RVA: 0x00024BD6 File Offset: 0x00023BD6
		internal y(int A_0, bool A_1, bool A_2, int A_3, bool A_4) : base(A_0, A_3, A_2, A_1, A_4)
		{
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00024BE8 File Offset: 0x00023BE8
		internal i a(byte[] A_0, bool A_1, i A_2)
		{
			int num = A_0.Length;
			int num2 = num % 4;
			if (num2 != 0)
			{
				num -= num2;
			}
			if (num2 == 0)
			{
				num -= 4;
				num2 = 4;
			}
			int i = 0;
			while (i < num)
			{
				int num3 = -1;
				if (A_1)
				{
					if (A_0[i] == 126)
					{
						num3 = 0;
					}
					else if (A_0[i + 1] == 126)
					{
						num3 = 1;
					}
					else if (A_0[i + 2] == 126)
					{
						num3 = 2;
					}
					else if (A_0[i + 3] == 126)
					{
						num3 = 3;
					}
					if (num3 >= 0)
					{
						if (num3 <= 2 && A_0[i + num3 + 1] == 49)
						{
							byte[] array = new byte[4];
							for (int j = 0; j < 4; j++)
							{
								array[j] = A_0[i + j];
							}
							A_2 = this.a(array, A_2, A_1);
							i += 3;
							goto IL_3C3;
						}
						i result;
						if (num3 >= 3 && A_0[i + num3 + 1] == 49)
						{
							byte[] array = new byte[5];
							for (int j = 0; j < 5; j++)
							{
								array[j] = A_0[i + j];
							}
							A_2 = this.a(array, A_2, A_1);
							int num4 = i + 5;
							int num5 = num - num4 + num2;
							array = new byte[num5];
							Array.Copy(A_0, num4, array, 0, num5);
							A_2 = this.a(array, A_1, A_2);
							result = A_2;
						}
						else
						{
							if (num3 > 3 || A_0[i + num3 + 1] != 50 || i + num3 + 7 > A_0.Length)
							{
								goto IL_26F;
							}
							byte[] array = new byte[num3 + 8];
							for (int j = 0; j < array.Length; j++)
							{
								array[j] = A_0[i + j];
							}
							A_2 = this.a(array, A_2, A_1);
							int num4 = i + num3 + 8;
							int num5 = num - num4 + num2;
							if (num5 > 0)
							{
								array = new byte[num5];
								Array.Copy(A_0, num4, array, 0, num5);
								A_2 = this.a(array, A_1, A_2);
							}
							else if (num5 == 0 && base.e())
							{
								A_2 = base.b(A_2);
							}
							result = A_2;
						}
						return result;
					}
					IL_26F:
					goto IL_270;
				}
				goto IL_270;
				IL_3C3:
				i++;
				continue;
				IL_270:
				if (!base.d() || A_2.a() + 4 <= base.c() - 4)
				{
					if (base.b() != 8)
					{
						base.b(base.b(), A_2);
						base.c(8, A_2);
					}
					if (A_0[i] < 32 || A_0[i] > 94 || A_0[i + 1] < 32 || A_0[i + 1] > 94 || A_0[i + 2] < 32 || A_0[i + 2] > 94 || A_0[i + 3] < 32 || A_0[i + 3] > 94)
					{
						throw new ap("Invalid barcode Value.");
					}
					int num6 = (int)(A_0[i] & 63) << 18;
					num6 |= (int)(A_0[i + 1] & 63) << 12;
					num6 |= (int)(A_0[i + 2] & 63) << 6;
					num6 |= (int)(A_0[i + 3] & 63);
					A_2.a((byte)(num6 >> 16 & 255));
					A_2.a((byte)(num6 >> 8 & 255));
					A_2.a((byte)(num6 & 255));
					i += 3;
				}
				else
				{
					if (A_2.a() == 0)
					{
						throw new ao("Invalid symbol size for overflow.");
					}
					A_2 = base.a(A_2);
					i--;
				}
				goto IL_3C3;
			}
			if (num2 != 0)
			{
				if (num2 >= 1)
				{
					byte[] array2 = new byte[num2];
					for (int j = 0; j < num2; j++)
					{
						array2[j] = A_0[num + j];
					}
					A_2 = this.a(array2, A_2, A_1);
				}
			}
			if (base.e())
			{
				A_2 = base.b(A_2);
			}
			return A_2;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0002503C File Offset: 0x0002403C
		private i a(byte[] A_0, i A_1, bool A_2)
		{
			if (base.b() != 1)
			{
				base.b(base.b(), A_1);
			}
			int i = 0;
			while (i < A_0.Length)
			{
				int num = 1;
				if (A_2 && A_0[i] == 126 && i < A_0.Length - 1 && A_0[i + 1] == 50 && i + 7 <= A_0.Length)
				{
					num = 4;
				}
				if (!base.d() || A_1.a() + num <= base.c() - 4)
				{
					if (A_2)
					{
						if (A_0[i] == 126 && i < A_0.Length - 1 && A_0[i + 1] == 49)
						{
							A_1.a(232);
							i++;
							goto IL_220;
						}
						if (A_0[i] == 126 && i < A_0.Length - 1 && A_0[i + 1] == 50 && i + 7 <= A_0.Length)
						{
							base.a(A_0, i + 2, i + 8, A_1);
							i += 7;
							goto IL_220;
						}
					}
					if (A_0[i] > 47 && A_0[i] < 58 && i < A_0.Length - 1 && A_0[i + 1] > 47 && A_0[i + 1] < 58)
					{
						int num2 = (int)(A_0[i] - 48);
						num2 *= 10;
						i++;
						num2 += (int)(A_0[i] - 48);
						A_1.a((byte)(num2 + 130));
					}
					else if (A_0[i] >= 0 && A_0[i] <= 127)
					{
						A_1.a(A_0[i] + 1);
					}
					else
					{
						if (A_0[i] <= 127 || A_0[i] > 255)
						{
							throw new ap("Invalid barcode value.");
						}
						A_1.a(235);
						A_1.a(A_0[i] - 128 + 1);
					}
				}
				else
				{
					if (A_1.a() == 0)
					{
						throw new ao("Invalid symbol size for overflow.");
					}
					A_1 = base.a(A_1);
					i--;
				}
				IL_220:
				i++;
				continue;
				goto IL_220;
			}
			return A_1;
		}
	}
}
