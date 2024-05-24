using System;

namespace zz93
{
	// Token: 0x020004D9 RID: 1241
	internal class agi : yx
	{
		// Token: 0x060032A8 RID: 12968 RVA: 0x001C4368 File Offset: 0x001C3368
		internal agi(agk A_0)
		{
			this.d = A_0;
			this.b = new byte[8192];
		}

		// Token: 0x060032A9 RID: 12969 RVA: 0x001C43A0 File Offset: 0x001C33A0
		internal override void k4(y0 A_0)
		{
			do
			{
				int num = A_0.c(this.b, this.c, this.b.Length - this.c);
				int num2 = num + this.c;
				if (this.b.Length == num2)
				{
					this.d.a(this.b, num2);
					this.f += num2;
					this.c = 0;
				}
				else
				{
					this.c += num;
				}
			}
			while (!A_0.d());
		}

		// Token: 0x060032AA RID: 12970 RVA: 0x001C443C File Offset: 0x001C343C
		internal override void k5(y0 A_0)
		{
			do
			{
				int num = A_0.c(this.b, this.c, this.b.Length - this.c);
				int num2 = num + this.c;
				if (this.b.Length == num2)
				{
					this.d.a(this.b, num2);
					this.f += num2;
					this.c = 0;
				}
				else
				{
					this.c += num;
				}
			}
			while (!A_0.c());
			if (this.c > 0)
			{
				this.d.a(this.b, this.c);
				this.f += this.c;
			}
		}

		// Token: 0x060032AB RID: 12971 RVA: 0x001C4514 File Offset: 0x001C3514
		internal override bp k6()
		{
			return new agj(this.d, this.e, this.f);
		}

		// Token: 0x060032AC RID: 12972 RVA: 0x001C4540 File Offset: 0x001C3540
		internal override void k7()
		{
			this.e = this.d.b();
			this.c = (this.f = 0);
		}

		// Token: 0x04001843 RID: 6211
		private const int a = 8192;

		// Token: 0x04001844 RID: 6212
		private byte[] b;

		// Token: 0x04001845 RID: 6213
		private int c = 0;

		// Token: 0x04001846 RID: 6214
		private agk d;

		// Token: 0x04001847 RID: 6215
		private long e = 0L;

		// Token: 0x04001848 RID: 6216
		private int f = 0;
	}
}
