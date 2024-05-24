using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002DC RID: 732
	[DataContract]
	public class SecurityIsolationStatus : DevToolsDomainEntityBase
	{
		// Token: 0x17000771 RID: 1905
		// (get) Token: 0x06001525 RID: 5413 RVA: 0x000194CB File Offset: 0x000176CB
		// (set) Token: 0x06001526 RID: 5414 RVA: 0x000194D3 File Offset: 0x000176D3
		[DataMember(Name = "coop", IsRequired = false)]
		public CrossOriginOpenerPolicyStatus Coop { get; set; }

		// Token: 0x17000772 RID: 1906
		// (get) Token: 0x06001527 RID: 5415 RVA: 0x000194DC File Offset: 0x000176DC
		// (set) Token: 0x06001528 RID: 5416 RVA: 0x000194E4 File Offset: 0x000176E4
		[DataMember(Name = "coep", IsRequired = false)]
		public CrossOriginEmbedderPolicyStatus Coep { get; set; }
	}
}
