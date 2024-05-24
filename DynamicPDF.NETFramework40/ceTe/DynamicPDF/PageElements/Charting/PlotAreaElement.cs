using System;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007A0 RID: 1952
	public abstract class PlotAreaElement
	{
		// Token: 0x1700063A RID: 1594
		// (get) Token: 0x06004E9C RID: 20124 RVA: 0x0027664C File Offset: 0x0027564C
		// (set) Token: 0x06004E9D RID: 20125 RVA: 0x00276664 File Offset: 0x00275664
		public Legend Legend
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x06004E9E RID: 20126 RVA: 0x00276670 File Offset: 0x00275670
		public PlotArea PlotArea
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x06004E9F RID: 20127 RVA: 0x00276688 File Offset: 0x00275688
		internal void a(PlotArea A_0)
		{
			this.b = A_0;
		}

		// Token: 0x04002A8A RID: 10890
		private Legend a;

		// Token: 0x04002A8B RID: 10891
		private PlotArea b;
	}
}
