using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000374 RID: 884
	internal class w7 : w6
	{
		// Token: 0x060025BD RID: 9661 RVA: 0x00161780 File Offset: 0x00160780
		internal override bool f3(rs A_0, PageWriter A_1)
		{
			return A_1.PageNumber % 2 == 0;
		}

		// Token: 0x060025BE RID: 9662 RVA: 0x001617A0 File Offset: 0x001607A0
		internal override bool f4(xs A_0, PageWriter A_1)
		{
			return A_1.PageNumber % 2 == 0;
		}

		// Token: 0x060025BF RID: 9663 RVA: 0x001617C0 File Offset: 0x001607C0
		internal override bool f5(rs A_0, DocumentWriter A_1, int A_2)
		{
			return A_2 % 2 == 0;
		}
	}
}
