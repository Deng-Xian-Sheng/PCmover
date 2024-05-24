using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x0200008B RID: 139
	internal class c3 : cw
	{
		// Token: 0x060006AB RID: 1707 RVA: 0x0005D52B File Offset: 0x0005C52B
		internal c3(ab6 A_0, abj A_1) : base(0, 0)
		{
			this.a = A_1;
			this.b = A_0;
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x0005D554 File Offset: 0x0005C554
		internal override ab6 bl()
		{
			return this.b;
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0005D56C File Offset: 0x0005C56C
		internal override void a9(DocumentWriter A_0, int A_1)
		{
			if (this.a != null)
			{
				A_0.WriteDictionaryOpen();
				this.a.b(A_0);
				PdfPage a_ = this.b.a().h();
				int num = A_0.b(a_);
				for (int i = 0; i < A_0.Document.Pages.Count; i++)
				{
					if (num == A_0.GetPageObject(i + 1))
					{
						base.a6(i);
						break;
					}
				}
				A_0.WriteName(cw.c);
				if (base.a() != null)
				{
					A_0.WriteReferenceShallow(A_0.Document.j().i().a(base.a().b()).a());
				}
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x0005D644 File Offset: 0x0005C644
		internal override bool bm(int A_0)
		{
			PdfPage pdfPage = this.b.a().h();
			int num = pdfPage.e();
			return num == A_0;
		}

		// Token: 0x0400038D RID: 909
		private abj a = null;

		// Token: 0x0400038E RID: 910
		private ab6 b = null;
	}
}
