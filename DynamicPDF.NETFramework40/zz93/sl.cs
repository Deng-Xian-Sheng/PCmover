using System;
using System.IO;

namespace zz93
{
	// Token: 0x020002C9 RID: 713
	internal class sl
	{
		// Token: 0x0600207C RID: 8316 RVA: 0x0013FB5C File Offset: 0x0013EB5C
		internal sl(sd A_0, byte[] A_1)
		{
			this.a = A_0;
			this.b = new sj(A_1);
		}

		// Token: 0x0600207D RID: 8317 RVA: 0x0013FB7A File Offset: 0x0013EB7A
		internal sl(int A_0, Stream A_1)
		{
			this.c = A_0;
			this.d = A_1;
			this.a();
		}

		// Token: 0x0600207E RID: 8318 RVA: 0x0013FB9C File Offset: 0x0013EB9C
		private void a()
		{
			while (this.c > 0)
			{
				int num = this.d.ReadByte();
				this.c--;
				int num2 = 0;
				int num3 = 0;
				if (16 == (num & -33))
				{
					num3 = ss.a(ref num2, this.d);
					this.a = new sd(num3, this.d);
				}
				else if (num == 4)
				{
					num3 = ss.a(ref num2, this.d);
					byte[] array = new byte[num3];
					for (int i = 0; i < num3; i++)
					{
						array[i] = (byte)this.d.ReadByte();
					}
					this.b = new sj(array);
				}
				this.c -= num2;
				this.c -= num3;
			}
		}

		// Token: 0x0600207F RID: 8319 RVA: 0x0013FC8C File Offset: 0x0013EC8C
		internal sd b()
		{
			return this.a;
		}

		// Token: 0x06002080 RID: 8320 RVA: 0x0013FCA4 File Offset: 0x0013ECA4
		internal byte[] c()
		{
			return this.b.a();
		}

		// Token: 0x06002081 RID: 8321 RVA: 0x0013FCC4 File Offset: 0x0013ECC4
		internal void d()
		{
			byte[] array = this.a.d();
			byte[] array2 = this.b.c();
			int num = array.Length + array2.Length;
			if (num != 0 && num < 127)
			{
				this.e = new byte[2 + num];
				this.e[0] = 48;
				this.e[1] = (byte)num;
				Array.Copy(array, 0, this.e, 2, array.Length);
				Array.Copy(array2, 0, this.e, 2 + array.Length, array2.Length);
			}
		}

		// Token: 0x06002082 RID: 8322 RVA: 0x0013FD54 File Offset: 0x0013ED54
		internal byte[] e()
		{
			this.d();
			return this.e;
		}

		// Token: 0x04000E2E RID: 3630
		private sd a;

		// Token: 0x04000E2F RID: 3631
		private sj b;

		// Token: 0x04000E30 RID: 3632
		private int c;

		// Token: 0x04000E31 RID: 3633
		private Stream d;

		// Token: 0x04000E32 RID: 3634
		private byte[] e;
	}
}
