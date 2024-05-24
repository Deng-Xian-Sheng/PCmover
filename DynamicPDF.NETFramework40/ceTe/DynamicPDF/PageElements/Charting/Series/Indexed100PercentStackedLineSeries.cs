using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008B5 RID: 2229
	public class Indexed100PercentStackedLineSeries : Stacked100PercentLineSeries
	{
		// Token: 0x06005B07 RID: 23303 RVA: 0x0033EA59 File Offset: 0x0033DA59
		public Indexed100PercentStackedLineSeries() : base(null, null)
		{
		}

		// Token: 0x06005B08 RID: 23304 RVA: 0x0033EA7C File Offset: 0x0033DA7C
		public Indexed100PercentStackedLineSeries(PercentageYAxis yAxis) : base(null, yAxis)
		{
		}

		// Token: 0x06005B09 RID: 23305 RVA: 0x0033EA9F File Offset: 0x0033DA9F
		public Indexed100PercentStackedLineSeries(IndexedXAxis xAxis, PercentageYAxis yAxis) : base(xAxis, yAxis)
		{
		}

		// Token: 0x06005B0A RID: 23306 RVA: 0x0033EAC2 File Offset: 0x0033DAC2
		public Indexed100PercentStackedLineSeries(IndexedXAxis xAxis, PercentageYAxis yAxis, Legend legend) : base(xAxis, yAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x17000951 RID: 2385
		public Indexed100PercentStackedLineSeriesElement this[int index]
		{
			get
			{
				return (Indexed100PercentStackedLineSeriesElement)base.b(index);
			}
		}

		// Token: 0x17000952 RID: 2386
		// (get) Token: 0x06005B0C RID: 23308 RVA: 0x0033EB10 File Offset: 0x0033DB10
		public PercentageYAxis YAxis
		{
			get
			{
				return (PercentageYAxis)base.n();
			}
		}

		// Token: 0x17000953 RID: 2387
		// (get) Token: 0x06005B0D RID: 23309 RVA: 0x0033EB30 File Offset: 0x0033DB30
		public IndexedXAxis XAxis
		{
			get
			{
				return (IndexedXAxis)base.m();
			}
		}

		// Token: 0x06005B0E RID: 23310 RVA: 0x0033EB4D File Offset: 0x0033DB4D
		public void Add(Indexed100PercentStackedLineSeriesElement element)
		{
			base.a(element);
		}

		// Token: 0x06005B0F RID: 23311 RVA: 0x0033EB58 File Offset: 0x0033DB58
		internal override float ig()
		{
			return this.b;
		}

		// Token: 0x06005B10 RID: 23312 RVA: 0x0033EB70 File Offset: 0x0033DB70
		internal override void iy(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005B11 RID: 23313 RVA: 0x0033EB98 File Offset: 0x0033DB98
		internal override float iz()
		{
			return this.a;
		}

		// Token: 0x06005B12 RID: 23314 RVA: 0x0033EBB0 File Offset: 0x0033DBB0
		internal override void i0(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002F9C RID: 12188
		private new float a = 2.1474836E+09f;

		// Token: 0x04002F9D RID: 12189
		private new float b = -2.1474836E+09f;
	}
}
