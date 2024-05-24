using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x0200029B RID: 667
	[DataContract]
	public class ContainerQueryContainerHighlightConfig : DevToolsDomainEntityBase
	{
		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x0600131E RID: 4894 RVA: 0x000178E1 File Offset: 0x00015AE1
		// (set) Token: 0x0600131F RID: 4895 RVA: 0x000178E9 File Offset: 0x00015AE9
		[DataMember(Name = "containerBorder", IsRequired = false)]
		public LineStyle ContainerBorder { get; set; }

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x06001320 RID: 4896 RVA: 0x000178F2 File Offset: 0x00015AF2
		// (set) Token: 0x06001321 RID: 4897 RVA: 0x000178FA File Offset: 0x00015AFA
		[DataMember(Name = "descendantBorder", IsRequired = false)]
		public LineStyle DescendantBorder { get; set; }
	}
}
