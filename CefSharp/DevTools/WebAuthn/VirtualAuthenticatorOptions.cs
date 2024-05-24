using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAuthn
{
	// Token: 0x020001A2 RID: 418
	[DataContract]
	public class VirtualAuthenticatorOptions : DevToolsDomainEntityBase
	{
		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06000C12 RID: 3090 RVA: 0x0001142C File Offset: 0x0000F62C
		// (set) Token: 0x06000C13 RID: 3091 RVA: 0x00011448 File Offset: 0x0000F648
		public AuthenticatorProtocol Protocol
		{
			get
			{
				return (AuthenticatorProtocol)DevToolsDomainEntityBase.StringToEnum(typeof(AuthenticatorProtocol), this.protocol);
			}
			set
			{
				this.protocol = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000C14 RID: 3092 RVA: 0x0001145B File Offset: 0x0000F65B
		// (set) Token: 0x06000C15 RID: 3093 RVA: 0x00011463 File Offset: 0x0000F663
		[DataMember(Name = "protocol", IsRequired = true)]
		internal string protocol { get; set; }

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06000C16 RID: 3094 RVA: 0x0001146C File Offset: 0x0000F66C
		// (set) Token: 0x06000C17 RID: 3095 RVA: 0x00011488 File Offset: 0x0000F688
		public Ctap2Version? Ctap2Version
		{
			get
			{
				return (Ctap2Version?)DevToolsDomainEntityBase.StringToEnum(typeof(Ctap2Version?), this.ctap2Version);
			}
			set
			{
				this.ctap2Version = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000C18 RID: 3096 RVA: 0x0001149B File Offset: 0x0000F69B
		// (set) Token: 0x06000C19 RID: 3097 RVA: 0x000114A3 File Offset: 0x0000F6A3
		[DataMember(Name = "ctap2Version", IsRequired = false)]
		internal string ctap2Version { get; set; }

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000C1A RID: 3098 RVA: 0x000114AC File Offset: 0x0000F6AC
		// (set) Token: 0x06000C1B RID: 3099 RVA: 0x000114C8 File Offset: 0x0000F6C8
		public AuthenticatorTransport Transport
		{
			get
			{
				return (AuthenticatorTransport)DevToolsDomainEntityBase.StringToEnum(typeof(AuthenticatorTransport), this.transport);
			}
			set
			{
				this.transport = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06000C1C RID: 3100 RVA: 0x000114DB File Offset: 0x0000F6DB
		// (set) Token: 0x06000C1D RID: 3101 RVA: 0x000114E3 File Offset: 0x0000F6E3
		[DataMember(Name = "transport", IsRequired = true)]
		internal string transport { get; set; }

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06000C1E RID: 3102 RVA: 0x000114EC File Offset: 0x0000F6EC
		// (set) Token: 0x06000C1F RID: 3103 RVA: 0x000114F4 File Offset: 0x0000F6F4
		[DataMember(Name = "hasResidentKey", IsRequired = false)]
		public bool? HasResidentKey { get; set; }

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06000C20 RID: 3104 RVA: 0x000114FD File Offset: 0x0000F6FD
		// (set) Token: 0x06000C21 RID: 3105 RVA: 0x00011505 File Offset: 0x0000F705
		[DataMember(Name = "hasUserVerification", IsRequired = false)]
		public bool? HasUserVerification { get; set; }

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000C22 RID: 3106 RVA: 0x0001150E File Offset: 0x0000F70E
		// (set) Token: 0x06000C23 RID: 3107 RVA: 0x00011516 File Offset: 0x0000F716
		[DataMember(Name = "hasLargeBlob", IsRequired = false)]
		public bool? HasLargeBlob { get; set; }

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000C24 RID: 3108 RVA: 0x0001151F File Offset: 0x0000F71F
		// (set) Token: 0x06000C25 RID: 3109 RVA: 0x00011527 File Offset: 0x0000F727
		[DataMember(Name = "hasCredBlob", IsRequired = false)]
		public bool? HasCredBlob { get; set; }

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000C26 RID: 3110 RVA: 0x00011530 File Offset: 0x0000F730
		// (set) Token: 0x06000C27 RID: 3111 RVA: 0x00011538 File Offset: 0x0000F738
		[DataMember(Name = "hasMinPinLength", IsRequired = false)]
		public bool? HasMinPinLength { get; set; }

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000C28 RID: 3112 RVA: 0x00011541 File Offset: 0x0000F741
		// (set) Token: 0x06000C29 RID: 3113 RVA: 0x00011549 File Offset: 0x0000F749
		[DataMember(Name = "automaticPresenceSimulation", IsRequired = false)]
		public bool? AutomaticPresenceSimulation { get; set; }

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x06000C2A RID: 3114 RVA: 0x00011552 File Offset: 0x0000F752
		// (set) Token: 0x06000C2B RID: 3115 RVA: 0x0001155A File Offset: 0x0000F75A
		[DataMember(Name = "isUserVerified", IsRequired = false)]
		public bool? IsUserVerified { get; set; }
	}
}
