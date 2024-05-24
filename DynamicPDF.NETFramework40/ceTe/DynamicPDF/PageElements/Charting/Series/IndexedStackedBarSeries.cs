using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008BD RID: 2237
	public class IndexedStackedBarSeries : StackedBarSeries
	{
		// Token: 0x06005B75 RID: 23413 RVA: 0x0033F731 File Offset: 0x0033E731
		public IndexedStackedBarSeries() : base(null, null)
		{
		}

		// Token: 0x06005B76 RID: 23414 RVA: 0x0033F754 File Offset: 0x0033E754
		public IndexedStackedBarSeries(NumericXAxis numericXAxis, IndexedYAxis indexedYAxis) : base(numericXAxis, indexedYAxis)
		{
		}

		// Token: 0x06005B77 RID: 23415 RVA: 0x0033F777 File Offset: 0x0033E777
		public IndexedStackedBarSeries(NumericXAxis numericXAxis, IndexedYAxis indexedYAxis, Legend legend) : base(numericXAxis, indexedYAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x06005B78 RID: 23416 RVA: 0x0033F7A2 File Offset: 0x0033E7A2
		public IndexedStackedBarSeries(NumericXAxis numericXAxis) : base(numericXAxis, null)
		{
		}

		// Token: 0x17000965 RID: 2405
		public IndexedStackedBarSeriesElement this[int index]
		{
			get
			{
				return (IndexedStackedBarSeriesElement)base.b(index);
			}
		}

		// Token: 0x17000966 RID: 2406
		// (get) Token: 0x06005B7A RID: 23418 RVA: 0x0033F7E8 File Offset: 0x0033E7E8
		public NumericXAxis XAxis
		{
			get
			{
				return (NumericXAxis)base.m();
			}
		}

		// Token: 0x17000967 RID: 2407
		// (get) Token: 0x06005B7B RID: 23419 RVA: 0x0033F808 File Offset: 0x0033E808
		public IndexedYAxis YAxis
		{
			get
			{
				return (IndexedYAxis)base.n();
			}
		}

		// Token: 0x06005B7C RID: 23420 RVA: 0x0033F825 File Offset: 0x0033E825
		public void Add(IndexedStackedBarSeriesElement indexedStackedBarSeriesElement)
		{
			base.a(indexedStackedBarSeriesElement);
		}

		// Token: 0x06005B7D RID: 23421 RVA: 0x0033F830 File Offset: 0x0033E830
		internal override float ig()
		{
			return this.b;
		}

		// Token: 0x06005B7E RID: 23422 RVA: 0x0033F848 File Offset: 0x0033E848
		internal override void iy(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005B7F RID: 23423 RVA: 0x0033F870 File Offset: 0x0033E870
		internal override float iz()
		{
			return this.a;
		}

		// Token: 0x06005B80 RID: 23424 RVA: 0x0033F888 File Offset: 0x0033E888
		internal override void i0(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002FAC RID: 12204
		private new float a = 2.1474836E+09f;

		// Token: 0x04002FAD RID: 12205
		private new float b = -2.1474836E+09f;
	}
}
