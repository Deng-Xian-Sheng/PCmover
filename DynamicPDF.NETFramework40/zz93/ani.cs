using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020005DC RID: 1500
	internal class ani : w6
	{
		// Token: 0x06003B68 RID: 15208 RVA: 0x001FC4D8 File Offset: 0x001FB4D8
		internal override bool f3(rs A_0, PageWriter A_1)
		{
			return A_1.PageNumber == 1;
		}

		// Token: 0x06003B69 RID: 15209 RVA: 0x001FC4F4 File Offset: 0x001FB4F4
		internal override bool f5(rs A_0, DocumentWriter A_1, int A_2)
		{
			return A_2 == 1;
		}
	}
}
