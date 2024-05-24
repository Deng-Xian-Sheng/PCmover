using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAuthn
{
	// Token: 0x020001A6 RID: 422
	[DataContract]
	public class GetCredentialsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06000C44 RID: 3140 RVA: 0x0001162C File Offset: 0x0000F82C
		// (set) Token: 0x06000C45 RID: 3141 RVA: 0x00011634 File Offset: 0x0000F834
		[DataMember]
		internal IList<Credential> credentials { get; set; }

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06000C46 RID: 3142 RVA: 0x0001163D File Offset: 0x0000F83D
		public IList<Credential> Credentials
		{
			get
			{
				return this.credentials;
			}
		}
	}
}
