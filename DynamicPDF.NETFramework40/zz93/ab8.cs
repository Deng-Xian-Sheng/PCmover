using System;

namespace zz93
{
	// Token: 0x0200043A RID: 1082
	internal class ab8
	{
		// Token: 0x06002CC4 RID: 11460 RVA: 0x00198347 File Offset: 0x00197347
		internal ab8()
		{
		}

		// Token: 0x06002CC5 RID: 11461 RVA: 0x0019836C File Offset: 0x0019736C
		internal void a(abj A_0, abt A_1)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 4401526)
				{
					if (num != 580)
					{
						if (num != 2550191)
						{
							if (num == 4401526)
							{
								this.c = (long)((abw)abk.c()).kd();
							}
						}
						else
						{
							A_1.b(abk.c());
						}
					}
					else
					{
						A_1.c(abk.c());
					}
				}
				else if (num <= 5152421)
				{
					if (num != 4914164)
					{
						if (num == 5152421)
						{
							this.b = ((abw)abk.c()).kd();
						}
					}
					else
					{
						A_1.a((ab6)abk.c());
					}
				}
				else if (num != 96088205)
				{
					if (num == 407524542)
					{
						this.a = (long)((abw)abk.c()).kd();
					}
				}
				else
				{
					A_1.a(abk.c());
				}
			}
		}

		// Token: 0x06002CC6 RID: 11462 RVA: 0x00198490 File Offset: 0x00197490
		internal long a()
		{
			return this.a;
		}

		// Token: 0x06002CC7 RID: 11463 RVA: 0x001984A8 File Offset: 0x001974A8
		internal long b()
		{
			return this.c;
		}

		// Token: 0x06002CC8 RID: 11464 RVA: 0x001984C0 File Offset: 0x001974C0
		internal int c()
		{
			return this.b;
		}

		// Token: 0x04001509 RID: 5385
		private long a = 0L;

		// Token: 0x0400150A RID: 5386
		private int b = 0;

		// Token: 0x0400150B RID: 5387
		private long c = 0L;
	}
}
