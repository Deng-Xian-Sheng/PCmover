using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008B9 RID: 2233
	public class IndexedColumnSeries : ColumnSeries
	{
		// Token: 0x06005B3E RID: 23358 RVA: 0x0033F089 File Offset: 0x0033E089
		public IndexedColumnSeries(string name) : this(name, null, null, null, 0f, null, null)
		{
		}

		// Token: 0x06005B3F RID: 23359 RVA: 0x0033F09F File Offset: 0x0033E09F
		public IndexedColumnSeries(string name, Color color) : this(name, null, null, color, 0f, null, null)
		{
		}

		// Token: 0x06005B40 RID: 23360 RVA: 0x0033F0B5 File Offset: 0x0033E0B5
		public IndexedColumnSeries(string name, IndexedXAxis indexedXAxis, NumericYAxis numericYAxis) : this(name, indexedXAxis, numericYAxis, null, 0f, null, null)
		{
		}

		// Token: 0x06005B41 RID: 23361 RVA: 0x0033F0CB File Offset: 0x0033E0CB
		public IndexedColumnSeries(string name, IndexedXAxis indexedXAxis) : this(name, indexedXAxis, null, null, 0f, null, null)
		{
		}

		// Token: 0x06005B42 RID: 23362 RVA: 0x0033F0E1 File Offset: 0x0033E0E1
		public IndexedColumnSeries(string name, NumericYAxis numericYAxis) : this(name, null, numericYAxis, null, 0f, null, null)
		{
		}

		// Token: 0x06005B43 RID: 23363 RVA: 0x0033F0F7 File Offset: 0x0033E0F7
		public IndexedColumnSeries(string name, IndexedXAxis indexedXAxis, NumericYAxis numericYAxis, Color color) : this(name, indexedXAxis, numericYAxis, color, 0f, null, null)
		{
		}

		// Token: 0x06005B44 RID: 23364 RVA: 0x0033F10E File Offset: 0x0033E10E
		public IndexedColumnSeries(string name, IndexedXAxis indexedXAxis, NumericYAxis numericYAxis, Color color, Legend legend) : this(name, indexedXAxis, numericYAxis, color, 0f, null, legend)
		{
		}

		// Token: 0x06005B45 RID: 23365 RVA: 0x0033F126 File Offset: 0x0033E126
		public IndexedColumnSeries(string name, IndexedXAxis indexedXAxis, NumericYAxis numericYAxis, Color color, float borderWidth) : this(name, indexedXAxis, numericYAxis, color, borderWidth, null, null)
		{
		}

		// Token: 0x06005B46 RID: 23366 RVA: 0x0033F13A File Offset: 0x0033E13A
		public IndexedColumnSeries(string name, IndexedXAxis indexedXAxis, NumericYAxis numericYAxis, float borderWidth, Color borderColor) : this(name, indexedXAxis, numericYAxis, null, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005B47 RID: 23367 RVA: 0x0033F14E File Offset: 0x0033E14E
		public IndexedColumnSeries(string name, IndexedXAxis indexedXAxis, NumericYAxis numericYAxis, Color color, float borderWidth, Color borderColor) : this(name, indexedXAxis, numericYAxis, color, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005B48 RID: 23368 RVA: 0x0033F163 File Offset: 0x0033E163
		public IndexedColumnSeries(string name, IndexedXAxis indexedXAxis, NumericYAxis numericYAxis, Color color, float borderWidth, Color borderColor, Legend legend) : base(name, indexedXAxis, numericYAxis, color, borderWidth, borderColor, legend)
		{
			base.a(new IndexedColumnValueList(this));
		}

		// Token: 0x1700095B RID: 2395
		// (get) Token: 0x06005B49 RID: 23369 RVA: 0x0033F19C File Offset: 0x0033E19C
		public IndexedColumnValueList Values
		{
			get
			{
				return (IndexedColumnValueList)base.a();
			}
		}

		// Token: 0x1700095C RID: 2396
		// (get) Token: 0x06005B4A RID: 23370 RVA: 0x0033F1BC File Offset: 0x0033E1BC
		public IndexedXAxis XAxis
		{
			get
			{
				return (IndexedXAxis)base.m();
			}
		}

		// Token: 0x1700095D RID: 2397
		// (get) Token: 0x06005B4B RID: 23371 RVA: 0x0033F1DC File Offset: 0x0033E1DC
		public NumericYAxis YAxis
		{
			get
			{
				return (NumericYAxis)base.n();
			}
		}

		// Token: 0x06005B4C RID: 23372 RVA: 0x0033F1FC File Offset: 0x0033E1FC
		internal override float ig()
		{
			return this.b;
		}

		// Token: 0x06005B4D RID: 23373 RVA: 0x0033F214 File Offset: 0x0033E214
		internal override void iy(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005B4E RID: 23374 RVA: 0x0033F23C File Offset: 0x0033E23C
		internal override float iz()
		{
			return this.a;
		}

		// Token: 0x06005B4F RID: 23375 RVA: 0x0033F254 File Offset: 0x0033E254
		internal override void i0(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002FA4 RID: 12196
		private new float a = 2.1474836E+09f;

		// Token: 0x04002FA5 RID: 12197
		private new float b = -2.1474836E+09f;
	}
}
