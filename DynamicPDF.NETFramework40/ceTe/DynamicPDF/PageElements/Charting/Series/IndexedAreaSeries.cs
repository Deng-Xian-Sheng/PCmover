using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008B7 RID: 2231
	public class IndexedAreaSeries : AreaSeries
	{
		// Token: 0x06005B1F RID: 23327 RVA: 0x0033ED29 File Offset: 0x0033DD29
		public IndexedAreaSeries(string name) : this(name, null, null, null, null, null)
		{
		}

		// Token: 0x06005B20 RID: 23328 RVA: 0x0033ED3A File Offset: 0x0033DD3A
		public IndexedAreaSeries(string name, IndexedXAxis xAxis, NumericYAxis yAxis) : this(name, xAxis, yAxis, null, null, null)
		{
		}

		// Token: 0x06005B21 RID: 23329 RVA: 0x0033ED4B File Offset: 0x0033DD4B
		public IndexedAreaSeries(string name, IndexedXAxis xAxis, NumericYAxis yAxis, Color color) : this(name, xAxis, yAxis, color, null, null)
		{
		}

		// Token: 0x06005B22 RID: 23330 RVA: 0x0033ED5D File Offset: 0x0033DD5D
		public IndexedAreaSeries(string name, IndexedXAxis xAxis, NumericYAxis yAxis, Color color, Marker marker) : this(name, xAxis, yAxis, color, marker, null)
		{
		}

		// Token: 0x06005B23 RID: 23331 RVA: 0x0033ED70 File Offset: 0x0033DD70
		public IndexedAreaSeries(string name, IndexedXAxis xAxis, NumericYAxis yAxis, Color color, Legend legend) : this(name, xAxis, yAxis, color, null, legend)
		{
		}

		// Token: 0x06005B24 RID: 23332 RVA: 0x0033ED83 File Offset: 0x0033DD83
		public IndexedAreaSeries(string name, IndexedXAxis xAxis, NumericYAxis yAxis, Color color, Marker marker, Legend legend) : base(name, xAxis, yAxis, color, marker, legend)
		{
			base.a(new IndexedAreaValueList(this));
		}

		// Token: 0x17000955 RID: 2389
		// (get) Token: 0x06005B25 RID: 23333 RVA: 0x0033EDBC File Offset: 0x0033DDBC
		public IndexedXAxis XAxis
		{
			get
			{
				return (IndexedXAxis)base.m();
			}
		}

		// Token: 0x17000956 RID: 2390
		// (get) Token: 0x06005B26 RID: 23334 RVA: 0x0033EDDC File Offset: 0x0033DDDC
		public NumericYAxis YAxis
		{
			get
			{
				return (NumericYAxis)base.n();
			}
		}

		// Token: 0x06005B27 RID: 23335 RVA: 0x0033EDFC File Offset: 0x0033DDFC
		internal override float ig()
		{
			return this.b;
		}

		// Token: 0x06005B28 RID: 23336 RVA: 0x0033EE14 File Offset: 0x0033DE14
		internal override void iy(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005B29 RID: 23337 RVA: 0x0033EE3C File Offset: 0x0033DE3C
		internal override float iz()
		{
			return this.a;
		}

		// Token: 0x06005B2A RID: 23338 RVA: 0x0033EE54 File Offset: 0x0033DE54
		internal override void i0(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x17000957 RID: 2391
		// (get) Token: 0x06005B2B RID: 23339 RVA: 0x0033EE7C File Offset: 0x0033DE7C
		public IndexedAreaValueList Values
		{
			get
			{
				return (IndexedAreaValueList)base.a();
			}
		}

		// Token: 0x04002FA0 RID: 12192
		private new float a = 2.1474836E+09f;

		// Token: 0x04002FA1 RID: 12193
		private new float b = -2.1474836E+09f;
	}
}
