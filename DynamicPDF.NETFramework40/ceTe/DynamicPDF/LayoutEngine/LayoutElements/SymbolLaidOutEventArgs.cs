using System;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000969 RID: 2409
	public class SymbolLaidOutEventArgs : EventArgs
	{
		// Token: 0x0600617E RID: 24958 RVA: 0x00363298 File Offset: 0x00362298
		internal SymbolLaidOutEventArgs(LayoutWriter A_0, Label A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000AA4 RID: 2724
		// (get) Token: 0x0600617F RID: 24959 RVA: 0x003632B4 File Offset: 0x003622B4
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000AA5 RID: 2725
		// (get) Token: 0x06006180 RID: 24960 RVA: 0x003632CC File Offset: 0x003622CC
		public Label Symbol
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04003241 RID: 12865
		private LayoutWriter a;

		// Token: 0x04003242 RID: 12866
		private Label b;
	}
}
