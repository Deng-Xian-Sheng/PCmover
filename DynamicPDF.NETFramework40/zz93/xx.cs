using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x02000391 RID: 913
	internal class xx
	{
		// Token: 0x06002702 RID: 9986 RVA: 0x00168D2E File Offset: 0x00167D2E
		internal xx(PageElement A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002703 RID: 9987 RVA: 0x00168D40 File Offset: 0x00167D40
		internal PageElement a()
		{
			return this.a;
		}

		// Token: 0x06002704 RID: 9988 RVA: 0x00168D58 File Offset: 0x00167D58
		internal xx b()
		{
			return this.b;
		}

		// Token: 0x06002705 RID: 9989 RVA: 0x00168D70 File Offset: 0x00167D70
		internal void a(xx A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002706 RID: 9990 RVA: 0x00168D7C File Offset: 0x00167D7C
		internal xx c()
		{
			return new xx(this.a.fc());
		}

		// Token: 0x040010F2 RID: 4338
		private PageElement a;

		// Token: 0x040010F3 RID: 4339
		private xx b;
	}
}
