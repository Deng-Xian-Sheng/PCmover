using System;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x0200082E RID: 2094
	public class SubReportFooter
	{
		// Token: 0x06005472 RID: 21618 RVA: 0x002951D8 File Offset: 0x002941D8
		internal SubReportFooter(rm A_0, vy A_1)
		{
			this.a = A_1.fw();
			this.b = A_1.fx();
			if (A_1.a() != null && A_1.a().a() > 0)
			{
				this.c = new ReportElementList(A_0, A_1.a());
			}
			A_0.b().DocumentLayout.a(this.a, this);
			if (A_1.b() != null)
			{
				this.d = new sx(A_0, A_1.b());
			}
		}

		// Token: 0x170007C6 RID: 1990
		// (get) Token: 0x06005473 RID: 21619 RVA: 0x00295284 File Offset: 0x00294284
		public float Height
		{
			get
			{
				return x5.b(this.b);
			}
		}

		// Token: 0x06005474 RID: 21620 RVA: 0x002952A4 File Offset: 0x002942A4
		internal ReportElementList a()
		{
			return this.c;
		}

		// Token: 0x06005475 RID: 21621 RVA: 0x002952BC File Offset: 0x002942BC
		internal sx b()
		{
			return this.d;
		}

		// Token: 0x06005476 RID: 21622 RVA: 0x002952D4 File Offset: 0x002942D4
		internal string c()
		{
			return this.a;
		}

		// Token: 0x04002D39 RID: 11577
		private string a;

		// Token: 0x04002D3A RID: 11578
		private x5 b;

		// Token: 0x04002D3B RID: 11579
		private ReportElementList c = null;

		// Token: 0x04002D3C RID: 11580
		private sx d = null;
	}
}
