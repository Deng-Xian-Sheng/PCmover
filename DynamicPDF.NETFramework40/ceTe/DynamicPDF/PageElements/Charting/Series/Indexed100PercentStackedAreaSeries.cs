using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008AF RID: 2223
	public class Indexed100PercentStackedAreaSeries : Stacked100PercentAreaSeries
	{
		// Token: 0x06005AC1 RID: 23233 RVA: 0x0033E259 File Offset: 0x0033D259
		public Indexed100PercentStackedAreaSeries() : base(null, null)
		{
		}

		// Token: 0x06005AC2 RID: 23234 RVA: 0x0033E27C File Offset: 0x0033D27C
		public Indexed100PercentStackedAreaSeries(PercentageYAxis yAxis) : base(null, yAxis)
		{
		}

		// Token: 0x06005AC3 RID: 23235 RVA: 0x0033E29F File Offset: 0x0033D29F
		public Indexed100PercentStackedAreaSeries(IndexedXAxis xAxis, PercentageYAxis yAxis) : base(xAxis, yAxis)
		{
		}

		// Token: 0x06005AC4 RID: 23236 RVA: 0x0033E2C2 File Offset: 0x0033D2C2
		public Indexed100PercentStackedAreaSeries(IndexedXAxis xAxis, PercentageYAxis yAxis, Legend legend) : base(xAxis, yAxis)
		{
			base.Legend = legend;
		}

		// Token: 0x17000945 RID: 2373
		public Indexed100PercentStackedAreaSeriesElement this[int index]
		{
			get
			{
				return (Indexed100PercentStackedAreaSeriesElement)base.b(index);
			}
		}

		// Token: 0x17000946 RID: 2374
		// (get) Token: 0x06005AC6 RID: 23238 RVA: 0x0033E310 File Offset: 0x0033D310
		public PercentageYAxis YAxis
		{
			get
			{
				return (PercentageYAxis)base.n();
			}
		}

		// Token: 0x17000947 RID: 2375
		// (get) Token: 0x06005AC7 RID: 23239 RVA: 0x0033E330 File Offset: 0x0033D330
		public IndexedXAxis XAxis
		{
			get
			{
				return (IndexedXAxis)base.m();
			}
		}

		// Token: 0x06005AC8 RID: 23240 RVA: 0x0033E34D File Offset: 0x0033D34D
		public void Add(Indexed100PercentStackedAreaSeriesElement element)
		{
			base.a(element);
		}

		// Token: 0x06005AC9 RID: 23241 RVA: 0x0033E358 File Offset: 0x0033D358
		internal override float ig()
		{
			return this.b;
		}

		// Token: 0x06005ACA RID: 23242 RVA: 0x0033E370 File Offset: 0x0033D370
		internal override void iy(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005ACB RID: 23243 RVA: 0x0033E398 File Offset: 0x0033D398
		internal override float iz()
		{
			return this.a;
		}

		// Token: 0x06005ACC RID: 23244 RVA: 0x0033E3B0 File Offset: 0x0033D3B0
		internal override void i0(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002F90 RID: 12176
		private new float a = 2.1474836E+09f;

		// Token: 0x04002F91 RID: 12177
		private new float b = -2.1474836E+09f;
	}
}
