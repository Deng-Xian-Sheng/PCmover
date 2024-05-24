using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002C5 RID: 709
	[DataContract]
	public class BlockedSetCookieWithReason : DevToolsDomainEntityBase
	{
		// Token: 0x17000723 RID: 1827
		// (get) Token: 0x0600147B RID: 5243 RVA: 0x00018D57 File Offset: 0x00016F57
		// (set) Token: 0x0600147C RID: 5244 RVA: 0x00018D73 File Offset: 0x00016F73
		public SetCookieBlockedReason[] BlockedReasons
		{
			get
			{
				return (SetCookieBlockedReason[])DevToolsDomainEntityBase.StringToEnum(typeof(SetCookieBlockedReason[]), this.blockedReasons);
			}
			set
			{
				this.blockedReasons = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000724 RID: 1828
		// (get) Token: 0x0600147D RID: 5245 RVA: 0x00018D81 File Offset: 0x00016F81
		// (set) Token: 0x0600147E RID: 5246 RVA: 0x00018D89 File Offset: 0x00016F89
		[DataMember(Name = "blockedReasons", IsRequired = true)]
		internal string blockedReasons { get; set; }

		// Token: 0x17000725 RID: 1829
		// (get) Token: 0x0600147F RID: 5247 RVA: 0x00018D92 File Offset: 0x00016F92
		// (set) Token: 0x06001480 RID: 5248 RVA: 0x00018D9A File Offset: 0x00016F9A
		[DataMember(Name = "cookieLine", IsRequired = true)]
		public string CookieLine { get; set; }

		// Token: 0x17000726 RID: 1830
		// (get) Token: 0x06001481 RID: 5249 RVA: 0x00018DA3 File Offset: 0x00016FA3
		// (set) Token: 0x06001482 RID: 5250 RVA: 0x00018DAB File Offset: 0x00016FAB
		[DataMember(Name = "cookie", IsRequired = false)]
		public Cookie Cookie { get; set; }
	}
}
