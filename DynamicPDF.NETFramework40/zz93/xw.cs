using System;
using System.Collections.Specialized;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x02000390 RID: 912
	internal class xw : rm
	{
		// Token: 0x060026F7 RID: 9975 RVA: 0x00168BC8 File Offset: 0x00167BC8
		internal xw()
		{
		}

		// Token: 0x060026F8 RID: 9976 RVA: 0x00168BDC File Offset: 0x00167BDC
		sz rm.a()
		{
			return this.d();
		}

		// Token: 0x060026F9 RID: 9977 RVA: 0x00168BF4 File Offset: 0x00167BF4
		string rm.b()
		{
			return "Page";
		}

		// Token: 0x060026FA RID: 9978 RVA: 0x00168C0C File Offset: 0x00167C0C
		DocumentLayoutPart rm.c()
		{
			return this.c;
		}

		// Token: 0x060026FB RID: 9979 RVA: 0x00168C24 File Offset: 0x00167C24
		internal sz d()
		{
			if (this.a == null)
			{
				this.a = new sz();
			}
			return this.a;
		}

		// Token: 0x060026FC RID: 9980 RVA: 0x00168C5C File Offset: 0x00167C5C
		internal bool e()
		{
			return this.a != null && this.a.b() != 0;
		}

		// Token: 0x060026FD RID: 9981 RVA: 0x00168C98 File Offset: 0x00167C98
		internal tm f()
		{
			if (this.b == null)
			{
				this.b = new tm();
			}
			return this.b;
		}

		// Token: 0x060026FE RID: 9982 RVA: 0x00168CCD File Offset: 0x00167CCD
		internal void a(tm A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060026FF RID: 9983 RVA: 0x00168CD8 File Offset: 0x00167CD8
		internal HybridDictionary g()
		{
			HybridDictionary result;
			if (this.d == null)
			{
				this.d = new HybridDictionary();
				result = this.d;
			}
			else
			{
				result = this.d;
			}
			return result;
		}

		// Token: 0x06002700 RID: 9984 RVA: 0x00168D18 File Offset: 0x00167D18
		bool rm.h()
		{
			return false;
		}

		// Token: 0x06002701 RID: 9985 RVA: 0x00168D2B File Offset: 0x00167D2B
		void rm.a(SubReport A_0)
		{
		}

		// Token: 0x040010EE RID: 4334
		private sz a;

		// Token: 0x040010EF RID: 4335
		private tm b;

		// Token: 0x040010F0 RID: 4336
		private DocumentLayoutPart c = null;

		// Token: 0x040010F1 RID: 4337
		private HybridDictionary d;
	}
}
