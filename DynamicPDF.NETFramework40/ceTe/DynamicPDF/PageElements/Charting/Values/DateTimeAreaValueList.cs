using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008E1 RID: 2273
	public class DateTimeAreaValueList : AreaValueList
	{
		// Token: 0x06005D7F RID: 23935 RVA: 0x0034F7AF File Offset: 0x0034E7AF
		internal DateTimeAreaValueList(DateTimeAreaSeries A_0) : base(A_0)
		{
		}

		// Token: 0x06005D80 RID: 23936 RVA: 0x0034F7BC File Offset: 0x0034E7BC
		public DateTimeAreaValue Add(float value1, DateTime obj)
		{
			DateTimeAreaValue dateTimeAreaValue = new DateTimeAreaValue(value1, obj);
			base.a(dateTimeAreaValue);
			this.a(obj);
			this.a(value1);
			return dateTimeAreaValue;
		}

		// Token: 0x06005D81 RID: 23937 RVA: 0x0034F7EF File Offset: 0x0034E7EF
		public void Add(DateTimeAreaValue areaValue)
		{
			base.a(areaValue);
			this.a(areaValue.Position);
			this.a(areaValue.Value);
		}

		// Token: 0x06005D82 RID: 23938 RVA: 0x0034F814 File Offset: 0x0034E814
		internal void a(float A_0)
		{
			AreaSeries areaSeries = base.c();
			areaSeries.a(A_0);
			areaSeries.b(A_0);
		}

		// Token: 0x06005D83 RID: 23939 RVA: 0x0034F83C File Offset: 0x0034E83C
		internal void a(DateTime A_0)
		{
			AreaSeries areaSeries = base.c();
			if (A_0 != DateTime.MinValue)
			{
				areaSeries.ii(A_0);
				areaSeries.ik(A_0);
			}
		}
	}
}
