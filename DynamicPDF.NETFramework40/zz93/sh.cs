using System;

namespace zz93
{
	// Token: 0x020002C5 RID: 709
	internal class sh
	{
		// Token: 0x06002067 RID: 8295 RVA: 0x0013F1DF File Offset: 0x0013E1DF
		internal sh(long A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002068 RID: 8296 RVA: 0x0013F1F9 File Offset: 0x0013E1F9
		internal sh(byte[] A_0)
		{
			this.b = A_0;
			this.c();
		}

		// Token: 0x06002069 RID: 8297 RVA: 0x0013F21C File Offset: 0x0013E21C
		internal void a()
		{
			if (this.a != 0L && this.a < 127L)
			{
				this.b = new byte[3];
				this.b[0] = 2;
				this.b[1] = 1;
				this.b[2] = (byte)this.a;
			}
			else if (this.a != 0L)
			{
				byte[] bytes = BitConverter.GetBytes(this.a);
				Array.Reverse(bytes);
				bool flag = true;
				int num = 0;
				int num2 = 0;
				byte[] array = new byte[bytes.Length + 1];
				foreach (byte b in bytes)
				{
					if (flag)
					{
						if (b >= 128)
						{
							num++;
							array[num2] = 0;
							num2++;
						}
						if (b > 0)
						{
							num++;
							flag = false;
							array[num2] = b;
							num2++;
						}
					}
					else
					{
						num++;
						array[num2] = b;
						num2++;
					}
				}
				this.b = new byte[2 + num];
				this.b[0] = 2;
				this.b[1] = (byte)num;
				Array.Copy(array, 0, this.b, 2, num);
			}
		}

		// Token: 0x0600206A RID: 8298 RVA: 0x0013F370 File Offset: 0x0013E370
		internal byte[] b()
		{
			this.a();
			return this.b;
		}

		// Token: 0x0600206B RID: 8299 RVA: 0x0013F390 File Offset: 0x0013E390
		internal void c()
		{
			if (this.b.Length == 1)
			{
				this.a = (long)((ulong)this.b[0]);
			}
			else
			{
				int num = 0;
				int num2 = 8;
				for (int num3 = this.b.Length; num3 != 0; num3--)
				{
					int num4 = (num3 - 1) * num2;
					long num5 = (long)((ulong)this.b[num++]);
					num5 <<= num4;
					this.a |= num5;
				}
			}
		}

		// Token: 0x0600206C RID: 8300 RVA: 0x0013F41C File Offset: 0x0013E41C
		internal long d()
		{
			return this.a;
		}

		// Token: 0x04000E23 RID: 3619
		private long a = 0L;

		// Token: 0x04000E24 RID: 3620
		private byte[] b;
	}
}
