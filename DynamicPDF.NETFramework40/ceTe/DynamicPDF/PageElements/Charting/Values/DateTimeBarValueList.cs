using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008E3 RID: 2275
	public class DateTimeBarValueList : BarValueList
	{
		// Token: 0x06005D87 RID: 23943 RVA: 0x0034F8C3 File Offset: 0x0034E8C3
		internal DateTimeBarValueList(DateTimeBarSeries A_0) : base(A_0)
		{
		}

		// Token: 0x06005D88 RID: 23944 RVA: 0x0034F8D0 File Offset: 0x0034E8D0
		public DateTimeBarValue Add(float value1, DateTime position)
		{
			DateTimeBarValue dateTimeBarValue = new DateTimeBarValue(value1, position);
			base.a(dateTimeBarValue);
			return dateTimeBarValue;
		}

		// Token: 0x06005D89 RID: 23945 RVA: 0x0034F8F3 File Offset: 0x0034E8F3
		public void Add(DateTimeBarValue dateTimeBarValue)
		{
			base.a(dateTimeBarValue);
		}
	}
}
