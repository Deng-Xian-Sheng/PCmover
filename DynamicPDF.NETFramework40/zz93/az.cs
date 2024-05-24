using System;

namespace zz93
{
	// Token: 0x02000036 RID: 54
	internal class az
	{
		// Token: 0x06000225 RID: 549 RVA: 0x00032901 File Offset: 0x00031901
		internal az(int A_0, int A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0003291C File Offset: 0x0003191C
		internal int a()
		{
			return this.b;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00032934 File Offset: 0x00031934
		internal int[] a(int[] A_0, byte[] A_1)
		{
			int num = 0;
			int num2 = 0;
			foreach (byte b in A_1)
			{
				num2 += (int)b;
			}
			if ((num2 + 4) % 8 != 0)
			{
				num = 8 - (num2 + 4) % 8;
			}
			int[] array = new int[num2 + 4 + num];
			int num3 = 0;
			for (int j = 0; j < A_0.Length; j++)
			{
				int k = A_0[j];
				int num4 = (int)A_1[j];
				int num5 = (int)A_1[j];
				int[] array2 = new int[num4];
				while (k > 0)
				{
					int num6 = k % 2;
					array2[--num4] = num6;
					k /= 2;
				}
				for (int l = 0; l < num5; l++)
				{
					array[num3] = array2[l];
					num3++;
				}
			}
			for (int j = 0; j < 4; j++)
			{
				array[num3] = 0;
				num3++;
			}
			for (int j = 0; j < num; j++)
			{
				array[num3] = 0;
				num3++;
			}
			return array;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00032A68 File Offset: 0x00031A68
		internal short[] c(int[] A_0)
		{
			short[] array = new short[this.a];
			int num = this.a;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < A_0.Length / 8; i++)
			{
				for (int j = 7; j >= 0; j--)
				{
					array[num2] = (short)((double)array[num2] + (double)A_0[num3++] * Math.Pow(2.0, (double)j));
				}
				num2++;
			}
			while (num2 != num)
			{
				array[num2++] = 236;
				if (num2 == num)
				{
					break;
				}
				array[num2++] = 17;
			}
			return array;
		}

		// Token: 0x04000176 RID: 374
		private int a;

		// Token: 0x04000177 RID: 375
		private int b;
	}
}
