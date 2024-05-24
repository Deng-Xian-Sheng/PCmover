using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x0200081C RID: 2076
	public class PageLaidOutEventArgs : EventArgs
	{
		// Token: 0x060053F9 RID: 21497 RVA: 0x002939B1 File Offset: 0x002929B1
		internal PageLaidOutEventArgs(LayoutWriter A_0, Page A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x060053FA RID: 21498 RVA: 0x002939D8 File Offset: 0x002929D8
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x060053FB RID: 21499 RVA: 0x002939F0 File Offset: 0x002929F0
		public Page FixedPage
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002D00 RID: 11520
		private LayoutWriter a = null;

		// Token: 0x04002D01 RID: 11521
		private Page b = null;
	}
}
