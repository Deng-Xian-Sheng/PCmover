using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008E7 RID: 2279
	public class DateTimeLineValue : LineValue
	{
		// Token: 0x06005D9F RID: 23967 RVA: 0x0035012E File Offset: 0x0034F12E
		public DateTimeLineValue(float value1, DateTime position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009C4 RID: 2500
		// (get) Token: 0x06005DA0 RID: 23968 RVA: 0x00350144 File Offset: 0x0034F144
		public DateTime Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005DA1 RID: 23969 RVA: 0x0035015C File Offset: 0x0034F15C
		internal int a()
		{
			return base.e().a(this.a);
		}

		// Token: 0x0400306B RID: 12395
		private new DateTime a;
	}
}
