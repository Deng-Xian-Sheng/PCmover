using System;

namespace zz93
{
	// Token: 0x020003C9 RID: 969
	internal class zc
	{
		// Token: 0x060028D9 RID: 10457 RVA: 0x0017A6B8 File Offset: 0x001796B8
		static zc()
		{
			try
			{
				byte[] array = new byte[288];
				int i = 0;
				while (i < 144)
				{
					array[i++] = 8;
				}
				while (i < 256)
				{
					array[i++] = 9;
				}
				while (i < 280)
				{
					array[i++] = 7;
				}
				while (i < 288)
				{
					array[i++] = 8;
				}
				zc.c = new zc(array);
				array = new byte[32];
				i = 0;
				while (i < 32)
				{
					array[i++] = 5;
				}
				zc.d = new zc(array);
			}
			catch (Exception)
			{
				throw new ApplicationException("InflaterHuffmanTree: static tree length illegal");
			}
		}

		// Token: 0x060028DA RID: 10458 RVA: 0x0017A794 File Offset: 0x00179794
		internal zc(byte[] A_0)
		{
			this.a(A_0);
		}

		// Token: 0x060028DB RID: 10459 RVA: 0x0017A7A8 File Offset: 0x001797A8
		private void a(byte[] A_0)
		{
			int[] array = new int[zc.a + 1];
			int[] array2 = new int[zc.a + 1];
			foreach (int j in A_0)
			{
				int j;
				if (j > 0)
				{
					array[j]++;
				}
			}
			int num = 0;
			int num2 = 512;
			for (int j = 1; j <= zc.a; j++)
			{
				array2[j] = num;
				num += array[j] << 16 - j;
				if (j >= 10)
				{
					int num3 = array2[j] & 130944;
					int num4 = num & 130944;
					num2 += num4 - num3 >> 16 - j;
				}
			}
			this.b = new short[num2];
			int num5 = 512;
			for (int j = zc.a; j >= 10; j--)
			{
				int num4 = num & 130944;
				num -= array[j] << 16 - j;
				int num3 = num & 130944;
				for (int i = num3; i < num4; i += 128)
				{
					this.b[(int)y4.c(i)] = (short)(-num5 << 4 | j);
					num5 += 1 << j - 9;
				}
			}
			for (int i = 0; i < A_0.Length; i++)
			{
				int j = (int)A_0[i];
				if (j != 0)
				{
					num = array2[j];
					int num6 = (int)y4.c(num);
					if (j <= 9)
					{
						do
						{
							this.b[num6] = (short)(i << 4 | j);
							num6 += 1 << j;
						}
						while (num6 < 512);
					}
					else
					{
						int num7 = (int)this.b[num6 & 511];
						int num8 = 1 << (num7 & 15);
						num7 = -(num7 >> 4);
						do
						{
							this.b[num7 | num6 >> 9] = (short)(i << 4 | j);
							num6 += 1 << j;
						}
						while (num6 < num8);
					}
					array2[j] = num + (1 << 16 - j);
				}
			}
		}

		// Token: 0x060028DC RID: 10460 RVA: 0x0017A9E8 File Offset: 0x001799E8
		internal int a(zg A_0)
		{
			int num;
			int result;
			if ((num = A_0.a(9)) >= 0)
			{
				int num2;
				if ((num2 = (int)this.b[num]) >= 0)
				{
					A_0.b(num2 & 15);
					result = num2 >> 4;
				}
				else
				{
					int num3 = -(num2 >> 4);
					int a_ = num2 & 15;
					if ((num = A_0.a(a_)) >= 0)
					{
						num2 = (int)this.b[num3 | num >> 9];
						A_0.b(num2 & 15);
						result = num2 >> 4;
					}
					else
					{
						int num4 = A_0.a();
						num = A_0.a(num4);
						num2 = (int)this.b[num3 | num >> 9];
						if ((num2 & 15) <= num4)
						{
							A_0.b(num2 & 15);
							result = num2 >> 4;
						}
						else
						{
							result = -1;
						}
					}
				}
			}
			else
			{
				int num4 = A_0.a();
				num = A_0.a(num4);
				int num2 = (int)this.b[num];
				if (num2 >= 0 && (num2 & 15) <= num4)
				{
					A_0.b(num2 & 15);
					result = num2 >> 4;
				}
				else
				{
					result = -1;
				}
			}
			return result;
		}

		// Token: 0x0400127A RID: 4730
		private static int a = 15;

		// Token: 0x0400127B RID: 4731
		private short[] b;

		// Token: 0x0400127C RID: 4732
		internal static zc c;

		// Token: 0x0400127D RID: 4733
		internal static zc d;
	}
}
