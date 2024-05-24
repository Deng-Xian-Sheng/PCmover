using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000265 RID: 613
	[DataContract]
	public class DownloadWillBeginEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x06001158 RID: 4440 RVA: 0x00015C06 File Offset: 0x00013E06
		// (set) Token: 0x06001159 RID: 4441 RVA: 0x00015C0E File Offset: 0x00013E0E
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x0600115A RID: 4442 RVA: 0x00015C17 File Offset: 0x00013E17
		// (set) Token: 0x0600115B RID: 4443 RVA: 0x00015C1F File Offset: 0x00013E1F
		[DataMember(Name = "guid", IsRequired = true)]
		public string Guid { get; private set; }

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x0600115C RID: 4444 RVA: 0x00015C28 File Offset: 0x00013E28
		// (set) Token: 0x0600115D RID: 4445 RVA: 0x00015C30 File Offset: 0x00013E30
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; private set; }

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x0600115E RID: 4446 RVA: 0x00015C39 File Offset: 0x00013E39
		// (set) Token: 0x0600115F RID: 4447 RVA: 0x00015C41 File Offset: 0x00013E41
		[DataMember(Name = "suggestedFilename", IsRequired = true)]
		public string SuggestedFilename { get; private set; }
	}
}
