using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008DB RID: 2267
	public class DateTime100PercentStackedColumnValueList : Stacked100PercentColumnValueList
	{
		// Token: 0x06005D53 RID: 23891 RVA: 0x0034E049 File Offset: 0x0034D049
		internal DateTime100PercentStackedColumnValueList(DateTime100PercentStackedColumnSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005D54 RID: 23892 RVA: 0x0034E058 File Offset: 0x0034D058
		public DateTime100PercentStackedColumnValue Add(float value1, DateTime position)
		{
			DateTime100PercentStackedColumnValue dateTime100PercentStackedColumnValue = new DateTime100PercentStackedColumnValue(value1, position);
			base.a(dateTime100PercentStackedColumnValue);
			return dateTime100PercentStackedColumnValue;
		}

		// Token: 0x06005D55 RID: 23893 RVA: 0x0034E07B File Offset: 0x0034D07B
		public void Add(DateTime100PercentStackedColumnValue dateTimeStackedColumnValue)
		{
			base.a(dateTimeStackedColumnValue);
		}
	}
}
