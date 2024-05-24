using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Security;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002BB RID: 699
	[DataContract]
	public class Response : DevToolsDomainEntityBase
	{
		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x060013F0 RID: 5104 RVA: 0x000187EB File Offset: 0x000169EB
		// (set) Token: 0x060013F1 RID: 5105 RVA: 0x000187F3 File Offset: 0x000169F3
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x060013F2 RID: 5106 RVA: 0x000187FC File Offset: 0x000169FC
		// (set) Token: 0x060013F3 RID: 5107 RVA: 0x00018804 File Offset: 0x00016A04
		[DataMember(Name = "status", IsRequired = true)]
		public int Status { get; set; }

		// Token: 0x170006E3 RID: 1763
		// (get) Token: 0x060013F4 RID: 5108 RVA: 0x0001880D File Offset: 0x00016A0D
		// (set) Token: 0x060013F5 RID: 5109 RVA: 0x00018815 File Offset: 0x00016A15
		[DataMember(Name = "statusText", IsRequired = true)]
		public string StatusText { get; set; }

		// Token: 0x170006E4 RID: 1764
		// (get) Token: 0x060013F6 RID: 5110 RVA: 0x0001881E File Offset: 0x00016A1E
		// (set) Token: 0x060013F7 RID: 5111 RVA: 0x00018826 File Offset: 0x00016A26
		[DataMember(Name = "headers", IsRequired = true)]
		public Headers Headers { get; set; }

		// Token: 0x170006E5 RID: 1765
		// (get) Token: 0x060013F8 RID: 5112 RVA: 0x0001882F File Offset: 0x00016A2F
		// (set) Token: 0x060013F9 RID: 5113 RVA: 0x00018837 File Offset: 0x00016A37
		[DataMember(Name = "headersText", IsRequired = false)]
		public string HeadersText { get; set; }

		// Token: 0x170006E6 RID: 1766
		// (get) Token: 0x060013FA RID: 5114 RVA: 0x00018840 File Offset: 0x00016A40
		// (set) Token: 0x060013FB RID: 5115 RVA: 0x00018848 File Offset: 0x00016A48
		[DataMember(Name = "mimeType", IsRequired = true)]
		public string MimeType { get; set; }

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x060013FC RID: 5116 RVA: 0x00018851 File Offset: 0x00016A51
		// (set) Token: 0x060013FD RID: 5117 RVA: 0x00018859 File Offset: 0x00016A59
		[DataMember(Name = "requestHeaders", IsRequired = false)]
		public Headers RequestHeaders { get; set; }

		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x060013FE RID: 5118 RVA: 0x00018862 File Offset: 0x00016A62
		// (set) Token: 0x060013FF RID: 5119 RVA: 0x0001886A File Offset: 0x00016A6A
		[DataMember(Name = "requestHeadersText", IsRequired = false)]
		public string RequestHeadersText { get; set; }

		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x06001400 RID: 5120 RVA: 0x00018873 File Offset: 0x00016A73
		// (set) Token: 0x06001401 RID: 5121 RVA: 0x0001887B File Offset: 0x00016A7B
		[DataMember(Name = "connectionReused", IsRequired = true)]
		public bool ConnectionReused { get; set; }

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x06001402 RID: 5122 RVA: 0x00018884 File Offset: 0x00016A84
		// (set) Token: 0x06001403 RID: 5123 RVA: 0x0001888C File Offset: 0x00016A8C
		[DataMember(Name = "connectionId", IsRequired = true)]
		public double ConnectionId { get; set; }

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x06001404 RID: 5124 RVA: 0x00018895 File Offset: 0x00016A95
		// (set) Token: 0x06001405 RID: 5125 RVA: 0x0001889D File Offset: 0x00016A9D
		[DataMember(Name = "remoteIPAddress", IsRequired = false)]
		public string RemoteIPAddress { get; set; }

		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x06001406 RID: 5126 RVA: 0x000188A6 File Offset: 0x00016AA6
		// (set) Token: 0x06001407 RID: 5127 RVA: 0x000188AE File Offset: 0x00016AAE
		[DataMember(Name = "remotePort", IsRequired = false)]
		public int? RemotePort { get; set; }

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x06001408 RID: 5128 RVA: 0x000188B7 File Offset: 0x00016AB7
		// (set) Token: 0x06001409 RID: 5129 RVA: 0x000188BF File Offset: 0x00016ABF
		[DataMember(Name = "fromDiskCache", IsRequired = false)]
		public bool? FromDiskCache { get; set; }

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x0600140A RID: 5130 RVA: 0x000188C8 File Offset: 0x00016AC8
		// (set) Token: 0x0600140B RID: 5131 RVA: 0x000188D0 File Offset: 0x00016AD0
		[DataMember(Name = "fromServiceWorker", IsRequired = false)]
		public bool? FromServiceWorker { get; set; }

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x0600140C RID: 5132 RVA: 0x000188D9 File Offset: 0x00016AD9
		// (set) Token: 0x0600140D RID: 5133 RVA: 0x000188E1 File Offset: 0x00016AE1
		[DataMember(Name = "fromPrefetchCache", IsRequired = false)]
		public bool? FromPrefetchCache { get; set; }

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x0600140E RID: 5134 RVA: 0x000188EA File Offset: 0x00016AEA
		// (set) Token: 0x0600140F RID: 5135 RVA: 0x000188F2 File Offset: 0x00016AF2
		[DataMember(Name = "encodedDataLength", IsRequired = true)]
		public double EncodedDataLength { get; set; }

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x06001410 RID: 5136 RVA: 0x000188FB File Offset: 0x00016AFB
		// (set) Token: 0x06001411 RID: 5137 RVA: 0x00018903 File Offset: 0x00016B03
		[DataMember(Name = "timing", IsRequired = false)]
		public ResourceTiming Timing { get; set; }

		// Token: 0x170006F2 RID: 1778
		// (get) Token: 0x06001412 RID: 5138 RVA: 0x0001890C File Offset: 0x00016B0C
		// (set) Token: 0x06001413 RID: 5139 RVA: 0x00018928 File Offset: 0x00016B28
		public ServiceWorkerResponseSource? ServiceWorkerResponseSource
		{
			get
			{
				return (ServiceWorkerResponseSource?)DevToolsDomainEntityBase.StringToEnum(typeof(ServiceWorkerResponseSource?), this.serviceWorkerResponseSource);
			}
			set
			{
				this.serviceWorkerResponseSource = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x06001414 RID: 5140 RVA: 0x0001893B File Offset: 0x00016B3B
		// (set) Token: 0x06001415 RID: 5141 RVA: 0x00018943 File Offset: 0x00016B43
		[DataMember(Name = "serviceWorkerResponseSource", IsRequired = false)]
		internal string serviceWorkerResponseSource { get; set; }

		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x06001416 RID: 5142 RVA: 0x0001894C File Offset: 0x00016B4C
		// (set) Token: 0x06001417 RID: 5143 RVA: 0x00018954 File Offset: 0x00016B54
		[DataMember(Name = "responseTime", IsRequired = false)]
		public double? ResponseTime { get; set; }

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x06001418 RID: 5144 RVA: 0x0001895D File Offset: 0x00016B5D
		// (set) Token: 0x06001419 RID: 5145 RVA: 0x00018965 File Offset: 0x00016B65
		[DataMember(Name = "cacheStorageCacheName", IsRequired = false)]
		public string CacheStorageCacheName { get; set; }

		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x0600141A RID: 5146 RVA: 0x0001896E File Offset: 0x00016B6E
		// (set) Token: 0x0600141B RID: 5147 RVA: 0x00018976 File Offset: 0x00016B76
		[DataMember(Name = "protocol", IsRequired = false)]
		public string Protocol { get; set; }

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x0600141C RID: 5148 RVA: 0x0001897F File Offset: 0x00016B7F
		// (set) Token: 0x0600141D RID: 5149 RVA: 0x0001899B File Offset: 0x00016B9B
		public SecurityState SecurityState
		{
			get
			{
				return (SecurityState)DevToolsDomainEntityBase.StringToEnum(typeof(SecurityState), this.securityState);
			}
			set
			{
				this.securityState = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x0600141E RID: 5150 RVA: 0x000189AE File Offset: 0x00016BAE
		// (set) Token: 0x0600141F RID: 5151 RVA: 0x000189B6 File Offset: 0x00016BB6
		[DataMember(Name = "securityState", IsRequired = true)]
		internal string securityState { get; set; }

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x06001420 RID: 5152 RVA: 0x000189BF File Offset: 0x00016BBF
		// (set) Token: 0x06001421 RID: 5153 RVA: 0x000189C7 File Offset: 0x00016BC7
		[DataMember(Name = "securityDetails", IsRequired = false)]
		public SecurityDetails SecurityDetails { get; set; }
	}
}
