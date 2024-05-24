using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007C4 RID: 1988
	public class IndexedXAxisLabel : XAxisLabel
	{
		// Token: 0x0600512B RID: 20779 RVA: 0x00287121 File Offset: 0x00286121
		public IndexedXAxisLabel(string text, int value1) : base(text)
		{
			this.a = value1;
		}

		// Token: 0x0600512C RID: 20780 RVA: 0x00287134 File Offset: 0x00286134
		public IndexedXAxisLabel(string text, int value1, Font font, float fontSize, Color textColor) : base(text, font, fontSize, textColor)
		{
			this.a = value1;
		}

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x0600512D RID: 20781 RVA: 0x0028714C File Offset: 0x0028614C
		// (set) Token: 0x0600512E RID: 20782 RVA: 0x00287164 File Offset: 0x00286164
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

		// Token: 0x04002B7A RID: 11130
		private new int a;
	}
}
