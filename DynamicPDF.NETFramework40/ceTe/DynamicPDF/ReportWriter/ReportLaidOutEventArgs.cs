using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x02000820 RID: 2080
	public class ReportLaidOutEventArgs : EventArgs
	{
		// Token: 0x06005409 RID: 21513 RVA: 0x00293A93 File Offset: 0x00292A93
		internal ReportLaidOutEventArgs(LayoutWriter A_0, int A_1, int A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x170007B0 RID: 1968
		// (get) Token: 0x0600540A RID: 21514 RVA: 0x00293ABC File Offset: 0x00292ABC
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170007B1 RID: 1969
		// (get) Token: 0x0600540B RID: 21515 RVA: 0x00293AD4 File Offset: 0x00292AD4
		public int StartPageNumber
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x170007B2 RID: 1970
		// (get) Token: 0x0600540C RID: 21516 RVA: 0x00293AEC File Offset: 0x00292AEC
		public int PageCount
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x04002D05 RID: 11525
		private LayoutWriter a = null;

		// Token: 0x04002D06 RID: 11526
		private int b;

		// Token: 0x04002D07 RID: 11527
		private int c;
	}
}
