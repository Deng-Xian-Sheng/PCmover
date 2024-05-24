using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.Network;

namespace CefSharp.DevTools.Fetch
{
	// Token: 0x020001C8 RID: 456
	[DataContract]
	public class RequestPausedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06000D2E RID: 3374 RVA: 0x00012270 File Offset: 0x00010470
		// (set) Token: 0x06000D2F RID: 3375 RVA: 0x00012278 File Offset: 0x00010478
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06000D30 RID: 3376 RVA: 0x00012281 File Offset: 0x00010481
		// (set) Token: 0x06000D31 RID: 3377 RVA: 0x00012289 File Offset: 0x00010489
		[DataMember(Name = "request", IsRequired = true)]
		public Request Request { get; private set; }

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06000D32 RID: 3378 RVA: 0x00012292 File Offset: 0x00010492
		// (set) Token: 0x06000D33 RID: 3379 RVA: 0x0001229A File Offset: 0x0001049A
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06000D34 RID: 3380 RVA: 0x000122A3 File Offset: 0x000104A3
		// (set) Token: 0x06000D35 RID: 3381 RVA: 0x000122BF File Offset: 0x000104BF
		public ResourceType ResourceType
		{
			get
			{
				return (ResourceType)DevToolsDomainEventArgsBase.StringToEnum(typeof(ResourceType), this.resourceType);
			}
			set
			{
				this.resourceType = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06000D36 RID: 3382 RVA: 0x000122D2 File Offset: 0x000104D2
		// (set) Token: 0x06000D37 RID: 3383 RVA: 0x000122DA File Offset: 0x000104DA
		[DataMember(Name = "resourceType", IsRequired = true)]
		internal string resourceType { get; private set; }

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06000D38 RID: 3384 RVA: 0x000122E3 File Offset: 0x000104E3
		// (set) Token: 0x06000D39 RID: 3385 RVA: 0x000122FF File Offset: 0x000104FF
		public ErrorReason? ResponseErrorReason
		{
			get
			{
				return (ErrorReason?)DevToolsDomainEventArgsBase.StringToEnum(typeof(ErrorReason?), this.responseErrorReason);
			}
			set
			{
				this.responseErrorReason = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06000D3A RID: 3386 RVA: 0x00012312 File Offset: 0x00010512
		// (set) Token: 0x06000D3B RID: 3387 RVA: 0x0001231A File Offset: 0x0001051A
		[DataMember(Name = "responseErrorReason", IsRequired = false)]
		internal string responseErrorReason { get; private set; }

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06000D3C RID: 3388 RVA: 0x00012323 File Offset: 0x00010523
		// (set) Token: 0x06000D3D RID: 3389 RVA: 0x0001232B File Offset: 0x0001052B
		[DataMember(Name = "responseStatusCode", IsRequired = false)]
		public int? ResponseStatusCode { get; private set; }

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06000D3E RID: 3390 RVA: 0x00012334 File Offset: 0x00010534
		// (set) Token: 0x06000D3F RID: 3391 RVA: 0x0001233C File Offset: 0x0001053C
		[DataMember(Name = "responseStatusText", IsRequired = false)]
		public string ResponseStatusText { get; private set; }

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x06000D40 RID: 3392 RVA: 0x00012345 File Offset: 0x00010545
		// (set) Token: 0x06000D41 RID: 3393 RVA: 0x0001234D File Offset: 0x0001054D
		[DataMember(Name = "responseHeaders", IsRequired = false)]
		public IList<HeaderEntry> ResponseHeaders { get; private set; }

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06000D42 RID: 3394 RVA: 0x00012356 File Offset: 0x00010556
		// (set) Token: 0x06000D43 RID: 3395 RVA: 0x0001235E File Offset: 0x0001055E
		[DataMember(Name = "networkId", IsRequired = false)]
		public string NetworkId { get; private set; }
	}
}
