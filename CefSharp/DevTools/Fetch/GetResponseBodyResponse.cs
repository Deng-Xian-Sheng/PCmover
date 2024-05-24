using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Fetch
{
	// Token: 0x020001CA RID: 458
	[DataContract]
	public class GetResponseBodyResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x06000D52 RID: 3410 RVA: 0x000123FB File Offset: 0x000105FB
		// (set) Token: 0x06000D53 RID: 3411 RVA: 0x00012403 File Offset: 0x00010603
		[DataMember]
		internal string body { get; set; }

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06000D54 RID: 3412 RVA: 0x0001240C File Offset: 0x0001060C
		public string Body
		{
			get
			{
				return this.body;
			}
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06000D55 RID: 3413 RVA: 0x00012414 File Offset: 0x00010614
		// (set) Token: 0x06000D56 RID: 3414 RVA: 0x0001241C File Offset: 0x0001061C
		[DataMember]
		internal bool base64Encoded { get; set; }

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06000D57 RID: 3415 RVA: 0x00012425 File Offset: 0x00010625
		public bool Base64Encoded
		{
			get
			{
				return this.base64Encoded;
			}
		}
	}
}
