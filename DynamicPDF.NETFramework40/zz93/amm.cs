using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x020005BB RID: 1467
	internal class amm
	{
		// Token: 0x06003A27 RID: 14887 RVA: 0x001F3A40 File Offset: 0x001F2A40
		internal amm(LayoutWriter A_0, amj A_1, ahn A_2)
		{
			this.b = A_2.c();
			if (A_2.b())
			{
				this.a = A_1;
			}
			this.c = new amj();
			A_2.a().a(this.c, A_0);
			if (A_2.e() != null)
			{
				this.d = new PdfDocument(A_2.e()).GetPage(A_2.f());
			}
		}

		// Token: 0x06003A28 RID: 14888 RVA: 0x001F3AC8 File Offset: 0x001F2AC8
		internal al7 a()
		{
			return this.b;
		}

		// Token: 0x06003A29 RID: 14889 RVA: 0x001F3AE0 File Offset: 0x001F2AE0
		internal void a(PageWriter A_0)
		{
			if (this.a != null)
			{
				this.a.a(A_0);
			}
			this.c.a(A_0);
		}

		// Token: 0x06003A2A RID: 14890 RVA: 0x001F3B18 File Offset: 0x001F2B18
		internal PdfPage b()
		{
			return this.d;
		}

		// Token: 0x04001B8C RID: 7052
		private amj a = null;

		// Token: 0x04001B8D RID: 7053
		private al7 b;

		// Token: 0x04001B8E RID: 7054
		private amj c;

		// Token: 0x04001B8F RID: 7055
		private PdfPage d;
	}
}
