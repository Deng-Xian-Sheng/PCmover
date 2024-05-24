using System;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x0200082F RID: 2095
	public class SubReportHeader
	{
		// Token: 0x06005477 RID: 21623 RVA: 0x002952EC File Offset: 0x002942EC
		internal SubReportHeader(rm A_0, v2 A_1)
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

		// Token: 0x170007C7 RID: 1991
		// (get) Token: 0x06005478 RID: 21624 RVA: 0x00295398 File Offset: 0x00294398
		public float Height
		{
			get
			{
				return x5.b(this.b);
			}
		}

		// Token: 0x06005479 RID: 21625 RVA: 0x002953B8 File Offset: 0x002943B8
		internal ReportElementList a()
		{
			return this.c;
		}

		// Token: 0x0600547A RID: 21626 RVA: 0x002953D0 File Offset: 0x002943D0
		internal sx b()
		{
			return this.d;
		}

		// Token: 0x0600547B RID: 21627 RVA: 0x002953E8 File Offset: 0x002943E8
		internal string c()
		{
			return this.a;
		}

		// Token: 0x04002D3D RID: 11581
		private string a;

		// Token: 0x04002D3E RID: 11582
		private x5 b;

		// Token: 0x04002D3F RID: 11583
		private ReportElementList c = null;

		// Token: 0x04002D40 RID: 11584
		private sx d = null;
	}
}
