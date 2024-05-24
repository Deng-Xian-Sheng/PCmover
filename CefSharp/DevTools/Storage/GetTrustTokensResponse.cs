using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x02000208 RID: 520
	[DataContract]
	public class GetTrustTokensResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06000EE6 RID: 3814 RVA: 0x00013D28 File Offset: 0x00011F28
		// (set) Token: 0x06000EE7 RID: 3815 RVA: 0x00013D30 File Offset: 0x00011F30
		[DataMember]
		internal IList<TrustTokens> tokens { get; set; }

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06000EE8 RID: 3816 RVA: 0x00013D39 File Offset: 0x00011F39
		public IList<TrustTokens> Tokens
		{
			get
			{
				return this.tokens;
			}
		}
	}
}
