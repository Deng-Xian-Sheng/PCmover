using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x02000374 RID: 884
	[DataContract]
	public class LayoutTreeSnapshot : DevToolsDomainEntityBase
	{
		// Token: 0x1700093A RID: 2362
		// (get) Token: 0x060019D8 RID: 6616 RVA: 0x0001E548 File Offset: 0x0001C748
		// (set) Token: 0x060019D9 RID: 6617 RVA: 0x0001E550 File Offset: 0x0001C750
		[DataMember(Name = "nodeIndex", IsRequired = true)]
		public int[] NodeIndex { get; set; }

		// Token: 0x1700093B RID: 2363
		// (get) Token: 0x060019DA RID: 6618 RVA: 0x0001E559 File Offset: 0x0001C759
		// (set) Token: 0x060019DB RID: 6619 RVA: 0x0001E561 File Offset: 0x0001C761
		[DataMember(Name = "styles", IsRequired = true)]
		public int[] Styles { get; set; }

		// Token: 0x1700093C RID: 2364
		// (get) Token: 0x060019DC RID: 6620 RVA: 0x0001E56A File Offset: 0x0001C76A
		// (set) Token: 0x060019DD RID: 6621 RVA: 0x0001E572 File Offset: 0x0001C772
		[DataMember(Name = "bounds", IsRequired = true)]
		public double[] Bounds { get; set; }

		// Token: 0x1700093D RID: 2365
		// (get) Token: 0x060019DE RID: 6622 RVA: 0x0001E57B File Offset: 0x0001C77B
		// (set) Token: 0x060019DF RID: 6623 RVA: 0x0001E583 File Offset: 0x0001C783
		[DataMember(Name = "text", IsRequired = true)]
		public int[] Text { get; set; }

		// Token: 0x1700093E RID: 2366
		// (get) Token: 0x060019E0 RID: 6624 RVA: 0x0001E58C File Offset: 0x0001C78C
		// (set) Token: 0x060019E1 RID: 6625 RVA: 0x0001E594 File Offset: 0x0001C794
		[DataMember(Name = "stackingContexts", IsRequired = true)]
		public RareBooleanData StackingContexts { get; set; }

		// Token: 0x1700093F RID: 2367
		// (get) Token: 0x060019E2 RID: 6626 RVA: 0x0001E59D File Offset: 0x0001C79D
		// (set) Token: 0x060019E3 RID: 6627 RVA: 0x0001E5A5 File Offset: 0x0001C7A5
		[DataMember(Name = "paintOrders", IsRequired = false)]
		public int[] PaintOrders { get; set; }

		// Token: 0x17000940 RID: 2368
		// (get) Token: 0x060019E4 RID: 6628 RVA: 0x0001E5AE File Offset: 0x0001C7AE
		// (set) Token: 0x060019E5 RID: 6629 RVA: 0x0001E5B6 File Offset: 0x0001C7B6
		[DataMember(Name = "offsetRects", IsRequired = false)]
		public double[] OffsetRects { get; set; }

		// Token: 0x17000941 RID: 2369
		// (get) Token: 0x060019E6 RID: 6630 RVA: 0x0001E5BF File Offset: 0x0001C7BF
		// (set) Token: 0x060019E7 RID: 6631 RVA: 0x0001E5C7 File Offset: 0x0001C7C7
		[DataMember(Name = "scrollRects", IsRequired = false)]
		public double[] ScrollRects { get; set; }

		// Token: 0x17000942 RID: 2370
		// (get) Token: 0x060019E8 RID: 6632 RVA: 0x0001E5D0 File Offset: 0x0001C7D0
		// (set) Token: 0x060019E9 RID: 6633 RVA: 0x0001E5D8 File Offset: 0x0001C7D8
		[DataMember(Name = "clientRects", IsRequired = false)]
		public double[] ClientRects { get; set; }

		// Token: 0x17000943 RID: 2371
		// (get) Token: 0x060019EA RID: 6634 RVA: 0x0001E5E1 File Offset: 0x0001C7E1
		// (set) Token: 0x060019EB RID: 6635 RVA: 0x0001E5E9 File Offset: 0x0001C7E9
		[DataMember(Name = "blendedBackgroundColors", IsRequired = false)]
		public int[] BlendedBackgroundColors { get; set; }

		// Token: 0x17000944 RID: 2372
		// (get) Token: 0x060019EC RID: 6636 RVA: 0x0001E5F2 File Offset: 0x0001C7F2
		// (set) Token: 0x060019ED RID: 6637 RVA: 0x0001E5FA File Offset: 0x0001C7FA
		[DataMember(Name = "textColorOpacities", IsRequired = false)]
		public double[] TextColorOpacities { get; set; }
	}
}
