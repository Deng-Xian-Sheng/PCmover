using System;
using ceTe.DynamicPDF.ReportWriter.IO;
using ceTe.DynamicPDF.ReportWriter.Layout;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x0200084C RID: 2124
	public class RecordBoxLaidOutEventArgs : EventArgs
	{
		// Token: 0x06005600 RID: 22016 RVA: 0x002995AE File Offset: 0x002985AE
		internal RecordBoxLaidOutEventArgs(LayoutWriter A_0, LayoutTextArea A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000844 RID: 2116
		// (get) Token: 0x06005601 RID: 22017 RVA: 0x002995C8 File Offset: 0x002985C8
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000845 RID: 2117
		// (get) Token: 0x06005602 RID: 22018 RVA: 0x002995E0 File Offset: 0x002985E0
		public LayoutTextArea ReportTextArea
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002DDD RID: 11741
		private LayoutWriter a;

		// Token: 0x04002DDE RID: 11742
		private LayoutTextArea b;
	}
}
