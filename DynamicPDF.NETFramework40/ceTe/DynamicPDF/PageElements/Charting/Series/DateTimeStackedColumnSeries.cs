using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008A8 RID: 2216
	public class DateTimeStackedColumnSeries : StackedColumnSeries
	{
		// Token: 0x06005A6A RID: 23146 RVA: 0x0033D3F2 File Offset: 0x0033C3F2
		public DateTimeStackedColumnSeries() : base(null, null)
		{
		}

		// Token: 0x06005A6B RID: 23147 RVA: 0x0033D415 File Offset: 0x0033C415
		public DateTimeStackedColumnSeries(DateTimeXAxis dateTimeXAxis, NumericYAxis numericYAxis) : base(dateTimeXAxis, numericYAxis)
		{
		}

		// Token: 0x06005A6C RID: 23148 RVA: 0x0033D438 File Offset: 0x0033C438
		public DateTimeStackedColumnSeries(DateTimeXAxis dateTimeXAxis, NumericYAxis numericYAxis, Legend legend) : base(dateTimeXAxis, numericYAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x06005A6D RID: 23149 RVA: 0x0033D463 File Offset: 0x0033C463
		public DateTimeStackedColumnSeries(NumericYAxis numericYAxis) : base(null, numericYAxis)
		{
		}

		// Token: 0x17000934 RID: 2356
		public DateTimeStackedColumnSeriesElement this[int index]
		{
			get
			{
				return (DateTimeStackedColumnSeriesElement)base.b(index);
			}
		}

		// Token: 0x17000935 RID: 2357
		// (get) Token: 0x06005A6F RID: 23151 RVA: 0x0033D4A8 File Offset: 0x0033C4A8
		public NumericYAxis YAxis
		{
			get
			{
				return (NumericYAxis)base.n();
			}
		}

		// Token: 0x17000936 RID: 2358
		// (get) Token: 0x06005A70 RID: 23152 RVA: 0x0033D4C8 File Offset: 0x0033C4C8
		public DateTimeXAxis XAxis
		{
			get
			{
				return (DateTimeXAxis)base.m();
			}
		}

		// Token: 0x06005A71 RID: 23153 RVA: 0x0033D4E5 File Offset: 0x0033C4E5
		public void Add(DateTimeStackedColumnSeriesElement dateTimeStackedColumnSeriesElement)
		{
			base.a(dateTimeStackedColumnSeriesElement);
		}

		// Token: 0x06005A72 RID: 23154 RVA: 0x0033D4F0 File Offset: 0x0033C4F0
		internal override DateTime ih()
		{
			return this.b;
		}

		// Token: 0x06005A73 RID: 23155 RVA: 0x0033D508 File Offset: 0x0033C508
		internal override void ii(DateTime A_0)
		{
			if (this.b == DateTime.MinValue)
			{
				this.b = A_0;
			}
			else if (A_0.CompareTo(this.b) > 0)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005A74 RID: 23156 RVA: 0x0033D554 File Offset: 0x0033C554
		internal override DateTime ij()
		{
			return this.a;
		}

		// Token: 0x06005A75 RID: 23157 RVA: 0x0033D56C File Offset: 0x0033C56C
		internal override void ik(DateTime A_0)
		{
			if (this.a == DateTime.MinValue)
			{
				this.a = A_0;
			}
			else if (A_0.CompareTo(this.a) < 0)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002F7B RID: 12155
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F7C RID: 12156
		private new DateTime b = DateTime.MinValue;
	}
}
