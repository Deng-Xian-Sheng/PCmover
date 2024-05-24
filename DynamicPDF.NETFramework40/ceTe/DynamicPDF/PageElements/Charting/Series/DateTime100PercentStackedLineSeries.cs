using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000896 RID: 2198
	public class DateTime100PercentStackedLineSeries : Stacked100PercentLineSeries
	{
		// Token: 0x0600598F RID: 22927 RVA: 0x0033B13E File Offset: 0x0033A13E
		public DateTime100PercentStackedLineSeries() : base(null, null)
		{
		}

		// Token: 0x06005990 RID: 22928 RVA: 0x0033B161 File Offset: 0x0033A161
		public DateTime100PercentStackedLineSeries(DateTimeXAxis xAxis, PercentageYAxis yAxis) : base(xAxis, yAxis)
		{
		}

		// Token: 0x06005991 RID: 22929 RVA: 0x0033B184 File Offset: 0x0033A184
		public DateTime100PercentStackedLineSeries(PercentageYAxis yAxis) : base(null, yAxis)
		{
		}

		// Token: 0x06005992 RID: 22930 RVA: 0x0033B1A7 File Offset: 0x0033A1A7
		public DateTime100PercentStackedLineSeries(DateTimeXAxis xAxis, PercentageYAxis yAxis, Legend legend) : base(xAxis, yAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x1700090A RID: 2314
		public DateTime100PercentStackedLineSeriesElement this[int index]
		{
			get
			{
				return (DateTime100PercentStackedLineSeriesElement)base.b(index);
			}
		}

		// Token: 0x1700090B RID: 2315
		// (get) Token: 0x06005994 RID: 22932 RVA: 0x0033B1F4 File Offset: 0x0033A1F4
		public DateTimeXAxis XAxis
		{
			get
			{
				return (DateTimeXAxis)base.m();
			}
		}

		// Token: 0x1700090C RID: 2316
		// (get) Token: 0x06005995 RID: 22933 RVA: 0x0033B214 File Offset: 0x0033A214
		public PercentageYAxis YAxis
		{
			get
			{
				return (PercentageYAxis)base.n();
			}
		}

		// Token: 0x06005996 RID: 22934 RVA: 0x0033B231 File Offset: 0x0033A231
		public void Add(DateTime100PercentStackedLineSeriesElement element)
		{
			base.a(element);
		}

		// Token: 0x06005997 RID: 22935 RVA: 0x0033B23C File Offset: 0x0033A23C
		internal override DateTime ih()
		{
			return this.b;
		}

		// Token: 0x06005998 RID: 22936 RVA: 0x0033B254 File Offset: 0x0033A254
		internal override void ii(DateTime A_0)
		{
			if (this.b == DateTime.MinValue)
			{
				this.b = A_0;
			}
			else if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005999 RID: 22937 RVA: 0x0033B29C File Offset: 0x0033A29C
		internal override DateTime ij()
		{
			return this.a;
		}

		// Token: 0x0600599A RID: 22938 RVA: 0x0033B2B4 File Offset: 0x0033A2B4
		internal override void ik(DateTime A_0)
		{
			if (this.a == DateTime.MinValue)
			{
				this.a = A_0;
			}
			else if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002F4B RID: 12107
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F4C RID: 12108
		private new DateTime b = DateTime.MinValue;
	}
}
