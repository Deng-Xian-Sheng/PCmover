using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008BF RID: 2239
	public class IndexedStackedColumnSeries : StackedColumnSeries
	{
		// Token: 0x06005B8D RID: 23437 RVA: 0x0033F9ED File Offset: 0x0033E9ED
		public IndexedStackedColumnSeries() : base(null, null)
		{
		}

		// Token: 0x06005B8E RID: 23438 RVA: 0x0033FA10 File Offset: 0x0033EA10
		public IndexedStackedColumnSeries(IndexedXAxis indexedXAxis, NumericYAxis numericYAxis) : base(indexedXAxis, numericYAxis)
		{
		}

		// Token: 0x06005B8F RID: 23439 RVA: 0x0033FA33 File Offset: 0x0033EA33
		public IndexedStackedColumnSeries(IndexedXAxis indexedXAxis, NumericYAxis numericYAxis, Legend legend) : base(indexedXAxis, numericYAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x06005B90 RID: 23440 RVA: 0x0033FA5E File Offset: 0x0033EA5E
		public IndexedStackedColumnSeries(NumericYAxis numericYAxis) : base(null, numericYAxis)
		{
		}

		// Token: 0x17000969 RID: 2409
		public IndexedStackedColumnSeriesElement this[int index]
		{
			get
			{
				return (IndexedStackedColumnSeriesElement)base.b(index);
			}
		}

		// Token: 0x1700096A RID: 2410
		// (get) Token: 0x06005B92 RID: 23442 RVA: 0x0033FAA4 File Offset: 0x0033EAA4
		public IndexedXAxis XAxis
		{
			get
			{
				return (IndexedXAxis)base.m();
			}
		}

		// Token: 0x1700096B RID: 2411
		// (get) Token: 0x06005B93 RID: 23443 RVA: 0x0033FAC4 File Offset: 0x0033EAC4
		public NumericYAxis YAxis
		{
			get
			{
				return (NumericYAxis)base.n();
			}
		}

		// Token: 0x06005B94 RID: 23444 RVA: 0x0033FAE1 File Offset: 0x0033EAE1
		public void Add(IndexedStackedColumnSeriesElement indexedStackedColumnSeriesElement)
		{
			base.a(indexedStackedColumnSeriesElement);
		}

		// Token: 0x06005B95 RID: 23445 RVA: 0x0033FAEC File Offset: 0x0033EAEC
		internal override float ig()
		{
			return this.b;
		}

		// Token: 0x06005B96 RID: 23446 RVA: 0x0033FB04 File Offset: 0x0033EB04
		internal override void iy(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005B97 RID: 23447 RVA: 0x0033FB2C File Offset: 0x0033EB2C
		internal override float iz()
		{
			return this.a;
		}

		// Token: 0x06005B98 RID: 23448 RVA: 0x0033FB44 File Offset: 0x0033EB44
		internal override void i0(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002FB0 RID: 12208
		private new float a = 2.1474836E+09f;

		// Token: 0x04002FB1 RID: 12209
		private new float b = -2.1474836E+09f;
	}
}
