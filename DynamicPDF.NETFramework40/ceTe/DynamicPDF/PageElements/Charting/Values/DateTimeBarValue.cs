using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008E2 RID: 2274
	public class DateTimeBarValue : BarValue
	{
		// Token: 0x06005D84 RID: 23940 RVA: 0x0034F875 File Offset: 0x0034E875
		public DateTimeBarValue(float value1, DateTime position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009C0 RID: 2496
		// (get) Token: 0x06005D85 RID: 23941 RVA: 0x0034F888 File Offset: 0x0034E888
		public DateTime Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005D86 RID: 23942 RVA: 0x0034F8A0 File Offset: 0x0034E8A0
		internal override int ir()
		{
			return base.d().b(this.a);
		}

		// Token: 0x04003063 RID: 12387
		private new DateTime a;
	}
}
