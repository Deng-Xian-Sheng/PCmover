using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000900 RID: 2304
	public class Indexed100PercentStackedLineValue : Stacked100PercentLineValue
	{
		// Token: 0x06005E75 RID: 24181 RVA: 0x003577D6 File Offset: 0x003567D6
		public Indexed100PercentStackedLineValue(float value1, int position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009E0 RID: 2528
		// (get) Token: 0x06005E76 RID: 24182 RVA: 0x003577EC File Offset: 0x003567EC
		public int Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x040030AC RID: 12460
		private new int a;
	}
}
