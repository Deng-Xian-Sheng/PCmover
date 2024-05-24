using System;

namespace zz93
{
	// Token: 0x0200003A RID: 58
	internal class a3 : az
	{
		// Token: 0x06000241 RID: 577 RVA: 0x0003A3D4 File Offset: 0x000393D4
		internal a3(int A_0, int A_1) : base(A_0, A_1)
		{
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0003A3E4 File Offset: 0x000393E4
		internal short[] a(byte[] A_0, int A_1, int A_2)
		{
			int[] array = new int[A_2];
			int num = 0;
			for (int i = 0; i < A_0.Length; i++)
			{
				byte[] array2 = new byte[2];
				if (A_0[i] > 128)
				{
					array2[0] = A_0[i];
					i++;
					array2[1] = A_0[i];
					array[num] = this.b(this.a(array2));
					num++;
				}
				else
				{
					array[num] = (int)A_0[i];
					num++;
				}
			}
			int[] array3 = this.b(array);
			int num2 = 0;
			int num3 = array3.Length;
			int num4;
			if (A_1 <= 8)
			{
				num4 = 8;
			}
			else if (A_1 >= 9 && A_1 <= 25)
			{
				num4 = 10;
			}
			else
			{
				num4 = 12;
			}
			int num5 = num3 + 2;
			int[] array4;
			byte[] array5;
			if (base.a() == 0)
			{
				num5++;
				array4 = new int[num5];
				array5 = new byte[num5];
				array4[num2] = 5;
				array5[num2] = 4;
				num2++;
			}
			else if (base.a() == 1)
			{
				num5++;
				array4 = new int[num5];
				array5 = new byte[num5];
				array4[num2] = 9;
				array5[num2] = 4;
				num2++;
			}
			else
			{
				array4 = new int[num5];
				array5 = new byte[num5];
			}
			array4[num2] = 8;
			array5[num2] = 4;
			num2++;
			array4[num2] = num3;
			array5[num2] = (byte)num4;
			num2++;
			for (int j = 0; j < num3; j++)
			{
				array4[num2] = array3[j];
				array5[num2] = 13;
				num2++;
			}
			int[] a_ = base.a(array4, array5);
			return base.c(a_);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0003A5B4 File Offset: 0x000395B4
		internal int b(short[] A_0)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < A_0.Length / 16; i++)
			{
				for (int j = 15; j >= 0; j--)
				{
					num = (int)((double)num + (double)A_0[num3++] * Math.Pow(2.0, (double)j));
				}
				num2++;
			}
			return num;
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0003A628 File Offset: 0x00039628
		private short[] a(byte[] A_0)
		{
			short[] array = new short[A_0.Length * 8];
			int num = 0;
			foreach (short num2 in A_0)
			{
				int num3 = 8;
				short[] array2 = new short[8];
				while (num2 > 0)
				{
					short num4 = num2 % 2;
					array2[--num3] = num4;
					num2 /= 2;
				}
				for (int j = 0; j < 8; j++)
				{
					array[num] = array2[j];
					num++;
				}
			}
			return array;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0003A6BC File Offset: 0x000396BC
		private int[] b(int[] A_0)
		{
			int[] array = new int[A_0.Length];
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] >= 33088 && A_0[i] <= 40956)
				{
					array[i] = A_0[i] - 33088;
				}
				else if (A_0[i] >= 57408 && A_0[i] <= 60351)
				{
					array[i] = A_0[i] - 49472;
				}
				else
				{
					array[i] = A_0[i];
				}
			}
			short[] a_ = this.a(array);
			int[] array2 = this.a(a_);
			int num = 0;
			int[] array3 = new int[A_0.Length];
			int num2 = 0;
			for (int i = 0; i < array2.Length; i++)
			{
				if (i % 2 == 0)
				{
					num = array2[i] * 192;
				}
				else
				{
					array3[num2] = array2[i] + num;
					num2++;
				}
			}
			return array3;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0003A7B8 File Offset: 0x000397B8
		private short[] a(int[] A_0)
		{
			short[] array = new short[A_0.Length * 16];
			int num = 0;
			foreach (short num2 in A_0)
			{
				int num3 = 16;
				short[] array2 = new short[16];
				while (num2 > 0)
				{
					short num4 = num2 % 2;
					array2[--num3] = num4;
					num2 /= 2;
				}
				for (int j = 0; j < 16; j++)
				{
					array[num] = array2[j];
					num++;
				}
			}
			return array;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0003A850 File Offset: 0x00039850
		private int[] a(short[] A_0)
		{
			int[] array = new int[A_0.Length / 8];
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < A_0.Length / 8; i++)
			{
				for (int j = 7; j >= 0; j--)
				{
					array[num] = (int)((double)array[num] + (double)A_0[num2++] * Math.Pow(2.0, (double)j));
				}
				num++;
			}
			return array;
		}
	}
}
