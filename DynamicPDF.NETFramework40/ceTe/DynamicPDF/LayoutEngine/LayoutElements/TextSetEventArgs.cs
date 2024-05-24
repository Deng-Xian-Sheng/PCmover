using System;
using ceTe.DynamicPDF.LayoutEngine.Layout;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000955 RID: 2389
	public class TextSetEventArgs : EventArgs
	{
		// Token: 0x06006138 RID: 24888 RVA: 0x00362FBA File Offset: 0x00361FBA
		internal TextSetEventArgs(string A_0, LayoutTextArea A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000A91 RID: 2705
		// (get) Token: 0x06006139 RID: 24889 RVA: 0x00362FD4 File Offset: 0x00361FD4
		public LayoutTextArea LayoutTextArea
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x17000A92 RID: 2706
		// (get) Token: 0x0600613A RID: 24890 RVA: 0x00362FEC File Offset: 0x00361FEC
		public string Text
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x0400322E RID: 12846
		private string a;

		// Token: 0x0400322F RID: 12847
		private LayoutTextArea b;
	}
}
