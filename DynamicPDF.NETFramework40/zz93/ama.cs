using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020005AF RID: 1455
	internal class ama : al7
	{
		// Token: 0x060039D2 RID: 14802 RVA: 0x001F1ECC File Offset: 0x001F0ECC
		internal override bool ne(amp A_0, PageWriter A_1)
		{
			return A_1.PageNumber == A_1.DocumentWriter.Document.Pages.Count;
		}

		// Token: 0x060039D3 RID: 14803 RVA: 0x001F1EFC File Offset: 0x001F0EFC
		internal override bool ng(amp A_0, DocumentWriter A_1, int A_2)
		{
			return A_2 == A_1.Document.Pages.Count;
		}
	}
}
