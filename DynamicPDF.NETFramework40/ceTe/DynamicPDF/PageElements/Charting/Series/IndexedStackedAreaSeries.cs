using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008BB RID: 2235
	public class IndexedStackedAreaSeries : StackedAreaSeries
	{
		// Token: 0x06005B5F RID: 23391 RVA: 0x0033F4A9 File Offset: 0x0033E4A9
		public IndexedStackedAreaSeries() : base(null, null)
		{
		}

		// Token: 0x06005B60 RID: 23392 RVA: 0x0033F4CC File Offset: 0x0033E4CC
		public IndexedStackedAreaSeries(NumericYAxis yAxis) : base(null, yAxis)
		{
		}

		// Token: 0x06005B61 RID: 23393 RVA: 0x0033F4EF File Offset: 0x0033E4EF
		public IndexedStackedAreaSeries(IndexedXAxis xAxis, NumericYAxis yAxis) : base(xAxis, yAxis)
		{
		}

		// Token: 0x06005B62 RID: 23394 RVA: 0x0033F512 File Offset: 0x0033E512
		public IndexedStackedAreaSeries(IndexedXAxis xAxis, NumericYAxis yAxis, Legend legend) : base(xAxis, yAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x17000961 RID: 2401
		public IndexedStackedAreaSeriesElement this[int index]
		{
			get
			{
				return (IndexedStackedAreaSeriesElement)base.b(index);
			}
		}

		// Token: 0x17000962 RID: 2402
		// (get) Token: 0x06005B64 RID: 23396 RVA: 0x0033F560 File Offset: 0x0033E560
		public IndexedXAxis XAxis
		{
			get
			{
				return (IndexedXAxis)base.m();
			}
		}

		// Token: 0x17000963 RID: 2403
		// (get) Token: 0x06005B65 RID: 23397 RVA: 0x0033F580 File Offset: 0x0033E580
		public NumericYAxis YAxis
		{
			get
			{
				return (NumericYAxis)base.n();
			}
		}

		// Token: 0x06005B66 RID: 23398 RVA: 0x0033F59D File Offset: 0x0033E59D
		public void Add(IndexedStackedAreaSeriesElement element)
		{
			base.a(element);
		}

		// Token: 0x06005B67 RID: 23399 RVA: 0x0033F5A8 File Offset: 0x0033E5A8
		internal override float ig()
		{
			return this.b;
		}

		// Token: 0x06005B68 RID: 23400 RVA: 0x0033F5C0 File Offset: 0x0033E5C0
		internal override void iy(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005B69 RID: 23401 RVA: 0x0033F5E8 File Offset: 0x0033E5E8
		internal override float iz()
		{
			return this.a;
		}

		// Token: 0x06005B6A RID: 23402 RVA: 0x0033F600 File Offset: 0x0033E600
		internal override void i0(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002FA8 RID: 12200
		private new float a = 2.1474836E+09f;

		// Token: 0x04002FA9 RID: 12201
		private new float b = -2.1474836E+09f;
	}
}
