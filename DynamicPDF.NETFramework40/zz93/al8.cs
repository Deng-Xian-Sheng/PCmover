using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020005AD RID: 1453
	internal class al8 : al7
	{
		// Token: 0x060039CB RID: 14795 RVA: 0x001F1E30 File Offset: 0x001F0E30
		internal override bool ne(amp A_0, PageWriter A_1)
		{
			return A_1.PageNumber % 2 == 0;
		}

		// Token: 0x060039CC RID: 14796 RVA: 0x001F1E50 File Offset: 0x001F0E50
		internal override bool nf(am1 A_0, PageWriter A_1)
		{
			return A_1.PageNumber % 2 == 0;
		}

		// Token: 0x060039CD RID: 14797 RVA: 0x001F1E70 File Offset: 0x001F0E70
		internal override bool ng(amp A_0, DocumentWriter A_1, int A_2)
		{
			return A_2 % 2 == 0;
		}
	}
}
