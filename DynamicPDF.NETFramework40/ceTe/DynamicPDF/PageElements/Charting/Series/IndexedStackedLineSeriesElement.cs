using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008C2 RID: 2242
	public class IndexedStackedLineSeriesElement : StackedLineSeriesElement
	{
		// Token: 0x06005BB1 RID: 23473 RVA: 0x0033FE25 File Offset: 0x0033EE25
		public IndexedStackedLineSeriesElement(string name) : this(name, StackedLineSeriesElement.b(), StackedLineSeriesElement.a(), null, null, null)
		{
		}

		// Token: 0x06005BB2 RID: 23474 RVA: 0x0033FE3E File Offset: 0x0033EE3E
		public IndexedStackedLineSeriesElement(string name, Color color) : this(name, StackedLineSeriesElement.b(), StackedLineSeriesElement.a(), color, null, null)
		{
		}

		// Token: 0x06005BB3 RID: 23475 RVA: 0x0033FE57 File Offset: 0x0033EE57
		public IndexedStackedLineSeriesElement(string name, Color color, float lineWidth) : this(name, lineWidth, StackedLineSeriesElement.a(), color, null, null)
		{
		}

		// Token: 0x06005BB4 RID: 23476 RVA: 0x0033FE6C File Offset: 0x0033EE6C
		public IndexedStackedLineSeriesElement(string name, Color color, float lineWidth, LineStyle style) : this(name, lineWidth, style, color, null, null)
		{
		}

		// Token: 0x06005BB5 RID: 23477 RVA: 0x0033FE7E File Offset: 0x0033EE7E
		public IndexedStackedLineSeriesElement(string name, Color color, float lineWidth, LineStyle style, Legend legend) : this(name, lineWidth, style, color, null, legend)
		{
		}

		// Token: 0x06005BB6 RID: 23478 RVA: 0x0033FE91 File Offset: 0x0033EE91
		public IndexedStackedLineSeriesElement(string name, Color color, float lineWidth, LineStyle style, Marker marker) : this(name, lineWidth, style, color, marker, null)
		{
		}

		// Token: 0x06005BB7 RID: 23479 RVA: 0x0033FEA4 File Offset: 0x0033EEA4
		public IndexedStackedLineSeriesElement(string name, float lineWidth, LineStyle style, Color color, Marker marker, Legend legend) : base(name, color, style, lineWidth, marker, legend)
		{
			base.a(new IndexedStackedLineValueList(this));
		}

		// Token: 0x06005BB8 RID: 23480 RVA: 0x0033FEDC File Offset: 0x0033EEDC
		internal override float i1()
		{
			return this.b;
		}

		// Token: 0x06005BB9 RID: 23481 RVA: 0x0033FEF4 File Offset: 0x0033EEF4
		internal override void i2(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005BBA RID: 23482 RVA: 0x0033FF1C File Offset: 0x0033EF1C
		internal override float i3()
		{
			return this.a;
		}

		// Token: 0x06005BBB RID: 23483 RVA: 0x0033FF34 File Offset: 0x0033EF34
		internal override void i4(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x17000970 RID: 2416
		// (get) Token: 0x06005BBC RID: 23484 RVA: 0x0033FF5C File Offset: 0x0033EF5C
		public IndexedStackedLineValueList Values
		{
			get
			{
				return (IndexedStackedLineValueList)base.c();
			}
		}

		// Token: 0x04002FB6 RID: 12214
		private new float a = 2.1474836E+09f;

		// Token: 0x04002FB7 RID: 12215
		private new float b = -2.1474836E+09f;
	}
}
