using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x0200090C RID: 2316
	public class IndexedStackedBarValue : StackedBarValue
	{
		// Token: 0x06005EA9 RID: 24233 RVA: 0x0035800D File Offset: 0x0035700D
		public IndexedStackedBarValue(float value1, int position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009E6 RID: 2534
		// (get) Token: 0x06005EAA RID: 24234 RVA: 0x00358020 File Offset: 0x00357020
		public int Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x040030B2 RID: 12466
		private new int a;
	}
}
