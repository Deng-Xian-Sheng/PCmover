using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007C1 RID: 1985
	public class YAxisLabelList : AxisLabelList
	{
		// Token: 0x0600511A RID: 20762 RVA: 0x00286C7A File Offset: 0x00285C7A
		internal YAxisLabelList()
		{
		}

		// Token: 0x0600511B RID: 20763 RVA: 0x00286C88 File Offset: 0x00285C88
		internal void a(PageWriter A_0, PlotArea A_1, YAxis A_2)
		{
			for (int i = 0; i < base.Count; i++)
			{
				YAxisLabel yaxisLabel = (YAxisLabel)base.a(i);
				float num = base.d(yaxisLabel);
				if (num != -3.4028235E+38f)
				{
					yaxisLabel.a(A_0, A_1, A_2, num);
				}
			}
		}
	}
}
