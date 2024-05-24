using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAuthn
{
	// Token: 0x020001A3 RID: 419
	[DataContract]
	public class Credential : DevToolsDomainEntityBase
	{
		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x06000C2D RID: 3117 RVA: 0x0001156B File Offset: 0x0000F76B
		// (set) Token: 0x06000C2E RID: 3118 RVA: 0x00011573 File Offset: 0x0000F773
		[DataMember(Name = "credentialId", IsRequired = true)]
		public byte[] CredentialId { get; set; }

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06000C2F RID: 3119 RVA: 0x0001157C File Offset: 0x0000F77C
		// (set) Token: 0x06000C30 RID: 3120 RVA: 0x00011584 File Offset: 0x0000F784
		[DataMember(Name = "isResidentCredential", IsRequired = true)]
		public bool IsResidentCredential { get; set; }

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06000C31 RID: 3121 RVA: 0x0001158D File Offset: 0x0000F78D
		// (set) Token: 0x06000C32 RID: 3122 RVA: 0x00011595 File Offset: 0x0000F795
		[DataMember(Name = "rpId", IsRequired = false)]
		public string RpId { get; set; }

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06000C33 RID: 3123 RVA: 0x0001159E File Offset: 0x0000F79E
		// (set) Token: 0x06000C34 RID: 3124 RVA: 0x000115A6 File Offset: 0x0000F7A6
		[DataMember(Name = "privateKey", IsRequired = true)]
		public byte[] PrivateKey { get; set; }

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06000C35 RID: 3125 RVA: 0x000115AF File Offset: 0x0000F7AF
		// (set) Token: 0x06000C36 RID: 3126 RVA: 0x000115B7 File Offset: 0x0000F7B7
		[DataMember(Name = "userHandle", IsRequired = false)]
		public byte[] UserHandle { get; set; }

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x06000C37 RID: 3127 RVA: 0x000115C0 File Offset: 0x0000F7C0
		// (set) Token: 0x06000C38 RID: 3128 RVA: 0x000115C8 File Offset: 0x0000F7C8
		[DataMember(Name = "signCount", IsRequired = true)]
		public int SignCount { get; set; }

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x06000C39 RID: 3129 RVA: 0x000115D1 File Offset: 0x0000F7D1
		// (set) Token: 0x06000C3A RID: 3130 RVA: 0x000115D9 File Offset: 0x0000F7D9
		[DataMember(Name = "largeBlob", IsRequired = false)]
		public byte[] LargeBlob { get; set; }
	}
}
