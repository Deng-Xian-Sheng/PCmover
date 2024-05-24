using System;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000843 RID: 2115
	public class PageNumberingLabelLaidOutEventArgs : EventArgs
	{
		// Token: 0x06005568 RID: 21864 RVA: 0x002979B6 File Offset: 0x002969B6
		internal PageNumberingLabelLaidOutEventArgs(LayoutWriter A_0, PageNumberingLabel A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x1700080E RID: 2062
		// (get) Token: 0x06005569 RID: 21865 RVA: 0x002979D0 File Offset: 0x002969D0
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x1700080F RID: 2063
		// (get) Token: 0x0600556A RID: 21866 RVA: 0x002979E8 File Offset: 0x002969E8
		public PageNumberingLabel PageNumberingLabel
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002D9C RID: 11676
		private LayoutWriter a;

		// Token: 0x04002D9D RID: 11677
		private PageNumberingLabel b;
	}
}
