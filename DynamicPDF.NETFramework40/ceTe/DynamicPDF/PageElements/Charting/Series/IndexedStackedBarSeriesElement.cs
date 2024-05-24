using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008BE RID: 2238
	public class IndexedStackedBarSeriesElement : StackedBarSeriesElement
	{
		// Token: 0x06005B81 RID: 23425 RVA: 0x0033F8AD File Offset: 0x0033E8AD
		public IndexedStackedBarSeriesElement(string name) : this(name, null, 0f, null, null)
		{
		}

		// Token: 0x06005B82 RID: 23426 RVA: 0x0033F8C1 File Offset: 0x0033E8C1
		public IndexedStackedBarSeriesElement(string name, Color color) : this(name, color, 0f, null, null)
		{
		}

		// Token: 0x06005B83 RID: 23427 RVA: 0x0033F8D5 File Offset: 0x0033E8D5
		public IndexedStackedBarSeriesElement(string name, Color color, Legend legend) : this(name, color, 0f, null, legend)
		{
		}

		// Token: 0x06005B84 RID: 23428 RVA: 0x0033F8E9 File Offset: 0x0033E8E9
		public IndexedStackedBarSeriesElement(string name, Color color, float borderWidth) : this(name, color, borderWidth, null, null)
		{
		}

		// Token: 0x06005B85 RID: 23429 RVA: 0x0033F8F9 File Offset: 0x0033E8F9
		public IndexedStackedBarSeriesElement(string name, float borderWidth, Color borderColor) : this(name, null, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005B86 RID: 23430 RVA: 0x0033F909 File Offset: 0x0033E909
		public IndexedStackedBarSeriesElement(string name, Color color, float borderWidth, Color borderColor) : this(name, color, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005B87 RID: 23431 RVA: 0x0033F91A File Offset: 0x0033E91A
		public IndexedStackedBarSeriesElement(string name, Color color, float borderWidth, Color borderColor, Legend legend) : base(name, color, borderWidth, borderColor, legend)
		{
			base.a(new IndexedStackedBarValueList(this));
		}

		// Token: 0x17000968 RID: 2408
		// (get) Token: 0x06005B88 RID: 23432 RVA: 0x0033F950 File Offset: 0x0033E950
		public IndexedStackedBarValueList Values
		{
			get
			{
				return (IndexedStackedBarValueList)base.a();
			}
		}

		// Token: 0x06005B89 RID: 23433 RVA: 0x0033F970 File Offset: 0x0033E970
		internal override float i1()
		{
			return this.b;
		}

		// Token: 0x06005B8A RID: 23434 RVA: 0x0033F988 File Offset: 0x0033E988
		internal override void i2(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005B8B RID: 23435 RVA: 0x0033F9B0 File Offset: 0x0033E9B0
		internal override float i3()
		{
			return this.a;
		}

		// Token: 0x06005B8C RID: 23436 RVA: 0x0033F9C8 File Offset: 0x0033E9C8
		internal override void i4(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002FAE RID: 12206
		private new float a = 2.1474836E+09f;

		// Token: 0x04002FAF RID: 12207
		private new float b = -2.1474836E+09f;
	}
}
