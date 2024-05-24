using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008F5 RID: 2293
	public class DateTimeStackedColumnValueList : StackedColumnValueList
	{
		// Token: 0x06005E36 RID: 24118 RVA: 0x00355EED File Offset: 0x00354EED
		internal DateTimeStackedColumnValueList(DateTimeStackedColumnSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005E37 RID: 24119 RVA: 0x00355EFC File Offset: 0x00354EFC
		public DateTimeStackedColumnValue Add(float value1, DateTime position)
		{
			DateTimeStackedColumnValue dateTimeStackedColumnValue = new DateTimeStackedColumnValue(value1, position);
			base.a(dateTimeStackedColumnValue);
			return dateTimeStackedColumnValue;
		}

		// Token: 0x06005E38 RID: 24120 RVA: 0x00355F1F File Offset: 0x00354F1F
		public void Add(DateTimeStackedColumnValue dateTimeStackedColumnValue)
		{
			base.a(dateTimeStackedColumnValue);
		}
	}
}
