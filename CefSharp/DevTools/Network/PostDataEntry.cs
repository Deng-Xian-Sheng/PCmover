using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002AE RID: 686
	[DataContract]
	public class PostDataEntry : DevToolsDomainEntityBase
	{
		// Token: 0x170006B2 RID: 1714
		// (get) Token: 0x0600138C RID: 5004 RVA: 0x000183CA File Offset: 0x000165CA
		// (set) Token: 0x0600138D RID: 5005 RVA: 0x000183D2 File Offset: 0x000165D2
		[DataMember(Name = "bytes", IsRequired = false)]
		public byte[] Bytes { get; set; }
	}
}
