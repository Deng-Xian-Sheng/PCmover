using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002FB RID: 763
	[DataContract]
	public class SubresourceWebBundleMetadataErrorEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007FA RID: 2042
		// (get) Token: 0x06001654 RID: 5716 RVA: 0x0001A016 File Offset: 0x00018216
		// (set) Token: 0x06001655 RID: 5717 RVA: 0x0001A01E File Offset: 0x0001821E
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007FB RID: 2043
		// (get) Token: 0x06001656 RID: 5718 RVA: 0x0001A027 File Offset: 0x00018227
		// (set) Token: 0x06001657 RID: 5719 RVA: 0x0001A02F File Offset: 0x0001822F
		[DataMember(Name = "errorMessage", IsRequired = true)]
		public string ErrorMessage { get; private set; }
	}
}
