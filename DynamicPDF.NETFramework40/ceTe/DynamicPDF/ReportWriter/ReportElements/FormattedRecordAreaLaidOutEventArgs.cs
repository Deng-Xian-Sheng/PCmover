using System;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000833 RID: 2099
	public class FormattedRecordAreaLaidOutEventArgs : EventArgs
	{
		// Token: 0x060054B5 RID: 21685 RVA: 0x00296242 File Offset: 0x00295242
		internal FormattedRecordAreaLaidOutEventArgs(LayoutWriter A_0, FormattedTextArea A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x060054B6 RID: 21686 RVA: 0x0029625C File Offset: 0x0029525C
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x060054B7 RID: 21687 RVA: 0x00296274 File Offset: 0x00295274
		public FormattedTextArea FormattedTextArea
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002D59 RID: 11609
		private LayoutWriter a;

		// Token: 0x04002D5A RID: 11610
		private FormattedTextArea b;
	}
}
