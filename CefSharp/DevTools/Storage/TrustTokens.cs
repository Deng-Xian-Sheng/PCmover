using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x020001FD RID: 509
	[DataContract]
	public class TrustTokens : DevToolsDomainEntityBase
	{
		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06000E95 RID: 3733 RVA: 0x00013A61 File Offset: 0x00011C61
		// (set) Token: 0x06000E96 RID: 3734 RVA: 0x00013A69 File Offset: 0x00011C69
		[DataMember(Name = "issuerOrigin", IsRequired = true)]
		public string IssuerOrigin { get; set; }

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06000E97 RID: 3735 RVA: 0x00013A72 File Offset: 0x00011C72
		// (set) Token: 0x06000E98 RID: 3736 RVA: 0x00013A7A File Offset: 0x00011C7A
		[DataMember(Name = "count", IsRequired = true)]
		public double Count { get; set; }
	}
}
