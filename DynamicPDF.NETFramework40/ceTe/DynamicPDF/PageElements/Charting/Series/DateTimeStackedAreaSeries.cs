using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x0200089F RID: 2207
	public class DateTimeStackedAreaSeries : StackedAreaSeries
	{
		// Token: 0x06005A19 RID: 23065 RVA: 0x0033C646 File Offset: 0x0033B646
		public DateTimeStackedAreaSeries() : base(null, null)
		{
		}

		// Token: 0x06005A1A RID: 23066 RVA: 0x0033C669 File Offset: 0x0033B669
		public DateTimeStackedAreaSeries(DateTimeXAxis xAxis, NumericYAxis yAxis) : base(xAxis, yAxis)
		{
		}

		// Token: 0x06005A1B RID: 23067 RVA: 0x0033C68C File Offset: 0x0033B68C
		public DateTimeStackedAreaSeries(DateTimeXAxis xAxis, NumericYAxis yAxis, Legend legend) : base(xAxis, yAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x06005A1C RID: 23068 RVA: 0x0033C6B7 File Offset: 0x0033B6B7
		public DateTimeStackedAreaSeries(NumericYAxis yAxis) : base(null, yAxis)
		{
		}

		// Token: 0x06005A1D RID: 23069 RVA: 0x0033C6DA File Offset: 0x0033B6DA
		public void Add(DateTimeStackedAreaSeriesElement element)
		{
			base.a(element);
		}

		// Token: 0x17000927 RID: 2343
		// (get) Token: 0x06005A1E RID: 23070 RVA: 0x0033C6E8 File Offset: 0x0033B6E8
		public DateTimeXAxis XAxis
		{
			get
			{
				return (DateTimeXAxis)base.m();
			}
		}

		// Token: 0x17000928 RID: 2344
		public DateTimeStackedAreaSeriesElement this[int index]
		{
			get
			{
				return (DateTimeStackedAreaSeriesElement)base.b(index);
			}
		}

		// Token: 0x17000929 RID: 2345
		// (get) Token: 0x06005A20 RID: 23072 RVA: 0x0033C728 File Offset: 0x0033B728
		public NumericYAxis YAxis
		{
			get
			{
				return (NumericYAxis)base.n();
			}
		}

		// Token: 0x06005A21 RID: 23073 RVA: 0x0033C748 File Offset: 0x0033B748
		internal override DateTime ih()
		{
			return this.b;
		}

		// Token: 0x06005A22 RID: 23074 RVA: 0x0033C760 File Offset: 0x0033B760
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

		// Token: 0x06005A23 RID: 23075 RVA: 0x0033C7AC File Offset: 0x0033B7AC
		internal override DateTime ij()
		{
			return this.a;
		}

		// Token: 0x06005A24 RID: 23076 RVA: 0x0033C7C4 File Offset: 0x0033B7C4
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

		// Token: 0x04002F6A RID: 12138
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F6B RID: 12139
		private new DateTime b = DateTime.MinValue;
	}
}
