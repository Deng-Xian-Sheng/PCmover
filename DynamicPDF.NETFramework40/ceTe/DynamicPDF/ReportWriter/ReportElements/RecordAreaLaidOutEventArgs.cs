using System;
using ceTe.DynamicPDF.ReportWriter.IO;
using ceTe.DynamicPDF.ReportWriter.Layout;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000849 RID: 2121
	public class RecordAreaLaidOutEventArgs : EventArgs
	{
		// Token: 0x060055BF RID: 21951 RVA: 0x002988EE File Offset: 0x002978EE
		internal RecordAreaLaidOutEventArgs(LayoutWriter A_0, LayoutTextArea A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x1700082B RID: 2091
		// (get) Token: 0x060055C0 RID: 21952 RVA: 0x00298908 File Offset: 0x00297908
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x1700082C RID: 2092
		// (get) Token: 0x060055C1 RID: 21953 RVA: 0x00298920 File Offset: 0x00297920
		public LayoutTextArea ReportTextArea
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002DC0 RID: 11712
		private LayoutWriter a;

		// Token: 0x04002DC1 RID: 11713
		private LayoutTextArea b;
	}
}
