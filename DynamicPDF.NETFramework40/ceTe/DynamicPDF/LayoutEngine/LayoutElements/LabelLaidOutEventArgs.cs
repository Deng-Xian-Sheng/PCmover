using System;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200095D RID: 2397
	public class LabelLaidOutEventArgs : EventArgs
	{
		// Token: 0x06006154 RID: 24916 RVA: 0x003630D0 File Offset: 0x003620D0
		internal LabelLaidOutEventArgs(LayoutWriter A_0, Label A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000A98 RID: 2712
		// (get) Token: 0x06006155 RID: 24917 RVA: 0x003630EC File Offset: 0x003620EC
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000A99 RID: 2713
		// (get) Token: 0x06006156 RID: 24918 RVA: 0x00363104 File Offset: 0x00362104
		public Label Label
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04003235 RID: 12853
		private LayoutWriter a;

		// Token: 0x04003236 RID: 12854
		private Label b;
	}
}
