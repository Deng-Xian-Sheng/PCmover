using System;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000953 RID: 2387
	public class LayingOutEventArgs : EventArgs
	{
		// Token: 0x06006130 RID: 24880 RVA: 0x00362F64 File Offset: 0x00361F64
		internal LayingOutEventArgs(LayoutWriter A_0)
		{
			this.a = A_0;
		}

		// Token: 0x17000A8F RID: 2703
		// (get) Token: 0x06006131 RID: 24881 RVA: 0x00362F80 File Offset: 0x00361F80
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000A90 RID: 2704
		// (get) Token: 0x06006132 RID: 24882 RVA: 0x00362F98 File Offset: 0x00361F98
		// (set) Token: 0x06006133 RID: 24883 RVA: 0x00362FB0 File Offset: 0x00361FB0
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

		// Token: 0x0400322C RID: 12844
		private LayoutWriter a;

		// Token: 0x0400322D RID: 12845
		private bool b = true;
	}
}
