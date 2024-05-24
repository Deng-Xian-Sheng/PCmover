using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x0200093B RID: 2363
	public class SubReportHeader
	{
		// Token: 0x06006008 RID: 24584 RVA: 0x0035FBF0 File Offset: 0x0035EBF0
		internal SubReportHeader(alo A_0, ak4 A_1)
		{
			this.a = A_1.mv();
			this.b = A_1.mx();
			if (A_1.a() != null && A_1.a().a() > 0)
			{
				this.c = new LayoutElementList(A_0, A_1.a());
			}
			A_0.b().DocumentLayout.a(this.a, this);
			if (A_1.b() != null)
			{
				this.d = new aho(A_0, A_1.b());
			}
		}

		// Token: 0x17000A39 RID: 2617
		// (get) Token: 0x06006009 RID: 24585 RVA: 0x0035FC9C File Offset: 0x0035EC9C
		public float Height
		{
			get
			{
				return x5.b(this.b);
			}
		}

		// Token: 0x0600600A RID: 24586 RVA: 0x0035FCBC File Offset: 0x0035ECBC
		internal LayoutElementList a()
		{
			return this.c;
		}

		// Token: 0x0600600B RID: 24587 RVA: 0x0035FCD4 File Offset: 0x0035ECD4
		internal aho b()
		{
			return this.d;
		}

		// Token: 0x0600600C RID: 24588 RVA: 0x0035FCEC File Offset: 0x0035ECEC
		internal string c()
		{
			return this.a;
		}

		// Token: 0x0400316F RID: 12655
		private string a;

		// Token: 0x04003170 RID: 12656
		private x5 b;

		// Token: 0x04003171 RID: 12657
		private LayoutElementList c = null;

		// Token: 0x04003172 RID: 12658
		private aho d = null;
	}
}
