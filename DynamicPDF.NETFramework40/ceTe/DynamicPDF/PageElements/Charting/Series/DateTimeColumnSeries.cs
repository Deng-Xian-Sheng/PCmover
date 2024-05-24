using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x0200089B RID: 2203
	public class DateTimeColumnSeries : ColumnSeries
	{
		// Token: 0x060059DA RID: 23002 RVA: 0x0033BA1C File Offset: 0x0033AA1C
		public DateTimeColumnSeries(string name) : this(name, null, null, null, 0f, null, null)
		{
		}

		// Token: 0x060059DB RID: 23003 RVA: 0x0033BA32 File Offset: 0x0033AA32
		public DateTimeColumnSeries(string name, Color color) : this(name, null, null, color, 0f, null, null)
		{
		}

		// Token: 0x060059DC RID: 23004 RVA: 0x0033BA48 File Offset: 0x0033AA48
		public DateTimeColumnSeries(string name, DateTimeXAxis dateTimeXAxis, NumericYAxis numericYAxis) : this(name, dateTimeXAxis, numericYAxis, null, 0f, null, null)
		{
		}

		// Token: 0x060059DD RID: 23005 RVA: 0x0033BA5E File Offset: 0x0033AA5E
		public DateTimeColumnSeries(string name, DateTimeXAxis dateTimeXAxis) : this(name, dateTimeXAxis, null, null, 0f, null, null)
		{
		}

		// Token: 0x060059DE RID: 23006 RVA: 0x0033BA74 File Offset: 0x0033AA74
		public DateTimeColumnSeries(string name, NumericYAxis numericYAxis) : this(name, null, numericYAxis, null, 0f, null, null)
		{
		}

		// Token: 0x060059DF RID: 23007 RVA: 0x0033BA8A File Offset: 0x0033AA8A
		public DateTimeColumnSeries(string name, DateTimeXAxis dateTimeXAxis, NumericYAxis numericYAxis, Color color) : this(name, dateTimeXAxis, numericYAxis, color, 0f, null, null)
		{
		}

		// Token: 0x060059E0 RID: 23008 RVA: 0x0033BAA1 File Offset: 0x0033AAA1
		public DateTimeColumnSeries(string name, DateTimeXAxis dateTimeXAxis, NumericYAxis numericYAxis, Color color, Legend legend) : this(name, dateTimeXAxis, numericYAxis, color, 0f, null, legend)
		{
		}

		// Token: 0x060059E1 RID: 23009 RVA: 0x0033BAB9 File Offset: 0x0033AAB9
		public DateTimeColumnSeries(string name, DateTimeXAxis dateTimeXAxis, NumericYAxis numericYAxis, Color color, float borderWidth) : this(name, dateTimeXAxis, numericYAxis, color, borderWidth, null, null)
		{
		}

		// Token: 0x060059E2 RID: 23010 RVA: 0x0033BACD File Offset: 0x0033AACD
		public DateTimeColumnSeries(string name, DateTimeXAxis dateTimeXAxis, NumericYAxis numericYAxis, float borderWidth, Color borderColor) : this(name, dateTimeXAxis, numericYAxis, null, borderWidth, borderColor, null)
		{
		}

		// Token: 0x060059E3 RID: 23011 RVA: 0x0033BAE1 File Offset: 0x0033AAE1
		public DateTimeColumnSeries(string name, DateTimeXAxis dateTimeXAxis, NumericYAxis numericYAxis, Color color, float borderWidth, Color borderColor) : this(name, dateTimeXAxis, numericYAxis, color, borderWidth, borderColor, null)
		{
		}

		// Token: 0x060059E4 RID: 23012 RVA: 0x0033BAF6 File Offset: 0x0033AAF6
		public DateTimeColumnSeries(string name, DateTimeXAxis dateTimeXAxis, NumericYAxis numericYAxis, Color color, float borderWidth, Color borderColor, Legend legend) : base(name, dateTimeXAxis, numericYAxis, color, borderWidth, borderColor, legend)
		{
			base.a(new DateTimeColumnValueList(this));
		}

		// Token: 0x1700091A RID: 2330
		// (get) Token: 0x060059E5 RID: 23013 RVA: 0x0033BB30 File Offset: 0x0033AB30
		public DateTimeColumnValueList Values
		{
			get
			{
				return (DateTimeColumnValueList)base.a();
			}
		}

		// Token: 0x1700091B RID: 2331
		// (get) Token: 0x060059E6 RID: 23014 RVA: 0x0033BB50 File Offset: 0x0033AB50
		public DateTimeXAxis XAxis
		{
			get
			{
				return (DateTimeXAxis)base.m();
			}
		}

		// Token: 0x1700091C RID: 2332
		// (get) Token: 0x060059E7 RID: 23015 RVA: 0x0033BB70 File Offset: 0x0033AB70
		public NumericYAxis YAxis
		{
			get
			{
				return (NumericYAxis)base.n();
			}
		}

		// Token: 0x060059E8 RID: 23016 RVA: 0x0033BB90 File Offset: 0x0033AB90
		internal override DateTime ih()
		{
			return this.b;
		}

		// Token: 0x060059E9 RID: 23017 RVA: 0x0033BBA8 File Offset: 0x0033ABA8
		internal override void ii(DateTime A_0)
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

		// Token: 0x060059EA RID: 23018 RVA: 0x0033BBF4 File Offset: 0x0033ABF4
		internal override DateTime ij()
		{
			return this.a;
		}

		// Token: 0x060059EB RID: 23019 RVA: 0x0033BC0C File Offset: 0x0033AC0C
		internal override void ik(DateTime A_0)
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

		// Token: 0x04002F5C RID: 12124
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F5D RID: 12125
		private new DateTime b = DateTime.MinValue;
	}
}
