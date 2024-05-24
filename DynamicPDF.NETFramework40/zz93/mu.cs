using System;

namespace zz93
{
	// Token: 0x020001F0 RID: 496
	internal class mu
	{
		// Token: 0x06001632 RID: 5682 RVA: 0x000F588F File Offset: 0x000F488F
		internal mu()
		{
		}

		// Token: 0x06001633 RID: 5683 RVA: 0x000F589A File Offset: 0x000F489A
		internal mu(ms A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001634 RID: 5684 RVA: 0x000F58AC File Offset: 0x000F48AC
		internal mu(mu A_0)
		{
			this.a = A_0.a();
			this.b = A_0.b();
		}

		// Token: 0x06001635 RID: 5685 RVA: 0x000F58D0 File Offset: 0x000F48D0
		internal ms a()
		{
			return this.a;
		}

		// Token: 0x06001636 RID: 5686 RVA: 0x000F58E8 File Offset: 0x000F48E8
		internal void a(ms A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001637 RID: 5687 RVA: 0x000F58F4 File Offset: 0x000F48F4
		internal mu b()
		{
			return this.b;
		}

		// Token: 0x06001638 RID: 5688 RVA: 0x000F590C File Offset: 0x000F490C
		internal void a(mu A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001639 RID: 5689 RVA: 0x000F5918 File Offset: 0x000F4918
		internal mu c()
		{
			return this.c;
		}

		// Token: 0x0600163A RID: 5690 RVA: 0x000F5930 File Offset: 0x000F4930
		internal void b(mu A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600163B RID: 5691 RVA: 0x000F593C File Offset: 0x000F493C
		internal mu d()
		{
			return new mu(this.a);
		}

		// Token: 0x04000A40 RID: 2624
		private ms a;

		// Token: 0x04000A41 RID: 2625
		private mu b;

		// Token: 0x04000A42 RID: 2626
		private mu c;
	}
}
