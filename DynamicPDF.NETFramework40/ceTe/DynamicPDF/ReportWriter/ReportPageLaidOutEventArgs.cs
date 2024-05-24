using System;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x02000824 RID: 2084
	public class ReportPageLaidOutEventArgs : EventArgs
	{
		// Token: 0x0600541A RID: 21530 RVA: 0x00293B86 File Offset: 0x00292B86
		internal ReportPageLaidOutEventArgs(LayoutWriter A_0, xq A_1)
		{
			this.c = A_0;
			this.d = A_1;
		}

		// Token: 0x170007B6 RID: 1974
		// (get) Token: 0x0600541B RID: 21531 RVA: 0x00293BBC File Offset: 0x00292BBC
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x170007B7 RID: 1975
		// (get) Token: 0x0600541C RID: 21532 RVA: 0x00293BD4 File Offset: 0x00292BD4
		public Page Page
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x170007B8 RID: 1976
		// (get) Token: 0x0600541D RID: 21533 RVA: 0x00293BEC File Offset: 0x00292BEC
		public ContentArea Header
		{
			get
			{
				if (this.a == null)
				{
					this.a = new ContentArea(0f, 0f, ((w1)this.c).c().d().Body.Width, ((w1)this.c).c().Header.Height);
				}
				return this.a;
			}
		}

		// Token: 0x170007B9 RID: 1977
		// (get) Token: 0x0600541E RID: 21534 RVA: 0x00293C64 File Offset: 0x00292C64
		public ContentArea Footer
		{
			get
			{
				if (this.b == null)
				{
					this.b = new ContentArea(0f, ((w1)this.c).b(), ((w1)this.c).c().d().Body.Width, ((w1)this.c).c().Footer.Height);
				}
				return this.b;
			}
		}

		// Token: 0x04002D0B RID: 11531
		private ContentArea a = null;

		// Token: 0x04002D0C RID: 11532
		private ContentArea b = null;

		// Token: 0x04002D0D RID: 11533
		private LayoutWriter c = null;

		// Token: 0x04002D0E RID: 11534
		private Page d = null;
	}
}
