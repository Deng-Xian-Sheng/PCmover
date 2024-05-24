using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008AA RID: 2218
	public class DateTimeStackedColumnSeriesElement : StackedColumnSeriesElement
	{
		// Token: 0x06005A81 RID: 23169 RVA: 0x0033D698 File Offset: 0x0033C698
		public DateTimeStackedColumnSeriesElement(string name) : this(name, null, 0f, null, null)
		{
		}

		// Token: 0x06005A82 RID: 23170 RVA: 0x0033D6AC File Offset: 0x0033C6AC
		public DateTimeStackedColumnSeriesElement(string name, Color color) : this(name, color, 0f, null, null)
		{
		}

		// Token: 0x06005A83 RID: 23171 RVA: 0x0033D6C0 File Offset: 0x0033C6C0
		public DateTimeStackedColumnSeriesElement(string name, Color color, Legend legend) : this(name, color, 0f, null, legend)
		{
		}

		// Token: 0x06005A84 RID: 23172 RVA: 0x0033D6D4 File Offset: 0x0033C6D4
		public DateTimeStackedColumnSeriesElement(string name, Color color, float borderWidth) : this(name, color, borderWidth, null, null)
		{
		}

		// Token: 0x06005A85 RID: 23173 RVA: 0x0033D6E4 File Offset: 0x0033C6E4
		public DateTimeStackedColumnSeriesElement(string name, float borderWidth, Color borderColor) : this(name, null, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005A86 RID: 23174 RVA: 0x0033D6F4 File Offset: 0x0033C6F4
		public DateTimeStackedColumnSeriesElement(string name, Color color, float borderWidth, Color borderColor) : this(name, color, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005A87 RID: 23175 RVA: 0x0033D705 File Offset: 0x0033C705
		public DateTimeStackedColumnSeriesElement(string name, Color color, float borderWidth, Color borderColor, Legend legend) : base(name, color, borderWidth, borderColor, legend)
		{
			base.a(new DateTimeStackedColumnValueList(this));
		}

		// Token: 0x1700093A RID: 2362
		// (get) Token: 0x06005A88 RID: 23176 RVA: 0x0033D73C File Offset: 0x0033C73C
		public DateTimeStackedColumnValueList Values
		{
			get
			{
				return (DateTimeStackedColumnValueList)base.a();
			}
		}

		// Token: 0x06005A89 RID: 23177 RVA: 0x0033D75C File Offset: 0x0033C75C
		internal override DateTime il()
		{
			return this.b;
		}

		// Token: 0x06005A8A RID: 23178 RVA: 0x0033D774 File Offset: 0x0033C774
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

		// Token: 0x06005A8B RID: 23179 RVA: 0x0033D7C0 File Offset: 0x0033C7C0
		internal override DateTime @in()
		{
			return this.a;
		}

		// Token: 0x06005A8C RID: 23180 RVA: 0x0033D7D8 File Offset: 0x0033C7D8
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

		// Token: 0x04002F81 RID: 12161
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F82 RID: 12162
		private new DateTime b = DateTime.MinValue;
	}
}
