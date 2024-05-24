using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x02000209 RID: 521
	[DataContract]
	public class ClearTrustTokensResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06000EEA RID: 3818 RVA: 0x00013D49 File Offset: 0x00011F49
		// (set) Token: 0x06000EEB RID: 3819 RVA: 0x00013D51 File Offset: 0x00011F51
		[DataMember]
		internal bool didDeleteTokens { get; set; }

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06000EEC RID: 3820 RVA: 0x00013D5A File Offset: 0x00011F5A
		public bool DidDeleteTokens
		{
			get
			{
				return this.didDeleteTokens;
			}
		}
	}
}
