using System;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x0200006A RID: 106
	internal class cb
	{
		// Token: 0x06000473 RID: 1139 RVA: 0x0004A5A8 File Offset: 0x000495A8
		internal cb(abj A_0)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 4)
				{
					this.a = (abe)abk.c().h6();
					break;
				}
			}
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0004A60C File Offset: 0x0004960C
		internal int a(PdfDocument A_0)
		{
			if (this.a != null)
			{
				if (!(this.a.a(0) is abv))
				{
					ab6 a_ = (ab6)this.a.a(0);
					PdfPage pdfPage = A_0.m().b(a_).h();
					return pdfPage.e() + 1;
				}
			}
			return -1;
		}

		// Token: 0x0400029A RID: 666
		private abe a;
	}
}
