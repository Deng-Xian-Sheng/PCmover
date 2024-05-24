using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000002 RID: 2
	public interface ICloudStorageCommon : IDisposable
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1
		string RefreshToken { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000002 RID: 2
		string UserEmail { get; }

		// Token: 0x06000003 RID: 3
		Task<List<string>> FindObjectsAsync(string bucket, string prefix, CancellationToken ct);

		// Token: 0x06000004 RID: 4
		Task<bool> DeleteObjectsAsync(string bucket, string prefix, CancellationToken ct);

		// Token: 0x06000005 RID: 5
		Task LogoutAsync(string logoutUrl, CancellationToken ct);

		// Token: 0x06000006 RID: 6
		Task<object> GetCredentialsAsync(CancellationToken ct);
	}
}
