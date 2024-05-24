using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008FA RID: 2298
	public class Indexed100PercentStackedAreaValue : Stacked100PercentAreaValue
	{
		// Token: 0x06005E5E RID: 24158 RVA: 0x003574B8 File Offset: 0x003564B8
		public Indexed100PercentStackedAreaValue(float value1, int position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009DD RID: 2525
		// (get) Token: 0x06005E5F RID: 24159 RVA: 0x003574CC File Offset: 0x003564CC
		public int Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x040030A9 RID: 12457
		private new int a;
	}
}
