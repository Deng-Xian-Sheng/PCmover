using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x02000822 RID: 2082
	public class ReportLayingOutEventArgs : EventArgs
	{
		// Token: 0x06005411 RID: 21521 RVA: 0x00293B04 File Offset: 0x00292B04
		internal ReportLayingOutEventArgs(LayoutWriter A_0, Report A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x170007B3 RID: 1971
		// (get) Token: 0x06005412 RID: 21522 RVA: 0x00293B34 File Offset: 0x00292B34
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170007B4 RID: 1972
		// (get) Token: 0x06005413 RID: 21523 RVA: 0x00293B4C File Offset: 0x00292B4C
		public Report Report
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x170007B5 RID: 1973
		// (get) Token: 0x06005414 RID: 21524 RVA: 0x00293B64 File Offset: 0x00292B64
		// (set) Token: 0x06005415 RID: 21525 RVA: 0x00293B7C File Offset: 0x00292B7C
		public bool Layout
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x04002D08 RID: 11528
		private LayoutWriter a = null;

		// Token: 0x04002D09 RID: 11529
		private Report b = null;

		// Token: 0x04002D0A RID: 11530
		private bool c = true;
	}
}
