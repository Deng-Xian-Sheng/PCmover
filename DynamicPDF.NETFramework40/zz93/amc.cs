using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020005B1 RID: 1457
	internal class amc : al7
	{
		// Token: 0x060039D8 RID: 14808 RVA: 0x001F1FA4 File Offset: 0x001F0FA4
		internal override bool ne(amp A_0, PageWriter A_1)
		{
			return A_1.PageNumber % 2 == 1;
		}

		// Token: 0x060039D9 RID: 14809 RVA: 0x001F1FC4 File Offset: 0x001F0FC4
		internal override bool nf(am1 A_0, PageWriter A_1)
		{
			return A_1.PageNumber % 2 == 1;
		}

		// Token: 0x060039DA RID: 14810 RVA: 0x001F1FE4 File Offset: 0x001F0FE4
		internal override bool ng(amp A_0, DocumentWriter A_1, int A_2)
		{
			return A_2 % 2 == 1;
		}
	}
}
