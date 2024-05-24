using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007C2 RID: 1986
	public class DateTimeYAxisLabelList : YAxisLabelList
	{
		// Token: 0x0600511C RID: 20764 RVA: 0x00286CE3 File Offset: 0x00285CE3
		internal DateTimeYAxisLabelList()
		{
		}

		// Token: 0x0600511D RID: 20765 RVA: 0x00286CEE File Offset: 0x00285CEE
		public void Add(DateTimeYAxisLabel dateTimeYAxisLabel)
		{
			base.a(dateTimeYAxisLabel);
		}

		// Token: 0x0600511E RID: 20766 RVA: 0x00286CFC File Offset: 0x00285CFC
		public DateTimeYAxisLabel AxisLabel(DateTime value1)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base.a(i) is DateTimeYAxisLabel)
				{
					DateTimeYAxisLabel dateTimeYAxisLabel = (DateTimeYAxisLabel)base.a(i);
					DateTimeYAxisLabel result;
					if (dateTimeYAxisLabel.Value.Equals(value1))
					{
						dateTimeYAxisLabel.a(false);
						result = dateTimeYAxisLabel;
					}
					else
					{
						if (Math.Abs(dateTimeYAxisLabel.Value.Ticks - value1.Ticks) >= 1000L)
						{
							goto IL_8C;
						}
						dateTimeYAxisLabel.a(false);
						result = dateTimeYAxisLabel;
					}
					return result;
				}
				IL_8C:;
			}
			return null;
		}
	}
}
