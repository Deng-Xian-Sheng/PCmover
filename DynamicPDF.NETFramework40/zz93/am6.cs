using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x020005CF RID: 1487
	internal class am6
	{
		// Token: 0x06003ADE RID: 15070 RVA: 0x001F9848 File Offset: 0x001F8848
		internal am6(PageElement A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003ADF RID: 15071 RVA: 0x001F985C File Offset: 0x001F885C
		internal PageElement a()
		{
			return this.a;
		}

		// Token: 0x06003AE0 RID: 15072 RVA: 0x001F9874 File Offset: 0x001F8874
		internal am6 b()
		{
			return this.b;
		}

		// Token: 0x06003AE1 RID: 15073 RVA: 0x001F988C File Offset: 0x001F888C
		internal void a(am6 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06003AE2 RID: 15074 RVA: 0x001F9898 File Offset: 0x001F8898
		internal am6 c()
		{
			return new am6(this.a.fc());
		}

		// Token: 0x04001BCA RID: 7114
		private PageElement a;

		// Token: 0x04001BCB RID: 7115
		private am6 b;
	}
}
