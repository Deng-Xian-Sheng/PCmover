using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x0200028E RID: 654
	[DataContract]
	public class FlexItemHighlightConfig : DevToolsDomainEntityBase
	{
		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x060012BC RID: 4796 RVA: 0x0001754B File Offset: 0x0001574B
		// (set) Token: 0x060012BD RID: 4797 RVA: 0x00017553 File Offset: 0x00015753
		[DataMember(Name = "baseSizeBox", IsRequired = false)]
		public BoxStyle BaseSizeBox { get; set; }

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x060012BE RID: 4798 RVA: 0x0001755C File Offset: 0x0001575C
		// (set) Token: 0x060012BF RID: 4799 RVA: 0x00017564 File Offset: 0x00015764
		[DataMember(Name = "baseSizeBorder", IsRequired = false)]
		public LineStyle BaseSizeBorder { get; set; }

		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x060012C0 RID: 4800 RVA: 0x0001756D File Offset: 0x0001576D
		// (set) Token: 0x060012C1 RID: 4801 RVA: 0x00017575 File Offset: 0x00015775
		[DataMember(Name = "flexibilityArrow", IsRequired = false)]
		public LineStyle FlexibilityArrow { get; set; }
	}
}
