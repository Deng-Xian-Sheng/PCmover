using System;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x0200082C RID: 2092
	public class ReportHeader
	{
		// Token: 0x0600546C RID: 21612 RVA: 0x002950B8 File Offset: 0x002940B8
		internal ReportHeader(rm A_0, v1 A_1)
		{
			this.a = A_1.fw();
			this.b = A_1.fx();
			if (A_1.b() != null && A_1.b().a() > 0)
			{
				this.c = new ReportElementList(A_0, A_1.b());
			}
			A_0.b().DocumentLayout.a(this.a, this);
			if (A_1.a() != null)
			{
				this.d = new sx(A_0, A_1.a());
			}
		}

		// Token: 0x170007C5 RID: 1989
		// (get) Token: 0x0600546D RID: 21613 RVA: 0x00295164 File Offset: 0x00294164
		public float Height
		{
			get
			{
				return x5.b(this.b);
			}
		}

		// Token: 0x0600546E RID: 21614 RVA: 0x00295184 File Offset: 0x00294184
		internal ReportElementList a()
		{
			return this.c;
		}

		// Token: 0x0600546F RID: 21615 RVA: 0x0029519C File Offset: 0x0029419C
		internal sx b()
		{
			return this.d;
		}

		// Token: 0x06005470 RID: 21616 RVA: 0x002951B4 File Offset: 0x002941B4
		internal string c()
		{
			return this.a;
		}

		// Token: 0x04002D35 RID: 11573
		private string a;

		// Token: 0x04002D36 RID: 11574
		private x5 b;

		// Token: 0x04002D37 RID: 11575
		private ReportElementList c = null;

		// Token: 0x04002D38 RID: 11576
		private sx d = null;
	}
}
