using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools
{
	// Token: 0x0200011E RID: 286
	[DataContract]
	public class DevToolsDomainErrorResponse
	{
		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000866 RID: 2150 RVA: 0x0000DA44 File Offset: 0x0000BC44
		// (set) Token: 0x06000867 RID: 2151 RVA: 0x0000DA4C File Offset: 0x0000BC4C
		[IgnoreDataMember]
		public int MessageId { get; set; }

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000868 RID: 2152 RVA: 0x0000DA55 File Offset: 0x0000BC55
		// (set) Token: 0x06000869 RID: 2153 RVA: 0x0000DA5D File Offset: 0x0000BC5D
		[DataMember(Name = "code", IsRequired = true)]
		public int Code { get; set; }

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x0000DA66 File Offset: 0x0000BC66
		// (set) Token: 0x0600086B RID: 2155 RVA: 0x0000DA6E File Offset: 0x0000BC6E
		[DataMember(Name = "message", IsRequired = true)]
		public string Message { get; set; }
	}
}
