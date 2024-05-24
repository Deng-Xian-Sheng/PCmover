using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008D9 RID: 2265
	public class DateTime100PercentStackedColumnValue : Stacked100PercentColumnValue
	{
		// Token: 0x06005D42 RID: 23874 RVA: 0x0034D7B6 File Offset: 0x0034C7B6
		public DateTime100PercentStackedColumnValue(float value1, DateTime position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009B7 RID: 2487
		// (get) Token: 0x06005D43 RID: 23875 RVA: 0x0034D7CC File Offset: 0x0034C7CC
		public DateTime Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005D44 RID: 23876 RVA: 0x0034D7E4 File Offset: 0x0034C7E4
		internal override int iq()
		{
			return base.b().a(this.a);
		}

		// Token: 0x04003053 RID: 12371
		private new DateTime a;
	}
}
