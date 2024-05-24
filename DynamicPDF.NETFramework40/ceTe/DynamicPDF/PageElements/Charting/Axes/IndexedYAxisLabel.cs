using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007C7 RID: 1991
	public class IndexedYAxisLabel : YAxisLabel
	{
		// Token: 0x0600513E RID: 20798 RVA: 0x0028753D File Offset: 0x0028653D
		public IndexedYAxisLabel(string text, int value1) : base(text)
		{
			this.a = value1;
		}

		// Token: 0x0600513F RID: 20799 RVA: 0x00287550 File Offset: 0x00286550
		public IndexedYAxisLabel(string text, int value1, Font font, float fontSize, Color textColor) : base(text, font, fontSize, textColor)
		{
			this.a = value1;
		}

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x06005140 RID: 20800 RVA: 0x00287568 File Offset: 0x00286568
		// (set) Token: 0x06005141 RID: 20801 RVA: 0x00287580 File Offset: 0x00286580
		public int Value
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x04002B7D RID: 11133
		private new int a;
	}
}
