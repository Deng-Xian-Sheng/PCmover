using System;

namespace zz93
{
	// Token: 0x0200000C RID: 12
	internal class j
	{
		// Token: 0x0600008B RID: 139 RVA: 0x0001B996 File Offset: 0x0001A996
		internal j(ax A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0001B9A8 File Offset: 0x0001A9A8
		internal int[] a(byte[] A_0)
		{
			int[] array = new int[128];
			int num = 0;
			int num2 = 0;
			int i = A_0.Length;
			int[] array2 = new int[5];
			for (int j = 0; j < A_0.Length; j++)
			{
				if (A_0[j] < 0 || A_0[j] > 255)
				{
					throw new ap("Bytes are out of range");
				}
			}
			while (i > 0)
			{
				if (i >= 6)
				{
					long num3 = 0L;
					int num4 = 5;
					for (int j = num2; j < num2 + 6; j++)
					{
						num3 += (long)((ulong)A_0[j] * (ulong)((long)Math.Pow(256.0, (double)num4)));
						num4--;
					}
					array2 = this.a(num3);
					for (int k = 0; k < array2.Length; k++)
					{
						if (num < array.Length)
						{
							array[num] = array2[k];
							num++;
						}
						else
						{
							array = this.a(array);
							array[num] = array2[k];
							num++;
						}
					}
				}
				else
				{
					for (int j = num2; j < A_0.Length; j++)
					{
						if (num < array.Length)
						{
							array[num] = (int)A_0[j];
							num++;
						}
						else
						{
							array = this.a(array);
							array[num] = (int)A_0[j];
							num++;
						}
					}
				}
				i -= 6;
				num2 += 6;
			}
			int[] array3 = new int[num];
			Array.Copy(array, 0, array3, 0, num);
			return array3;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0001BB50 File Offset: 0x0001AB50
		internal int[] a()
		{
			int num = 0;
			byte[] array = this.a.c();
			int[] array2 = new int[128];
			int[] array3 = new int[5];
			int num2 = this.a.e();
			int num3 = this.a.d();
			int num4 = array.Length - num3;
			byte[] array4 = new byte[num4];
			int num5 = 0;
			int num6 = 0;
			for (int i = num3; i < array.Length; i++)
			{
				array4[num6++] = array[i];
			}
			for (int i = 0; i < array4.Length; i++)
			{
				if (array4[i] < 0 || array4[i] > 255)
				{
					throw new ap("Bytes are out of range");
				}
			}
			num2--;
			int num7 = num2 / 5;
			int num8 = num2 % 5;
			if (num7 <= 0)
			{
				throw new ao("Please increase the number of rows or columns in the barcode since the size is not enough to write any data into one or more of the barcodes.");
			}
			while (num4 > 0 && num7 > 0)
			{
				if (num4 >= 6)
				{
					long num9 = 0L;
					int num10 = 5;
					for (int i = num5; i < num5 + 6; i++)
					{
						num9 += (long)((ulong)array4[i] * (ulong)((long)Math.Pow(256.0, (double)num10)));
						num10--;
					}
					array3 = this.a(num9);
					for (int j = 0; j < array3.Length; j++)
					{
						if (num < array2.Length)
						{
							array2[num] = array3[j];
							num++;
						}
						else
						{
							array2 = this.a(array2);
							array2[num] = array3[j];
							num++;
						}
					}
					num4 -= 6;
					num5 += 6;
				}
				else
				{
					int num11 = 0;
					for (int i = num5; i < array4.Length; i++)
					{
						if (num < array2.Length)
						{
							array2[num] = (int)array4[i];
							num++;
							num11++;
						}
						else
						{
							array2 = this.a(array2);
							array2[num] = (int)array4[i];
							num++;
							num11++;
						}
					}
					num4 -= num11;
					num5 += num11;
				}
				num7--;
			}
			if (num8 > 0 && num7 == 0)
			{
				for (int i = 0; i < num8; i++)
				{
					if (num < array2.Length)
					{
						array2[num] = 900;
						num++;
					}
					else
					{
						array2 = this.a(array2);
						array2[num] = 900;
						num++;
					}
				}
			}
			this.a.b(num3 + num5);
			this.a.c(num5);
			int[] array5 = new int[num];
			Array.Copy(array2, 0, array5, 0, num);
			return array5;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0001BE3C File Offset: 0x0001AE3C
		internal int[] a(byte[] A_0, int A_1)
		{
			int[] array = new int[128];
			int num = 0;
			int num2 = 0;
			int num3 = A_0.Length;
			int[] array2 = new int[5];
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] < 0 || A_0[i] > 255)
				{
					throw new ap("Bytes are out of range");
				}
			}
			while (num3 > 0 && A_1 > 0)
			{
				if (num3 >= 6)
				{
					if (A_1 >= 5)
					{
						long num4 = 0L;
						int num5 = 5;
						for (int i = num2; i < num2 + 6; i++)
						{
							num4 += (long)((ulong)A_0[i] * (ulong)((long)Math.Pow(256.0, (double)num5)));
							num5--;
						}
						array2 = this.a(num4);
						for (int j = 0; j < array2.Length; j++)
						{
							if (num < array.Length)
							{
								array[num] = array2[j];
								num++;
							}
							else
							{
								array = this.a(array);
								array[num] = array2[j];
								num++;
							}
						}
						num3 -= 6;
						num2 += 6;
						A_1 -= array2.Length;
					}
					else
					{
						int j;
						for (j = 0; j < A_1; j++)
						{
							if (num < array.Length)
							{
								array[num] = 900;
								num++;
							}
							else
							{
								array = this.a(array);
								array[num] = 900;
								num++;
							}
						}
						A_1 -= j;
					}
				}
				else
				{
					int num6 = 0;
					for (int i = num2; i < A_0.Length; i++)
					{
						if (num6 < A_1)
						{
							if (num < array.Length)
							{
								array[num] = (int)A_0[i];
								num++;
							}
							else
							{
								array = this.a(array);
								array[num] = (int)A_0[i];
								num++;
							}
							num6++;
						}
					}
					num3 -= num6;
					num2 += num6;
					A_1 -= num6;
				}
			}
			this.a.a(A_1);
			this.a.b(num2);
			int[] array3 = new int[num];
			Array.Copy(array, 0, array3, 0, num);
			return array3;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0001C09C File Offset: 0x0001B09C
		private int[] a(long A_0)
		{
			int[] array = new int[5];
			int[] array2 = new int[5];
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 5; i++)
			{
				long num3 = A_0 % 900L;
				A_0 /= 900L;
				array[num] = (int)num3;
				num++;
			}
			int[] array3 = new int[num];
			Array.Copy(array, 0, array3, 0, num);
			array2 = new int[array3.Length];
			for (int j = array3.Length - 1; j >= 0; j--)
			{
				array2[num2] = array3[j];
				num2++;
			}
			return array2;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0001C144 File Offset: 0x0001B144
		private int[] a(int[] A_0)
		{
			int[] array = new int[A_0.Length * 2];
			Array.Copy(A_0, 0, array, 0, A_0.Length);
			return array;
		}

		// Token: 0x0400005B RID: 91
		private ax a;
	}
}
