using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x0200088A RID: 2186
	public abstract class Stacked100PercentSeriesElement : StackedSeriesElementBase
	{
		// Token: 0x06005918 RID: 22808 RVA: 0x00339734 File Offset: 0x00338734
		internal Stacked100PercentSeriesElement(string A_0, Color A_1, Legend A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x170008F8 RID: 2296
		// (get) Token: 0x06005919 RID: 22809 RVA: 0x00339750 File Offset: 0x00338750
		// (set) Token: 0x0600591A RID: 22810 RVA: 0x00339768 File Offset: 0x00338768
		public string PercentageFormat
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

		// Token: 0x04002F33 RID: 12083
		private new string a = "#.##%";
	}
}
