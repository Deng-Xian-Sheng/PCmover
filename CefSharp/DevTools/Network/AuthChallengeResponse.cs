using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002CB RID: 715
	[DataContract]
	public class AuthChallengeResponse : DevToolsDomainEntityBase
	{
		// Token: 0x17000740 RID: 1856
		// (get) Token: 0x060014B9 RID: 5305 RVA: 0x0001900E File Offset: 0x0001720E
		// (set) Token: 0x060014BA RID: 5306 RVA: 0x0001902A File Offset: 0x0001722A
		public AuthChallengeResponseResponse Response
		{
			get
			{
				return (AuthChallengeResponseResponse)DevToolsDomainEntityBase.StringToEnum(typeof(AuthChallengeResponseResponse), this.response);
			}
			set
			{
				this.response = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000741 RID: 1857
		// (get) Token: 0x060014BB RID: 5307 RVA: 0x0001903D File Offset: 0x0001723D
		// (set) Token: 0x060014BC RID: 5308 RVA: 0x00019045 File Offset: 0x00017245
		[DataMember(Name = "response", IsRequired = true)]
		internal string response { get; set; }

		// Token: 0x17000742 RID: 1858
		// (get) Token: 0x060014BD RID: 5309 RVA: 0x0001904E File Offset: 0x0001724E
		// (set) Token: 0x060014BE RID: 5310 RVA: 0x00019056 File Offset: 0x00017256
		[DataMember(Name = "username", IsRequired = false)]
		public string Username { get; set; }

		// Token: 0x17000743 RID: 1859
		// (get) Token: 0x060014BF RID: 5311 RVA: 0x0001905F File Offset: 0x0001725F
		// (set) Token: 0x060014C0 RID: 5312 RVA: 0x00019067 File Offset: 0x00017267
		[DataMember(Name = "password", IsRequired = false)]
		public string Password { get; set; }
	}
}
