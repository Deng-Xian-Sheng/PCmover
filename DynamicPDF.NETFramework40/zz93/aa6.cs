using System;

namespace zz93
{
	// Token: 0x02000414 RID: 1044
	internal class aa6
	{
		// Token: 0x06002B96 RID: 11158 RVA: 0x00192E94 File Offset: 0x00191E94
		static aa6()
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
				aa6.c = new aa6(array);
				array = new byte[32];
				i = 0;
				while (i < 32)
				{
					array[i++] = 5;
				}
				aa6.d = new aa6(array);
			}
			catch (Exception)
			{
				throw new ApplicationException("InflaterHuffmanTree: static tree length illegal");
			}
		}

		// Token: 0x06002B97 RID: 11159 RVA: 0x00192F70 File Offset: 0x00191F70
		internal aa6(byte[] A_0)
		{
			this.a(A_0);
		}

		// Token: 0x06002B98 RID: 11160 RVA: 0x00192F84 File Offset: 0x00191F84
		private void a(byte[] A_0)
		{
			int[] array = new int[aa6.a + 1];
			int[] array2 = new int[aa6.a + 1];
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
			for (int j = 1; j <= aa6.a; j++)
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
			if (num != 65536)
			{
				throw new Exception("Code lengths don't add up properly.");
			}
			this.b = new short[num2];
			int num5 = 512;
			for (int j = aa6.a; j >= 10; j--)
			{
				int num4 = num & 130944;
				num -= array[j] << 16 - j;
				int num3 = num & 130944;
				for (int i = num3; i < num4; i += 128)
				{
					this.b[(int)aa1.c(i)] = (short)(-num5 << 4 | j);
					num5 += 1 << j - 9;
				}
			}
			for (int i = 0; i < A_0.Length; i++)
			{
				int j = (int)A_0[i];
				if (j != 0)
				{
					num = array2[j];
					int num6 = (int)aa1.c(num);
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

		// Token: 0x06002B99 RID: 11161 RVA: 0x001931E0 File Offset: 0x001921E0
		internal int a(aa8 A_0)
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

		// Token: 0x04001488 RID: 5256
		private static int a = 15;

		// Token: 0x04001489 RID: 5257
		private short[] b;

		// Token: 0x0400148A RID: 5258
		internal static aa6 c;

		// Token: 0x0400148B RID: 5259
		internal static aa6 d;
	}
}
