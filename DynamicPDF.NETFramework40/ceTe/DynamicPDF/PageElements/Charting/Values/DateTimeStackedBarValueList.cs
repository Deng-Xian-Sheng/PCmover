using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008F1 RID: 2289
	public class DateTimeStackedBarValueList : StackedBarValueList
	{
		// Token: 0x06005E0B RID: 24075 RVA: 0x00354761 File Offset: 0x00353761
		internal DateTimeStackedBarValueList(DateTimeStackedBarSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005E0C RID: 24076 RVA: 0x00354770 File Offset: 0x00353770
		public DateTimeStackedBarValue Add(float value1, DateTime position)
		{
			DateTimeStackedBarValue dateTimeStackedBarValue = new DateTimeStackedBarValue(value1, position);
			base.a(dateTimeStackedBarValue);
			return dateTimeStackedBarValue;
		}

		// Token: 0x06005E0D RID: 24077 RVA: 0x00354793 File Offset: 0x00353793
		public void Add(DateTimeStackedBarValue dateTimeStackedBarValue)
		{
			base.a(dateTimeStackedBarValue);
		}
	}
}
