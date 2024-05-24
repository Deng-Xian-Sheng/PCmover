using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008C1 RID: 2241
	public class IndexedStackedLineSeries : StackedLineSeries
	{
		// Token: 0x06005BA5 RID: 23461 RVA: 0x0033FCA9 File Offset: 0x0033ECA9
		public IndexedStackedLineSeries() : base(null, null)
		{
		}

		// Token: 0x06005BA6 RID: 23462 RVA: 0x0033FCCC File Offset: 0x0033ECCC
		public IndexedStackedLineSeries(NumericYAxis yAxis) : base(null, yAxis)
		{
		}

		// Token: 0x06005BA7 RID: 23463 RVA: 0x0033FCEF File Offset: 0x0033ECEF
		public IndexedStackedLineSeries(IndexedXAxis xAxis, NumericYAxis yAxis) : base(xAxis, yAxis)
		{
		}

		// Token: 0x06005BA8 RID: 23464 RVA: 0x0033FD12 File Offset: 0x0033ED12
		public IndexedStackedLineSeries(IndexedXAxis xAxis, NumericYAxis yAxis, Legend legend) : base(xAxis, yAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x1700096D RID: 2413
		public IndexedStackedLineSeriesElement this[int index]
		{
			get
			{
				return (IndexedStackedLineSeriesElement)base.b(index);
			}
		}

		// Token: 0x1700096E RID: 2414
		// (get) Token: 0x06005BAA RID: 23466 RVA: 0x0033FD60 File Offset: 0x0033ED60
		public IndexedXAxis XAxis
		{
			get
			{
				return (IndexedXAxis)base.m();
			}
		}

		// Token: 0x1700096F RID: 2415
		// (get) Token: 0x06005BAB RID: 23467 RVA: 0x0033FD80 File Offset: 0x0033ED80
		public NumericYAxis YAxis
		{
			get
			{
				return (NumericYAxis)base.n();
			}
		}

		// Token: 0x06005BAC RID: 23468 RVA: 0x0033FD9D File Offset: 0x0033ED9D
		public void Add(IndexedStackedLineSeriesElement element)
		{
			base.a(element);
		}

		// Token: 0x06005BAD RID: 23469 RVA: 0x0033FDA8 File Offset: 0x0033EDA8
		internal override float ig()
		{
			return this.b;
		}

		// Token: 0x06005BAE RID: 23470 RVA: 0x0033FDC0 File Offset: 0x0033EDC0
		internal override void iy(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005BAF RID: 23471 RVA: 0x0033FDE8 File Offset: 0x0033EDE8
		internal override float iz()
		{
			return this.a;
		}

		// Token: 0x06005BB0 RID: 23472 RVA: 0x0033FE00 File Offset: 0x0033EE00
		internal override void i0(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002FB4 RID: 12212
		private new float a = 2.1474836E+09f;

		// Token: 0x04002FB5 RID: 12213
		private new float b = -2.1474836E+09f;
	}
}
