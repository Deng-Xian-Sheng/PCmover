using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000399 RID: 921
	internal class x4 : rc
	{
		// Token: 0x06002759 RID: 10073 RVA: 0x0016AA48 File Offset: 0x00169A48
		internal x4(char[] A_0, int A_1, int A_2)
		{
			w5 w = new w5(A_0, A_1, A_2);
			w.a(true);
			w.d(true);
			if (w.b(false))
			{
				this.a = w.c(false);
			}
			else
			{
				this.a = w.g();
			}
			if (!(this.a is tp) && !(this.a is rc))
			{
				throw new ReportWriterException("Function returns non boolean value for visibility condition.");
			}
			this.b = w.f();
		}

		// Token: 0x0600275A RID: 10074 RVA: 0x0016AAE0 File Offset: 0x00169AE0
		internal bool a()
		{
			return this.b != null && this.b.b() != 0;
		}

		// Token: 0x0600275B RID: 10075 RVA: 0x0016AB10 File Offset: 0x00169B10
		internal sz b()
		{
			return this.b;
		}

		// Token: 0x0600275C RID: 10076 RVA: 0x0016AB28 File Offset: 0x00169B28
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x0600275D RID: 10077 RVA: 0x0016AB48 File Offset: 0x00169B48
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x0600275E RID: 10078 RVA: 0x0016AB68 File Offset: 0x00169B68
		internal override bool ee(LayoutWriter A_0)
		{
			return this.a.ee(A_0);
		}

		// Token: 0x0600275F RID: 10079 RVA: 0x0016AB88 File Offset: 0x00169B88
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			return this.a.ef(A_0, A_1);
		}

		// Token: 0x06002760 RID: 10080 RVA: 0x0016ABA7 File Offset: 0x00169BA7
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x04001111 RID: 4369
		private new q7 a;

		// Token: 0x04001112 RID: 4370
		private new sz b;
	}
}
