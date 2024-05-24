using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003F8 RID: 1016
	[DataContract]
	public class DownloadWillBeginEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000AC2 RID: 2754
		// (get) Token: 0x06001DA9 RID: 7593 RVA: 0x00021FAD File Offset: 0x000201AD
		// (set) Token: 0x06001DAA RID: 7594 RVA: 0x00021FB5 File Offset: 0x000201B5
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }

		// Token: 0x17000AC3 RID: 2755
		// (get) Token: 0x06001DAB RID: 7595 RVA: 0x00021FBE File Offset: 0x000201BE
		// (set) Token: 0x06001DAC RID: 7596 RVA: 0x00021FC6 File Offset: 0x000201C6
		[DataMember(Name = "guid", IsRequired = true)]
		public string Guid { get; private set; }

		// Token: 0x17000AC4 RID: 2756
		// (get) Token: 0x06001DAD RID: 7597 RVA: 0x00021FCF File Offset: 0x000201CF
		// (set) Token: 0x06001DAE RID: 7598 RVA: 0x00021FD7 File Offset: 0x000201D7
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; private set; }

		// Token: 0x17000AC5 RID: 2757
		// (get) Token: 0x06001DAF RID: 7599 RVA: 0x00021FE0 File Offset: 0x000201E0
		// (set) Token: 0x06001DB0 RID: 7600 RVA: 0x00021FE8 File Offset: 0x000201E8
		[DataMember(Name = "suggestedFilename", IsRequired = true)]
		public string SuggestedFilename { get; private set; }
	}
}
