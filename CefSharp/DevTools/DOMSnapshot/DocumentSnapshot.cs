using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x02000372 RID: 882
	[DataContract]
	public class DocumentSnapshot : DevToolsDomainEntityBase
	{
		// Token: 0x1700091B RID: 2331
		// (get) Token: 0x06001998 RID: 6552 RVA: 0x0001E329 File Offset: 0x0001C529
		// (set) Token: 0x06001999 RID: 6553 RVA: 0x0001E331 File Offset: 0x0001C531
		[DataMember(Name = "documentURL", IsRequired = true)]
		public int DocumentURL { get; set; }

		// Token: 0x1700091C RID: 2332
		// (get) Token: 0x0600199A RID: 6554 RVA: 0x0001E33A File Offset: 0x0001C53A
		// (set) Token: 0x0600199B RID: 6555 RVA: 0x0001E342 File Offset: 0x0001C542
		[DataMember(Name = "title", IsRequired = true)]
		public int Title { get; set; }

		// Token: 0x1700091D RID: 2333
		// (get) Token: 0x0600199C RID: 6556 RVA: 0x0001E34B File Offset: 0x0001C54B
		// (set) Token: 0x0600199D RID: 6557 RVA: 0x0001E353 File Offset: 0x0001C553
		[DataMember(Name = "baseURL", IsRequired = true)]
		public int BaseURL { get; set; }

		// Token: 0x1700091E RID: 2334
		// (get) Token: 0x0600199E RID: 6558 RVA: 0x0001E35C File Offset: 0x0001C55C
		// (set) Token: 0x0600199F RID: 6559 RVA: 0x0001E364 File Offset: 0x0001C564
		[DataMember(Name = "contentLanguage", IsRequired = true)]
		public int ContentLanguage { get; set; }

		// Token: 0x1700091F RID: 2335
		// (get) Token: 0x060019A0 RID: 6560 RVA: 0x0001E36D File Offset: 0x0001C56D
		// (set) Token: 0x060019A1 RID: 6561 RVA: 0x0001E375 File Offset: 0x0001C575
		[DataMember(Name = "encodingName", IsRequired = true)]
		public int EncodingName { get; set; }

		// Token: 0x17000920 RID: 2336
		// (get) Token: 0x060019A2 RID: 6562 RVA: 0x0001E37E File Offset: 0x0001C57E
		// (set) Token: 0x060019A3 RID: 6563 RVA: 0x0001E386 File Offset: 0x0001C586
		[DataMember(Name = "publicId", IsRequired = true)]
		public int PublicId { get; set; }

		// Token: 0x17000921 RID: 2337
		// (get) Token: 0x060019A4 RID: 6564 RVA: 0x0001E38F File Offset: 0x0001C58F
		// (set) Token: 0x060019A5 RID: 6565 RVA: 0x0001E397 File Offset: 0x0001C597
		[DataMember(Name = "systemId", IsRequired = true)]
		public int SystemId { get; set; }

		// Token: 0x17000922 RID: 2338
		// (get) Token: 0x060019A6 RID: 6566 RVA: 0x0001E3A0 File Offset: 0x0001C5A0
		// (set) Token: 0x060019A7 RID: 6567 RVA: 0x0001E3A8 File Offset: 0x0001C5A8
		[DataMember(Name = "frameId", IsRequired = true)]
		public int FrameId { get; set; }

		// Token: 0x17000923 RID: 2339
		// (get) Token: 0x060019A8 RID: 6568 RVA: 0x0001E3B1 File Offset: 0x0001C5B1
		// (set) Token: 0x060019A9 RID: 6569 RVA: 0x0001E3B9 File Offset: 0x0001C5B9
		[DataMember(Name = "nodes", IsRequired = true)]
		public NodeTreeSnapshot Nodes { get; set; }

		// Token: 0x17000924 RID: 2340
		// (get) Token: 0x060019AA RID: 6570 RVA: 0x0001E3C2 File Offset: 0x0001C5C2
		// (set) Token: 0x060019AB RID: 6571 RVA: 0x0001E3CA File Offset: 0x0001C5CA
		[DataMember(Name = "layout", IsRequired = true)]
		public LayoutTreeSnapshot Layout { get; set; }

		// Token: 0x17000925 RID: 2341
		// (get) Token: 0x060019AC RID: 6572 RVA: 0x0001E3D3 File Offset: 0x0001C5D3
		// (set) Token: 0x060019AD RID: 6573 RVA: 0x0001E3DB File Offset: 0x0001C5DB
		[DataMember(Name = "textBoxes", IsRequired = true)]
		public TextBoxSnapshot TextBoxes { get; set; }

		// Token: 0x17000926 RID: 2342
		// (get) Token: 0x060019AE RID: 6574 RVA: 0x0001E3E4 File Offset: 0x0001C5E4
		// (set) Token: 0x060019AF RID: 6575 RVA: 0x0001E3EC File Offset: 0x0001C5EC
		[DataMember(Name = "scrollOffsetX", IsRequired = false)]
		public double? ScrollOffsetX { get; set; }

		// Token: 0x17000927 RID: 2343
		// (get) Token: 0x060019B0 RID: 6576 RVA: 0x0001E3F5 File Offset: 0x0001C5F5
		// (set) Token: 0x060019B1 RID: 6577 RVA: 0x0001E3FD File Offset: 0x0001C5FD
		[DataMember(Name = "scrollOffsetY", IsRequired = false)]
		public double? ScrollOffsetY { get; set; }

		// Token: 0x17000928 RID: 2344
		// (get) Token: 0x060019B2 RID: 6578 RVA: 0x0001E406 File Offset: 0x0001C606
		// (set) Token: 0x060019B3 RID: 6579 RVA: 0x0001E40E File Offset: 0x0001C60E
		[DataMember(Name = "contentWidth", IsRequired = false)]
		public double? ContentWidth { get; set; }

		// Token: 0x17000929 RID: 2345
		// (get) Token: 0x060019B4 RID: 6580 RVA: 0x0001E417 File Offset: 0x0001C617
		// (set) Token: 0x060019B5 RID: 6581 RVA: 0x0001E41F File Offset: 0x0001C61F
		[DataMember(Name = "contentHeight", IsRequired = false)]
		public double? ContentHeight { get; set; }
	}
}
