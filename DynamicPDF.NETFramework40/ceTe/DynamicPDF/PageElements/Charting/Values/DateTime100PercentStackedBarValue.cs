using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008D5 RID: 2261
	public class DateTime100PercentStackedBarValue : Stacked100PercentBarValue
	{
		// Token: 0x06005D16 RID: 23830 RVA: 0x0034BFFB File Offset: 0x0034AFFB
		public DateTime100PercentStackedBarValue(float value1, DateTime position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009B1 RID: 2481
		// (get) Token: 0x06005D17 RID: 23831 RVA: 0x0034C010 File Offset: 0x0034B010
		public DateTime Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005D18 RID: 23832 RVA: 0x0034C028 File Offset: 0x0034B028
		internal override int ip()
		{
			return base.b().b(this.a);
		}

		// Token: 0x04003043 RID: 12355
		private new DateTime a;
	}
}
