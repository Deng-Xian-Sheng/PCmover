using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008B8 RID: 2232
	public class IndexedBarSeries : BarSeries
	{
		// Token: 0x06005B2C RID: 23340 RVA: 0x0033EE99 File Offset: 0x0033DE99
		public IndexedBarSeries(string name) : this(name, null, null, null, 0f, null, null)
		{
		}

		// Token: 0x06005B2D RID: 23341 RVA: 0x0033EEAF File Offset: 0x0033DEAF
		public IndexedBarSeries(string name, Color color) : this(name, null, null, color, 0f, null, null)
		{
		}

		// Token: 0x06005B2E RID: 23342 RVA: 0x0033EEC5 File Offset: 0x0033DEC5
		public IndexedBarSeries(string name, NumericXAxis numericXAxis, IndexedYAxis indexedYAxis) : this(name, numericXAxis, indexedYAxis, null, 0f, null, null)
		{
		}

		// Token: 0x06005B2F RID: 23343 RVA: 0x0033EEDB File Offset: 0x0033DEDB
		public IndexedBarSeries(string name, NumericXAxis numericXAxis) : this(name, numericXAxis, null, null, 0f, null, null)
		{
		}

		// Token: 0x06005B30 RID: 23344 RVA: 0x0033EEF1 File Offset: 0x0033DEF1
		public IndexedBarSeries(string name, IndexedYAxis indexedYAxis) : this(name, null, indexedYAxis, null, 0f, null, null)
		{
		}

		// Token: 0x06005B31 RID: 23345 RVA: 0x0033EF07 File Offset: 0x0033DF07
		public IndexedBarSeries(string name, NumericXAxis numericXAxis, IndexedYAxis indexedYAxis, Color color) : this(name, numericXAxis, indexedYAxis, color, 0f, null, null)
		{
		}

		// Token: 0x06005B32 RID: 23346 RVA: 0x0033EF1E File Offset: 0x0033DF1E
		public IndexedBarSeries(string name, NumericXAxis numericXAxis, IndexedYAxis indexedYAxis, Color color, Legend legend) : this(name, numericXAxis, indexedYAxis, color, 0f, null, legend)
		{
		}

		// Token: 0x06005B33 RID: 23347 RVA: 0x0033EF36 File Offset: 0x0033DF36
		public IndexedBarSeries(string name, NumericXAxis numericXAxis, IndexedYAxis indexedYAxis, Color color, float borderWidth) : this(name, numericXAxis, indexedYAxis, color, borderWidth, null, null)
		{
		}

		// Token: 0x06005B34 RID: 23348 RVA: 0x0033EF4A File Offset: 0x0033DF4A
		public IndexedBarSeries(string name, NumericXAxis numericXAxis, IndexedYAxis indexedYAxis, float borderWidth, Color borderColor) : this(name, numericXAxis, indexedYAxis, null, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005B35 RID: 23349 RVA: 0x0033EF5E File Offset: 0x0033DF5E
		public IndexedBarSeries(string name, NumericXAxis numericXAxis, IndexedYAxis indexedYAxis, Color color, float borderWidth, Color borderColor) : this(name, numericXAxis, indexedYAxis, color, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005B36 RID: 23350 RVA: 0x0033EF73 File Offset: 0x0033DF73
		public IndexedBarSeries(string name, NumericXAxis numericXAxis, IndexedYAxis indexedYAxis, Color color, float borderWidth, Color borderColor, Legend legend) : base(name, numericXAxis, indexedYAxis, color, borderWidth, borderColor, legend)
		{
			base.a(new IndexedBarValueList(this));
		}

		// Token: 0x17000958 RID: 2392
		// (get) Token: 0x06005B37 RID: 23351 RVA: 0x0033EFAC File Offset: 0x0033DFAC
		public IndexedBarValueList Values
		{
			get
			{
				return (IndexedBarValueList)base.a();
			}
		}

		// Token: 0x17000959 RID: 2393
		// (get) Token: 0x06005B38 RID: 23352 RVA: 0x0033EFCC File Offset: 0x0033DFCC
		public NumericXAxis XAxis
		{
			get
			{
				return (NumericXAxis)base.m();
			}
		}

		// Token: 0x1700095A RID: 2394
		// (get) Token: 0x06005B39 RID: 23353 RVA: 0x0033EFEC File Offset: 0x0033DFEC
		public IndexedYAxis YAxis
		{
			get
			{
				return (IndexedYAxis)base.n();
			}
		}

		// Token: 0x06005B3A RID: 23354 RVA: 0x0033F00C File Offset: 0x0033E00C
		internal override float ig()
		{
			return this.b;
		}

		// Token: 0x06005B3B RID: 23355 RVA: 0x0033F024 File Offset: 0x0033E024
		internal override void iy(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005B3C RID: 23356 RVA: 0x0033F04C File Offset: 0x0033E04C
		internal override float iz()
		{
			return this.a;
		}

		// Token: 0x06005B3D RID: 23357 RVA: 0x0033F064 File Offset: 0x0033E064
		internal override void i0(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002FA2 RID: 12194
		private new float a = 2.1474836E+09f;

		// Token: 0x04002FA3 RID: 12195
		private new float b = -2.1474836E+09f;
	}
}
