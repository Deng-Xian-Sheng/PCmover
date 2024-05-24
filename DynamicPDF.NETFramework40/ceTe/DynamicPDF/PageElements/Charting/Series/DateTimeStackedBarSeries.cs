using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008A4 RID: 2212
	public class DateTimeStackedBarSeries : StackedBarSeries
	{
		// Token: 0x06005A40 RID: 23104 RVA: 0x0033CCF6 File Offset: 0x0033BCF6
		public DateTimeStackedBarSeries() : base(null, null)
		{
		}

		// Token: 0x06005A41 RID: 23105 RVA: 0x0033CD19 File Offset: 0x0033BD19
		public DateTimeStackedBarSeries(NumericXAxis numericXAxis, DateTimeYAxis dateTimeYAxis) : base(numericXAxis, dateTimeYAxis)
		{
		}

		// Token: 0x06005A42 RID: 23106 RVA: 0x0033CD3C File Offset: 0x0033BD3C
		public DateTimeStackedBarSeries(NumericXAxis numericXAxis, DateTimeYAxis dateTimeYAxis, Legend legend) : base(numericXAxis, dateTimeYAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x1700092D RID: 2349
		public DateTimeStackedBarSeriesElement this[int index]
		{
			get
			{
				return (DateTimeStackedBarSeriesElement)base.b(index);
			}
		}

		// Token: 0x1700092E RID: 2350
		// (get) Token: 0x06005A44 RID: 23108 RVA: 0x0033CD88 File Offset: 0x0033BD88
		public NumericXAxis XAxis
		{
			get
			{
				return (NumericXAxis)base.m();
			}
		}

		// Token: 0x1700092F RID: 2351
		// (get) Token: 0x06005A45 RID: 23109 RVA: 0x0033CDA8 File Offset: 0x0033BDA8
		public DateTimeYAxis YAxis
		{
			get
			{
				return (DateTimeYAxis)base.n();
			}
		}

		// Token: 0x06005A46 RID: 23110 RVA: 0x0033CDC5 File Offset: 0x0033BDC5
		public DateTimeStackedBarSeries(NumericXAxis numericXAxis) : base(numericXAxis, null)
		{
		}

		// Token: 0x06005A47 RID: 23111 RVA: 0x0033CDE8 File Offset: 0x0033BDE8
		public void Add(DateTimeStackedBarSeriesElement dateTimeStackedBarSeriesElement)
		{
			base.a(dateTimeStackedBarSeriesElement);
		}

		// Token: 0x06005A48 RID: 23112 RVA: 0x0033CDF4 File Offset: 0x0033BDF4
		internal override DateTime ih()
		{
			return this.b;
		}

		// Token: 0x06005A49 RID: 23113 RVA: 0x0033CE0C File Offset: 0x0033BE0C
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

		// Token: 0x06005A4A RID: 23114 RVA: 0x0033CE58 File Offset: 0x0033BE58
		internal override DateTime ij()
		{
			return this.a;
		}

		// Token: 0x06005A4B RID: 23115 RVA: 0x0033CE70 File Offset: 0x0033BE70
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

		// Token: 0x04002F72 RID: 12146
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F73 RID: 12147
		private new DateTime b = DateTime.MinValue;
	}
}
