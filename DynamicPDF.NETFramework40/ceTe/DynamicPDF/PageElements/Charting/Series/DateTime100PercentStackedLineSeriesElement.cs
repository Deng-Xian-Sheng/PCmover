using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000898 RID: 2200
	public class DateTime100PercentStackedLineSeriesElement : Stacked100PercentLineSeriesElement
	{
		// Token: 0x060059AF RID: 22959 RVA: 0x0033B495 File Offset: 0x0033A495
		public DateTime100PercentStackedLineSeriesElement(string name) : this(name, Stacked100PercentLineSeriesElement.b(), Stacked100PercentLineSeriesElement.a(), null, null, null)
		{
		}

		// Token: 0x060059B0 RID: 22960 RVA: 0x0033B4AE File Offset: 0x0033A4AE
		public DateTime100PercentStackedLineSeriesElement(string name, Color color) : this(name, Stacked100PercentLineSeriesElement.b(), Stacked100PercentLineSeriesElement.a(), color, null, null)
		{
		}

		// Token: 0x060059B1 RID: 22961 RVA: 0x0033B4C7 File Offset: 0x0033A4C7
		public DateTime100PercentStackedLineSeriesElement(string name, Color color, float lineWidth) : this(name, lineWidth, Stacked100PercentLineSeriesElement.a(), color, null, null)
		{
		}

		// Token: 0x060059B2 RID: 22962 RVA: 0x0033B4DC File Offset: 0x0033A4DC
		public DateTime100PercentStackedLineSeriesElement(string name, Color color, float lineWidth, LineStyle style) : this(name, lineWidth, style, color, null, null)
		{
		}

		// Token: 0x060059B3 RID: 22963 RVA: 0x0033B4EE File Offset: 0x0033A4EE
		public DateTime100PercentStackedLineSeriesElement(string name, Color color, float lineWidth, LineStyle style, Legend legend) : this(name, lineWidth, style, color, null, legend)
		{
		}

		// Token: 0x060059B4 RID: 22964 RVA: 0x0033B501 File Offset: 0x0033A501
		public DateTime100PercentStackedLineSeriesElement(string name, Color color, float lineWidth, LineStyle style, Marker marker) : this(name, lineWidth, style, color, marker, null)
		{
		}

		// Token: 0x060059B5 RID: 22965 RVA: 0x0033B514 File Offset: 0x0033A514
		public DateTime100PercentStackedLineSeriesElement(string name, float lineWidth, LineStyle style, Color color, Marker marker, Legend legend) : base(name, color, style, lineWidth, marker, legend)
		{
			base.a(new DateTime100PercentStackedLineValueList(this));
		}

		// Token: 0x060059B6 RID: 22966 RVA: 0x0033B54C File Offset: 0x0033A54C
		internal override DateTime il()
		{
			return this.b;
		}

		// Token: 0x060059B7 RID: 22967 RVA: 0x0033B564 File Offset: 0x0033A564
		internal override void im(DateTime A_0)
		{
			if (this.b == DateTime.MinValue)
			{
				this.b = A_0;
			}
			else if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x060059B8 RID: 22968 RVA: 0x0033B5AC File Offset: 0x0033A5AC
		internal override DateTime @in()
		{
			return this.a;
		}

		// Token: 0x060059B9 RID: 22969 RVA: 0x0033B5C4 File Offset: 0x0033A5C4
		internal override void io(DateTime A_0)
		{
			if (this.a == DateTime.MinValue)
			{
				this.a = A_0;
			}
			else if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x17000913 RID: 2323
		// (get) Token: 0x060059BA RID: 22970 RVA: 0x0033B60C File Offset: 0x0033A60C
		public DateTime100PercentStackedLineValueList Values
		{
			get
			{
				return (DateTime100PercentStackedLineValueList)base.c();
			}
		}

		// Token: 0x04002F56 RID: 12118
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F57 RID: 12119
		private new DateTime b = DateTime.MinValue;
	}
}
