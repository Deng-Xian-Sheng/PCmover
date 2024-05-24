using System;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x0200084F RID: 2127
	public class RectangleLaidOutEventArgs : EventArgs
	{
		// Token: 0x0600562A RID: 22058 RVA: 0x00299B76 File Offset: 0x00298B76
		internal RectangleLaidOutEventArgs(LayoutWriter A_0, Rectangle A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000851 RID: 2129
		// (get) Token: 0x0600562B RID: 22059 RVA: 0x00299B90 File Offset: 0x00298B90
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000852 RID: 2130
		// (get) Token: 0x0600562C RID: 22060 RVA: 0x00299BA8 File Offset: 0x00298BA8
		public Rectangle Rectangle
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002DEE RID: 11758
		private LayoutWriter a;

		// Token: 0x04002DEF RID: 11759
		private Rectangle b;
	}
}
