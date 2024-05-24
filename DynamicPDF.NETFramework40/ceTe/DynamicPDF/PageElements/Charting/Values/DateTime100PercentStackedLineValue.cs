using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008DD RID: 2269
	public class DateTime100PercentStackedLineValue : Stacked100PercentLineValue
	{
		// Token: 0x06005D63 RID: 23907 RVA: 0x0034E846 File Offset: 0x0034D846
		public DateTime100PercentStackedLineValue(float value1, DateTime position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009BC RID: 2492
		// (get) Token: 0x06005D64 RID: 23908 RVA: 0x0034E85C File Offset: 0x0034D85C
		public DateTime Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005D65 RID: 23909 RVA: 0x0034E874 File Offset: 0x0034D874
		internal int a()
		{
			return base.e().a(this.a);
		}

		// Token: 0x0400305D RID: 12381
		private new DateTime a;
	}
}
