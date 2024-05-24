using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007D4 RID: 2004
	public class PercentageXAxisLabel : XAxisLabel
	{
		// Token: 0x0600517C RID: 20860 RVA: 0x00289250 File Offset: 0x00288250
		public PercentageXAxisLabel(string text, float value1) : base(text)
		{
			this.a = value1;
		}

		// Token: 0x0600517D RID: 20861 RVA: 0x00289263 File Offset: 0x00288263
		public PercentageXAxisLabel(string text, float value1, Font font, float fontSize, Color textColor) : base(text, font, fontSize, textColor)
		{
			this.a = value1;
		}

		// Token: 0x17000701 RID: 1793
		// (get) Token: 0x0600517E RID: 20862 RVA: 0x0028927C File Offset: 0x0028827C
		// (set) Token: 0x0600517F RID: 20863 RVA: 0x00289294 File Offset: 0x00288294
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

		// Token: 0x04002BA2 RID: 11170
		private new float a;
	}
}
