using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007D2 RID: 2002
	public class NumericYAxisLabelList : YAxisLabelList
	{
		// Token: 0x0600516C RID: 20844 RVA: 0x00288D76 File Offset: 0x00287D76
		internal NumericYAxisLabelList()
		{
		}

		// Token: 0x0600516D RID: 20845 RVA: 0x00288D81 File Offset: 0x00287D81
		public void Add(NumericYAxisLabel numericYAxisLabel)
		{
			base.a(numericYAxisLabel);
		}

		// Token: 0x0600516E RID: 20846 RVA: 0x00288D8C File Offset: 0x00287D8C
		public NumericYAxisLabel AxisLabel(float value1)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base.a(i) is NumericYAxisLabel)
				{
					NumericYAxisLabel numericYAxisLabel = (NumericYAxisLabel)base.a(i);
					if (numericYAxisLabel.Value == value1)
					{
						numericYAxisLabel.a(false);
						return numericYAxisLabel;
					}
				}
			}
			return null;
		}
	}
}
