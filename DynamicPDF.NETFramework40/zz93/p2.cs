using System;
using ceTe.DynamicPDF.PageElements.Html;

namespace zz93
{
	// Token: 0x02000264 RID: 612
	internal class p2
	{
		// Token: 0x06001BB8 RID: 7096 RVA: 0x0011DDF0 File Offset: 0x0011CDF0
		internal p2(p1 A_0)
		{
			this.a = A_0;
			this.b = A_0.c;
			this.c = A_0.a;
		}

		// Token: 0x06001BB9 RID: 7097 RVA: 0x0011DE1C File Offset: 0x0011CE1C
		internal d0 a()
		{
			return this.c.a();
		}

		// Token: 0x06001BBA RID: 7098 RVA: 0x0011DE39 File Offset: 0x0011CE39
		internal void b()
		{
			this.c = this.a.a;
		}

		// Token: 0x06001BBB RID: 7099 RVA: 0x0011DE50 File Offset: 0x0011CE50
		internal bool c()
		{
			bool result = false;
			if (this.b != this.a.c)
			{
				throw new HtmlParsingException("A concurrent modification occured.");
			}
			this.c = this.c.b();
			if (this.c != this.a.a)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x04000C87 RID: 3207
		private p1 a;

		// Token: 0x04000C88 RID: 3208
		private int b;

		// Token: 0x04000C89 RID: 3209
		private os c;
	}
}
