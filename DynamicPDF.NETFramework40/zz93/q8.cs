using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200028F RID: 655
	internal abstract class q8 : q7
	{
		// Token: 0x06001D61 RID: 7521 RVA: 0x0012B88C File Offset: 0x0012A88C
		internal override bool ee(LayoutWriter A_0)
		{
			return q7.a(this.es(A_0));
		}

		// Token: 0x06001D62 RID: 7522 RVA: 0x0012B8AC File Offset: 0x0012A8AC
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			return q7.a(this.et(A_0, A_1));
		}

		// Token: 0x06001D63 RID: 7523 RVA: 0x0012B8CC File Offset: 0x0012A8CC
		internal override DateTime eg(LayoutWriter A_0)
		{
			return q7.b(this.es(A_0));
		}

		// Token: 0x06001D64 RID: 7524 RVA: 0x0012B8EC File Offset: 0x0012A8EC
		internal override DateTime eh(LayoutWriter A_0, vi A_1)
		{
			return q7.b(this.et(A_0, A_1));
		}

		// Token: 0x06001D65 RID: 7525 RVA: 0x0012B90C File Offset: 0x0012A90C
		internal override decimal ei(LayoutWriter A_0)
		{
			return q7.e(this.es(A_0));
		}

		// Token: 0x06001D66 RID: 7526 RVA: 0x0012B92C File Offset: 0x0012A92C
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return q7.e(this.et(A_0, A_1));
		}

		// Token: 0x06001D67 RID: 7527 RVA: 0x0012B94C File Offset: 0x0012A94C
		internal override double ek(LayoutWriter A_0)
		{
			return q7.d(this.es(A_0));
		}

		// Token: 0x06001D68 RID: 7528 RVA: 0x0012B96C File Offset: 0x0012A96C
		internal override double el(LayoutWriter A_0, vi A_1)
		{
			return q7.d(this.et(A_0, A_1));
		}

		// Token: 0x06001D69 RID: 7529 RVA: 0x0012B98C File Offset: 0x0012A98C
		internal override int em(LayoutWriter A_0)
		{
			return q7.c(this.es(A_0));
		}

		// Token: 0x06001D6A RID: 7530 RVA: 0x0012B9AC File Offset: 0x0012A9AC
		internal override int en(LayoutWriter A_0, vi A_1)
		{
			return q7.c(this.et(A_0, A_1));
		}

		// Token: 0x06001D6B RID: 7531 RVA: 0x0012B9CC File Offset: 0x0012A9CC
		internal override string eo(LayoutWriter A_0)
		{
			object obj = this.es(A_0);
			string result;
			if (obj != null)
			{
				result = obj.ToString();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06001D6C RID: 7532 RVA: 0x0012B9F8 File Offset: 0x0012A9F8
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			object obj = this.et(A_0, A_1);
			string result;
			if (obj != null)
			{
				result = obj.ToString();
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
