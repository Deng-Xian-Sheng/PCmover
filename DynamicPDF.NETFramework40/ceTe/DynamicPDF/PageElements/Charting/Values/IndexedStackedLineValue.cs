using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000910 RID: 2320
	public class IndexedStackedLineValue : StackedLineValue
	{
		// Token: 0x06005EB7 RID: 24247 RVA: 0x003581B2 File Offset: 0x003571B2
		public IndexedStackedLineValue(float value1, int position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009E8 RID: 2536
		// (get) Token: 0x06005EB8 RID: 24248 RVA: 0x003581C8 File Offset: 0x003571C8
		public int Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x040030B4 RID: 12468
		private new int a;
	}
}
