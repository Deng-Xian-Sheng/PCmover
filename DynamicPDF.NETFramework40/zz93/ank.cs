using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020005DE RID: 1502
	internal class ank : w6
	{
		// Token: 0x06003B6E RID: 15214 RVA: 0x001FC574 File Offset: 0x001FB574
		internal override bool f3(rs A_0, PageWriter A_1)
		{
			return A_1.PageNumber != 1 && A_1.PageNumber != A_1.DocumentWriter.Document.Pages.Count;
		}

		// Token: 0x06003B6F RID: 15215 RVA: 0x001FC5B4 File Offset: 0x001FB5B4
		internal override bool f5(rs A_0, DocumentWriter A_1, int A_2)
		{
			return A_2 != 1 && A_2 != A_1.Document.Pages.Count;
		}
	}
}
