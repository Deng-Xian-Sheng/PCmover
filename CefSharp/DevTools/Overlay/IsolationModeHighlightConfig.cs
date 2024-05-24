using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x0200029D RID: 669
	[DataContract]
	public class IsolationModeHighlightConfig : DevToolsDomainEntityBase
	{
		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x06001328 RID: 4904 RVA: 0x00017935 File Offset: 0x00015B35
		// (set) Token: 0x06001329 RID: 4905 RVA: 0x0001793D File Offset: 0x00015B3D
		[DataMember(Name = "resizerColor", IsRequired = false)]
		public RGBA ResizerColor { get; set; }

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x0600132A RID: 4906 RVA: 0x00017946 File Offset: 0x00015B46
		// (set) Token: 0x0600132B RID: 4907 RVA: 0x0001794E File Offset: 0x00015B4E
		[DataMember(Name = "resizerHandleColor", IsRequired = false)]
		public RGBA ResizerHandleColor { get; set; }

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x0600132C RID: 4908 RVA: 0x00017957 File Offset: 0x00015B57
		// (set) Token: 0x0600132D RID: 4909 RVA: 0x0001795F File Offset: 0x00015B5F
		[DataMember(Name = "maskColor", IsRequired = false)]
		public RGBA MaskColor { get; set; }
	}
}
