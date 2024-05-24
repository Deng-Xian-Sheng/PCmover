using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005A9 RID: 1449
	internal class al4 : ahp
	{
		// Token: 0x06003992 RID: 14738 RVA: 0x001EFDDA File Offset: 0x001EEDDA
		internal al4(int A_0, int A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06003993 RID: 14739 RVA: 0x001EFDF3 File Offset: 0x001EEDF3
		internal override void lu(LayoutWriter A_0, alq A_1, char[] A_2)
		{
			A_1.a(A_2, this.a, this.b);
		}

		// Token: 0x06003994 RID: 14740 RVA: 0x001EFE0A File Offset: 0x001EEE0A
		internal override void lv(LayoutWriter A_0, akk A_1, alq A_2, char[] A_3)
		{
			A_2.a(A_3, this.a, this.b);
		}

		// Token: 0x04001B6F RID: 7023
		private int a;

		// Token: 0x04001B70 RID: 7024
		private int b;
	}
}
