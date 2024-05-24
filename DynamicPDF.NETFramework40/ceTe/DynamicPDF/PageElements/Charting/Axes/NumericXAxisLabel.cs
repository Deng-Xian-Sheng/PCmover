using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007CE RID: 1998
	public class NumericXAxisLabel : XAxisLabel
	{
		// Token: 0x06005153 RID: 20819 RVA: 0x0028815C File Offset: 0x0028715C
		public NumericXAxisLabel(string text, float value1) : base(text)
		{
			this.a = value1;
		}

		// Token: 0x06005154 RID: 20820 RVA: 0x0028816F File Offset: 0x0028716F
		public NumericXAxisLabel(string text, float value1, Font font, float fontSize, Color textColor) : base(text, font, fontSize, textColor)
		{
			this.a = value1;
		}

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x06005155 RID: 20821 RVA: 0x00288188 File Offset: 0x00287188
		// (set) Token: 0x06005156 RID: 20822 RVA: 0x002881A0 File Offset: 0x002871A0
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

		// Token: 0x04002B9A RID: 11162
		private new float a;
	}
}
