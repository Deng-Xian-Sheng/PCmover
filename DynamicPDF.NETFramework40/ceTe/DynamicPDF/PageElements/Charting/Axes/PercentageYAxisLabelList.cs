using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007D8 RID: 2008
	public class PercentageYAxisLabelList : YAxisLabelList
	{
		// Token: 0x06005194 RID: 20884 RVA: 0x002897C6 File Offset: 0x002887C6
		internal PercentageYAxisLabelList()
		{
		}

		// Token: 0x06005195 RID: 20885 RVA: 0x002897D1 File Offset: 0x002887D1
		public void Add(PercentageYAxisLabel percentageAxisLabel)
		{
			base.a(percentageAxisLabel);
		}

		// Token: 0x06005196 RID: 20886 RVA: 0x002897DC File Offset: 0x002887DC
		public PercentageYAxisLabel AxisLabel(float value1)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base.a(i) is PercentageYAxisLabel)
				{
					PercentageYAxisLabel percentageYAxisLabel = (PercentageYAxisLabel)base.a(i);
					if (percentageYAxisLabel.Value == value1)
					{
						percentageYAxisLabel.a(false);
						return percentageYAxisLabel;
					}
				}
			}
			return null;
		}
	}
}
