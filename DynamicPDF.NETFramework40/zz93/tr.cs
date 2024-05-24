using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002F4 RID: 756
	internal abstract class tr : q7
	{
		// Token: 0x06002198 RID: 8600 RVA: 0x0014619C File Offset: 0x0014519C
		internal override bool ee(LayoutWriter A_0)
		{
			return q7.a(this.ek(A_0));
		}

		// Token: 0x06002199 RID: 8601 RVA: 0x001461C0 File Offset: 0x001451C0
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			return q7.a(this.el(A_0, A_1));
		}

		// Token: 0x0600219A RID: 8602 RVA: 0x001461E4 File Offset: 0x001451E4
		internal override DateTime eg(LayoutWriter A_0)
		{
			return q7.b(this.ek(A_0));
		}

		// Token: 0x0600219B RID: 8603 RVA: 0x00146208 File Offset: 0x00145208
		internal override DateTime eh(LayoutWriter A_0, vi A_1)
		{
			return q7.b(this.el(A_0, A_1));
		}

		// Token: 0x0600219C RID: 8604 RVA: 0x0014622C File Offset: 0x0014522C
		internal override decimal ei(LayoutWriter A_0)
		{
			return q7.e(this.ek(A_0));
		}

		// Token: 0x0600219D RID: 8605 RVA: 0x00146250 File Offset: 0x00145250
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return q7.e(this.el(A_0, A_1));
		}

		// Token: 0x0600219E RID: 8606 RVA: 0x00146274 File Offset: 0x00145274
		internal override int em(LayoutWriter A_0)
		{
			return q7.c(this.ek(A_0));
		}

		// Token: 0x0600219F RID: 8607 RVA: 0x00146298 File Offset: 0x00145298
		internal override int en(LayoutWriter A_0, vi A_1)
		{
			return q7.c(this.el(A_0, A_1));
		}

		// Token: 0x060021A0 RID: 8608 RVA: 0x001462BC File Offset: 0x001452BC
		internal override object es(LayoutWriter A_0)
		{
			return this.ek(A_0);
		}

		// Token: 0x060021A1 RID: 8609 RVA: 0x001462DC File Offset: 0x001452DC
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			return this.el(A_0, A_1);
		}

		// Token: 0x060021A2 RID: 8610 RVA: 0x001462FC File Offset: 0x001452FC
		internal override string eo(LayoutWriter A_0)
		{
			return this.ek(A_0).ToString();
		}

		// Token: 0x060021A3 RID: 8611 RVA: 0x00146320 File Offset: 0x00145320
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			return this.el(A_0, A_1).ToString();
		}
	}
}
