using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002A2 RID: 674
	internal class rq : q6
	{
		// Token: 0x06001E0E RID: 7694 RVA: 0x00130BFB File Offset: 0x0012FBFB
		internal rq(q7 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001E0F RID: 7695 RVA: 0x00130C14 File Offset: 0x0012FC14
		internal q7 a()
		{
			return this.a;
		}

		// Token: 0x06001E10 RID: 7696 RVA: 0x00130C2C File Offset: 0x0012FC2C
		internal override bool e8()
		{
			return true;
		}

		// Token: 0x06001E11 RID: 7697 RVA: 0x00130C3F File Offset: 0x0012FC3F
		internal override void ec(LayoutWriter A_0, wt A_1, char[] A_2)
		{
			this.a.ec(A_0, A_1, A_2);
		}

		// Token: 0x06001E12 RID: 7698 RVA: 0x00130C51 File Offset: 0x0012FC51
		internal override void ed(LayoutWriter A_0, vi A_1, wt A_2, char[] A_3)
		{
			this.a.ed(A_0, A_1, A_2, A_3);
		}

		// Token: 0x04000D4C RID: 3404
		private q7 a = null;
	}
}
