using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002FD RID: 765
	[DataContract]
	public class SubresourceWebBundleInnerResponseErrorEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007FF RID: 2047
		// (get) Token: 0x06001660 RID: 5728 RVA: 0x0001A07B File Offset: 0x0001827B
		// (set) Token: 0x06001661 RID: 5729 RVA: 0x0001A083 File Offset: 0x00018283
		[DataMember(Name = "innerRequestId", IsRequired = true)]
		public string InnerRequestId { get; private set; }

		// Token: 0x17000800 RID: 2048
		// (get) Token: 0x06001662 RID: 5730 RVA: 0x0001A08C File Offset: 0x0001828C
		// (set) Token: 0x06001663 RID: 5731 RVA: 0x0001A094 File Offset: 0x00018294
		[DataMember(Name = "innerRequestURL", IsRequired = true)]
		public string InnerRequestURL { get; private set; }

		// Token: 0x17000801 RID: 2049
		// (get) Token: 0x06001664 RID: 5732 RVA: 0x0001A09D File Offset: 0x0001829D
		// (set) Token: 0x06001665 RID: 5733 RVA: 0x0001A0A5 File Offset: 0x000182A5
		[DataMember(Name = "errorMessage", IsRequired = true)]
		public string ErrorMessage { get; private set; }

		// Token: 0x17000802 RID: 2050
		// (get) Token: 0x06001666 RID: 5734 RVA: 0x0001A0AE File Offset: 0x000182AE
		// (set) Token: 0x06001667 RID: 5735 RVA: 0x0001A0B6 File Offset: 0x000182B6
		[DataMember(Name = "bundleRequestId", IsRequired = false)]
		public string BundleRequestId { get; private set; }
	}
}
