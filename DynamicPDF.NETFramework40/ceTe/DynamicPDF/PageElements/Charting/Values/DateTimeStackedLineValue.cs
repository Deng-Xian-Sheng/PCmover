using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008F7 RID: 2295
	public class DateTimeStackedLineValue : StackedLineValue
	{
		// Token: 0x06005E46 RID: 24134 RVA: 0x0035666C File Offset: 0x0035566C
		public DateTimeStackedLineValue(float value1, DateTime position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009DA RID: 2522
		// (get) Token: 0x06005E47 RID: 24135 RVA: 0x00356680 File Offset: 0x00355680
		public DateTime Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005E48 RID: 24136 RVA: 0x00356698 File Offset: 0x00355698
		internal int a()
		{
			return base.e().a(this.a);
		}

		// Token: 0x040030A4 RID: 12452
		private new DateTime a;
	}
}
