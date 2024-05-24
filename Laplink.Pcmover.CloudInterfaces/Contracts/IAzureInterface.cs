using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000005 RID: 5
	public interface IAzureInterface : ICloudStorageCommon, IDisposable
	{
		// Token: 0x1700000D RID: 13
		// (set) Token: 0x0600001E RID: 30
		string StorageAccount { set; }

		// Token: 0x0600001F RID: 31
		void SetCredentialsFromAccessKey(string secret);

		// Token: 0x1700000E RID: 14
		// (set) Token: 0x06000020 RID: 32
		string ClientId { set; }

		// Token: 0x1700000F RID: 15
		// (set) Token: 0x06000021 RID: 33
		string TenantId { set; }

		// Token: 0x06000022 RID: 34
		Task UseIntegratedWindowsAuthenticationAsync(CancellationToken ct);

		// Token: 0x06000023 RID: 35
		Task<List<string>> GetCachedAccountsAsync(CancellationToken ct);

		// Token: 0x06000024 RID: 36
		Task<bool> DoOAuth2AuthenticationAsync(string username, string password, IntPtr hWnd, CancellationToken ct);
	}
}
