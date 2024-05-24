using System;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000836 RID: 2102
	public class ImageLaidOutEventArgs : EventArgs
	{
		// Token: 0x060054D4 RID: 21716 RVA: 0x00296693 File Offset: 0x00295693
		internal ImageLaidOutEventArgs(LayoutWriter A_0, Image A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x060054D5 RID: 21717 RVA: 0x002966AC File Offset: 0x002956AC
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170007E2 RID: 2018
		// (get) Token: 0x060054D6 RID: 21718 RVA: 0x002966C4 File Offset: 0x002956C4
		public Image Image
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002D65 RID: 11621
		private LayoutWriter a;

		// Token: 0x04002D66 RID: 11622
		private Image b;
	}
}
