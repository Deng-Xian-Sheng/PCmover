using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020002B1 RID: 689
	internal class r1 : be
	{
		// Token: 0x06001FB1 RID: 8113 RVA: 0x001391D5 File Offset: 0x001381D5
		internal r1(string A_0, string A_1, string A_2, bool A_3) : base(A_0, A_2, A_3)
		{
			this.a = A_1;
		}

		// Token: 0x06001FB2 RID: 8114 RVA: 0x001391F6 File Offset: 0x001381F6
		internal override void n(DocumentWriter A_0)
		{
			base.n(A_0);
			A_0.WriteName(86);
			A_0.WriteText(this.a);
			A_0.WriteDictionaryClose();
		}

		// Token: 0x04000DA8 RID: 3496
		private string a = string.Empty;
	}
}
