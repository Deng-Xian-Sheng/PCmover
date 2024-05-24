using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.Data
{
	// Token: 0x020007FC RID: 2044
	public class ClosingRecordSetEventArgs : EventArgs
	{
		// Token: 0x06005304 RID: 21252 RVA: 0x0029093C File Offset: 0x0028F93C
		public ClosingRecordSetEventArgs(RecordSet recordSet, LayoutWriter layoutWriter)
		{
			this.b = recordSet;
			this.a = layoutWriter;
		}

		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x06005305 RID: 21253 RVA: 0x00290964 File Offset: 0x0028F964
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x06005306 RID: 21254 RVA: 0x0029097C File Offset: 0x0028F97C
		public RecordSet RecordSet
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x06005307 RID: 21255 RVA: 0x00290994 File Offset: 0x0028F994
		// (set) Token: 0x06005308 RID: 21256 RVA: 0x002909AC File Offset: 0x0028F9AC
		public bool Closed
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x04002C56 RID: 11350
		private LayoutWriter a;

		// Token: 0x04002C57 RID: 11351
		private RecordSet b = null;

		// Token: 0x04002C58 RID: 11352
		private bool c = false;
	}
}
