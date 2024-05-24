using System;
using System.IO;

namespace zz93
{
	// Token: 0x020002C1 RID: 705
	internal class sd
	{
		// Token: 0x06002059 RID: 8281 RVA: 0x0013EE6C File Offset: 0x0013DE6C
		internal sd(string A_0)
		{
			this.a = new si(A_0);
		}

		// Token: 0x0600205A RID: 8282 RVA: 0x0013EE83 File Offset: 0x0013DE83
		internal sd(int A_0, Stream A_1)
		{
			this.c = A_0;
			this.d = A_1;
			this.a();
		}

		// Token: 0x0600205B RID: 8283 RVA: 0x0013EEA4 File Offset: 0x0013DEA4
		private void a()
		{
			while (this.c > 0)
			{
				int num = this.d.ReadByte();
				this.c--;
				int num2 = 0;
				if (num == 6)
				{
					int num3 = ss.a(ref num2, this.d);
					byte[] array = new byte[num3];
					for (int i = 0; i < num3; i++)
					{
						array[i] = (byte)this.d.ReadByte();
					}
					this.a = new si(array);
					this.c -= num2;
					this.c -= num3;
				}
			}
		}

		// Token: 0x0600205C RID: 8284 RVA: 0x0013EF60 File Offset: 0x0013DF60
		internal string b()
		{
			return this.a.d();
		}

		// Token: 0x0600205D RID: 8285 RVA: 0x0013EF80 File Offset: 0x0013DF80
		internal void c()
		{
			byte[] array = this.a.c();
			int num = array.Length;
			if (num != 0 && num < 127)
			{
				this.b = new byte[2 + num];
				this.b[0] = 48;
				this.b[1] = (byte)num;
				Array.Copy(array, 0, this.b, 2, num);
			}
		}

		// Token: 0x0600205E RID: 8286 RVA: 0x0013EFE8 File Offset: 0x0013DFE8
		internal byte[] d()
		{
			this.c();
			return this.b;
		}

		// Token: 0x04000E0F RID: 3599
		private si a;

		// Token: 0x04000E10 RID: 3600
		private byte[] b;

		// Token: 0x04000E11 RID: 3601
		private int c;

		// Token: 0x04000E12 RID: 3602
		private Stream d;
	}
}
