using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000887 RID: 2183
	public abstract class Stacked100PercentSeries : StackedSeries
	{
		// Token: 0x06005900 RID: 22784 RVA: 0x00338DDD File Offset: 0x00337DDD
		internal Stacked100PercentSeries(XAxis A_0, YAxis A_1) : base(A_0, A_1, true)
		{
		}

		// Token: 0x06005901 RID: 22785
		internal abstract void @if();
	}
}
