using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000502 RID: 1282
	internal class ahn
	{
		// Token: 0x06003424 RID: 13348 RVA: 0x001CEEFC File Offset: 0x001CDEFC
		internal ahn(alo A_0, akr A_1)
		{
			this.a = A_1.e();
			this.b = A_1.d();
			this.c = A_1.c();
			this.d = new LayoutElementList(A_0, A_1.b());
			A_0.b().DocumentLayout.a(this.a, this);
			this.e = A_1.f();
			this.f = A_1.g();
		}

		// Token: 0x06003425 RID: 13349 RVA: 0x001CEF88 File Offset: 0x001CDF88
		internal LayoutElementList a()
		{
			return this.d;
		}

		// Token: 0x06003426 RID: 13350 RVA: 0x001CEFA0 File Offset: 0x001CDFA0
		internal bool b()
		{
			return this.c;
		}

		// Token: 0x06003427 RID: 13351 RVA: 0x001CEFB8 File Offset: 0x001CDFB8
		internal al7 c()
		{
			return this.b;
		}

		// Token: 0x06003428 RID: 13352 RVA: 0x001CEFD0 File Offset: 0x001CDFD0
		internal string d()
		{
			return this.a;
		}

		// Token: 0x06003429 RID: 13353 RVA: 0x001CEFE8 File Offset: 0x001CDFE8
		internal string e()
		{
			return this.e;
		}

		// Token: 0x0600342A RID: 13354 RVA: 0x001CF000 File Offset: 0x001CE000
		internal int f()
		{
			return this.f;
		}

		// Token: 0x04001947 RID: 6471
		private string a;

		// Token: 0x04001948 RID: 6472
		private al7 b;

		// Token: 0x04001949 RID: 6473
		private bool c;

		// Token: 0x0400194A RID: 6474
		private LayoutElementList d;

		// Token: 0x0400194B RID: 6475
		private string e = null;

		// Token: 0x0400194C RID: 6476
		private int f = 1;
	}
}
