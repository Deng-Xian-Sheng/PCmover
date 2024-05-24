using System;

namespace zz93
{
	// Token: 0x020002C7 RID: 711
	internal class sj
	{
		// Token: 0x06002075 RID: 8309 RVA: 0x0013F888 File Offset: 0x0013E888
		internal sj(byte[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002076 RID: 8310 RVA: 0x0013F89C File Offset: 0x0013E89C
		internal byte[] a()
		{
			return this.a;
		}

		// Token: 0x06002077 RID: 8311 RVA: 0x0013F8B4 File Offset: 0x0013E8B4
		internal void b()
		{
			if (this.a.Length > 0 && this.a.Length < 127)
			{
				this.b = new byte[this.a.Length + 2];
				this.b[0] = 4;
				this.b[1] = (byte)this.a.Length;
				Array.Copy(this.a, 0, this.b, 2, this.a.Length);
			}
			else if (this.a.Length > 0)
			{
				byte[] bytes = BitConverter.GetBytes(this.a.Length);
				Array.Reverse(bytes);
				bool flag = true;
				int num = 0;
				int num2 = 0;
				byte[] array = new byte[bytes.Length + 1];
				foreach (byte b in bytes)
				{
					if (flag)
					{
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
				this.b = new byte[2 + num + this.a.Length];
				this.b[0] = 4;
				this.b[1] = (byte)(128 + num);
				Array.Copy(array, 0, this.b, 2, num);
				Array.Copy(this.a, 0, this.b, 2 + num, this.a.Length);
			}
		}

		// Token: 0x06002078 RID: 8312 RVA: 0x0013FA3C File Offset: 0x0013EA3C
		internal byte[] c()
		{
			this.b();
			return this.b;
		}

		// Token: 0x04000E29 RID: 3625
		private byte[] a;

		// Token: 0x04000E2A RID: 3626
		private byte[] b;
	}
}
