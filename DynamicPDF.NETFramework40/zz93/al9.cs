using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020005AE RID: 1454
	internal class al9 : al7
	{
		// Token: 0x060039CF RID: 14799 RVA: 0x001F1E90 File Offset: 0x001F0E90
		internal override bool ne(amp A_0, PageWriter A_1)
		{
			return A_1.PageNumber == 1;
		}

		// Token: 0x060039D0 RID: 14800 RVA: 0x001F1EAC File Offset: 0x001F0EAC
		internal override bool ng(amp A_0, DocumentWriter A_1, int A_2)
		{
			return A_2 == 1;
		}
	}
}
