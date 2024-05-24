using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008AE RID: 2222
	public class DateTimeStackedLineSeriesElement : StackedLineSeriesElement
	{
		// Token: 0x06005AB5 RID: 23221 RVA: 0x0033E0BE File Offset: 0x0033D0BE
		public DateTimeStackedLineSeriesElement(string name) : this(name, StackedLineSeriesElement.b(), StackedLineSeriesElement.a(), null, null, null)
		{
		}

		// Token: 0x06005AB6 RID: 23222 RVA: 0x0033E0D7 File Offset: 0x0033D0D7
		public DateTimeStackedLineSeriesElement(string name, Color color) : this(name, StackedLineSeriesElement.b(), StackedLineSeriesElement.a(), color, null, null)
		{
		}

		// Token: 0x06005AB7 RID: 23223 RVA: 0x0033E0F0 File Offset: 0x0033D0F0
		public DateTimeStackedLineSeriesElement(string name, Color color, float lineWidth) : this(name, lineWidth, StackedLineSeriesElement.a(), color, null, null)
		{
		}

		// Token: 0x06005AB8 RID: 23224 RVA: 0x0033E105 File Offset: 0x0033D105
		public DateTimeStackedLineSeriesElement(string name, Color color, float lineWidth, LineStyle style) : this(name, lineWidth, style, color, null, null)
		{
		}

		// Token: 0x06005AB9 RID: 23225 RVA: 0x0033E117 File Offset: 0x0033D117
		public DateTimeStackedLineSeriesElement(string name, Color color, float lineWidth, LineStyle style, Legend legend) : this(name, lineWidth, style, color, null, legend)
		{
		}

		// Token: 0x06005ABA RID: 23226 RVA: 0x0033E12A File Offset: 0x0033D12A
		public DateTimeStackedLineSeriesElement(string name, Color color, float lineWidth, LineStyle style, Marker marker) : this(name, lineWidth, style, color, marker, null)
		{
		}

		// Token: 0x06005ABB RID: 23227 RVA: 0x0033E13D File Offset: 0x0033D13D
		public DateTimeStackedLineSeriesElement(string name, float lineWidth, LineStyle style, Color color, Marker marker, Legend legend) : base(name, color, style, lineWidth, marker, legend)
		{
			base.a(new DateTimeStackedLineValueList(this));
		}

		// Token: 0x06005ABC RID: 23228 RVA: 0x0033E174 File Offset: 0x0033D174
		internal override DateTime il()
		{
			return this.b;
		}

		// Token: 0x06005ABD RID: 23229 RVA: 0x0033E18C File Offset: 0x0033D18C
		internal override void im(DateTime A_0)
		{
			if (this.b == DateTime.MinValue)
			{
				this.b = A_0;
			}
			else if (A_0.CompareTo(this.b) > 0)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005ABE RID: 23230 RVA: 0x0033E1D8 File Offset: 0x0033D1D8
		internal override DateTime @in()
		{
			return this.a;
		}

		// Token: 0x06005ABF RID: 23231 RVA: 0x0033E1F0 File Offset: 0x0033D1F0
		internal override void io(DateTime A_0)
		{
			if (this.a == DateTime.MinValue)
			{
				this.a = A_0;
			}
			else if (A_0.CompareTo(this.a) < 0)
			{
				this.a = A_0;
			}
		}

		// Token: 0x17000944 RID: 2372
		// (get) Token: 0x06005AC0 RID: 23232 RVA: 0x0033E23C File Offset: 0x0033D23C
		public DateTimeStackedLineValueList Values
		{
			get
			{
				return (DateTimeStackedLineValueList)base.c();
			}
		}

		// Token: 0x04002F8E RID: 12174
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F8F RID: 12175
		private new DateTime b = DateTime.MinValue;
	}
}
