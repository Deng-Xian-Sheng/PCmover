using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.Data
{
	// Token: 0x02000803 RID: 2051
	public class OpeningRecordSetEventArgs : EventArgs
	{
		// Token: 0x0600533E RID: 21310 RVA: 0x002913EA File Offset: 0x002903EA
		public OpeningRecordSetEventArgs(LayoutWriter layoutWriter)
		{
			this.a = layoutWriter;
		}

		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x0600533F RID: 21311 RVA: 0x00291404 File Offset: 0x00290404
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x06005340 RID: 21312 RVA: 0x0029141C File Offset: 0x0029041C
		// (set) Token: 0x06005341 RID: 21313 RVA: 0x00291434 File Offset: 0x00290434
		public RecordSet RecordSet
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

		// Token: 0x04002C6F RID: 11375
		private LayoutWriter a;

		// Token: 0x04002C70 RID: 11376
		private RecordSet b = null;
	}
}
