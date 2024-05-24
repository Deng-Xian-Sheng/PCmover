using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008F9 RID: 2297
	public class DateTimeStackedLineValueList : StackedLineValueList
	{
		// Token: 0x06005E5A RID: 24154 RVA: 0x0035742A File Offset: 0x0035642A
		internal DateTimeStackedLineValueList(DateTimeStackedLineSeriesElement A_0) : base(A_0)
		{
		}

		// Token: 0x06005E5B RID: 24155 RVA: 0x00357436 File Offset: 0x00356436
		public void Add(DateTimeStackedLineValue lineValue)
		{
			base.a(lineValue);
			this.a(lineValue.Position);
		}

		// Token: 0x06005E5C RID: 24156 RVA: 0x00357450 File Offset: 0x00356450
		public DateTimeStackedLineValue Add(float value1, DateTime obj)
		{
			DateTimeStackedLineValue dateTimeStackedLineValue = new DateTimeStackedLineValue(value1, obj);
			base.a(dateTimeStackedLineValue);
			this.a(obj);
			return dateTimeStackedLineValue;
		}

		// Token: 0x06005E5D RID: 24157 RVA: 0x0035747C File Offset: 0x0035647C
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
