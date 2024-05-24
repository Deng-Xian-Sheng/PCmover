using System;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x02000815 RID: 2069
	public class DocumentLayoutPartList
	{
		// Token: 0x060053CC RID: 21452 RVA: 0x00292BA4 File Offset: 0x00291BA4
		internal DocumentLayoutPartList(DocumentLayout A_0, int A_1)
		{
			this.c = A_0;
			this.a = new DocumentLayoutPart[A_1];
		}

		// Token: 0x060053CD RID: 21453 RVA: 0x00292BD0 File Offset: 0x00291BD0
		internal void a(wi A_0)
		{
			Report report = new Report(this.c);
			report.a(A_0);
			this.a[this.b++] = report;
			if (report.ey())
			{
				this.d = true;
			}
		}

		// Token: 0x060053CE RID: 21454 RVA: 0x00292C20 File Offset: 0x00291C20
		internal void a(v7 A_0)
		{
			FixedPage fixedPage = new FixedPage(A_0, this.c);
			this.a[this.b++] = fixedPage;
			if (fixedPage.ey())
			{
				this.d = true;
			}
		}

		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x060053CF RID: 21455 RVA: 0x00292C68 File Offset: 0x00291C68
		public int Count
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x170007A6 RID: 1958
		public DocumentLayoutPart this[int index]
		{
			get
			{
				return this.a[index];
			}
		}

		// Token: 0x060053D1 RID: 21457 RVA: 0x00292C9C File Offset: 0x00291C9C
		internal bool a()
		{
			return this.d;
		}

		// Token: 0x060053D2 RID: 21458 RVA: 0x00292CB4 File Offset: 0x00291CB4
		internal void b()
		{
			for (int i = 0; i < this.b; i++)
			{
				DocumentLayoutPart documentLayoutPart = this.a[i];
				if (documentLayoutPart.ey())
				{
					documentLayoutPart.ev();
				}
			}
		}

		// Token: 0x04002CE1 RID: 11489
		private DocumentLayoutPart[] a;

		// Token: 0x04002CE2 RID: 11490
		private int b = 0;

		// Token: 0x04002CE3 RID: 11491
		private DocumentLayout c;

		// Token: 0x04002CE4 RID: 11492
		private bool d = false;
	}
}
