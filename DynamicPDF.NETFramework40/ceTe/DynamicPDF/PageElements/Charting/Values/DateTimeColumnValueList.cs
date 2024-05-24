using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008E5 RID: 2277
	public class DateTimeColumnValueList : ColumnValueList
	{
		// Token: 0x06005D8D RID: 23949 RVA: 0x0034F94F File Offset: 0x0034E94F
		internal DateTimeColumnValueList(DateTimeColumnSeries A_0) : base(A_0)
		{
		}

		// Token: 0x06005D8E RID: 23950 RVA: 0x0034F95C File Offset: 0x0034E95C
		public DateTimeColumnValue Add(float value1, DateTime position)
		{
			DateTimeColumnValue dateTimeColumnValue = new DateTimeColumnValue(value1, position);
			base.a(dateTimeColumnValue);
			return dateTimeColumnValue;
		}

		// Token: 0x06005D8F RID: 23951 RVA: 0x0034F97F File Offset: 0x0034E97F
		public void Add(DateTimeColumnValue dateTimeColumnValue)
		{
			base.a(dateTimeColumnValue);
		}
	}
}
