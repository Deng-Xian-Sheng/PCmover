using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200037F RID: 895
	internal class xi
	{
		// Token: 0x06002614 RID: 9748 RVA: 0x00162FBC File Offset: 0x00161FBC
		internal xi(LayoutWriter A_0, xf A_1, sw A_2)
		{
			this.b = A_2.c();
			if (A_2.b())
			{
				this.a = A_1;
			}
			this.c = new xf();
			A_2.a().a(this.c, A_0);
			if (A_2.e() != null)
			{
				this.d = new PdfDocument(A_2.e()).GetPage(A_2.f());
			}
		}

		// Token: 0x06002615 RID: 9749 RVA: 0x00163044 File Offset: 0x00162044
		internal w6 a()
		{
			return this.b;
		}

		// Token: 0x06002616 RID: 9750 RVA: 0x0016305C File Offset: 0x0016205C
		internal void a(PageWriter A_0)
		{
			if (this.a != null)
			{
				this.a.a(A_0);
			}
			this.c.a(A_0);
		}

		// Token: 0x06002617 RID: 9751 RVA: 0x00163094 File Offset: 0x00162094
		internal PdfPage b()
		{
			return this.d;
		}

		// Token: 0x040010A5 RID: 4261
		private xf a = null;

		// Token: 0x040010A6 RID: 4262
		private w6 b;

		// Token: 0x040010A7 RID: 4263
		private xf c;

		// Token: 0x040010A8 RID: 4264
		private PdfPage d;
	}
}
