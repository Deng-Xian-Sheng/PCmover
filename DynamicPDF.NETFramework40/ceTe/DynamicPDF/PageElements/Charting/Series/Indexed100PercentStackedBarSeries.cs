using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008B1 RID: 2225
	public class Indexed100PercentStackedBarSeries : Stacked100PercentBarSeries
	{
		// Token: 0x06005AD7 RID: 23255 RVA: 0x0033E4E1 File Offset: 0x0033D4E1
		public Indexed100PercentStackedBarSeries() : base(null, null)
		{
		}

		// Token: 0x06005AD8 RID: 23256 RVA: 0x0033E504 File Offset: 0x0033D504
		public Indexed100PercentStackedBarSeries(PercentageXAxis percentageXAxis, IndexedYAxis indexedYAxis) : base(percentageXAxis, indexedYAxis)
		{
		}

		// Token: 0x06005AD9 RID: 23257 RVA: 0x0033E527 File Offset: 0x0033D527
		public Indexed100PercentStackedBarSeries(PercentageXAxis percentageXAxis, IndexedYAxis indexedYAxis, Legend legend) : base(percentageXAxis, indexedYAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x06005ADA RID: 23258 RVA: 0x0033E552 File Offset: 0x0033D552
		public Indexed100PercentStackedBarSeries(PercentageXAxis percentageXAxis) : base(percentageXAxis, null)
		{
		}

		// Token: 0x17000949 RID: 2377
		public Indexed100PercentStackedBarSeriesElement this[int index]
		{
			get
			{
				return (Indexed100PercentStackedBarSeriesElement)base.b(index);
			}
		}

		// Token: 0x1700094A RID: 2378
		// (get) Token: 0x06005ADC RID: 23260 RVA: 0x0033E598 File Offset: 0x0033D598
		public PercentageXAxis XAxis
		{
			get
			{
				return (PercentageXAxis)base.m();
			}
		}

		// Token: 0x1700094B RID: 2379
		// (get) Token: 0x06005ADD RID: 23261 RVA: 0x0033E5B8 File Offset: 0x0033D5B8
		public IndexedYAxis YAxis
		{
			get
			{
				return (IndexedYAxis)base.n();
			}
		}

		// Token: 0x06005ADE RID: 23262 RVA: 0x0033E5D5 File Offset: 0x0033D5D5
		public void Add(Indexed100PercentStackedBarSeriesElement indexedStackedBarSeriesElement)
		{
			base.a(indexedStackedBarSeriesElement);
		}

		// Token: 0x06005ADF RID: 23263 RVA: 0x0033E5E0 File Offset: 0x0033D5E0
		internal override float ig()
		{
			return this.b;
		}

		// Token: 0x06005AE0 RID: 23264 RVA: 0x0033E5F8 File Offset: 0x0033D5F8
		internal override void iy(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005AE1 RID: 23265 RVA: 0x0033E620 File Offset: 0x0033D620
		internal override float iz()
		{
			return this.a;
		}

		// Token: 0x06005AE2 RID: 23266 RVA: 0x0033E638 File Offset: 0x0033D638
		internal override void i0(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002F94 RID: 12180
		private new float a = 2.1474836E+09f;

		// Token: 0x04002F95 RID: 12181
		private new float b = -2.1474836E+09f;
	}
}
