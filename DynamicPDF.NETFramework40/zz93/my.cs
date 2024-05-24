using System;

namespace zz93
{
	// Token: 0x020001F4 RID: 500
	internal class my
	{
		// Token: 0x06001658 RID: 5720 RVA: 0x000F5D62 File Offset: 0x000F4D62
		internal my()
		{
		}

		// Token: 0x06001659 RID: 5721 RVA: 0x000F5D94 File Offset: 0x000F4D94
		internal my(my A_0)
		{
			this.a = A_0.a();
			this.b = A_0.b();
			this.c = A_0.c();
			this.d = A_0.d();
		}

		// Token: 0x0600165A RID: 5722 RVA: 0x000F5E00 File Offset: 0x000F4E00
		internal void a(ho A_0)
		{
			if (!A_0.a().a())
			{
				this.a = new x5?(A_0.a().b());
				if (A_0.a().c())
				{
					this.c = mw.b;
				}
				else if (A_0.a().d())
				{
					this.c = mw.d;
				}
				else
				{
					this.c = mw.a;
					this.d = A_0.a().e();
				}
			}
		}

		// Token: 0x0600165B RID: 5723 RVA: 0x000F5E88 File Offset: 0x000F4E88
		internal x5? a()
		{
			return this.a;
		}

		// Token: 0x0600165C RID: 5724 RVA: 0x000F5EA0 File Offset: 0x000F4EA0
		internal void a(x5? A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600165D RID: 5725 RVA: 0x000F5EAC File Offset: 0x000F4EAC
		internal x5? b()
		{
			return this.b;
		}

		// Token: 0x0600165E RID: 5726 RVA: 0x000F5EC4 File Offset: 0x000F4EC4
		internal void b(x5? A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600165F RID: 5727 RVA: 0x000F5ED0 File Offset: 0x000F4ED0
		internal mw c()
		{
			return this.c;
		}

		// Token: 0x06001660 RID: 5728 RVA: 0x000F5EE8 File Offset: 0x000F4EE8
		internal void a(mw A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001661 RID: 5729 RVA: 0x000F5EF4 File Offset: 0x000F4EF4
		internal i2 d()
		{
			return this.d;
		}

		// Token: 0x06001662 RID: 5730 RVA: 0x000F5F0C File Offset: 0x000F4F0C
		internal my e()
		{
			return new my(this);
		}

		// Token: 0x04000A4F RID: 2639
		private x5? a = null;

		// Token: 0x04000A50 RID: 2640
		private x5? b = null;

		// Token: 0x04000A51 RID: 2641
		private mw c = mw.e;

		// Token: 0x04000A52 RID: 2642
		private i2 d = i2.a;
	}
}
