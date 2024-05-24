using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008F3 RID: 2291
	public class DateTimeStackedColumnValue : StackedColumnValue
	{
		// Token: 0x06005E25 RID: 24101 RVA: 0x0035565E File Offset: 0x0035465E
		public DateTimeStackedColumnValue(float value1, DateTime position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009D5 RID: 2517
		// (get) Token: 0x06005E26 RID: 24102 RVA: 0x00355674 File Offset: 0x00354674
		public DateTime Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005E27 RID: 24103 RVA: 0x0035568C File Offset: 0x0035468C
		internal override int iu()
		{
			return base.b().a(this.a);
		}

		// Token: 0x0400309A RID: 12442
		private new DateTime a;
	}
}
