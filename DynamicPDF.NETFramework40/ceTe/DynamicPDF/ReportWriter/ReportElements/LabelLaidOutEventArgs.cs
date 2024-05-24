using System;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000839 RID: 2105
	public class LabelLaidOutEventArgs : EventArgs
	{
		// Token: 0x060054FE RID: 21758 RVA: 0x00296BFA File Offset: 0x00295BFA
		internal LabelLaidOutEventArgs(LayoutWriter A_0, Label A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x060054FF RID: 21759 RVA: 0x00296C14 File Offset: 0x00295C14
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x06005500 RID: 21760 RVA: 0x00296C2C File Offset: 0x00295C2C
		public Label Label
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002D76 RID: 11638
		private LayoutWriter a;

		// Token: 0x04002D77 RID: 11639
		private Label b;
	}
}
