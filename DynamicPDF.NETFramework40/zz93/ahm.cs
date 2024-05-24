using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000501 RID: 1281
	internal class ahm
	{
		// Token: 0x0600341F RID: 13343 RVA: 0x001CEE57 File Offset: 0x001CDE57
		internal ahm(string A_0) : this(A_0.ToCharArray(), 0, A_0.Length)
		{
		}

		// Token: 0x06003420 RID: 13344 RVA: 0x001CEE6F File Offset: 0x001CDE6F
		internal ahm(char[] A_0, int A_1, int A_2)
		{
			this.c = A_1;
			this.b = new al5(A_0, A_1, A_2);
			this.a = this.b.i();
		}

		// Token: 0x06003421 RID: 13345 RVA: 0x001CEEA0 File Offset: 0x001CDEA0
		internal bool a(LayoutWriter A_0)
		{
			return this.a.l5(A_0);
		}

		// Token: 0x06003422 RID: 13346 RVA: 0x001CEEC0 File Offset: 0x001CDEC0
		internal ahq a()
		{
			return this.a;
		}

		// Token: 0x06003423 RID: 13347 RVA: 0x001CEED8 File Offset: 0x001CDED8
		internal string b()
		{
			return this.b.b(this.c);
		}

		// Token: 0x04001944 RID: 6468
		private ahq a;

		// Token: 0x04001945 RID: 6469
		private al5 b;

		// Token: 0x04001946 RID: 6470
		private int c;
	}
}
