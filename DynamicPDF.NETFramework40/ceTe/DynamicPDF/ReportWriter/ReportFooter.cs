using System;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x0200082B RID: 2091
	public class ReportFooter
	{
		// Token: 0x06005467 RID: 21607 RVA: 0x00294FA4 File Offset: 0x00293FA4
		internal ReportFooter(rm A_0, vx A_1)
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

		// Token: 0x170007C4 RID: 1988
		// (get) Token: 0x06005468 RID: 21608 RVA: 0x00295050 File Offset: 0x00294050
		public float Height
		{
			get
			{
				return x5.b(this.b);
			}
		}

		// Token: 0x06005469 RID: 21609 RVA: 0x00295070 File Offset: 0x00294070
		internal ReportElementList a()
		{
			return this.c;
		}

		// Token: 0x0600546A RID: 21610 RVA: 0x00295088 File Offset: 0x00294088
		internal sx b()
		{
			return this.d;
		}

		// Token: 0x0600546B RID: 21611 RVA: 0x002950A0 File Offset: 0x002940A0
		internal string c()
		{
			return this.a;
		}

		// Token: 0x04002D31 RID: 11569
		private string a;

		// Token: 0x04002D32 RID: 11570
		private x5 b;

		// Token: 0x04002D33 RID: 11571
		private ReportElementList c = null;

		// Token: 0x04002D34 RID: 11572
		private sx d = null;
	}
}
