using System;
using System.IO;

namespace zz93
{
	// Token: 0x020002CC RID: 716
	internal class so
	{
		// Token: 0x06002089 RID: 8329 RVA: 0x0013FF88 File Offset: 0x0013EF88
		internal so(int A_0, Stream A_1)
		{
			this.a = A_0;
			this.b = A_1;
			this.a();
		}

		// Token: 0x0600208A RID: 8330 RVA: 0x0013FFA8 File Offset: 0x0013EFA8
		private void a()
		{
			while (this.a > 0)
			{
				int num = this.b.ReadByte();
				this.a--;
				int num2 = 0;
				int num3 = 0;
				if (num == 2)
				{
					num3 = ss.a(ref num2, this.b);
					this.b.Position = this.b.Position + (long)num3;
				}
				else if (17 == (num & -33))
				{
					num2 = 0;
					num3 = ss.a(ref num2, this.b);
					this.b.Position = this.b.Position + (long)num3;
				}
				else if (16 == (num & -33))
				{
					num2 = 0;
					num3 = ss.a(ref num2, this.b);
					this.c = new sk(num3, this.b);
				}
				else if (num == 160)
				{
					num2 = 0;
					num3 = ss.a(ref num2, this.b);
					this.b.Position = this.b.Position + (long)num3;
				}
				this.a -= num2;
				this.a -= num3;
			}
		}

		// Token: 0x0600208B RID: 8331 RVA: 0x001400F0 File Offset: 0x0013F0F0
		internal st b()
		{
			return this.c.b().b();
		}

		// Token: 0x04000E39 RID: 3641
		private int a;

		// Token: 0x04000E3A RID: 3642
		private Stream b;

		// Token: 0x04000E3B RID: 3643
		private sk c;
	}
}
