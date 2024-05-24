using System;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x02000798 RID: 1944
	public class BarColumnPercentageDataLabel : PercentageDataLabel
	{
		// Token: 0x06004E85 RID: 20101 RVA: 0x00276462 File Offset: 0x00275462
		public BarColumnPercentageDataLabel(bool showValue) : base(showValue)
		{
		}

		// Token: 0x06004E86 RID: 20102 RVA: 0x00276475 File Offset: 0x00275475
		public BarColumnPercentageDataLabel(bool showValue, bool showSeries) : base(showValue, showSeries)
		{
		}

		// Token: 0x06004E87 RID: 20103 RVA: 0x00276489 File Offset: 0x00275489
		public BarColumnPercentageDataLabel(bool showValue, bool showPosition, bool showSeries) : base(showValue, showPosition, showSeries)
		{
		}

		// Token: 0x06004E88 RID: 20104 RVA: 0x0027649E File Offset: 0x0027549E
		public BarColumnPercentageDataLabel(bool showValue, bool showPercentage, bool showPosition, bool showSeries) : base(showValue, showPercentage, showPosition, showSeries)
		{
		}

		// Token: 0x06004E89 RID: 20105 RVA: 0x002764B5 File Offset: 0x002754B5
		public BarColumnPercentageDataLabel(Font font, float fontSize, Color color, bool showValue) : base(font, fontSize, color, showValue)
		{
		}

		// Token: 0x17000635 RID: 1589
		// (get) Token: 0x06004E8A RID: 20106 RVA: 0x002764CC File Offset: 0x002754CC
		// (set) Token: 0x06004E8B RID: 20107 RVA: 0x002764E4 File Offset: 0x002754E4
		public DataLabelLocation Location
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x04002A67 RID: 10855
		private new DataLabelLocation a = DataLabelLocation.Default;
	}
}
