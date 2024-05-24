using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000902 RID: 2306
	public class IndexedAreaValue : AreaValue
	{
		// Token: 0x06005E7E RID: 24190 RVA: 0x00357956 File Offset: 0x00356956
		public IndexedAreaValue(float value1, int position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009E1 RID: 2529
		// (get) Token: 0x06005E7F RID: 24191 RVA: 0x0035796C File Offset: 0x0035696C
		public int Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x040030AD RID: 12461
		private new int a;
	}
}
