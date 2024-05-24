using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x02000826 RID: 2086
	public class ReportPageLayingOutEventArgs : EventArgs
	{
		// Token: 0x06005423 RID: 21539 RVA: 0x00293CE7 File Offset: 0x00292CE7
		internal ReportPageLayingOutEventArgs(LayoutWriter A_0)
		{
			this.a = A_0;
		}

		// Token: 0x170007BA RID: 1978
		// (get) Token: 0x06005424 RID: 21540 RVA: 0x00293D00 File Offset: 0x00292D00
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x04002D0F RID: 11535
		private LayoutWriter a = null;
	}
}
