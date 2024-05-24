using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002FA RID: 762
	[DataContract]
	public class SubresourceWebBundleMetadataReceivedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007F8 RID: 2040
		// (get) Token: 0x0600164F RID: 5711 RVA: 0x00019FEC File Offset: 0x000181EC
		// (set) Token: 0x06001650 RID: 5712 RVA: 0x00019FF4 File Offset: 0x000181F4
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007F9 RID: 2041
		// (get) Token: 0x06001651 RID: 5713 RVA: 0x00019FFD File Offset: 0x000181FD
		// (set) Token: 0x06001652 RID: 5714 RVA: 0x0001A005 File Offset: 0x00018205
		[DataMember(Name = "urls", IsRequired = true)]
		public string[] Urls { get; private set; }
	}
}
