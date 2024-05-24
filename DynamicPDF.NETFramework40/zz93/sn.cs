using System;
using System.IO;

namespace zz93
{
	// Token: 0x020002CB RID: 715
	internal class sn
	{
		// Token: 0x06002086 RID: 8326 RVA: 0x0013FE11 File Offset: 0x0013EE11
		internal sn(int A_0, Stream A_1)
		{
			this.a = A_0;
			this.b = A_1;
			this.a();
		}

		// Token: 0x06002087 RID: 8327 RVA: 0x0013FE34 File Offset: 0x0013EE34
		internal void a()
		{
			while (this.a > 0)
			{
				int num = 0;
				int num2 = this.b.ReadByte();
				this.a--;
				int num3 = 0;
				if (num2 == 2)
				{
					num3 = ss.a(ref num, this.b);
					this.c = new sm(num3, this.b);
				}
				else if (16 == (num2 & -33))
				{
					num = 0;
					num3 = ss.a(ref num, this.b);
					byte[] array = new byte[num3];
					for (int i = 0; i < num3; i++)
					{
						array[i] = (byte)this.b.ReadByte();
					}
				}
				else if (num2 == 3)
				{
					num = 0;
					num3 = ss.a(ref num, this.b);
					byte[] array = new byte[num3];
					for (int i = 0; i < num3; i++)
					{
						array[i] = (byte)this.b.ReadByte();
					}
				}
				this.a -= num;
				this.a -= num3;
			}
		}

		// Token: 0x06002088 RID: 8328 RVA: 0x0013FF70 File Offset: 0x0013EF70
		internal sm b()
		{
			return this.c;
		}

		// Token: 0x04000E36 RID: 3638
		private int a;

		// Token: 0x04000E37 RID: 3639
		private Stream b;

		// Token: 0x04000E38 RID: 3640
		private sm c;
	}
}
