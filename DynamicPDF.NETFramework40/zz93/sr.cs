using System;

namespace zz93
{
	// Token: 0x020002CF RID: 719
	internal class sr
	{
		// Token: 0x06002091 RID: 8337 RVA: 0x00140510 File Offset: 0x0013F510
		internal sr(string A_0, byte[] A_1, bool A_2, int A_3)
		{
			this.a = new sh(1L);
			this.b = new sl(new sd(A_0), A_1);
			this.d = new sg(A_2);
			this.c = new sh((long)A_3);
		}

		// Token: 0x06002092 RID: 8338 RVA: 0x0014056C File Offset: 0x0013F56C
		internal sl b()
		{
			return this.b;
		}

		// Token: 0x06002093 RID: 8339 RVA: 0x00140584 File Offset: 0x0013F584
		internal long c()
		{
			return this.c.d();
		}

		// Token: 0x06002094 RID: 8340 RVA: 0x001405A4 File Offset: 0x0013F5A4
		private void a()
		{
			byte[] array = this.a.b();
			byte[] array2 = this.b.e();
			byte[] array3 = null;
			byte[] array4 = null;
			int num = array.Length + array2.Length;
			if (this.c != null)
			{
				array4 = this.c.b();
				num += array4.Length;
			}
			if (this.d != null && this.d.b())
			{
				array3 = this.d.c();
				num += array3.Length;
			}
			if (num != 0 && num < 127)
			{
				this.e = new byte[2 + num];
				this.e[0] = 48;
				this.e[1] = (byte)num;
				int num2 = 2;
				Array.Copy(array, 0, this.e, num2, array.Length);
				num2 += array.Length;
				Array.Copy(array2, 0, this.e, num2, array2.Length);
				num2 += array2.Length;
				if (array4 != null)
				{
					Array.Copy(array4, 0, this.e, num2, array4.Length);
					num2 += array4.Length;
				}
				if (array3 != null)
				{
					Array.Copy(array3, 0, this.e, num2, array3.Length);
					num2 += array3.Length;
				}
			}
			else if (num != 0)
			{
				byte[] bytes = BitConverter.GetBytes(num);
				Array.Reverse(bytes);
				bool flag = true;
				int num3 = 0;
				int num4 = 0;
				byte[] array5 = new byte[bytes.Length + 1];
				foreach (byte b in bytes)
				{
					if (flag)
					{
						if (b > 0)
						{
							num3++;
							flag = false;
							array5[num4] = b;
							num4++;
						}
					}
					else
					{
						num3++;
						array5[num4] = b;
						num4++;
					}
				}
				this.e = new byte[2 + num3 + num];
				this.e[0] = 48;
				this.e[1] = (byte)(128 + num3);
				Array.Copy(array5, 0, this.e, 2, num3);
				int num2 = 2 + num3;
				Array.Copy(array, 0, this.e, num2, array.Length);
				num2 += array.Length;
				Array.Copy(array2, 0, this.e, num2, array2.Length);
				num2 += array2.Length;
				if (array4 != null)
				{
					Array.Copy(array4, 0, this.e, num2, array4.Length);
					num2 += array4.Length;
				}
				if (array3 != null)
				{
					Array.Copy(array3, 0, this.e, num2, array3.Length);
					num2 += array3.Length;
				}
			}
		}

		// Token: 0x06002095 RID: 8341 RVA: 0x00140870 File Offset: 0x0013F870
		internal byte[] d()
		{
			this.a();
			return this.e;
		}

		// Token: 0x04000E3F RID: 3647
		private sh a;

		// Token: 0x04000E40 RID: 3648
		private sl b;

		// Token: 0x04000E41 RID: 3649
		private sh c;

		// Token: 0x04000E42 RID: 3650
		private sg d = new sg(false);

		// Token: 0x04000E43 RID: 3651
		private byte[] e;
	}
}
