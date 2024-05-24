using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008BA RID: 2234
	public class IndexedLineSeries : LineSeries
	{
		// Token: 0x06005B50 RID: 23376 RVA: 0x0033F27C File Offset: 0x0033E27C
		public IndexedLineSeries(string name) : this(name, null, null, LineSeries.b(), LineSeries.a(), null, null, null)
		{
		}

		// Token: 0x06005B51 RID: 23377 RVA: 0x0033F2A4 File Offset: 0x0033E2A4
		public IndexedLineSeries(string name, IndexedXAxis xAxis, NumericYAxis yAxis) : this(name, xAxis, yAxis, LineSeries.b(), LineSeries.a(), null, null, null)
		{
		}

		// Token: 0x06005B52 RID: 23378 RVA: 0x0033F2CC File Offset: 0x0033E2CC
		public IndexedLineSeries(string name, IndexedXAxis xAxis, NumericYAxis yAxis, Color color) : this(name, xAxis, yAxis, LineSeries.b(), LineSeries.a(), color, null, null)
		{
		}

		// Token: 0x06005B53 RID: 23379 RVA: 0x0033F2F4 File Offset: 0x0033E2F4
		public IndexedLineSeries(string name, IndexedXAxis xAxis, NumericYAxis yAxis, Color color, float lineWidth) : this(name, xAxis, yAxis, lineWidth, LineSeries.a(), color, null, null)
		{
		}

		// Token: 0x06005B54 RID: 23380 RVA: 0x0033F318 File Offset: 0x0033E318
		public IndexedLineSeries(string name, IndexedXAxis xAxis, NumericYAxis yAxis, Color color, float lineWidth, LineStyle style) : this(name, xAxis, yAxis, lineWidth, style, color, null, null)
		{
		}

		// Token: 0x06005B55 RID: 23381 RVA: 0x0033F33C File Offset: 0x0033E33C
		public IndexedLineSeries(string name, IndexedXAxis xAxis, NumericYAxis yAxis, Color color, float lineWidth, LineStyle style, Legend legend) : this(name, xAxis, yAxis, lineWidth, style, color, null, legend)
		{
		}

		// Token: 0x06005B56 RID: 23382 RVA: 0x0033F360 File Offset: 0x0033E360
		public IndexedLineSeries(string name, IndexedXAxis xAxis, NumericYAxis yAxis, Color color, float lineWidth, LineStyle style, Marker marker) : this(name, xAxis, yAxis, lineWidth, style, color, marker, null)
		{
		}

		// Token: 0x06005B57 RID: 23383 RVA: 0x0033F384 File Offset: 0x0033E384
		public IndexedLineSeries(string name, IndexedXAxis xAxis, NumericYAxis yAxis, float lineWidth, LineStyle style, Color color, Marker marker, Legend legend) : base(name, xAxis, yAxis, color, style, lineWidth, marker, legend)
		{
			base.a(new IndexedLineValueList(this));
		}

		// Token: 0x1700095E RID: 2398
		// (get) Token: 0x06005B58 RID: 23384 RVA: 0x0033F3CC File Offset: 0x0033E3CC
		public IndexedXAxis XAxis
		{
			get
			{
				return (IndexedXAxis)base.m();
			}
		}

		// Token: 0x1700095F RID: 2399
		// (get) Token: 0x06005B59 RID: 23385 RVA: 0x0033F3EC File Offset: 0x0033E3EC
		public NumericYAxis YAxis
		{
			get
			{
				return (NumericYAxis)base.n();
			}
		}

		// Token: 0x06005B5A RID: 23386 RVA: 0x0033F40C File Offset: 0x0033E40C
		internal override float ig()
		{
			return this.b;
		}

		// Token: 0x06005B5B RID: 23387 RVA: 0x0033F424 File Offset: 0x0033E424
		internal override void iy(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005B5C RID: 23388 RVA: 0x0033F44C File Offset: 0x0033E44C
		internal override float iz()
		{
			return this.a;
		}

		// Token: 0x06005B5D RID: 23389 RVA: 0x0033F464 File Offset: 0x0033E464
		internal override void i0(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x17000960 RID: 2400
		// (get) Token: 0x06005B5E RID: 23390 RVA: 0x0033F48C File Offset: 0x0033E48C
		public IndexedLineValueList Values
		{
			get
			{
				return (IndexedLineValueList)base.c();
			}
		}

		// Token: 0x04002FA6 RID: 12198
		private new float a = 2.1474836E+09f;

		// Token: 0x04002FA7 RID: 12199
		private new float b = -2.1474836E+09f;
	}
}
