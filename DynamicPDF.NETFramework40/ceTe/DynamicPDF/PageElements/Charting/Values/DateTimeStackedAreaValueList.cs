using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008ED RID: 2285
	public class DateTimeStackedAreaValueList : StackedAreaValueList
	{
		// Token: 0x06005DDF RID: 24031 RVA: 0x00353025 File Offset: 0x00352025
		public DateTimeStackedAreaValueList(DateTimeStackedAreaSeriesElement areaSeries) : base(areaSeries)
		{
		}

		// Token: 0x06005DE0 RID: 24032 RVA: 0x00353034 File Offset: 0x00352034
		public DateTimeStackedAreaValue Add(float value1, DateTime obj)
		{
			DateTimeStackedAreaValue dateTimeStackedAreaValue = new DateTimeStackedAreaValue(value1, obj);
			base.a(dateTimeStackedAreaValue);
			this.a(obj);
			return dateTimeStackedAreaValue;
		}

		// Token: 0x06005DE1 RID: 24033 RVA: 0x0035305F File Offset: 0x0035205F
		public void Add(DateTimeStackedAreaValue areaValue)
		{
			base.a(areaValue);
			this.a(areaValue.Position);
		}

		// Token: 0x06005DE2 RID: 24034 RVA: 0x00353078 File Offset: 0x00352078
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
