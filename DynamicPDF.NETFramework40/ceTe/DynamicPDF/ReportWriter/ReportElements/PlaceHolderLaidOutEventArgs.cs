using System;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000846 RID: 2118
	public class PlaceHolderLaidOutEventArgs : EventArgs
	{
		// Token: 0x06005582 RID: 21890 RVA: 0x00297D56 File Offset: 0x00296D56
		internal PlaceHolderLaidOutEventArgs(LayoutWriter A_0, ContentArea A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000814 RID: 2068
		// (get) Token: 0x06005583 RID: 21891 RVA: 0x00297D70 File Offset: 0x00296D70
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000815 RID: 2069
		// (get) Token: 0x06005584 RID: 21892 RVA: 0x00297D88 File Offset: 0x00296D88
		public ContentArea ContentArea
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002DA5 RID: 11685
		private LayoutWriter a;

		// Token: 0x04002DA6 RID: 11686
		private ContentArea b;
	}
}
