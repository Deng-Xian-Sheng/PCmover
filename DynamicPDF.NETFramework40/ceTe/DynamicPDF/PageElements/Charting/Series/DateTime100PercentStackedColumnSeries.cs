using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000892 RID: 2194
	public class DateTime100PercentStackedColumnSeries : Stacked100PercentColumnSeries
	{
		// Token: 0x06005963 RID: 22883 RVA: 0x0033A682 File Offset: 0x00339682
		public DateTime100PercentStackedColumnSeries() : base(null, null)
		{
		}

		// Token: 0x06005964 RID: 22884 RVA: 0x0033A6A5 File Offset: 0x003396A5
		public DateTime100PercentStackedColumnSeries(DateTimeXAxis dateTimeXAxis, PercentageYAxis percentageYAxis) : base(dateTimeXAxis, percentageYAxis)
		{
		}

		// Token: 0x06005965 RID: 22885 RVA: 0x0033A6C8 File Offset: 0x003396C8
		public DateTime100PercentStackedColumnSeries(DateTimeXAxis dateTimeXAxis, PercentageYAxis percentageYAxis, Legend legend) : base(dateTimeXAxis, percentageYAxis)
		{
		}

		// Token: 0x06005966 RID: 22886 RVA: 0x0033A6EB File Offset: 0x003396EB
		public DateTime100PercentStackedColumnSeries(PercentageYAxis percentageYAxis) : base(null, percentageYAxis)
		{
		}

		// Token: 0x17000903 RID: 2307
		public DateTime100PercentStackedColumnSeriesElement this[int index]
		{
			get
			{
				return (DateTime100PercentStackedColumnSeriesElement)base.b(index);
			}
		}

		// Token: 0x17000904 RID: 2308
		// (get) Token: 0x06005968 RID: 22888 RVA: 0x0033A730 File Offset: 0x00339730
		public DateTimeXAxis XAxis
		{
			get
			{
				return (DateTimeXAxis)base.m();
			}
		}

		// Token: 0x17000905 RID: 2309
		// (get) Token: 0x06005969 RID: 22889 RVA: 0x0033A750 File Offset: 0x00339750
		public PercentageYAxis YAxis
		{
			get
			{
				return (PercentageYAxis)base.n();
			}
		}

		// Token: 0x0600596A RID: 22890 RVA: 0x0033A76D File Offset: 0x0033976D
		public void Add(DateTime100PercentStackedColumnSeriesElement dateTimeStackedColumnSeriesElement)
		{
			base.a(dateTimeStackedColumnSeriesElement);
		}

		// Token: 0x0600596B RID: 22891 RVA: 0x0033A778 File Offset: 0x00339778
		internal override DateTime ih()
		{
			return this.b;
		}

		// Token: 0x0600596C RID: 22892 RVA: 0x0033A790 File Offset: 0x00339790
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

		// Token: 0x0600596D RID: 22893 RVA: 0x0033A7D8 File Offset: 0x003397D8
		internal override DateTime ij()
		{
			return this.a;
		}

		// Token: 0x0600596E RID: 22894 RVA: 0x0033A7F0 File Offset: 0x003397F0
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

		// Token: 0x04002F43 RID: 12099
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F44 RID: 12100
		private new DateTime b = DateTime.MinValue;
	}
}
