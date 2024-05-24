using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008E9 RID: 2281
	public class DateTimeLineValueList : LineValueList
	{
		// Token: 0x06005DAF RID: 23983 RVA: 0x00350F7B File Offset: 0x0034FF7B
		internal DateTimeLineValueList(DateTimeLineSeries A_0) : base(A_0)
		{
		}

		// Token: 0x06005DB0 RID: 23984 RVA: 0x00350F87 File Offset: 0x0034FF87
		public void Add(DateTimeLineValue lineValue)
		{
			base.a(lineValue);
			this.a(lineValue.Position);
			this.a(lineValue.Value);
		}

		// Token: 0x06005DB1 RID: 23985 RVA: 0x00350FAC File Offset: 0x0034FFAC
		public DateTimeLineValue Add(float value1, DateTime obj)
		{
			DateTimeLineValue dateTimeLineValue = new DateTimeLineValue(value1, obj);
			base.a(dateTimeLineValue);
			this.a(obj);
			this.a(value1);
			return dateTimeLineValue;
		}

		// Token: 0x06005DB2 RID: 23986 RVA: 0x00350FE0 File Offset: 0x0034FFE0
		internal void a(float A_0)
		{
			LineSeries lineSeries = base.c();
			lineSeries.a(A_0);
			lineSeries.b(A_0);
		}

		// Token: 0x06005DB3 RID: 23987 RVA: 0x00351008 File Offset: 0x00350008
		internal void a(DateTime A_0)
		{
			LineSeries lineSeries = base.c();
			if (A_0 != DateTime.MinValue)
			{
				lineSeries.ii(A_0);
				lineSeries.ik(A_0);
			}
		}
	}
}
