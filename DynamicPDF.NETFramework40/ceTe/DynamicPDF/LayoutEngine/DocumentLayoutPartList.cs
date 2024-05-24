using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x0200092C RID: 2348
	public class DocumentLayoutPartList
	{
		// Token: 0x06005F84 RID: 24452 RVA: 0x0035D9C8 File Offset: 0x0035C9C8
		internal DocumentLayoutPartList(DocumentLayout A_0, int A_1)
		{
			this.c = A_0;
			this.a = new DocumentLayoutPart[A_1];
		}

		// Token: 0x06005F85 RID: 24453 RVA: 0x0035D9F4 File Offset: 0x0035C9F4
		internal void a(alh A_0)
		{
			Report report = new Report(this.c);
			report.a(A_0);
			this.a[this.b++] = report;
			if (report.m2())
			{
				this.d = true;
			}
		}

		// Token: 0x06005F86 RID: 24454 RVA: 0x0035DA44 File Offset: 0x0035CA44
		internal void a(ak9 A_0)
		{
			FixedPage fixedPage = new FixedPage(A_0, this.c);
			this.a[this.b++] = fixedPage;
			if (fixedPage.m2())
			{
				this.d = true;
			}
		}

		// Token: 0x17000A28 RID: 2600
		// (get) Token: 0x06005F87 RID: 24455 RVA: 0x0035DA8C File Offset: 0x0035CA8C
		public int Count
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x17000A29 RID: 2601
		public DocumentLayoutPart this[int index]
		{
			get
			{
				return this.a[index];
			}
		}

		// Token: 0x06005F89 RID: 24457 RVA: 0x0035DAC0 File Offset: 0x0035CAC0
		internal bool a()
		{
			return this.d;
		}

		// Token: 0x06005F8A RID: 24458 RVA: 0x0035DAD8 File Offset: 0x0035CAD8
		internal void b()
		{
			for (int i = 0; i < this.b; i++)
			{
				DocumentLayoutPart documentLayoutPart = this.a[i];
				if (documentLayoutPart.m2())
				{
					documentLayoutPart.mz();
				}
			}
		}

		// Token: 0x04003121 RID: 12577
		private DocumentLayoutPart[] a;

		// Token: 0x04003122 RID: 12578
		private int b = 0;

		// Token: 0x04003123 RID: 12579
		private DocumentLayout c;

		// Token: 0x04003124 RID: 12580
		private bool d = false;
	}
}
