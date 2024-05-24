using System;
using System.IO;

namespace zz93
{
	// Token: 0x020002CE RID: 718
	internal class sq
	{
		// Token: 0x0600208E RID: 8334 RVA: 0x001403F4 File Offset: 0x0013F3F4
		internal sq(int A_0, Stream A_1)
		{
			this.a = A_0;
			this.b = A_1;
			this.a();
		}

		// Token: 0x0600208F RID: 8335 RVA: 0x00140414 File Offset: 0x0013F414
		private void a()
		{
			while (this.a > 0)
			{
				int num = this.b.ReadByte();
				this.a--;
				int num2 = 0;
				int num3 = 0;
				if (num == 4)
				{
					num3 = ss.a(ref num2, this.b);
					int num4 = this.b.ReadByte();
					int num5 = 0;
					int num6 = 0;
					if (16 == (num4 & -33))
					{
						num6 = ss.a(ref num5, this.b);
						this.c = new st(num6, this.b);
					}
					this.a -= num5;
					this.a -= num6;
				}
				this.a -= num2;
				this.a -= num3;
			}
		}

		// Token: 0x06002090 RID: 8336 RVA: 0x001404F8 File Offset: 0x0013F4F8
		internal st b()
		{
			return this.c;
		}

		// Token: 0x04000E3C RID: 3644
		private int a;

		// Token: 0x04000E3D RID: 3645
		private Stream b;

		// Token: 0x04000E3E RID: 3646
		private st c;
	}
}
