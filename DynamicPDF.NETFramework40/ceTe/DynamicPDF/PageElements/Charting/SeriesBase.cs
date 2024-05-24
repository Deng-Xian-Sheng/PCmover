using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007A1 RID: 1953
	public abstract class SeriesBase : PlotAreaElement
	{
		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x06004EA1 RID: 20129 RVA: 0x0027669C File Offset: 0x0027569C
		// (set) Token: 0x06004EA2 RID: 20130 RVA: 0x002766B4 File Offset: 0x002756B4
		public bool DrawBehindAxis
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

		// Token: 0x06004EA3 RID: 20131
		internal abstract void ic(PageWriter A_0);

		// Token: 0x06004EA4 RID: 20132
		internal abstract void ib(PageWriter A_0);

		// Token: 0x04002A8C RID: 10892
		private new bool a = true;
	}
}
