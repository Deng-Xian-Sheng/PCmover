using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007D7 RID: 2007
	public class PercentageYAxisLabel : YAxisLabel
	{
		// Token: 0x06005190 RID: 20880 RVA: 0x00289778 File Offset: 0x00288778
		public PercentageYAxisLabel(string text, float value1) : base(text)
		{
			this.a = value1;
		}

		// Token: 0x06005191 RID: 20881 RVA: 0x0028978B File Offset: 0x0028878B
		public PercentageYAxisLabel(string text, float value1, Font font, float fontSize, Color textColor) : base(text, font, fontSize, textColor)
		{
			this.a = value1;
		}

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x06005192 RID: 20882 RVA: 0x002897A4 File Offset: 0x002887A4
		// (set) Token: 0x06005193 RID: 20883 RVA: 0x002897BC File Offset: 0x002887BC
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

		// Token: 0x04002BA5 RID: 11173
		private new float a;
	}
}
