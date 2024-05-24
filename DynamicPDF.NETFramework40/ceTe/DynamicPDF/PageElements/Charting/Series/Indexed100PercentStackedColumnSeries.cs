using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008B3 RID: 2227
	public class Indexed100PercentStackedColumnSeries : Stacked100PercentColumnSeries
	{
		// Token: 0x06005AEF RID: 23279 RVA: 0x0033E79D File Offset: 0x0033D79D
		public Indexed100PercentStackedColumnSeries() : base(null, null)
		{
		}

		// Token: 0x06005AF0 RID: 23280 RVA: 0x0033E7C0 File Offset: 0x0033D7C0
		public Indexed100PercentStackedColumnSeries(IndexedXAxis indexedXAxis, PercentageYAxis percentageYAxis) : base(indexedXAxis, percentageYAxis)
		{
		}

		// Token: 0x06005AF1 RID: 23281 RVA: 0x0033E7E3 File Offset: 0x0033D7E3
		public Indexed100PercentStackedColumnSeries(IndexedXAxis indexedXAxis, PercentageYAxis percentageYAxis, Legend legend) : base(indexedXAxis, percentageYAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x06005AF2 RID: 23282 RVA: 0x0033E80E File Offset: 0x0033D80E
		public Indexed100PercentStackedColumnSeries(PercentageYAxis percentageYAxis) : base(null, percentageYAxis)
		{
		}

		// Token: 0x1700094D RID: 2381
		public Indexed100PercentStackedColumnSeriesElement this[int index]
		{
			get
			{
				return (Indexed100PercentStackedColumnSeriesElement)base.b(index);
			}
		}

		// Token: 0x1700094E RID: 2382
		// (get) Token: 0x06005AF4 RID: 23284 RVA: 0x0033E854 File Offset: 0x0033D854
		public PercentageYAxis YAxis
		{
			get
			{
				return (PercentageYAxis)base.n();
			}
		}

		// Token: 0x1700094F RID: 2383
		// (get) Token: 0x06005AF5 RID: 23285 RVA: 0x0033E874 File Offset: 0x0033D874
		public IndexedXAxis XAxis
		{
			get
			{
				return (IndexedXAxis)base.m();
			}
		}

		// Token: 0x06005AF6 RID: 23286 RVA: 0x0033E891 File Offset: 0x0033D891
		public void Add(Indexed100PercentStackedColumnSeriesElement indexedStackedColumnSeriesElement)
		{
			base.a(indexedStackedColumnSeriesElement);
		}

		// Token: 0x06005AF7 RID: 23287 RVA: 0x0033E89C File Offset: 0x0033D89C
		internal override float ig()
		{
			return this.b;
		}

		// Token: 0x06005AF8 RID: 23288 RVA: 0x0033E8B4 File Offset: 0x0033D8B4
		internal override void iy(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005AF9 RID: 23289 RVA: 0x0033E8DC File Offset: 0x0033D8DC
		internal override float iz()
		{
			return this.a;
		}

		// Token: 0x06005AFA RID: 23290 RVA: 0x0033E8F4 File Offset: 0x0033D8F4
		internal override void i0(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002F98 RID: 12184
		private new float a = 2.1474836E+09f;

		// Token: 0x04002F99 RID: 12185
		private new float b = -2.1474836E+09f;
	}
}
