using System;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000853 RID: 2131
	public class SymbolLaidOutEventArgs : EventArgs
	{
		// Token: 0x0600567F RID: 22143 RVA: 0x0029AD56 File Offset: 0x00299D56
		internal SymbolLaidOutEventArgs(LayoutWriter A_0, Label A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000865 RID: 2149
		// (get) Token: 0x06005680 RID: 22144 RVA: 0x0029AD70 File Offset: 0x00299D70
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000866 RID: 2150
		// (get) Token: 0x06005681 RID: 22145 RVA: 0x0029AD88 File Offset: 0x00299D88
		public Label Symbol
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04002E15 RID: 11797
		private LayoutWriter a;

		// Token: 0x04002E16 RID: 11798
		private Label b;
	}
}
