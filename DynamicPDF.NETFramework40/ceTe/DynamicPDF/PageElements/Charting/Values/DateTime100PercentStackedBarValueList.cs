using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008D7 RID: 2263
	public class DateTime100PercentStackedBarValueList : Stacked100PercentBarValueList
	{
		// Token: 0x06005D27 RID: 23847 RVA: 0x0034C88D File Offset: 0x0034B88D
		internal DateTime100PercentStackedBarValueList(DateTime100PercentStackedBarSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005D28 RID: 23848 RVA: 0x0034C89C File Offset: 0x0034B89C
		public DateTime100PercentStackedBarValue Add(float value1, DateTime position)
		{
			DateTime100PercentStackedBarValue dateTime100PercentStackedBarValue = new DateTime100PercentStackedBarValue(value1, position);
			base.a(dateTime100PercentStackedBarValue);
			return dateTime100PercentStackedBarValue;
		}

		// Token: 0x06005D29 RID: 23849 RVA: 0x0034C8BF File Offset: 0x0034B8BF
		public void Add(DateTime100PercentStackedBarValue dateTimeStackedBarValue)
		{
			base.a(dateTimeStackedBarValue);
		}
	}
}
