using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Fetch
{
	// Token: 0x020001C5 RID: 453
	[DataContract]
	public class AuthChallenge : DevToolsDomainEntityBase
	{
		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06000D1A RID: 3354 RVA: 0x0001218B File Offset: 0x0001038B
		// (set) Token: 0x06000D1B RID: 3355 RVA: 0x000121A7 File Offset: 0x000103A7
		public AuthChallengeSource? Source
		{
			get
			{
				return (AuthChallengeSource?)DevToolsDomainEntityBase.StringToEnum(typeof(AuthChallengeSource?), this.source);
			}
			set
			{
				this.source = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06000D1C RID: 3356 RVA: 0x000121BA File Offset: 0x000103BA
		// (set) Token: 0x06000D1D RID: 3357 RVA: 0x000121C2 File Offset: 0x000103C2
		[DataMember(Name = "source", IsRequired = false)]
		internal string source { get; set; }

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06000D1E RID: 3358 RVA: 0x000121CB File Offset: 0x000103CB
		// (set) Token: 0x06000D1F RID: 3359 RVA: 0x000121D3 File Offset: 0x000103D3
		[DataMember(Name = "origin", IsRequired = true)]
		public string Origin { get; set; }

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06000D20 RID: 3360 RVA: 0x000121DC File Offset: 0x000103DC
		// (set) Token: 0x06000D21 RID: 3361 RVA: 0x000121E4 File Offset: 0x000103E4
		[DataMember(Name = "scheme", IsRequired = true)]
		public string Scheme { get; set; }

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06000D22 RID: 3362 RVA: 0x000121ED File Offset: 0x000103ED
		// (set) Token: 0x06000D23 RID: 3363 RVA: 0x000121F5 File Offset: 0x000103F5
		[DataMember(Name = "realm", IsRequired = true)]
		public string Realm { get; set; }
	}
}
