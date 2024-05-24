using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008B6 RID: 2230
	public class Indexed100PercentStackedLineSeriesElement : Stacked100PercentLineSeriesElement
	{
		// Token: 0x06005B13 RID: 23315 RVA: 0x0033EBD5 File Offset: 0x0033DBD5
		public Indexed100PercentStackedLineSeriesElement(string name) : this(name, Stacked100PercentLineSeriesElement.b(), Stacked100PercentLineSeriesElement.a(), null, null, null)
		{
		}

		// Token: 0x06005B14 RID: 23316 RVA: 0x0033EBEE File Offset: 0x0033DBEE
		public Indexed100PercentStackedLineSeriesElement(string name, Color color) : this(name, Stacked100PercentLineSeriesElement.b(), Stacked100PercentLineSeriesElement.a(), color, null, null)
		{
		}

		// Token: 0x06005B15 RID: 23317 RVA: 0x0033EC07 File Offset: 0x0033DC07
		public Indexed100PercentStackedLineSeriesElement(string name, Color color, float lineWidth) : this(name, lineWidth, Stacked100PercentLineSeriesElement.a(), color, null, null)
		{
		}

		// Token: 0x06005B16 RID: 23318 RVA: 0x0033EC1C File Offset: 0x0033DC1C
		public Indexed100PercentStackedLineSeriesElement(string name, Color color, float lineWidth, LineStyle style) : this(name, lineWidth, style, color, null, null)
		{
		}

		// Token: 0x06005B17 RID: 23319 RVA: 0x0033EC2E File Offset: 0x0033DC2E
		public Indexed100PercentStackedLineSeriesElement(string name, Color color, float lineWidth, LineStyle style, Legend legend) : this(name, lineWidth, style, color, null, legend)
		{
		}

		// Token: 0x06005B18 RID: 23320 RVA: 0x0033EC41 File Offset: 0x0033DC41
		public Indexed100PercentStackedLineSeriesElement(string name, Color color, float lineWidth, LineStyle style, Marker marker) : this(name, lineWidth, style, color, marker, null)
		{
		}

		// Token: 0x06005B19 RID: 23321 RVA: 0x0033EC54 File Offset: 0x0033DC54
		public Indexed100PercentStackedLineSeriesElement(string name, float lineWidth, LineStyle style, Color color, Marker marker, Legend legend) : base(name, color, style, lineWidth, marker, legend)
		{
			base.a(new Indexed100PercentStackedLineValueList(this));
		}

		// Token: 0x06005B1A RID: 23322 RVA: 0x0033EC8C File Offset: 0x0033DC8C
		internal override float i1()
		{
			return this.b;
		}

		// Token: 0x06005B1B RID: 23323 RVA: 0x0033ECA4 File Offset: 0x0033DCA4
		internal override void i2(float A_0)
		{
			if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005B1C RID: 23324 RVA: 0x0033ECCC File Offset: 0x0033DCCC
		internal override float i3()
		{
			return this.a;
		}

		// Token: 0x06005B1D RID: 23325 RVA: 0x0033ECE4 File Offset: 0x0033DCE4
		internal override void i4(float A_0)
		{
			if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x17000954 RID: 2388
		// (get) Token: 0x06005B1E RID: 23326 RVA: 0x0033ED0C File Offset: 0x0033DD0C
		public Indexed100PercentStackedLineValueList Values
		{
			get
			{
				return (Indexed100PercentStackedLineValueList)base.c();
			}
		}

		// Token: 0x04002F9E RID: 12190
		private new float a = 2.1474836E+09f;

		// Token: 0x04002F9F RID: 12191
		private new float b = -2.1474836E+09f;
	}
}
