using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002E1 RID: 737
	[DataContract]
	public class LoadNetworkResourceOptions : DevToolsDomainEntityBase
	{
		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x06001551 RID: 5457 RVA: 0x0001965D File Offset: 0x0001785D
		// (set) Token: 0x06001552 RID: 5458 RVA: 0x00019665 File Offset: 0x00017865
		[DataMember(Name = "disableCache", IsRequired = true)]
		public bool DisableCache { get; set; }

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x06001553 RID: 5459 RVA: 0x0001966E File Offset: 0x0001786E
		// (set) Token: 0x06001554 RID: 5460 RVA: 0x00019676 File Offset: 0x00017876
		[DataMember(Name = "includeCredentials", IsRequired = true)]
		public bool IncludeCredentials { get; set; }
	}
}
