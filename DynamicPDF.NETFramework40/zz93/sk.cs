using System;
using System.IO;

namespace zz93
{
	// Token: 0x020002C8 RID: 712
	internal class sk
	{
		// Token: 0x06002079 RID: 8313 RVA: 0x0013FA5B File Offset: 0x0013EA5B
		internal sk(int A_0, Stream A_1)
		{
			this.a = A_0;
			this.b = A_1;
			this.a();
		}

		// Token: 0x0600207A RID: 8314 RVA: 0x0013FA7C File Offset: 0x0013EA7C
		private void a()
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
					this.c = new sq(num3, this.b);
				}
				this.a -= num2;
				this.a -= num3;
			}
		}

		// Token: 0x0600207B RID: 8315 RVA: 0x0013FB44 File Offset: 0x0013EB44
		internal sq b()
		{
			return this.c;
		}

		// Token: 0x04000E2B RID: 3627
		private int a;

		// Token: 0x04000E2C RID: 3628
		private Stream b;

		// Token: 0x04000E2D RID: 3629
		private sq c;
	}
}
