using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000889 RID: 2185
	public class DateTime100PercentStackedAreaSeries : Stacked100PercentAreaSeries
	{
		// Token: 0x0600590C RID: 22796 RVA: 0x00339572 File Offset: 0x00338572
		public DateTime100PercentStackedAreaSeries() : base(null, null)
		{
		}

		// Token: 0x0600590D RID: 22797 RVA: 0x00339595 File Offset: 0x00338595
		public DateTime100PercentStackedAreaSeries(DateTimeXAxis xAxis, PercentageYAxis yAxis) : base(xAxis, yAxis)
		{
		}

		// Token: 0x0600590E RID: 22798 RVA: 0x003395B8 File Offset: 0x003385B8
		public DateTime100PercentStackedAreaSeries(DateTimeXAxis xAxis, PercentageYAxis yAxis, Legend legend) : base(xAxis, yAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x0600590F RID: 22799 RVA: 0x003395E3 File Offset: 0x003385E3
		public DateTime100PercentStackedAreaSeries(PercentageYAxis yAxis) : base(null, yAxis)
		{
		}

		// Token: 0x06005910 RID: 22800 RVA: 0x00339606 File Offset: 0x00338606
		public void Add(DateTime100PercentStackedAreaSeriesElement element)
		{
			base.a(element);
		}

		// Token: 0x170008F5 RID: 2293
		public DateTime100PercentStackedAreaSeriesElement this[int index]
		{
			get
			{
				return (DateTime100PercentStackedAreaSeriesElement)base.b(index);
			}
		}

		// Token: 0x170008F6 RID: 2294
		// (get) Token: 0x06005912 RID: 22802 RVA: 0x00339634 File Offset: 0x00338634
		public DateTimeXAxis XAxis
		{
			get
			{
				return (DateTimeXAxis)base.m();
			}
		}

		// Token: 0x170008F7 RID: 2295
		// (get) Token: 0x06005913 RID: 22803 RVA: 0x00339654 File Offset: 0x00338654
		public PercentageYAxis YAxis
		{
			get
			{
				return (PercentageYAxis)base.n();
			}
		}

		// Token: 0x06005914 RID: 22804 RVA: 0x00339674 File Offset: 0x00338674
		internal override DateTime ih()
		{
			return this.b;
		}

		// Token: 0x06005915 RID: 22805 RVA: 0x0033968C File Offset: 0x0033868C
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

		// Token: 0x06005916 RID: 22806 RVA: 0x003396D4 File Offset: 0x003386D4
		internal override DateTime ij()
		{
			return this.a;
		}

		// Token: 0x06005917 RID: 22807 RVA: 0x003396EC File Offset: 0x003386EC
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

		// Token: 0x04002F31 RID: 12081
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F32 RID: 12082
		private new DateTime b = DateTime.MinValue;
	}
}
