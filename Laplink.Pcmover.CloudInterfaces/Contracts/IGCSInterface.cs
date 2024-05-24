using System;
using System.Threading;
using System.Threading.Tasks;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000003 RID: 3
	public interface IGCSInterface : ICloudStorageCommon, IDisposable
	{
		// Token: 0x06000007 RID: 7
		void SetCredentialsFromServiceAccount(string json);

		// Token: 0x06000008 RID: 8
		Task DoOAuth2AuthenticationAsync(string json, string userHint, bool requestStorageScope, CancellationToken ct);

		// Token: 0x06000009 RID: 9
		Task UseDefaultCredentialsAsync(CancellationToken ct);

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000A RID: 10
		// (set) Token: 0x0600000B RID: 11
		string RequiredGroup { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000C RID: 12
		string IdToken { get; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000D RID: 13
		string Name { get; }

		// Token: 0x0600000E RID: 14
		Task RefreshTokensAsync(CancellationToken ct);

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000F RID: 15
		long ExpiresIn { get; }
	}
}
