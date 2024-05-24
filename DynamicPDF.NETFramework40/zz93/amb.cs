using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020005B0 RID: 1456
	internal class amb : al7
	{
		// Token: 0x060039D5 RID: 14805 RVA: 0x001F1F2C File Offset: 0x001F0F2C
		internal override bool ne(amp A_0, PageWriter A_1)
		{
			return A_1.PageNumber != 1 && A_1.PageNumber != A_1.DocumentWriter.Document.Pages.Count;
		}

		// Token: 0x060039D6 RID: 14806 RVA: 0x001F1F6C File Offset: 0x001F0F6C
		internal override bool ng(amp A_0, DocumentWriter A_1, int A_2)
		{
			return A_2 != 1 && A_2 != A_1.Document.Pages.Count;
		}
	}
}
