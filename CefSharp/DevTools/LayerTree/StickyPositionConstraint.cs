using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x02000321 RID: 801
	[DataContract]
	public class StickyPositionConstraint : DevToolsDomainEntityBase
	{
		// Token: 0x1700084B RID: 2123
		// (get) Token: 0x06001770 RID: 6000 RVA: 0x0001B7AD File Offset: 0x000199AD
		// (set) Token: 0x06001771 RID: 6001 RVA: 0x0001B7B5 File Offset: 0x000199B5
		[DataMember(Name = "stickyBoxRect", IsRequired = true)]
		public Rect StickyBoxRect { get; set; }

		// Token: 0x1700084C RID: 2124
		// (get) Token: 0x06001772 RID: 6002 RVA: 0x0001B7BE File Offset: 0x000199BE
		// (set) Token: 0x06001773 RID: 6003 RVA: 0x0001B7C6 File Offset: 0x000199C6
		[DataMember(Name = "containingBlockRect", IsRequired = true)]
		public Rect ContainingBlockRect { get; set; }

		// Token: 0x1700084D RID: 2125
		// (get) Token: 0x06001774 RID: 6004 RVA: 0x0001B7CF File Offset: 0x000199CF
		// (set) Token: 0x06001775 RID: 6005 RVA: 0x0001B7D7 File Offset: 0x000199D7
		[DataMember(Name = "nearestLayerShiftingStickyBox", IsRequired = false)]
		public string NearestLayerShiftingStickyBox { get; set; }

		// Token: 0x1700084E RID: 2126
		// (get) Token: 0x06001776 RID: 6006 RVA: 0x0001B7E0 File Offset: 0x000199E0
		// (set) Token: 0x06001777 RID: 6007 RVA: 0x0001B7E8 File Offset: 0x000199E8
		[DataMember(Name = "nearestLayerShiftingContainingBlock", IsRequired = false)]
		public string NearestLayerShiftingContainingBlock { get; set; }
	}
}
