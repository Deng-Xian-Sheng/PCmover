using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000937 RID: 2359
	public class ReportFooter
	{
		// Token: 0x06005FF7 RID: 24567 RVA: 0x0035F898 File Offset: 0x0035E898
		internal ReportFooter(alo A_0, ak0 A_1)
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

		// Token: 0x17000A36 RID: 2614
		// (get) Token: 0x06005FF8 RID: 24568 RVA: 0x0035F944 File Offset: 0x0035E944
		public float Height
		{
			get
			{
				return x5.b(this.b);
			}
		}

		// Token: 0x06005FF9 RID: 24569 RVA: 0x0035F964 File Offset: 0x0035E964
		internal LayoutElementList a()
		{
			return this.c;
		}

		// Token: 0x06005FFA RID: 24570 RVA: 0x0035F97C File Offset: 0x0035E97C
		internal aho b()
		{
			return this.d;
		}

		// Token: 0x06005FFB RID: 24571 RVA: 0x0035F994 File Offset: 0x0035E994
		internal string c()
		{
			return this.a;
		}

		// Token: 0x04003163 RID: 12643
		private string a;

		// Token: 0x04003164 RID: 12644
		private x5 b;

		// Token: 0x04003165 RID: 12645
		private LayoutElementList c = null;

		// Token: 0x04003166 RID: 12646
		private aho d = null;
	}
}
