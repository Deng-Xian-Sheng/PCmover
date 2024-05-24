using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008FE RID: 2302
	public class Indexed100PercentStackedColumnValue : Stacked100PercentColumnValue
	{
		// Token: 0x06005E6E RID: 24174 RVA: 0x00357702 File Offset: 0x00356702
		public Indexed100PercentStackedColumnValue(float value1, int position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009DF RID: 2527
		// (get) Token: 0x06005E6F RID: 24175 RVA: 0x00357718 File Offset: 0x00356718
		public int Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x040030AB RID: 12459
		private new int a;
	}
}
