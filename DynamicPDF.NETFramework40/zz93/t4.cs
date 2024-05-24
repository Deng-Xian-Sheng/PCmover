using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000301 RID: 769
	internal abstract class t4 : q7
	{
		// Token: 0x060021F6 RID: 8694 RVA: 0x001488FC File Offset: 0x001478FC
		internal override bool ee(LayoutWriter A_0)
		{
			return q7.a(this.ei(A_0));
		}

		// Token: 0x060021F7 RID: 8695 RVA: 0x00148920 File Offset: 0x00147920
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			return q7.a(this.ej(A_0, A_1));
		}

		// Token: 0x060021F8 RID: 8696 RVA: 0x00148944 File Offset: 0x00147944
		internal override DateTime eg(LayoutWriter A_0)
		{
			return q7.b(this.ei(A_0));
		}

		// Token: 0x060021F9 RID: 8697 RVA: 0x00148968 File Offset: 0x00147968
		internal override DateTime eh(LayoutWriter A_0, vi A_1)
		{
			return q7.b(this.ej(A_0, A_1));
		}

		// Token: 0x060021FA RID: 8698 RVA: 0x0014898C File Offset: 0x0014798C
		internal override double ek(LayoutWriter A_0)
		{
			return q7.d(this.ei(A_0));
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001489B0 File Offset: 0x001479B0
		internal override double el(LayoutWriter A_0, vi A_1)
		{
			return q7.d(this.ej(A_0, A_1));
		}

		// Token: 0x060021FC RID: 8700 RVA: 0x001489D4 File Offset: 0x001479D4
		internal override decimal ei(LayoutWriter A_0)
		{
			return q7.e(this.em(A_0));
		}

		// Token: 0x060021FD RID: 8701 RVA: 0x001489F8 File Offset: 0x001479F8
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return q7.e(this.en(A_0, A_1));
		}

		// Token: 0x060021FE RID: 8702 RVA: 0x00148A1C File Offset: 0x00147A1C
		internal override object es(LayoutWriter A_0)
		{
			return this.ei(A_0);
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x00148A3C File Offset: 0x00147A3C
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			return this.ej(A_0, A_1);
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x00148A5C File Offset: 0x00147A5C
		internal override string eo(LayoutWriter A_0)
		{
			return this.ei(A_0).ToString();
		}

		// Token: 0x06002201 RID: 8705 RVA: 0x00148A80 File Offset: 0x00147A80
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			return this.ej(A_0, A_1).ToString();
		}
	}
}
