using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x0200036C RID: 876
	[DataContract]
	public class LayoutTreeNode : DevToolsDomainEntityBase
	{
		// Token: 0x1700090C RID: 2316
		// (get) Token: 0x06001974 RID: 6516 RVA: 0x0001E1FA File Offset: 0x0001C3FA
		// (set) Token: 0x06001975 RID: 6517 RVA: 0x0001E202 File Offset: 0x0001C402
		[DataMember(Name = "domNodeIndex", IsRequired = true)]
		public int DomNodeIndex { get; set; }

		// Token: 0x1700090D RID: 2317
		// (get) Token: 0x06001976 RID: 6518 RVA: 0x0001E20B File Offset: 0x0001C40B
		// (set) Token: 0x06001977 RID: 6519 RVA: 0x0001E213 File Offset: 0x0001C413
		[DataMember(Name = "boundingBox", IsRequired = true)]
		public Rect BoundingBox { get; set; }

		// Token: 0x1700090E RID: 2318
		// (get) Token: 0x06001978 RID: 6520 RVA: 0x0001E21C File Offset: 0x0001C41C
		// (set) Token: 0x06001979 RID: 6521 RVA: 0x0001E224 File Offset: 0x0001C424
		[DataMember(Name = "layoutText", IsRequired = false)]
		public string LayoutText { get; set; }

		// Token: 0x1700090F RID: 2319
		// (get) Token: 0x0600197A RID: 6522 RVA: 0x0001E22D File Offset: 0x0001C42D
		// (set) Token: 0x0600197B RID: 6523 RVA: 0x0001E235 File Offset: 0x0001C435
		[DataMember(Name = "inlineTextNodes", IsRequired = false)]
		public IList<InlineTextBox> InlineTextNodes { get; set; }

		// Token: 0x17000910 RID: 2320
		// (get) Token: 0x0600197C RID: 6524 RVA: 0x0001E23E File Offset: 0x0001C43E
		// (set) Token: 0x0600197D RID: 6525 RVA: 0x0001E246 File Offset: 0x0001C446
		[DataMember(Name = "styleIndex", IsRequired = false)]
		public int? StyleIndex { get; set; }

		// Token: 0x17000911 RID: 2321
		// (get) Token: 0x0600197E RID: 6526 RVA: 0x0001E24F File Offset: 0x0001C44F
		// (set) Token: 0x0600197F RID: 6527 RVA: 0x0001E257 File Offset: 0x0001C457
		[DataMember(Name = "paintOrder", IsRequired = false)]
		public int? PaintOrder { get; set; }

		// Token: 0x17000912 RID: 2322
		// (get) Token: 0x06001980 RID: 6528 RVA: 0x0001E260 File Offset: 0x0001C460
		// (set) Token: 0x06001981 RID: 6529 RVA: 0x0001E268 File Offset: 0x0001C468
		[DataMember(Name = "isStackingContext", IsRequired = false)]
		public bool? IsStackingContext { get; set; }
	}
}
