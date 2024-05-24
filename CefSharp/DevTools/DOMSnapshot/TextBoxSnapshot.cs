using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x02000375 RID: 885
	[DataContract]
	public class TextBoxSnapshot : DevToolsDomainEntityBase
	{
		// Token: 0x17000945 RID: 2373
		// (get) Token: 0x060019EF RID: 6639 RVA: 0x0001E60B File Offset: 0x0001C80B
		// (set) Token: 0x060019F0 RID: 6640 RVA: 0x0001E613 File Offset: 0x0001C813
		[DataMember(Name = "layoutIndex", IsRequired = true)]
		public int[] LayoutIndex { get; set; }

		// Token: 0x17000946 RID: 2374
		// (get) Token: 0x060019F1 RID: 6641 RVA: 0x0001E61C File Offset: 0x0001C81C
		// (set) Token: 0x060019F2 RID: 6642 RVA: 0x0001E624 File Offset: 0x0001C824
		[DataMember(Name = "bounds", IsRequired = true)]
		public double[] Bounds { get; set; }

		// Token: 0x17000947 RID: 2375
		// (get) Token: 0x060019F3 RID: 6643 RVA: 0x0001E62D File Offset: 0x0001C82D
		// (set) Token: 0x060019F4 RID: 6644 RVA: 0x0001E635 File Offset: 0x0001C835
		[DataMember(Name = "start", IsRequired = true)]
		public int[] Start { get; set; }

		// Token: 0x17000948 RID: 2376
		// (get) Token: 0x060019F5 RID: 6645 RVA: 0x0001E63E File Offset: 0x0001C83E
		// (set) Token: 0x060019F6 RID: 6646 RVA: 0x0001E646 File Offset: 0x0001C846
		[DataMember(Name = "length", IsRequired = true)]
		public int[] Length { get; set; }
	}
}
