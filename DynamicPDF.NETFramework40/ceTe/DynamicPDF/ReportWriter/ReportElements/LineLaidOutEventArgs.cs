using System;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x0200083E RID: 2110
	public class LineLaidOutEventArgs : EventArgs
	{
		// Token: 0x06005528 RID: 21800 RVA: 0x00297127 File Offset: 0x00296127
		internal LineLaidOutEventArgs(LayoutWriter A_0, Line A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x170007FB RID: 2043
		// (get) Token: 0x06005529 RID: 21801 RVA: 0x00297140 File Offset: 0x00296140
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170007FC RID: 2044
		// (get) Token: 0x0600552A RID: 21802 RVA: 0x00297158 File Offset: 0x00296158
		public Line Line
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002D85 RID: 11653
		private LayoutWriter a;

		// Token: 0x04002D86 RID: 11654
		private Line b;
	}
}
