using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008FC RID: 2300
	public class Indexed100PercentStackedBarValue : Stacked100PercentBarValue
	{
		// Token: 0x06005E67 RID: 24167 RVA: 0x00357631 File Offset: 0x00356631
		public Indexed100PercentStackedBarValue(float value1, int position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009DE RID: 2526
		// (get) Token: 0x06005E68 RID: 24168 RVA: 0x00357644 File Offset: 0x00356644
		public int Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x040030AA RID: 12458
		private new int a;
	}
}
