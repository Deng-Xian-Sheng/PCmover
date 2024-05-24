using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007D5 RID: 2005
	public class PercentageXAxisLabelList : XAxisLabelList
	{
		// Token: 0x06005180 RID: 20864 RVA: 0x0028929E File Offset: 0x0028829E
		internal PercentageXAxisLabelList()
		{
		}

		// Token: 0x06005181 RID: 20865 RVA: 0x002892A9 File Offset: 0x002882A9
		public void Add(PercentageXAxisLabel percentageXAxisLabel)
		{
			base.a(percentageXAxisLabel);
		}

		// Token: 0x06005182 RID: 20866 RVA: 0x002892B4 File Offset: 0x002882B4
		public PercentageXAxisLabel AxisLabel(float value1)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base.a(i) is PercentageXAxisLabel)
				{
					PercentageXAxisLabel percentageXAxisLabel = (PercentageXAxisLabel)base.a(i);
					if (percentageXAxisLabel.Value == value1)
					{
						percentageXAxisLabel.a(false);
						return percentageXAxisLabel;
					}
				}
			}
			return null;
		}
	}
}
