using System;
using System.Threading;
using System.Threading.Tasks;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000004 RID: 4
	public interface IAWSInterface : ICloudStorageCommon, IDisposable
	{
		// Token: 0x17000007 RID: 7
		// (set) Token: 0x06000010 RID: 16
		string Region { set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000011 RID: 17
		// (set) Token: 0x06000012 RID: 18
		string IdentityPoolId { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000013 RID: 19
		// (set) Token: 0x06000014 RID: 20
		string ClientId { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000015 RID: 21
		// (set) Token: 0x06000016 RID: 22
		string UserPoolId { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000017 RID: 23
		string ProviderName { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000018 RID: 24
		// (set) Token: 0x06000019 RID: 25
		string Domain { get; set; }

		// Token: 0x0600001A RID: 26
		void SetCredentialsFromAccessKey(string key, string secret);

		// Token: 0x0600001B RID: 27
		Task DoOAuth2AuthenticationAsync(string redirectUrl, CancellationToken ct);

		// Token: 0x0600001C RID: 28
		Task SetGCSInterfaceAsync(IGCSInterface gcs, CancellationToken ct);

		// Token: 0x0600001D RID: 29
		void UseDefaultCredentials(CancellationToken ct);
	}
}
