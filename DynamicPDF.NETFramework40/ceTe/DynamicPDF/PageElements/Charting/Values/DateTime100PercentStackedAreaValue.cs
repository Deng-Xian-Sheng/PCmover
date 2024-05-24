using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008D1 RID: 2257
	public class DateTime100PercentStackedAreaValue : Stacked100PercentAreaValue
	{
		// Token: 0x06005CE7 RID: 23783 RVA: 0x0034A533 File Offset: 0x00349533
		public DateTime100PercentStackedAreaValue(float value1, DateTime position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009AB RID: 2475
		// (get) Token: 0x06005CE8 RID: 23784 RVA: 0x0034A548 File Offset: 0x00349548
		public DateTime Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005CE9 RID: 23785 RVA: 0x0034A560 File Offset: 0x00349560
		internal int a()
		{
			return base.g().a(this.a);
		}

		// Token: 0x04003032 RID: 12338
		private new DateTime a;
	}
}
