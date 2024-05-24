using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000261 RID: 609
	[DataContract]
	public class FrameRequestedNavigationEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x0600113A RID: 4410 RVA: 0x00015AAF File Offset: 0x00013CAF
		// (set) Token: 0x0600113B RID: 4411 RVA: 0x00015AB7 File Offset: 0x00013CB7
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x0600113C RID: 4412 RVA: 0x00015AC0 File Offset: 0x00013CC0
		// (set) Token: 0x0600113D RID: 4413 RVA: 0x00015ADC File Offset: 0x00013CDC
		public ClientNavigationReason Reason
		{
			get
			{
				return (ClientNavigationReason)DevToolsDomainEventArgsBase.StringToEnum(typeof(ClientNavigationReason), this.reason);
			}
			set
			{
				this.reason = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x0600113E RID: 4414 RVA: 0x00015AEF File Offset: 0x00013CEF
		// (set) Token: 0x0600113F RID: 4415 RVA: 0x00015AF7 File Offset: 0x00013CF7
		[DataMember(Name = "reason", IsRequired = true)]
		internal string reason { get; private set; }

		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x06001140 RID: 4416 RVA: 0x00015B00 File Offset: 0x00013D00
		// (set) Token: 0x06001141 RID: 4417 RVA: 0x00015B08 File Offset: 0x00013D08
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; private set; }

		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x06001142 RID: 4418 RVA: 0x00015B11 File Offset: 0x00013D11
		// (set) Token: 0x06001143 RID: 4419 RVA: 0x00015B2D File Offset: 0x00013D2D
		public ClientNavigationDisposition Disposition
		{
			get
			{
				return (ClientNavigationDisposition)DevToolsDomainEventArgsBase.StringToEnum(typeof(ClientNavigationDisposition), this.disposition);
			}
			set
			{
				this.disposition = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x06001144 RID: 4420 RVA: 0x00015B40 File Offset: 0x00013D40
		// (set) Token: 0x06001145 RID: 4421 RVA: 0x00015B48 File Offset: 0x00013D48
		[DataMember(Name = "disposition", IsRequired = true)]
		internal string disposition { get; private set; }
	}
}
