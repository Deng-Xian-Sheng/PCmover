using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020005DD RID: 1501
	internal class anj : w6
	{
		// Token: 0x06003B6B RID: 15211 RVA: 0x001FC514 File Offset: 0x001FB514
		internal override bool f3(rs A_0, PageWriter A_1)
		{
			return A_1.PageNumber == A_1.DocumentWriter.Document.Pages.Count;
		}

		// Token: 0x06003B6C RID: 15212 RVA: 0x001FC544 File Offset: 0x001FB544
		internal override bool f5(rs A_0, DocumentWriter A_1, int A_2)
		{
			return A_2 == A_1.Document.Pages.Count;
		}
	}
}
