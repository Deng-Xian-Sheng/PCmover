using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x0200093A RID: 2362
	public class SubReportFooter
	{
		// Token: 0x06006003 RID: 24579 RVA: 0x0035FADC File Offset: 0x0035EADC
		internal SubReportFooter(alo A_0, ak1 A_1)
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

		// Token: 0x17000A38 RID: 2616
		// (get) Token: 0x06006004 RID: 24580 RVA: 0x0035FB88 File Offset: 0x0035EB88
		public float Height
		{
			get
			{
				return x5.b(this.b);
			}
		}

		// Token: 0x06006005 RID: 24581 RVA: 0x0035FBA8 File Offset: 0x0035EBA8
		internal LayoutElementList a()
		{
			return this.c;
		}

		// Token: 0x06006006 RID: 24582 RVA: 0x0035FBC0 File Offset: 0x0035EBC0
		internal aho b()
		{
			return this.d;
		}

		// Token: 0x06006007 RID: 24583 RVA: 0x0035FBD8 File Offset: 0x0035EBD8
		internal string c()
		{
			return this.a;
		}

		// Token: 0x0400316B RID: 12651
		private string a;

		// Token: 0x0400316C RID: 12652
		private x5 b;

		// Token: 0x0400316D RID: 12653
		private LayoutElementList c = null;

		// Token: 0x0400316E RID: 12654
		private aho d = null;
	}
}
