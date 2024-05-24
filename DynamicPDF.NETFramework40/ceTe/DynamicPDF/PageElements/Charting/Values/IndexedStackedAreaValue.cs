using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x0200090A RID: 2314
	public class IndexedStackedAreaValue : StackedAreaValue
	{
		// Token: 0x06005EA0 RID: 24224 RVA: 0x00357E93 File Offset: 0x00356E93
		public IndexedStackedAreaValue(float value1, int position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009E5 RID: 2533
		// (get) Token: 0x06005EA1 RID: 24225 RVA: 0x00357EA8 File Offset: 0x00356EA8
		public int Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x040030B1 RID: 12465
		private new int a;
	}
}
