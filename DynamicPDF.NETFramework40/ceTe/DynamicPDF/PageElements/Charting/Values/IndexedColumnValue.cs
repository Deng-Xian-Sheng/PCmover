using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000906 RID: 2310
	public class IndexedColumnValue : ColumnValue
	{
		// Token: 0x06005E8F RID: 24207 RVA: 0x00357BF2 File Offset: 0x00356BF2
		public IndexedColumnValue(float value1, int position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009E3 RID: 2531
		// (get) Token: 0x06005E90 RID: 24208 RVA: 0x00357C08 File Offset: 0x00356C08
		public int Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x040030AF RID: 12463
		private new int a;
	}
}
