using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000908 RID: 2312
	public class IndexedLineValue : LineValue
	{
		// Token: 0x06005E96 RID: 24214 RVA: 0x00357CC6 File Offset: 0x00356CC6
		public IndexedLineValue(float value1, int position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009E4 RID: 2532
		// (get) Token: 0x06005E97 RID: 24215 RVA: 0x00357CDC File Offset: 0x00356CDC
		public int Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x040030B0 RID: 12464
		private new int a;
	}
}
