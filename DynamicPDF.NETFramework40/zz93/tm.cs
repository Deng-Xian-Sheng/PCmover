using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002EF RID: 751
	internal class tm
	{
		// Token: 0x0600216F RID: 8559 RVA: 0x00145BEA File Offset: 0x00144BEA
		internal tm()
		{
		}

		// Token: 0x06002170 RID: 8560 RVA: 0x00145C04 File Offset: 0x00144C04
		internal void a(q4 A_0)
		{
			if (this.b == null)
			{
				this.b = A_0;
				this.a = A_0;
			}
			else
			{
				this.b.a(A_0);
				this.b = A_0;
			}
		}

		// Token: 0x06002171 RID: 8561 RVA: 0x00145C50 File Offset: 0x00144C50
		internal void a(LayoutWriter A_0, bool A_1)
		{
			for (q4 q = this.a; q != null; q = q.a())
			{
				q.d7(A_0, A_1);
			}
		}

		// Token: 0x04000EA5 RID: 3749
		private q4 a = null;

		// Token: 0x04000EA6 RID: 3750
		private q4 b = null;
	}
}
