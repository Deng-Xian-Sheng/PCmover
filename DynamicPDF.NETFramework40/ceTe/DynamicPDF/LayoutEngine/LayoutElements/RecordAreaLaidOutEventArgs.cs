using System;
using ceTe.DynamicPDF.LayoutEngine.Layout;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000963 RID: 2403
	public class RecordAreaLaidOutEventArgs : EventArgs
	{
		// Token: 0x06006169 RID: 24937 RVA: 0x003631B4 File Offset: 0x003621B4
		internal RecordAreaLaidOutEventArgs(LayoutWriter A_0, LayoutTextArea A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000A9E RID: 2718
		// (get) Token: 0x0600616A RID: 24938 RVA: 0x003631D0 File Offset: 0x003621D0
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000A9F RID: 2719
		// (get) Token: 0x0600616B RID: 24939 RVA: 0x003631E8 File Offset: 0x003621E8
		public LayoutTextArea ReportTextArea
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x0400323B RID: 12859
		private LayoutWriter a;

		// Token: 0x0400323C RID: 12860
		private LayoutTextArea b;
	}
}
