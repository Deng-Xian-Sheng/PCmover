using System;

namespace zz93
{
	// Token: 0x020001F6 RID: 502
	internal class m0
	{
		// Token: 0x06001677 RID: 5751 RVA: 0x000F61EA File Offset: 0x000F51EA
		internal m0()
		{
		}

		// Token: 0x06001678 RID: 5752 RVA: 0x000F620C File Offset: 0x000F520C
		internal m0(m0 A_0)
		{
			this.a = A_0.b();
			this.b = A_0.c();
			this.c = A_0.a();
		}

		// Token: 0x06001679 RID: 5753 RVA: 0x000F625C File Offset: 0x000F525C
		internal void a(fb<f8>[] A_0)
		{
			for (int i = 0; i < A_0.Length; i++)
			{
				int num = A_0[i].a();
				if (num <= 389285250)
				{
					if (num != 0)
					{
						if (num == 389285250)
						{
							this.b = A_0[i].b().kw().a();
						}
					}
					else if (A_0[i].b() != null && !A_0[i].b().g())
					{
						i = A_0.Length;
					}
				}
				else if (num != 430959576)
				{
					if (num == 514326864)
					{
						this.c = A_0[i].b().kv().a();
					}
				}
				else
				{
					this.a = A_0[i].b().kx().a();
				}
			}
		}

		// Token: 0x0600167A RID: 5754 RVA: 0x000F6348 File Offset: 0x000F5348
		internal string a()
		{
			return this.c;
		}

		// Token: 0x0600167B RID: 5755 RVA: 0x000F6360 File Offset: 0x000F5360
		internal void a(string A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600167C RID: 5756 RVA: 0x000F636C File Offset: 0x000F536C
		internal ok b()
		{
			return this.a;
		}

		// Token: 0x0600167D RID: 5757 RVA: 0x000F6384 File Offset: 0x000F5384
		internal void a(ok A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600167E RID: 5758 RVA: 0x000F6390 File Offset: 0x000F5390
		internal hp c()
		{
			return this.b;
		}

		// Token: 0x0600167F RID: 5759 RVA: 0x000F63A8 File Offset: 0x000F53A8
		internal void a(hp A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001680 RID: 5760 RVA: 0x000F63B4 File Offset: 0x000F53B4
		internal m0 d()
		{
			return new m0(this);
		}

		// Token: 0x04000A5A RID: 2650
		private ok a = ok.v;

		// Token: 0x04000A5B RID: 2651
		private hp b = hp.b;

		// Token: 0x04000A5C RID: 2652
		private string c = null;
	}
}
