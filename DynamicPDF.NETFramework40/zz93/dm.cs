using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200009F RID: 159
	internal class dm : be
	{
		// Token: 0x060007AD RID: 1965 RVA: 0x0006E9A8 File Offset: 0x0006D9A8
		internal dm(string A_0, float A_1, string A_2, bool A_3) : base(A_0, A_2, A_3)
		{
			this.a = A_1;
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x0006E9C9 File Offset: 0x0006D9C9
		internal override void n(DocumentWriter A_0)
		{
			base.n(A_0);
			A_0.WriteName(86);
			A_0.WriteNumber(this.a);
			A_0.WriteDictionaryClose();
		}

		// Token: 0x04000415 RID: 1045
		private float a = 0f;
	}
}
