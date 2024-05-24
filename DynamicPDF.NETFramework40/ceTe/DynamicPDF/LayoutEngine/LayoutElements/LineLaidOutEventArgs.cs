using System;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200095F RID: 2399
	public class LineLaidOutEventArgs : EventArgs
	{
		// Token: 0x0600615B RID: 24923 RVA: 0x0036311C File Offset: 0x0036211C
		internal LineLaidOutEventArgs(LayoutWriter A_0, Line A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x17000A9A RID: 2714
		// (get) Token: 0x0600615C RID: 24924 RVA: 0x00363138 File Offset: 0x00362138
		public LayoutWriter LayoutWriter
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000A9B RID: 2715
		// (get) Token: 0x0600615D RID: 24925 RVA: 0x00363150 File Offset: 0x00362150
		public Line Line
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04003237 RID: 12855
		private LayoutWriter a;

		// Token: 0x04003238 RID: 12856
		private Line b;
	}
}
