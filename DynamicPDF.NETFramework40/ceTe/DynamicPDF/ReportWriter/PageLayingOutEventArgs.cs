using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x0200081E RID: 2078
	public class PageLayingOutEventArgs : EventArgs
	{
		// Token: 0x06005400 RID: 21504 RVA: 0x00293A08 File Offset: 0x00292A08
		internal PageLayingOutEventArgs(LayoutWriter A_0)
		{
			this.a = A_0;
		}

		// Token: 0x170007AD RID: 1965
		// (get) Token: 0x06005401 RID: 21505 RVA: 0x00293A24 File Offset: 0x00292A24
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170007AE RID: 1966
		// (get) Token: 0x06005402 RID: 21506 RVA: 0x00293A3C File Offset: 0x00292A3C
		// (set) Token: 0x06005403 RID: 21507 RVA: 0x00293A54 File Offset: 0x00292A54
		public bool Layout
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

		// Token: 0x170007AF RID: 1967
		// (get) Token: 0x06005404 RID: 21508 RVA: 0x00293A60 File Offset: 0x00292A60
		public Page Page
		{
			get
			{
				if (this.c == null)
				{
					this.c = new Page();
				}
				return this.c;
			}
		}

		// Token: 0x04002D02 RID: 11522
		private LayoutWriter a;

		// Token: 0x04002D03 RID: 11523
		private bool b = true;

		// Token: 0x04002D04 RID: 11524
		private Page c;
	}
}
