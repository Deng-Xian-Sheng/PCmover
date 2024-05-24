using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x02000373 RID: 883
	[DataContract]
	public class NodeTreeSnapshot : DevToolsDomainEntityBase
	{
		// Token: 0x1700092A RID: 2346
		// (get) Token: 0x060019B7 RID: 6583 RVA: 0x0001E430 File Offset: 0x0001C630
		// (set) Token: 0x060019B8 RID: 6584 RVA: 0x0001E438 File Offset: 0x0001C638
		[DataMember(Name = "parentIndex", IsRequired = false)]
		public int[] ParentIndex { get; set; }

		// Token: 0x1700092B RID: 2347
		// (get) Token: 0x060019B9 RID: 6585 RVA: 0x0001E441 File Offset: 0x0001C641
		// (set) Token: 0x060019BA RID: 6586 RVA: 0x0001E449 File Offset: 0x0001C649
		[DataMember(Name = "nodeType", IsRequired = false)]
		public int[] NodeType { get; set; }

		// Token: 0x1700092C RID: 2348
		// (get) Token: 0x060019BB RID: 6587 RVA: 0x0001E452 File Offset: 0x0001C652
		// (set) Token: 0x060019BC RID: 6588 RVA: 0x0001E45A File Offset: 0x0001C65A
		[DataMember(Name = "shadowRootType", IsRequired = false)]
		public RareStringData ShadowRootType { get; set; }

		// Token: 0x1700092D RID: 2349
		// (get) Token: 0x060019BD RID: 6589 RVA: 0x0001E463 File Offset: 0x0001C663
		// (set) Token: 0x060019BE RID: 6590 RVA: 0x0001E46B File Offset: 0x0001C66B
		[DataMember(Name = "nodeName", IsRequired = false)]
		public int[] NodeName { get; set; }

		// Token: 0x1700092E RID: 2350
		// (get) Token: 0x060019BF RID: 6591 RVA: 0x0001E474 File Offset: 0x0001C674
		// (set) Token: 0x060019C0 RID: 6592 RVA: 0x0001E47C File Offset: 0x0001C67C
		[DataMember(Name = "nodeValue", IsRequired = false)]
		public int[] NodeValue { get; set; }

		// Token: 0x1700092F RID: 2351
		// (get) Token: 0x060019C1 RID: 6593 RVA: 0x0001E485 File Offset: 0x0001C685
		// (set) Token: 0x060019C2 RID: 6594 RVA: 0x0001E48D File Offset: 0x0001C68D
		[DataMember(Name = "backendNodeId", IsRequired = false)]
		public int[] BackendNodeId { get; set; }

		// Token: 0x17000930 RID: 2352
		// (get) Token: 0x060019C3 RID: 6595 RVA: 0x0001E496 File Offset: 0x0001C696
		// (set) Token: 0x060019C4 RID: 6596 RVA: 0x0001E49E File Offset: 0x0001C69E
		[DataMember(Name = "attributes", IsRequired = false)]
		public int[] Attributes { get; set; }

		// Token: 0x17000931 RID: 2353
		// (get) Token: 0x060019C5 RID: 6597 RVA: 0x0001E4A7 File Offset: 0x0001C6A7
		// (set) Token: 0x060019C6 RID: 6598 RVA: 0x0001E4AF File Offset: 0x0001C6AF
		[DataMember(Name = "textValue", IsRequired = false)]
		public RareStringData TextValue { get; set; }

		// Token: 0x17000932 RID: 2354
		// (get) Token: 0x060019C7 RID: 6599 RVA: 0x0001E4B8 File Offset: 0x0001C6B8
		// (set) Token: 0x060019C8 RID: 6600 RVA: 0x0001E4C0 File Offset: 0x0001C6C0
		[DataMember(Name = "inputValue", IsRequired = false)]
		public RareStringData InputValue { get; set; }

		// Token: 0x17000933 RID: 2355
		// (get) Token: 0x060019C9 RID: 6601 RVA: 0x0001E4C9 File Offset: 0x0001C6C9
		// (set) Token: 0x060019CA RID: 6602 RVA: 0x0001E4D1 File Offset: 0x0001C6D1
		[DataMember(Name = "inputChecked", IsRequired = false)]
		public RareBooleanData InputChecked { get; set; }

		// Token: 0x17000934 RID: 2356
		// (get) Token: 0x060019CB RID: 6603 RVA: 0x0001E4DA File Offset: 0x0001C6DA
		// (set) Token: 0x060019CC RID: 6604 RVA: 0x0001E4E2 File Offset: 0x0001C6E2
		[DataMember(Name = "optionSelected", IsRequired = false)]
		public RareBooleanData OptionSelected { get; set; }

		// Token: 0x17000935 RID: 2357
		// (get) Token: 0x060019CD RID: 6605 RVA: 0x0001E4EB File Offset: 0x0001C6EB
		// (set) Token: 0x060019CE RID: 6606 RVA: 0x0001E4F3 File Offset: 0x0001C6F3
		[DataMember(Name = "contentDocumentIndex", IsRequired = false)]
		public RareIntegerData ContentDocumentIndex { get; set; }

		// Token: 0x17000936 RID: 2358
		// (get) Token: 0x060019CF RID: 6607 RVA: 0x0001E4FC File Offset: 0x0001C6FC
		// (set) Token: 0x060019D0 RID: 6608 RVA: 0x0001E504 File Offset: 0x0001C704
		[DataMember(Name = "pseudoType", IsRequired = false)]
		public RareStringData PseudoType { get; set; }

		// Token: 0x17000937 RID: 2359
		// (get) Token: 0x060019D1 RID: 6609 RVA: 0x0001E50D File Offset: 0x0001C70D
		// (set) Token: 0x060019D2 RID: 6610 RVA: 0x0001E515 File Offset: 0x0001C715
		[DataMember(Name = "isClickable", IsRequired = false)]
		public RareBooleanData IsClickable { get; set; }

		// Token: 0x17000938 RID: 2360
		// (get) Token: 0x060019D3 RID: 6611 RVA: 0x0001E51E File Offset: 0x0001C71E
		// (set) Token: 0x060019D4 RID: 6612 RVA: 0x0001E526 File Offset: 0x0001C726
		[DataMember(Name = "currentSourceURL", IsRequired = false)]
		public RareStringData CurrentSourceURL { get; set; }

		// Token: 0x17000939 RID: 2361
		// (get) Token: 0x060019D5 RID: 6613 RVA: 0x0001E52F File Offset: 0x0001C72F
		// (set) Token: 0x060019D6 RID: 6614 RVA: 0x0001E537 File Offset: 0x0001C737
		[DataMember(Name = "originURL", IsRequired = false)]
		public RareStringData OriginURL { get; set; }
	}
}
