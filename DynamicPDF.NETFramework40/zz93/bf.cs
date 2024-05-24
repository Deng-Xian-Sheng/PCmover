using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000046 RID: 70
	internal class bf : be
	{
		// Token: 0x0600028C RID: 652 RVA: 0x0003DCA0 File Offset: 0x0003CCA0
		internal bf(string A_0, string A_1, bool A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0003DCAE File Offset: 0x0003CCAE
		internal override void n(DocumentWriter A_0)
		{
			base.n(A_0);
			A_0.WriteName(86);
			A_0.ak(32);
			A_0.ap();
			A_0.WriteDictionaryClose();
		}
	}
}
