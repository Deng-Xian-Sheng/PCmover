using System;

namespace zz93
{
	// Token: 0x0200014A RID: 330
	internal class ia
	{
		// Token: 0x06000C4C RID: 3148 RVA: 0x000913D4 File Offset: 0x000903D4
		internal id a()
		{
			return this.a;
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x000913EC File Offset: 0x000903EC
		internal void a(id A_0)
		{
			if (this.a == null)
			{
				this.a = new id();
				this.a.a(A_0.a());
				this.a.a(A_0.b());
				this.a.a(null);
			}
			else
			{
				this.b = new id();
				this.b.a(A_0.a());
				this.b.a(A_0.b());
				this.b.a(this.a);
				this.a = this.b;
			}
		}

		// Token: 0x04000655 RID: 1621
		private id a;

		// Token: 0x04000656 RID: 1622
		private id b;
	}
}
