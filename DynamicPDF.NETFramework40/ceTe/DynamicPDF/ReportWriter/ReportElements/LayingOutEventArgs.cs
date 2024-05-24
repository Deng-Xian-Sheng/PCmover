using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x0200083B RID: 2107
	public class LayingOutEventArgs : EventArgs
	{
		// Token: 0x06005505 RID: 21765 RVA: 0x00296C44 File Offset: 0x00295C44
		internal LayingOutEventArgs(LayoutWriter A_0)
		{
			this.a = A_0;
		}

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x06005506 RID: 21766 RVA: 0x00296C60 File Offset: 0x00295C60
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x06005507 RID: 21767 RVA: 0x00296C78 File Offset: 0x00295C78
		// (set) Token: 0x06005508 RID: 21768 RVA: 0x00296C90 File Offset: 0x00295C90
		public bool Layout
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x04002D78 RID: 11640
		private LayoutWriter a;

		// Token: 0x04002D79 RID: 11641
		private bool b = true;
	}
}
