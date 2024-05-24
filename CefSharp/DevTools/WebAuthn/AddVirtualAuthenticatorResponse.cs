using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAuthn
{
	// Token: 0x020001A4 RID: 420
	[DataContract]
	public class AddVirtualAuthenticatorResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170003DA RID: 986
		// (get) Token: 0x06000C3C RID: 3132 RVA: 0x000115EA File Offset: 0x0000F7EA
		// (set) Token: 0x06000C3D RID: 3133 RVA: 0x000115F2 File Offset: 0x0000F7F2
		[DataMember]
		internal string authenticatorId { get; set; }

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06000C3E RID: 3134 RVA: 0x000115FB File Offset: 0x0000F7FB
		public string AuthenticatorId
		{
			get
			{
				return this.authenticatorId;
			}
		}
	}
}
