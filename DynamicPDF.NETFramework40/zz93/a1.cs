using System;

namespace zz93
{
	// Token: 0x02000038 RID: 56
	internal class a1 : az
	{
		// Token: 0x0600022B RID: 555 RVA: 0x00032DB2 File Offset: 0x00031DB2
		internal a1(int A_0, int A_1) : base(A_0, A_1)
		{
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00032DC0 File Offset: 0x00031DC0
		internal short[] a(byte[] A_0, int A_1)
		{
			int num = 0;
			int num2 = A_0.Length;
			int num3;
			if (A_1 < 9)
			{
				num3 = 8;
			}
			else
			{
				num3 = 16;
			}
			int num4 = num2 + 2;
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
			array[num] = 4;
			array2[num] = 4;
			num++;
			array[num] = num2;
			array2[num] = (byte)num3;
			num++;
			for (int i = 0; i < num2; i++)
			{
				array[i + num] = (int)A_0[i];
				array2[i + num] = 8;
			}
			num += num2;
			int[] a_ = base.a(array, array2);
			return base.c(a_);
		}
	}
}
