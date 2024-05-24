using System;

namespace zz93
{
	// Token: 0x0200003B RID: 59
	internal class a4 : az
	{
		// Token: 0x06000248 RID: 584 RVA: 0x0003A8CE File Offset: 0x000398CE
		internal a4(int A_0, int A_1) : base(A_0, A_1)
		{
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0003A8DC File Offset: 0x000398DC
		internal short[] a(byte[] A_0, int A_1)
		{
			int num = 0;
			int num2 = A_0.Length;
			int num3;
			if (A_1 <= 8)
			{
				num3 = 10;
			}
			else if (A_1 >= 9 && A_1 <= 25)
			{
				num3 = 12;
			}
			else
			{
				num3 = 14;
			}
			int num4;
			if (num2 % 3 == 0)
			{
				num4 = num2 / 3 + 2;
			}
			else
			{
				num4 = num2 / 3 + 3;
			}
			int[] array;
			byte[] array2;
			if (base.a() == 0)
			{
				num4++;
				array = new int[num4];
				array2 = new byte[num4];
				array[num] = 5;
				array2[num] = 4;
				num++;
			}
			else if (base.a() == 1)
			{
				num4++;
				array = new int[num4];
				array2 = new byte[num4];
				array[num] = 9;
				array2[num] = 4;
				num++;
			}
			else
			{
				array = new int[num4];
				array2 = new byte[num4];
			}
			array[num] = 1;
			array2[num] = 4;
			num++;
			array[num] = num2;
			array2[num] = (byte)num3;
			num++;
			for (int i = 0; i < num2; i++)
			{
				if (i % 3 == 0)
				{
					array[num] = (int)(A_0[i] - 48);
					array2[num] = 4;
				}
				else
				{
					array[num] = array[num] * 10 + (int)(A_0[i] - 48);
					if (i % 3 == 1)
					{
						array2[num] = 7;
					}
					else
					{
						array2[num] = 10;
						if (i < num2 - 1)
						{
							num++;
						}
					}
				}
			}
			num++;
			int[] a_ = base.a(array, array2);
			return base.c(a_);
		}
	}
}
