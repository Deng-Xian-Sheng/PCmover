using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007BC RID: 1980
	public class DateTimeXAxisLabelList : XAxisLabelList
	{
		// Token: 0x060050CD RID: 20685 RVA: 0x002840BD File Offset: 0x002830BD
		internal DateTimeXAxisLabelList()
		{
		}

		// Token: 0x060050CE RID: 20686 RVA: 0x002840C8 File Offset: 0x002830C8
		public void Add(DateTimeXAxisLabel dateTimeAxisLabel)
		{
			base.a(dateTimeAxisLabel);
		}

		// Token: 0x060050CF RID: 20687 RVA: 0x002840D4 File Offset: 0x002830D4
		public DateTimeXAxisLabel AxisLabel(DateTime value1)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (base.a(i) is DateTimeXAxisLabel)
				{
					DateTimeXAxisLabel dateTimeXAxisLabel = (DateTimeXAxisLabel)base.a(i);
					DateTimeXAxisLabel result;
					if (dateTimeXAxisLabel.Value.Equals(value1))
					{
						dateTimeXAxisLabel.a(false);
						result = dateTimeXAxisLabel;
					}
					else
					{
						if (Math.Abs(dateTimeXAxisLabel.Value.Ticks - value1.Ticks) >= 1000L)
						{
							goto IL_8C;
						}
						dateTimeXAxisLabel.a(false);
						result = dateTimeXAxisLabel;
					}
					return result;
				}
				IL_8C:;
			}
			return null;
		}
	}
}
