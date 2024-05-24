using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002DF RID: 735
	[DataContract]
	public class ReportingApiEndpoint : DevToolsDomainEntityBase
	{
		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x0600153F RID: 5439 RVA: 0x000195C5 File Offset: 0x000177C5
		// (set) Token: 0x06001540 RID: 5440 RVA: 0x000195CD File Offset: 0x000177CD
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x1700077E RID: 1918
		// (get) Token: 0x06001541 RID: 5441 RVA: 0x000195D6 File Offset: 0x000177D6
		// (set) Token: 0x06001542 RID: 5442 RVA: 0x000195DE File Offset: 0x000177DE
		[DataMember(Name = "groupName", IsRequired = true)]
		public string GroupName { get; set; }
	}
}
