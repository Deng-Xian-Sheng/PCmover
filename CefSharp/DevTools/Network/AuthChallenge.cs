using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002C9 RID: 713
	[DataContract]
	public class AuthChallenge : DevToolsDomainEntityBase
	{
		// Token: 0x1700073B RID: 1851
		// (get) Token: 0x060014AE RID: 5294 RVA: 0x00018F93 File Offset: 0x00017193
		// (set) Token: 0x060014AF RID: 5295 RVA: 0x00018FAF File Offset: 0x000171AF
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

		// Token: 0x1700073C RID: 1852
		// (get) Token: 0x060014B0 RID: 5296 RVA: 0x00018FC2 File Offset: 0x000171C2
		// (set) Token: 0x060014B1 RID: 5297 RVA: 0x00018FCA File Offset: 0x000171CA
		[DataMember(Name = "source", IsRequired = false)]
		internal string source { get; set; }

		// Token: 0x1700073D RID: 1853
		// (get) Token: 0x060014B2 RID: 5298 RVA: 0x00018FD3 File Offset: 0x000171D3
		// (set) Token: 0x060014B3 RID: 5299 RVA: 0x00018FDB File Offset: 0x000171DB
		[DataMember(Name = "origin", IsRequired = true)]
		public string Origin { get; set; }

		// Token: 0x1700073E RID: 1854
		// (get) Token: 0x060014B4 RID: 5300 RVA: 0x00018FE4 File Offset: 0x000171E4
		// (set) Token: 0x060014B5 RID: 5301 RVA: 0x00018FEC File Offset: 0x000171EC
		[DataMember(Name = "scheme", IsRequired = true)]
		public string Scheme { get; set; }

		// Token: 0x1700073F RID: 1855
		// (get) Token: 0x060014B6 RID: 5302 RVA: 0x00018FF5 File Offset: 0x000171F5
		// (set) Token: 0x060014B7 RID: 5303 RVA: 0x00018FFD File Offset: 0x000171FD
		[DataMember(Name = "realm", IsRequired = true)]
		public string Realm { get; set; }
	}
}
