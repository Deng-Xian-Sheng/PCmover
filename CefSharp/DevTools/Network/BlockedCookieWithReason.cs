using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002C6 RID: 710
	[DataContract]
	public class BlockedCookieWithReason : DevToolsDomainEntityBase
	{
		// Token: 0x17000727 RID: 1831
		// (get) Token: 0x06001484 RID: 5252 RVA: 0x00018DBC File Offset: 0x00016FBC
		// (set) Token: 0x06001485 RID: 5253 RVA: 0x00018DD8 File Offset: 0x00016FD8
		public CookieBlockedReason[] BlockedReasons
		{
			get
			{
				return (CookieBlockedReason[])DevToolsDomainEntityBase.StringToEnum(typeof(CookieBlockedReason[]), this.blockedReasons);
			}
			set
			{
				this.blockedReasons = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000728 RID: 1832
		// (get) Token: 0x06001486 RID: 5254 RVA: 0x00018DE6 File Offset: 0x00016FE6
		// (set) Token: 0x06001487 RID: 5255 RVA: 0x00018DEE File Offset: 0x00016FEE
		[DataMember(Name = "blockedReasons", IsRequired = true)]
		internal string blockedReasons { get; set; }

		// Token: 0x17000729 RID: 1833
		// (get) Token: 0x06001488 RID: 5256 RVA: 0x00018DF7 File Offset: 0x00016FF7
		// (set) Token: 0x06001489 RID: 5257 RVA: 0x00018DFF File Offset: 0x00016FFF
		[DataMember(Name = "cookie", IsRequired = true)]
		public Cookie Cookie { get; set; }
	}
}
