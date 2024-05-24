using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAuthn
{
	// Token: 0x020001A5 RID: 421
	[DataContract]
	public class GetCredentialResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06000C40 RID: 3136 RVA: 0x0001160B File Offset: 0x0000F80B
		// (set) Token: 0x06000C41 RID: 3137 RVA: 0x00011613 File Offset: 0x0000F813
		[DataMember]
		internal Credential credential { get; set; }

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06000C42 RID: 3138 RVA: 0x0001161C File Offset: 0x0000F81C
		public Credential Credential
		{
			get
			{
				return this.credential;
			}
		}
	}
}
