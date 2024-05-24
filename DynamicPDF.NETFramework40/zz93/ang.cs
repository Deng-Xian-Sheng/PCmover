using System;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x020005DA RID: 1498
	internal class ang
	{
		// Token: 0x06003B5A RID: 15194 RVA: 0x001FC24C File Offset: 0x001FB24C
		internal ang(alo A_0, alm A_1)
		{
			this.a = A_1.a();
			if (A_1.e() != null)
			{
				this.b = new PdfDocument(A_1.e()).GetPage(A_1.d());
			}
			if (A_1.b().a() > 0)
			{
				this.c = new LayoutElementList(A_0, A_1.b());
			}
			A_0.b().DocumentLayout.a(this.a, this);
			if (A_1.c() != null)
			{
				this.d = new aho(A_0, A_1.c(), ref this.e);
			}
		}

		// Token: 0x06003B5B RID: 15195 RVA: 0x001FC31C File Offset: 0x001FB31C
		internal LayoutElementList a()
		{
			return this.c;
		}

		// Token: 0x06003B5C RID: 15196 RVA: 0x001FC334 File Offset: 0x001FB334
		internal aho b()
		{
			return this.d;
		}

		// Token: 0x06003B5D RID: 15197 RVA: 0x001FC34C File Offset: 0x001FB34C
		internal string c()
		{
			return this.a;
		}

		// Token: 0x06003B5E RID: 15198 RVA: 0x001FC364 File Offset: 0x001FB364
		internal PdfPage d()
		{
			return this.b;
		}

		// Token: 0x06003B5F RID: 15199 RVA: 0x001FC37C File Offset: 0x001FB37C
		internal bool e()
		{
			return this.e;
		}

		// Token: 0x04001BF0 RID: 7152
		private string a;

		// Token: 0x04001BF1 RID: 7153
		private PdfPage b = null;

		// Token: 0x04001BF2 RID: 7154
		private LayoutElementList c = null;

		// Token: 0x04001BF3 RID: 7155
		private aho d = null;

		// Token: 0x04001BF4 RID: 7156
		private bool e = false;
	}
}
