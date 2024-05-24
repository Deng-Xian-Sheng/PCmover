using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008D3 RID: 2259
	public class DateTime100PercentStackedAreaValueList : Stacked100PercentAreaValueList
	{
		// Token: 0x06005CFB RID: 23803 RVA: 0x0034B131 File Offset: 0x0034A131
		internal DateTime100PercentStackedAreaValueList(DateTime100PercentStackedAreaSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005CFC RID: 23804 RVA: 0x0034B140 File Offset: 0x0034A140
		public DateTime100PercentStackedAreaValue Add(float value1, DateTime obj)
		{
			DateTime100PercentStackedAreaValue dateTime100PercentStackedAreaValue = new DateTime100PercentStackedAreaValue(value1, obj);
			base.a(dateTime100PercentStackedAreaValue);
			this.a(obj);
			return dateTime100PercentStackedAreaValue;
		}

		// Token: 0x06005CFD RID: 23805 RVA: 0x0034B16B File Offset: 0x0034A16B
		public void Add(DateTime100PercentStackedAreaValue areaValue)
		{
			base.a(areaValue);
			this.a(areaValue.Position);
		}

		// Token: 0x06005CFE RID: 23806 RVA: 0x0034B184 File Offset: 0x0034A184
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
