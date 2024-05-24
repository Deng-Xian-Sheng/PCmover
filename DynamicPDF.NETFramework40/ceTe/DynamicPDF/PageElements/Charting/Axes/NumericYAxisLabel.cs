using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007D1 RID: 2001
	public class NumericYAxisLabel : YAxisLabel
	{
		// Token: 0x06005168 RID: 20840 RVA: 0x00288D28 File Offset: 0x00287D28
		public NumericYAxisLabel(string text, float value1) : base(text)
		{
			this.a = value1;
		}

		// Token: 0x06005169 RID: 20841 RVA: 0x00288D3B File Offset: 0x00287D3B
		public NumericYAxisLabel(string text, float value1, Font font, float fontSize, Color textColor) : base(text, font, fontSize, textColor)
		{
			this.a = value1;
		}

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x0600516A RID: 20842 RVA: 0x00288D54 File Offset: 0x00287D54
		// (set) Token: 0x0600516B RID: 20843 RVA: 0x00288D6C File Offset: 0x00287D6C
		public float Value
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

		// Token: 0x04002B9F RID: 11167
		private new float a;
	}
}
