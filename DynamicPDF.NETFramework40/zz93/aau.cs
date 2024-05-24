using System;

namespace zz93
{
	// Token: 0x02000407 RID: 1031
	internal class aau
	{
		// Token: 0x06002B36 RID: 11062 RVA: 0x0018F30F File Offset: 0x0018E30F
		internal aau()
		{
		}

		// Token: 0x06002B37 RID: 11063 RVA: 0x0018F31C File Offset: 0x0018E31C
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

		// Token: 0x06002B38 RID: 11064 RVA: 0x0018F3B6 File Offset: 0x0018E3B6
		internal void a(byte[] A_0, byte[] A_1)
		{
			this.a(A_0, 0, A_0.Length, A_1);
		}

		// Token: 0x06002B39 RID: 11065 RVA: 0x0018F3C8 File Offset: 0x0018E3C8
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
