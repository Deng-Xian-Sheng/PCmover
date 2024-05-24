using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000291 RID: 657
	internal abstract class ra : q7
	{
		// Token: 0x06001D76 RID: 7542 RVA: 0x0012BD34 File Offset: 0x0012AD34
		internal override bool ee(LayoutWriter A_0)
		{
			return q7.a(this.ei(A_0));
		}

		// Token: 0x06001D77 RID: 7543 RVA: 0x0012BD58 File Offset: 0x0012AD58
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			return q7.a(this.ej(A_0, A_1));
		}

		// Token: 0x06001D78 RID: 7544 RVA: 0x0012BD7C File Offset: 0x0012AD7C
		internal override DateTime eg(LayoutWriter A_0)
		{
			return q7.b(this.ei(A_0));
		}

		// Token: 0x06001D79 RID: 7545 RVA: 0x0012BDA0 File Offset: 0x0012ADA0
		internal override DateTime eh(LayoutWriter A_0, vi A_1)
		{
			return q7.b(this.ej(A_0, A_1));
		}

		// Token: 0x06001D7A RID: 7546 RVA: 0x0012BDC4 File Offset: 0x0012ADC4
		internal override double ek(LayoutWriter A_0)
		{
			return q7.d(this.ei(A_0));
		}

		// Token: 0x06001D7B RID: 7547 RVA: 0x0012BDE8 File Offset: 0x0012ADE8
		internal override double el(LayoutWriter A_0, vi A_1)
		{
			return q7.d(this.ej(A_0, A_1));
		}

		// Token: 0x06001D7C RID: 7548 RVA: 0x0012BE0C File Offset: 0x0012AE0C
		internal override int em(LayoutWriter A_0)
		{
			return q7.c(this.ei(A_0));
		}

		// Token: 0x06001D7D RID: 7549 RVA: 0x0012BE30 File Offset: 0x0012AE30
		internal override int en(LayoutWriter A_0, vi A_1)
		{
			return q7.c(this.ej(A_0, A_1));
		}

		// Token: 0x06001D7E RID: 7550 RVA: 0x0012BE54 File Offset: 0x0012AE54
		internal override object es(LayoutWriter A_0)
		{
			return this.ei(A_0);
		}

		// Token: 0x06001D7F RID: 7551 RVA: 0x0012BE74 File Offset: 0x0012AE74
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			return this.ej(A_0, A_1);
		}

		// Token: 0x06001D80 RID: 7552 RVA: 0x0012BE94 File Offset: 0x0012AE94
		internal override string eo(LayoutWriter A_0)
		{
			return this.ei(A_0).ToString();
		}

		// Token: 0x06001D81 RID: 7553 RVA: 0x0012BEB8 File Offset: 0x0012AEB8
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			return this.ej(A_0, A_1).ToString();
		}
	}
}
