using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x0200080B RID: 2059
	public class DocumentLayoutEventArgs : EventArgs
	{
		// Token: 0x06005365 RID: 21349 RVA: 0x00291B6C File Offset: 0x00290B6C
		internal DocumentLayoutEventArgs(LayoutWriter A_0)
		{
			this.a = A_0;
		}

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x06005366 RID: 21350 RVA: 0x00291B88 File Offset: 0x00290B88
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x04002CBA RID: 11450
		private LayoutWriter a = null;
	}
}
