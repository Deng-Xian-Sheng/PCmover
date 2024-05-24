using System;

namespace zz93
{
	// Token: 0x020003B8 RID: 952
	internal class yw
	{
		// Token: 0x06002853 RID: 10323 RVA: 0x001759CB File Offset: 0x001749CB
		internal yw()
		{
		}

		// Token: 0x06002854 RID: 10324 RVA: 0x001759D8 File Offset: 0x001749D8
		internal int[] a(byte[] A_0)
		{
			int[] array = new int[256];
			int num = A_0.Length;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < 256; i++)
			{
				array[i] = i;
			}
			for (int i = 0; i < 256; i++)
			{
				int num4 = array[i];
				num2 = (num2 + num4 + (int)A_0[num3] & 255);
				array[i] = array[num2];
				array[num2] = num4;
				if (++num3 >= num)
				{
					num3 = 0;
				}
			}
			return array;
		}

		// Token: 0x06002855 RID: 10325 RVA: 0x00175A72 File Offset: 0x00174A72
		internal void a(byte[] A_0, byte[] A_1)
		{
			this.a(A_0, 0, A_0.Length, A_1);
		}

		// Token: 0x06002856 RID: 10326 RVA: 0x00175A84 File Offset: 0x00174A84
		internal void a(byte[] A_0, int A_1, int A_2, byte[] A_3)
		{
			int[] array = this.a(A_3);
			int num = 0;
			int num2 = 0;
			int num3 = A_1 + A_2;
			for (int i = A_1; i < num3; i++)
			{
				num = (num + 1 & 255);
				int num4 = array[num];
				num2 = (num2 + num4 & 255);
				int num5 = array[num] = array[num2];
				array[num2] = num4;
				int num6 = i;
				A_0[num6] ^= (byte)array[num4 + num5 & 255];
			}
		}
	}
}
