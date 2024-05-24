using System;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000961 RID: 2401
	public class PageNumberingLabelLaidOutEventArgs : EventArgs
	{
		// Token: 0x06006162 RID: 24930 RVA: 0x00363168 File Offset: 0x00362168
		internal PageNumberingLabelLaidOutEventArgs(LayoutWriter A_0, PageNumberingLabel A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000A9C RID: 2716
		// (get) Token: 0x06006163 RID: 24931 RVA: 0x00363184 File Offset: 0x00362184
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000A9D RID: 2717
		// (get) Token: 0x06006164 RID: 24932 RVA: 0x0036319C File Offset: 0x0036219C
		public PageNumberingLabel PageNumberingLabel
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04003239 RID: 12857
		private LayoutWriter a;

		// Token: 0x0400323A RID: 12858
		private PageNumberingLabel b;
	}
}
