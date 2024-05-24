using System;
using ceTe.DynamicPDF.LayoutEngine.Layout;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000965 RID: 2405
	public class RecordBoxLaidOutEventArgs : EventArgs
	{
		// Token: 0x06006170 RID: 24944 RVA: 0x00363200 File Offset: 0x00362200
		internal RecordBoxLaidOutEventArgs(LayoutWriter A_0, LayoutTextArea A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000AA0 RID: 2720
		// (get) Token: 0x06006171 RID: 24945 RVA: 0x0036321C File Offset: 0x0036221C
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000AA1 RID: 2721
		// (get) Token: 0x06006172 RID: 24946 RVA: 0x00363234 File Offset: 0x00362234
		public LayoutTextArea ReportTextArea
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x0400323D RID: 12861
		private LayoutWriter a;

		// Token: 0x0400323E RID: 12862
		private LayoutTextArea b;
	}
}
