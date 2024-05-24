using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008A6 RID: 2214
	public class DateTimeStackedBarSeriesElement : StackedBarSeriesElement
	{
		// Token: 0x06005A57 RID: 23127 RVA: 0x0033CF9C File Offset: 0x0033BF9C
		public DateTimeStackedBarSeriesElement(string name) : this(name, null, 0f, null, null)
		{
		}

		// Token: 0x06005A58 RID: 23128 RVA: 0x0033CFB0 File Offset: 0x0033BFB0
		public DateTimeStackedBarSeriesElement(string name, Color color) : this(name, color, 0f, null, null)
		{
		}

		// Token: 0x06005A59 RID: 23129 RVA: 0x0033CFC4 File Offset: 0x0033BFC4
		public DateTimeStackedBarSeriesElement(string name, Color color, Legend legend) : this(name, color, 0f, null, legend)
		{
		}

		// Token: 0x06005A5A RID: 23130 RVA: 0x0033CFD8 File Offset: 0x0033BFD8
		public DateTimeStackedBarSeriesElement(string name, Color color, float borderWidth) : this(name, color, borderWidth, null, null)
		{
		}

		// Token: 0x06005A5B RID: 23131 RVA: 0x0033CFE8 File Offset: 0x0033BFE8
		public DateTimeStackedBarSeriesElement(string name, float borderWidth, Color borderColor) : this(name, null, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005A5C RID: 23132 RVA: 0x0033CFF8 File Offset: 0x0033BFF8
		public DateTimeStackedBarSeriesElement(string name, Color color, float borderWidth, Color borderColor) : this(name, color, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005A5D RID: 23133 RVA: 0x0033D009 File Offset: 0x0033C009
		public DateTimeStackedBarSeriesElement(string name, Color color, float borderWidth, Color borderColor, Legend legend) : base(name, color, borderWidth, borderColor, legend)
		{
			base.a(new DateTimeStackedBarValueList(this));
		}

		// Token: 0x17000933 RID: 2355
		// (get) Token: 0x06005A5E RID: 23134 RVA: 0x0033D040 File Offset: 0x0033C040
		public DateTimeStackedBarValueList Values
		{
			get
			{
				return (DateTimeStackedBarValueList)base.a();
			}
		}

		// Token: 0x06005A5F RID: 23135 RVA: 0x0033D060 File Offset: 0x0033C060
		internal override DateTime il()
		{
			return this.b;
		}

		// Token: 0x06005A60 RID: 23136 RVA: 0x0033D078 File Offset: 0x0033C078
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

		// Token: 0x06005A61 RID: 23137 RVA: 0x0033D0C0 File Offset: 0x0033C0C0
		internal override DateTime @in()
		{
			return this.a;
		}

		// Token: 0x06005A62 RID: 23138 RVA: 0x0033D0D8 File Offset: 0x0033C0D8
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

		// Token: 0x04002F78 RID: 12152
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F79 RID: 12153
		private new DateTime b = DateTime.MinValue;
	}
}
