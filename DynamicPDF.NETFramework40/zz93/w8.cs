using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000375 RID: 885
	internal class w8 : w6
	{
		// Token: 0x060025C1 RID: 9665 RVA: 0x001617E0 File Offset: 0x001607E0
		internal override bool f3(rs A_0, PageWriter A_1)
		{
			return A_1.PageNumber % 2 == 1;
		}

		// Token: 0x060025C2 RID: 9666 RVA: 0x00161800 File Offset: 0x00160800
		internal override bool f4(xs A_0, PageWriter A_1)
		{
			return A_1.PageNumber % 2 == 1;
		}

		// Token: 0x060025C3 RID: 9667 RVA: 0x00161820 File Offset: 0x00160820
		internal override bool f5(rs A_0, DocumentWriter A_1, int A_2)
		{
			return A_2 % 2 == 1;
		}
	}
}
