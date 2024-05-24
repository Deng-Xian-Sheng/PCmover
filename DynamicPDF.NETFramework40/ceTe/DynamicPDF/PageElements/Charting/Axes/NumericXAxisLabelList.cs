using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007CF RID: 1999
	public class NumericXAxisLabelList : XAxisLabelList
	{
		// Token: 0x06005157 RID: 20823 RVA: 0x002881AA File Offset: 0x002871AA
		internal NumericXAxisLabelList()
		{
		}

		// Token: 0x06005158 RID: 20824 RVA: 0x002881B5 File Offset: 0x002871B5
		public void Add(NumericXAxisLabel numericXAxisLabel)
		{
			base.a(numericXAxisLabel);
		}

		// Token: 0x06005159 RID: 20825 RVA: 0x002881C0 File Offset: 0x002871C0
		public NumericXAxisLabel AxisLabel(float value1)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (((XAxisLabel)base.a(i)) is NumericXAxisLabel)
				{
					NumericXAxisLabel numericXAxisLabel = (NumericXAxisLabel)base.a(i);
					if (numericXAxisLabel.Value == value1)
					{
						numericXAxisLabel.a(false);
						return numericXAxisLabel;
					}
				}
			}
			return null;
		}
	}
}
