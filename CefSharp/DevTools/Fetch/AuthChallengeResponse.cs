using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Fetch
{
	// Token: 0x020001C7 RID: 455
	[DataContract]
	public class AuthChallengeResponse : DevToolsDomainEntityBase
	{
		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06000D25 RID: 3365 RVA: 0x00012206 File Offset: 0x00010406
		// (set) Token: 0x06000D26 RID: 3366 RVA: 0x00012222 File Offset: 0x00010422
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

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06000D27 RID: 3367 RVA: 0x00012235 File Offset: 0x00010435
		// (set) Token: 0x06000D28 RID: 3368 RVA: 0x0001223D File Offset: 0x0001043D
		[DataMember(Name = "response", IsRequired = true)]
		internal string response { get; set; }

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06000D29 RID: 3369 RVA: 0x00012246 File Offset: 0x00010446
		// (set) Token: 0x06000D2A RID: 3370 RVA: 0x0001224E File Offset: 0x0001044E
		[DataMember(Name = "username", IsRequired = false)]
		public string Username { get; set; }

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06000D2B RID: 3371 RVA: 0x00012257 File Offset: 0x00010457
		// (set) Token: 0x06000D2C RID: 3372 RVA: 0x0001225F File Offset: 0x0001045F
		[DataMember(Name = "password", IsRequired = false)]
		public string Password { get; set; }
	}
}
