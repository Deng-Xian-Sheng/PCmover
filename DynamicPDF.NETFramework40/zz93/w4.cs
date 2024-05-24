using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000371 RID: 881
	internal class w4 : q6
	{
		// Token: 0x06002588 RID: 9608 RVA: 0x0015F6CC File Offset: 0x0015E6CC
		internal w4(int A_0, int A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06002589 RID: 9609 RVA: 0x0015F6E5 File Offset: 0x0015E6E5
		internal override void ec(LayoutWriter A_0, wt A_1, char[] A_2)
		{
			A_1.a(A_2, this.a, this.b);
		}

		// Token: 0x0600258A RID: 9610 RVA: 0x0015F6FC File Offset: 0x0015E6FC
		internal override void ed(LayoutWriter A_0, vi A_1, wt A_2, char[] A_3)
		{
			A_2.a(A_3, this.a, this.b);
		}

		// Token: 0x04001089 RID: 4233
		private int a;

		// Token: 0x0400108A RID: 4234
		private int b;
	}
}
