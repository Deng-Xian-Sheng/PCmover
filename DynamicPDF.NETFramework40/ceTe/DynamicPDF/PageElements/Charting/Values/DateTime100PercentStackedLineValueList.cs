using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008DF RID: 2271
	public class DateTime100PercentStackedLineValueList : Stacked100PercentLineValueList
	{
		// Token: 0x06005D78 RID: 23928 RVA: 0x0034F6D2 File Offset: 0x0034E6D2
		internal DateTime100PercentStackedLineValueList(DateTime100PercentStackedLineSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005D79 RID: 23929 RVA: 0x0034F6DE File Offset: 0x0034E6DE
		public void Add(DateTime100PercentStackedLineValue lineValue)
		{
			base.a(lineValue);
			this.a(lineValue.Position);
		}

		// Token: 0x06005D7A RID: 23930 RVA: 0x0034F6F8 File Offset: 0x0034E6F8
		public DateTime100PercentStackedLineValue Add(float value1, DateTime obj)
		{
			DateTime100PercentStackedLineValue dateTime100PercentStackedLineValue = new DateTime100PercentStackedLineValue(value1, obj);
			base.a(dateTime100PercentStackedLineValue);
			this.a(obj);
			return dateTime100PercentStackedLineValue;
		}

		// Token: 0x06005D7B RID: 23931 RVA: 0x0034F724 File Offset: 0x0034E724
		internal void a(DateTime A_0)
		{
			if (A_0 != DateTime.MinValue)
			{
				base.b().im(A_0);
				base.b().io(A_0);
			}
		}
	}
}
