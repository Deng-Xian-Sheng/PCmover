using System;
using System.IO;

namespace zz93
{
	// Token: 0x020002C3 RID: 707
	internal class sf
	{
		// Token: 0x06002060 RID: 8288 RVA: 0x0013F00F File Offset: 0x0013E00F
		internal sf(int A_0, Stream A_1)
		{
			this.a = A_0;
			this.b = A_1;
			this.a();
		}

		// Token: 0x06002061 RID: 8289 RVA: 0x0013F030 File Offset: 0x0013E030
		internal void a()
		{
			while (this.a > 0)
			{
				int num = this.b.ReadByte();
				this.a--;
				int num2 = 0;
				int num3 = 0;
				if (num == 6)
				{
					num3 = ss.a(ref num2, this.b);
					this.b.Position = this.b.Position + (long)num3;
				}
				else if (num == 160)
				{
					num3 = ss.a(ref num2, this.b);
					num = this.b.ReadByte();
					this.a--;
					if (16 == (num & -33))
					{
						num2 = 0;
						num3 = ss.a(ref num2, this.b);
						this.c = new so(num3, this.b);
					}
				}
				this.a -= num2;
				this.a -= num3;
			}
		}

		// Token: 0x06002062 RID: 8290 RVA: 0x0013F134 File Offset: 0x0013E134
		internal so b()
		{
			return this.c;
		}

		// Token: 0x04000E1E RID: 3614
		private int a;

		// Token: 0x04000E1F RID: 3615
		private Stream b;

		// Token: 0x04000E20 RID: 3616
		private so c;
	}
}
