using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200026D RID: 621
	[DataContract]
	public class NavigatedWithinDocumentEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x06001193 RID: 4499 RVA: 0x00015E34 File Offset: 0x00014034
		// (set) Token: 0x06001194 RID: 4500 RVA: 0x00015E3C File Offset: 0x0001403C
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x06001195 RID: 4501 RVA: 0x00015E45 File Offset: 0x00014045
		// (set) Token: 0x06001196 RID: 4502 RVA: 0x00015E4D File Offset: 0x0001404D
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; private set; }
	}
}
