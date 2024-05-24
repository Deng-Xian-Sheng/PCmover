using System;
using System.Text;

namespace zz93
{
	// Token: 0x020002C6 RID: 710
	internal class si
	{
		// Token: 0x0600206D RID: 8301 RVA: 0x0013F434 File Offset: 0x0013E434
		internal si(string A_0)
		{
			this.a = A_0;
			this.b = this.a(this.a);
		}

		// Token: 0x0600206E RID: 8302 RVA: 0x0013F45F File Offset: 0x0013E45F
		internal si(byte[] A_0)
		{
			this.c = A_0;
			this.a();
		}

		// Token: 0x0600206F RID: 8303 RVA: 0x0013F480 File Offset: 0x0013E480
		private void a()
		{
			StringBuilder stringBuilder = new StringBuilder();
			long num = 0L;
			bool flag = true;
			for (int num2 = 0; num2 != this.c.Length; num2++)
			{
				int num3 = (int)this.c[num2];
				if (num < 36028797018963968L)
				{
					num = num * 128L + (long)(num3 & 127);
					if ((num3 & 128) == 0)
					{
						if (flag)
						{
							switch ((int)num / 40)
							{
							case 0:
								stringBuilder.Append('0');
								break;
							case 1:
								stringBuilder.Append('1');
								num -= 40L;
								break;
							default:
								stringBuilder.Append('2');
								num -= 80L;
								break;
							}
							flag = false;
						}
						stringBuilder.Append('.');
						stringBuilder.Append(num);
						num = 0L;
					}
				}
			}
			this.a = stringBuilder.ToString();
		}

		// Token: 0x06002070 RID: 8304 RVA: 0x0013F57C File Offset: 0x0013E57C
		private int[] a(string A_0)
		{
			char[] separator = new char[]
			{
				'.'
			};
			string[] array = A_0.Split(separator);
			int[] array2 = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = int.Parse(array[i]);
			}
			return array2;
		}

		// Token: 0x06002071 RID: 8305 RVA: 0x0013F5D4 File Offset: 0x0013E5D4
		internal void b()
		{
			byte[] array = new byte[20];
			int num = this.b[0];
			int num2 = this.b[1];
			this.d = 0;
			this.a(array, (long)(40 * num + num2));
			for (int i = 2; i < this.b.Length; i++)
			{
				this.a(array, (long)this.b[i]);
			}
			this.c = new byte[2 + this.d];
			this.c[0] = 6;
			this.c[1] = (byte)this.d;
			Array.Copy(array, 0, this.c, 2, this.d);
		}

		// Token: 0x06002072 RID: 8306 RVA: 0x0013F680 File Offset: 0x0013E680
		private void a(byte[] A_0, long A_1)
		{
			if (A_1 >= 128L)
			{
				if (A_1 >= 16384L)
				{
					if (A_1 >= 2097152L)
					{
						if (A_1 >= 268435456L)
						{
							if (A_1 >= 34359738368L)
							{
								if (A_1 >= 4398046511104L)
								{
									if (A_1 >= 562949953421312L)
									{
										if (A_1 >= 72057594037927936L)
										{
											A_0[this.d] = (byte)(A_1 >> 56 | 128L);
											this.d++;
										}
										A_0[this.d] = (byte)(A_1 >> 49 | 128L);
										this.d++;
									}
									A_0[this.d] = (byte)(A_1 >> 42 | 128L);
									this.d++;
								}
								A_0[this.d] = (byte)(A_1 >> 35 | 128L);
								this.d++;
							}
							A_0[this.d] = (byte)(A_1 >> 28 | 128L);
							this.d++;
						}
						A_0[this.d] = (byte)(A_1 >> 21 | 128L);
						this.d++;
					}
					A_0[this.d] = (byte)(A_1 >> 14 | 128L);
					this.d++;
				}
				A_0[this.d] = (byte)(A_1 >> 7 | 128L);
				this.d++;
			}
			A_0[this.d] = (byte)(A_1 & 127L);
			this.d++;
		}

		// Token: 0x06002073 RID: 8307 RVA: 0x0013F850 File Offset: 0x0013E850
		internal byte[] c()
		{
			this.b();
			return this.c;
		}

		// Token: 0x06002074 RID: 8308 RVA: 0x0013F870 File Offset: 0x0013E870
		internal string d()
		{
			return this.a;
		}

		// Token: 0x04000E25 RID: 3621
		private string a;

		// Token: 0x04000E26 RID: 3622
		private int[] b;

		// Token: 0x04000E27 RID: 3623
		private byte[] c;

		// Token: 0x04000E28 RID: 3624
		private int d = 0;
	}
}
