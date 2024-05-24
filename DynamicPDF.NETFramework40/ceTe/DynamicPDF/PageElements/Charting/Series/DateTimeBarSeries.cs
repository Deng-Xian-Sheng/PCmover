using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x0200089A RID: 2202
	public class DateTimeBarSeries : BarSeries
	{
		// Token: 0x060059C8 RID: 22984 RVA: 0x0033B7E1 File Offset: 0x0033A7E1
		public DateTimeBarSeries(string name) : this(name, null, null, null, 0f, null, null)
		{
		}

		// Token: 0x060059C9 RID: 22985 RVA: 0x0033B7F7 File Offset: 0x0033A7F7
		public DateTimeBarSeries(string name, Color color) : this(name, null, null, color, 0f, null, null)
		{
		}

		// Token: 0x060059CA RID: 22986 RVA: 0x0033B80D File Offset: 0x0033A80D
		public DateTimeBarSeries(string name, NumericXAxis numericXAxis, DateTimeYAxis dateTimeYAxis) : this(name, numericXAxis, dateTimeYAxis, null, 0f, null, null)
		{
		}

		// Token: 0x060059CB RID: 22987 RVA: 0x0033B823 File Offset: 0x0033A823
		public DateTimeBarSeries(string name, NumericXAxis numericXAxis) : this(name, numericXAxis, null, null, 0f, null, null)
		{
		}

		// Token: 0x060059CC RID: 22988 RVA: 0x0033B839 File Offset: 0x0033A839
		public DateTimeBarSeries(string name, DateTimeYAxis dateTimeYAxis) : this(name, null, dateTimeYAxis, null, 0f, null, null)
		{
		}

		// Token: 0x060059CD RID: 22989 RVA: 0x0033B84F File Offset: 0x0033A84F
		public DateTimeBarSeries(string name, NumericXAxis numericXAxis, DateTimeYAxis dateTimeYAxis, Color color) : this(name, numericXAxis, dateTimeYAxis, color, 0f, null, null)
		{
		}

		// Token: 0x060059CE RID: 22990 RVA: 0x0033B866 File Offset: 0x0033A866
		public DateTimeBarSeries(string name, NumericXAxis numericXAxis, DateTimeYAxis dateTimeYAxis, Color color, Legend legend) : this(name, numericXAxis, dateTimeYAxis, color, 0f, null, legend)
		{
		}

		// Token: 0x060059CF RID: 22991 RVA: 0x0033B87E File Offset: 0x0033A87E
		public DateTimeBarSeries(string name, NumericXAxis numericXAxis, DateTimeYAxis dateTimeYAxis, Color color, float borderWidth) : this(name, numericXAxis, dateTimeYAxis, color, borderWidth, null, null)
		{
		}

		// Token: 0x060059D0 RID: 22992 RVA: 0x0033B892 File Offset: 0x0033A892
		public DateTimeBarSeries(string name, NumericXAxis numericXAxis, DateTimeYAxis dateTimeYAxis, float borderWidth, Color borderColor) : this(name, numericXAxis, dateTimeYAxis, null, borderWidth, borderColor, null)
		{
		}

		// Token: 0x060059D1 RID: 22993 RVA: 0x0033B8A6 File Offset: 0x0033A8A6
		public DateTimeBarSeries(string name, NumericXAxis numericXAxis, DateTimeYAxis dateTimeYAxis, Color color, float borderWidth, Color borderColor) : this(name, numericXAxis, dateTimeYAxis, color, borderWidth, borderColor, null)
		{
		}

		// Token: 0x060059D2 RID: 22994 RVA: 0x0033B8BB File Offset: 0x0033A8BB
		public DateTimeBarSeries(string name, NumericXAxis numericXAxis, DateTimeYAxis dateTimeYAxis, Color color, float borderWidth, Color borderColor, Legend legend) : base(name, numericXAxis, dateTimeYAxis, color, borderWidth, borderColor, legend)
		{
			base.a(new DateTimeBarValueList(this));
		}

		// Token: 0x17000917 RID: 2327
		// (get) Token: 0x060059D3 RID: 22995 RVA: 0x0033B8F4 File Offset: 0x0033A8F4
		public DateTimeBarValueList Values
		{
			get
			{
				return (DateTimeBarValueList)base.a();
			}
		}

		// Token: 0x17000918 RID: 2328
		// (get) Token: 0x060059D4 RID: 22996 RVA: 0x0033B914 File Offset: 0x0033A914
		public NumericXAxis XAxis
		{
			get
			{
				return (NumericXAxis)base.m();
			}
		}

		// Token: 0x17000919 RID: 2329
		// (get) Token: 0x060059D5 RID: 22997 RVA: 0x0033B934 File Offset: 0x0033A934
		public DateTimeYAxis YAxis
		{
			get
			{
				return (DateTimeYAxis)base.n();
			}
		}

		// Token: 0x060059D6 RID: 22998 RVA: 0x0033B954 File Offset: 0x0033A954
		internal override DateTime ih()
		{
			return this.b;
		}

		// Token: 0x060059D7 RID: 22999 RVA: 0x0033B96C File Offset: 0x0033A96C
		internal override void ii(DateTime A_0)
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

		// Token: 0x060059D8 RID: 23000 RVA: 0x0033B9B8 File Offset: 0x0033A9B8
		internal override DateTime ij()
		{
			return this.a;
		}

		// Token: 0x060059D9 RID: 23001 RVA: 0x0033B9D0 File Offset: 0x0033A9D0
		internal override void ik(DateTime A_0)
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

		// Token: 0x04002F5A RID: 12122
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F5B RID: 12123
		private new DateTime b = DateTime.MinValue;
	}
}
