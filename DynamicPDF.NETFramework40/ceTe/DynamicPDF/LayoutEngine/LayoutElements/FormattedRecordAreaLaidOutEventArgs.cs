using System;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000959 RID: 2393
	public class FormattedRecordAreaLaidOutEventArgs : EventArgs
	{
		// Token: 0x06006146 RID: 24902 RVA: 0x0036303A File Offset: 0x0036203A
		internal FormattedRecordAreaLaidOutEventArgs(LayoutWriter A_0, FormattedTextArea A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000A94 RID: 2708
		// (get) Token: 0x06006147 RID: 24903 RVA: 0x00363054 File Offset: 0x00362054
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000A95 RID: 2709
		// (get) Token: 0x06006148 RID: 24904 RVA: 0x0036306C File Offset: 0x0036206C
		public FormattedTextArea FormattedTextArea
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04003231 RID: 12849
		private LayoutWriter a;

		// Token: 0x04003232 RID: 12850
		private FormattedTextArea b;
	}
}
