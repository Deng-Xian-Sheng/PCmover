using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008AC RID: 2220
	public class DateTimeStackedLineSeries : StackedLineSeries
	{
		// Token: 0x06005A95 RID: 23189 RVA: 0x0033DD62 File Offset: 0x0033CD62
		public DateTimeStackedLineSeries() : base(null, null)
		{
		}

		// Token: 0x06005A96 RID: 23190 RVA: 0x0033DD85 File Offset: 0x0033CD85
		public DateTimeStackedLineSeries(DateTimeXAxis xAxis, NumericYAxis yAxis) : base(xAxis, yAxis)
		{
		}

		// Token: 0x06005A97 RID: 23191 RVA: 0x0033DDA8 File Offset: 0x0033CDA8
		public DateTimeStackedLineSeries(NumericYAxis yAxis) : base(null, yAxis)
		{
		}

		// Token: 0x06005A98 RID: 23192 RVA: 0x0033DDCB File Offset: 0x0033CDCB
		public DateTimeStackedLineSeries(DateTimeXAxis xAxis, NumericYAxis yAxis, Legend legend) : base(xAxis, yAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x1700093B RID: 2363
		public DateTimeStackedLineSeriesElement this[int index]
		{
			get
			{
				return (DateTimeStackedLineSeriesElement)base.b(index);
			}
		}

		// Token: 0x1700093C RID: 2364
		// (get) Token: 0x06005A9A RID: 23194 RVA: 0x0033DE18 File Offset: 0x0033CE18
		public NumericYAxis YAxis
		{
			get
			{
				return (NumericYAxis)base.n();
			}
		}

		// Token: 0x1700093D RID: 2365
		// (get) Token: 0x06005A9B RID: 23195 RVA: 0x0033DE38 File Offset: 0x0033CE38
		public DateTimeXAxis XAxis
		{
			get
			{
				return (DateTimeXAxis)base.m();
			}
		}

		// Token: 0x06005A9C RID: 23196 RVA: 0x0033DE55 File Offset: 0x0033CE55
		public void Add(DateTimeStackedLineSeriesElement element)
		{
			base.a(element);
		}

		// Token: 0x06005A9D RID: 23197 RVA: 0x0033DE60 File Offset: 0x0033CE60
		internal override DateTime ih()
		{
			return this.b;
		}

		// Token: 0x06005A9E RID: 23198 RVA: 0x0033DE78 File Offset: 0x0033CE78
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

		// Token: 0x06005A9F RID: 23199 RVA: 0x0033DEC4 File Offset: 0x0033CEC4
		internal override DateTime ij()
		{
			return this.a;
		}

		// Token: 0x06005AA0 RID: 23200 RVA: 0x0033DEDC File Offset: 0x0033CEDC
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

		// Token: 0x04002F83 RID: 12163
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F84 RID: 12164
		private new DateTime b = DateTime.MinValue;
	}
}
