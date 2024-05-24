using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x0200090E RID: 2318
	public class IndexedStackedColumnValue : StackedColumnValue
	{
		// Token: 0x06005EB0 RID: 24240 RVA: 0x003580DE File Offset: 0x003570DE
		public IndexedStackedColumnValue(float value1, int position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009E7 RID: 2535
		// (get) Token: 0x06005EB1 RID: 24241 RVA: 0x003580F4 File Offset: 0x003570F4
		public int Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x040030B3 RID: 12467
		private new int a;
	}
}
