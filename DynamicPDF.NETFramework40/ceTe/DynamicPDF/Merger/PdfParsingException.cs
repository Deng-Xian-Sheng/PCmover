using System;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006EB RID: 1771
	public class PdfParsingException : Exception
	{
		// Token: 0x06004455 RID: 17493 RVA: 0x0023393A File Offset: 0x0023293A
		internal PdfParsingException(string A_0) : base(A_0)
		{
		}

		// Token: 0x06004456 RID: 17494 RVA: 0x00233946 File Offset: 0x00232946
		internal PdfParsingException(string A_0, Exception A_1) : base(A_0, A_1)
		{
		}
	}
}
