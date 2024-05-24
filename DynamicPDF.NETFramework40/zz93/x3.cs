using System;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000398 RID: 920
	internal class x3
	{
		// Token: 0x06002753 RID: 10067 RVA: 0x0016A900 File Offset: 0x00169900
		internal x3(rm A_0, wp A_1)
		{
			this.a = A_1.a();
			if (A_1.e() != null)
			{
				this.b = new PdfDocument(A_1.e()).GetPage(A_1.d());
			}
			if (A_1.b().a() > 0)
			{
				this.c = new ReportElementList(A_0, A_1.b());
			}
			A_0.b().DocumentLayout.a(this.a, this);
			if (A_1.c() != null)
			{
				this.d = new sx(A_0, A_1.c(), ref this.e);
			}
		}

		// Token: 0x06002754 RID: 10068 RVA: 0x0016A9D0 File Offset: 0x001699D0
		internal ReportElementList a()
		{
			return this.c;
		}

		// Token: 0x06002755 RID: 10069 RVA: 0x0016A9E8 File Offset: 0x001699E8
		internal sx b()
		{
			return this.d;
		}

		// Token: 0x06002756 RID: 10070 RVA: 0x0016AA00 File Offset: 0x00169A00
		internal string c()
		{
			return this.a;
		}

		// Token: 0x06002757 RID: 10071 RVA: 0x0016AA18 File Offset: 0x00169A18
		internal PdfPage d()
		{
			return this.b;
		}

		// Token: 0x06002758 RID: 10072 RVA: 0x0016AA30 File Offset: 0x00169A30
		internal bool e()
		{
			return this.e;
		}

		// Token: 0x0400110C RID: 4364
		private string a;

		// Token: 0x0400110D RID: 4365
		private PdfPage b = null;

		// Token: 0x0400110E RID: 4366
		private ReportElementList c = null;

		// Token: 0x0400110F RID: 4367
		private sx d = null;

		// Token: 0x04001110 RID: 4368
		private bool e = false;
	}
}
