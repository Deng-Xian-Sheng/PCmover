using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x0200088E RID: 2190
	public class DateTime100PercentStackedBarSeries : Stacked100PercentBarSeries
	{
		// Token: 0x06005937 RID: 22839 RVA: 0x00339DE6 File Offset: 0x00338DE6
		public DateTime100PercentStackedBarSeries() : base(null, null)
		{
		}

		// Token: 0x06005938 RID: 22840 RVA: 0x00339E09 File Offset: 0x00338E09
		public DateTime100PercentStackedBarSeries(PercentageXAxis percentageXAxis, DateTimeYAxis dateTimeYAxis) : base(percentageXAxis, dateTimeYAxis)
		{
		}

		// Token: 0x06005939 RID: 22841 RVA: 0x00339E2C File Offset: 0x00338E2C
		public DateTime100PercentStackedBarSeries(PercentageXAxis percentageXAxis, DateTimeYAxis dateTimeYAxis, Legend legend) : base(percentageXAxis, dateTimeYAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x0600593A RID: 22842 RVA: 0x00339E57 File Offset: 0x00338E57
		public DateTime100PercentStackedBarSeries(PercentageXAxis percentageXAxis) : base(percentageXAxis, null)
		{
		}

		// Token: 0x170008FC RID: 2300
		public DateTime100PercentStackedBarSeriesElement this[int index]
		{
			get
			{
				return (DateTime100PercentStackedBarSeriesElement)base.b(index);
			}
		}

		// Token: 0x170008FD RID: 2301
		// (get) Token: 0x0600593C RID: 22844 RVA: 0x00339E9C File Offset: 0x00338E9C
		public DateTimeYAxis YAxis
		{
			get
			{
				return (DateTimeYAxis)base.n();
			}
		}

		// Token: 0x170008FE RID: 2302
		// (get) Token: 0x0600593D RID: 22845 RVA: 0x00339EBC File Offset: 0x00338EBC
		public PercentageXAxis XAxis
		{
			get
			{
				return (PercentageXAxis)base.m();
			}
		}

		// Token: 0x0600593E RID: 22846 RVA: 0x00339ED9 File Offset: 0x00338ED9
		public void Add(DateTime100PercentStackedBarSeriesElement dateTimeStackedBarSeriesElement)
		{
			base.a(dateTimeStackedBarSeriesElement);
		}

		// Token: 0x0600593F RID: 22847 RVA: 0x00339EE4 File Offset: 0x00338EE4
		internal override DateTime ih()
		{
			return this.b;
		}

		// Token: 0x06005940 RID: 22848 RVA: 0x00339EFC File Offset: 0x00338EFC
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

		// Token: 0x06005941 RID: 22849 RVA: 0x00339F44 File Offset: 0x00338F44
		internal override DateTime ij()
		{
			return this.a;
		}

		// Token: 0x06005942 RID: 22850 RVA: 0x00339F5C File Offset: 0x00338F5C
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

		// Token: 0x04002F3A RID: 12090
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F3B RID: 12091
		private new DateTime b = DateTime.MinValue;
	}
}
