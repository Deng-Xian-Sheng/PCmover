using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000904 RID: 2308
	public class IndexedBarValue : BarValue
	{
		// Token: 0x06005E88 RID: 24200 RVA: 0x00357B1F File Offset: 0x00356B1F
		public IndexedBarValue(float value1, int position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009E2 RID: 2530
		// (get) Token: 0x06005E89 RID: 24201 RVA: 0x00357B34 File Offset: 0x00356B34
		public int Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x040030AE RID: 12462
		private new int a;
	}
}
