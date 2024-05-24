using System;

namespace zz93
{
	// Token: 0x020004C1 RID: 1217
	internal class afu : fs
	{
		// Token: 0x060031F9 RID: 12793 RVA: 0x001BF12B File Offset: 0x001BE12B
		internal afu(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060031FA RID: 12794 RVA: 0x001BF140 File Offset: 0x001BE140
		internal string a()
		{
			return this.a;
		}

		// Token: 0x060031FB RID: 12795 RVA: 0x001BF158 File Offset: 0x001BE158
		internal void a(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060031FC RID: 12796 RVA: 0x001BF164 File Offset: 0x001BE164
		internal bool b()
		{
			return this.b;
		}

		// Token: 0x060031FD RID: 12797 RVA: 0x001BF17C File Offset: 0x001BE17C
		internal void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060031FE RID: 12798 RVA: 0x001BF188 File Offset: 0x001BE188
		internal override afu kl()
		{
			return this;
		}

		// Token: 0x0400176D RID: 5997
		private string a;

		// Token: 0x0400176E RID: 5998
		private bool b;
	}
}
