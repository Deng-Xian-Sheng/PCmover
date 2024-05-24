using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002FC RID: 764
	[DataContract]
	public class SubresourceWebBundleInnerResponseParsedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007FC RID: 2044
		// (get) Token: 0x06001659 RID: 5721 RVA: 0x0001A040 File Offset: 0x00018240
		// (set) Token: 0x0600165A RID: 5722 RVA: 0x0001A048 File Offset: 0x00018248
		[DataMember(Name = "innerRequestId", IsRequired = true)]
		public string InnerRequestId { get; private set; }

		// Token: 0x170007FD RID: 2045
		// (get) Token: 0x0600165B RID: 5723 RVA: 0x0001A051 File Offset: 0x00018251
		// (set) Token: 0x0600165C RID: 5724 RVA: 0x0001A059 File Offset: 0x00018259
		[DataMember(Name = "innerRequestURL", IsRequired = true)]
		public string InnerRequestURL { get; private set; }

		// Token: 0x170007FE RID: 2046
		// (get) Token: 0x0600165D RID: 5725 RVA: 0x0001A062 File Offset: 0x00018262
		// (set) Token: 0x0600165E RID: 5726 RVA: 0x0001A06A File Offset: 0x0001826A
		[DataMember(Name = "bundleRequestId", IsRequired = false)]
		public string BundleRequestId { get; private set; }
	}
}
