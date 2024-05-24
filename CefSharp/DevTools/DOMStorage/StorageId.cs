using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMStorage
{
	// Token: 0x02000363 RID: 867
	[DataContract]
	public class StorageId : DevToolsDomainEntityBase
	{
		// Token: 0x170008DD RID: 2269
		// (get) Token: 0x06001900 RID: 6400 RVA: 0x0001DC7C File Offset: 0x0001BE7C
		// (set) Token: 0x06001901 RID: 6401 RVA: 0x0001DC84 File Offset: 0x0001BE84
		[DataMember(Name = "securityOrigin", IsRequired = true)]
		public string SecurityOrigin { get; set; }

		// Token: 0x170008DE RID: 2270
		// (get) Token: 0x06001902 RID: 6402 RVA: 0x0001DC8D File Offset: 0x0001BE8D
		// (set) Token: 0x06001903 RID: 6403 RVA: 0x0001DC95 File Offset: 0x0001BE95
		[DataMember(Name = "isLocalStorage", IsRequired = true)]
		public bool IsLocalStorage { get; set; }
	}
}
