using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x02000297 RID: 663
	[DataContract]
	public class ScrollSnapContainerHighlightConfig : DevToolsDomainEntityBase
	{
		// Token: 0x17000685 RID: 1669
		// (get) Token: 0x06001304 RID: 4868 RVA: 0x00017806 File Offset: 0x00015A06
		// (set) Token: 0x06001305 RID: 4869 RVA: 0x0001780E File Offset: 0x00015A0E
		[DataMember(Name = "snapportBorder", IsRequired = false)]
		public LineStyle SnapportBorder { get; set; }

		// Token: 0x17000686 RID: 1670
		// (get) Token: 0x06001306 RID: 4870 RVA: 0x00017817 File Offset: 0x00015A17
		// (set) Token: 0x06001307 RID: 4871 RVA: 0x0001781F File Offset: 0x00015A1F
		[DataMember(Name = "snapAreaBorder", IsRequired = false)]
		public LineStyle SnapAreaBorder { get; set; }

		// Token: 0x17000687 RID: 1671
		// (get) Token: 0x06001308 RID: 4872 RVA: 0x00017828 File Offset: 0x00015A28
		// (set) Token: 0x06001309 RID: 4873 RVA: 0x00017830 File Offset: 0x00015A30
		[DataMember(Name = "scrollMarginColor", IsRequired = false)]
		public RGBA ScrollMarginColor { get; set; }

		// Token: 0x17000688 RID: 1672
		// (get) Token: 0x0600130A RID: 4874 RVA: 0x00017839 File Offset: 0x00015A39
		// (set) Token: 0x0600130B RID: 4875 RVA: 0x00017841 File Offset: 0x00015A41
		[DataMember(Name = "scrollPaddingColor", IsRequired = false)]
		public RGBA ScrollPaddingColor { get; set; }
	}
}
