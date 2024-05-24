using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008A2 RID: 2210
	public class DateTimeStackedAreaSeriesElement : StackedAreaSeriesElement
	{
		// Token: 0x06005A2F RID: 23087 RVA: 0x0033C8C8 File Offset: 0x0033B8C8
		public DateTimeStackedAreaSeriesElement(string name) : this(name, null, null, null)
		{
		}

		// Token: 0x06005A30 RID: 23088 RVA: 0x0033C8D7 File Offset: 0x0033B8D7
		public DateTimeStackedAreaSeriesElement(string name, Color color) : this(name, color, null, null)
		{
		}

		// Token: 0x06005A31 RID: 23089 RVA: 0x0033C8E6 File Offset: 0x0033B8E6
		public DateTimeStackedAreaSeriesElement(string name, Color color, Legend legend) : this(name, color, null, legend)
		{
		}

		// Token: 0x06005A32 RID: 23090 RVA: 0x0033C8F5 File Offset: 0x0033B8F5
		public DateTimeStackedAreaSeriesElement(string name, Color color, Marker marker) : this(name, color, marker, null)
		{
		}

		// Token: 0x06005A33 RID: 23091 RVA: 0x0033C904 File Offset: 0x0033B904
		public DateTimeStackedAreaSeriesElement(string name, Color color, Marker marker, Legend legend) : base(name, color, marker, legend)
		{
			base.a(new DateTimeStackedAreaValueList(this));
		}

		// Token: 0x06005A34 RID: 23092 RVA: 0x0033C938 File Offset: 0x0033B938
		internal override DateTime il()
		{
			return this.b;
		}

		// Token: 0x06005A35 RID: 23093 RVA: 0x0033C950 File Offset: 0x0033B950
		internal override void im(DateTime A_0)
		{
			if (this.b == DateTime.MinValue)
			{
				this.b = A_0;
			}
			else if (DateTime.Compare(A_0, this.b) > 0)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005A36 RID: 23094 RVA: 0x0033C99C File Offset: 0x0033B99C
		internal override DateTime @in()
		{
			return this.a;
		}

		// Token: 0x06005A37 RID: 23095 RVA: 0x0033C9B4 File Offset: 0x0033B9B4
		internal override void io(DateTime A_0)
		{
			if (this.a == DateTime.MinValue)
			{
				this.a = A_0;
			}
			else if (DateTime.Compare(A_0, this.a) < 0)
			{
				this.a = A_0;
			}
		}

		// Token: 0x1700092C RID: 2348
		// (get) Token: 0x06005A38 RID: 23096 RVA: 0x0033CA00 File Offset: 0x0033BA00
		public DateTimeStackedAreaValueList Values
		{
			get
			{
				return (DateTimeStackedAreaValueList)base.a();
			}
		}

		// Token: 0x04002F6F RID: 12143
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F70 RID: 12144
		private new DateTime b = DateTime.MinValue;
	}
}
