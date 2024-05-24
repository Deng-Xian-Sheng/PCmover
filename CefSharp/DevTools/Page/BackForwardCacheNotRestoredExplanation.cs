using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000256 RID: 598
	[DataContract]
	public class BackForwardCacheNotRestoredExplanation : DevToolsDomainEntityBase
	{
		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x06001103 RID: 4355 RVA: 0x0001584A File Offset: 0x00013A4A
		// (set) Token: 0x06001104 RID: 4356 RVA: 0x00015866 File Offset: 0x00013A66
		public BackForwardCacheNotRestoredReasonType Type
		{
			get
			{
				return (BackForwardCacheNotRestoredReasonType)DevToolsDomainEntityBase.StringToEnum(typeof(BackForwardCacheNotRestoredReasonType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x06001105 RID: 4357 RVA: 0x00015879 File Offset: 0x00013A79
		// (set) Token: 0x06001106 RID: 4358 RVA: 0x00015881 File Offset: 0x00013A81
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x06001107 RID: 4359 RVA: 0x0001588A File Offset: 0x00013A8A
		// (set) Token: 0x06001108 RID: 4360 RVA: 0x000158A6 File Offset: 0x00013AA6
		public BackForwardCacheNotRestoredReason Reason
		{
			get
			{
				return (BackForwardCacheNotRestoredReason)DevToolsDomainEntityBase.StringToEnum(typeof(BackForwardCacheNotRestoredReason), this.reason);
			}
			set
			{
				this.reason = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170005BF RID: 1471
		// (get) Token: 0x06001109 RID: 4361 RVA: 0x000158B9 File Offset: 0x00013AB9
		// (set) Token: 0x0600110A RID: 4362 RVA: 0x000158C1 File Offset: 0x00013AC1
		[DataMember(Name = "reason", IsRequired = true)]
		internal string reason { get; set; }
	}
}
