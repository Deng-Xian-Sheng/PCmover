using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x02000006 RID: 6
	public class CloudAuthentication : IDisposable
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600001A RID: 26 RVA: 0x0000223B File Offset: 0x0000043B
		// (set) Token: 0x0600001B RID: 27 RVA: 0x00002243 File Offset: 0x00000443
		public ICloudStorageCommon CloudStorageCommon { get; private set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000224C File Offset: 0x0000044C
		// (set) Token: 0x0600001D RID: 29 RVA: 0x00002254 File Offset: 0x00000454
		public string CloudToken { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600001E RID: 30 RVA: 0x0000225D File Offset: 0x0000045D
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002265 File Offset: 0x00000465
		public List<string> CloudObjects { get; private set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000020 RID: 32 RVA: 0x0000226E File Offset: 0x0000046E
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002276 File Offset: 0x00000476
		public string UserEmail { get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000022 RID: 34 RVA: 0x0000227F File Offset: 0x0000047F
		// (set) Token: 0x06000023 RID: 35 RVA: 0x00002287 File Offset: 0x00000487
		public string Message { get; private set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002290 File Offset: 0x00000490
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00002298 File Offset: 0x00000498
		public string Username { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000026 RID: 38 RVA: 0x000022A1 File Offset: 0x000004A1
		// (set) Token: 0x06000027 RID: 39 RVA: 0x000022A9 File Offset: 0x000004A9
		public string Password { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000022B2 File Offset: 0x000004B2
		// (set) Token: 0x06000029 RID: 41 RVA: 0x000022BA File Offset: 0x000004BA
		public bool IsAuthenticated { get; private set; }

		// Token: 0x0600002A RID: 42 RVA: 0x000022C3 File Offset: 0x000004C3
		public CloudAuthentication(DefaultPolicy policy)
		{
			this._Policy = policy;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000022D4 File Offset: 0x000004D4
		public Task<bool> Authenticate(CancellationToken ct)
		{
			CloudAuthentication.<Authenticate>d__34 <Authenticate>d__;
			<Authenticate>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<Authenticate>d__.<>4__this = this;
			<Authenticate>d__.ct = ct;
			<Authenticate>d__.<>1__state = -1;
			<Authenticate>d__.<>t__builder.Start<CloudAuthentication.<Authenticate>d__34>(ref <Authenticate>d__);
			return <Authenticate>d__.<>t__builder.Task;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002320 File Offset: 0x00000520
		private Task DoAWSAuthentication(CancellationToken ct)
		{
			CloudAuthentication.<DoAWSAuthentication>d__35 <DoAWSAuthentication>d__;
			<DoAWSAuthentication>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<DoAWSAuthentication>d__.<>4__this = this;
			<DoAWSAuthentication>d__.ct = ct;
			<DoAWSAuthentication>d__.<>1__state = -1;
			<DoAWSAuthentication>d__.<>t__builder.Start<CloudAuthentication.<DoAWSAuthentication>d__35>(ref <DoAWSAuthentication>d__);
			return <DoAWSAuthentication>d__.<>t__builder.Task;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000236C File Offset: 0x0000056C
		public Task DoGoogleAuthentication(IAWSInterface aws, CancellationToken ct)
		{
			CloudAuthentication.<DoGoogleAuthentication>d__36 <DoGoogleAuthentication>d__;
			<DoGoogleAuthentication>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<DoGoogleAuthentication>d__.<>4__this = this;
			<DoGoogleAuthentication>d__.aws = aws;
			<DoGoogleAuthentication>d__.ct = ct;
			<DoGoogleAuthentication>d__.<>1__state = -1;
			<DoGoogleAuthentication>d__.<>t__builder.Start<CloudAuthentication.<DoGoogleAuthentication>d__36>(ref <DoGoogleAuthentication>d__);
			return <DoGoogleAuthentication>d__.<>t__builder.Task;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000023C0 File Offset: 0x000005C0
		private Task DoAzureAuthentication(string account, CancellationToken ct)
		{
			CloudAuthentication.<DoAzureAuthentication>d__37 <DoAzureAuthentication>d__;
			<DoAzureAuthentication>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<DoAzureAuthentication>d__.<>4__this = this;
			<DoAzureAuthentication>d__.ct = ct;
			<DoAzureAuthentication>d__.<>1__state = -1;
			<DoAzureAuthentication>d__.<>t__builder.Start<CloudAuthentication.<DoAzureAuthentication>d__37>(ref <DoAzureAuthentication>d__);
			return <DoAzureAuthentication>d__.<>t__builder.Task;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000240B File Offset: 0x0000060B
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposedValue)
			{
				ICloudStorageCommon cloudStorageCommon = this.CloudStorageCommon;
				if (cloudStorageCommon != null)
				{
					cloudStorageCommon.Dispose();
				}
				this.disposedValue = true;
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000242D File Offset: 0x0000062D
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0400000D RID: 13
		private readonly DefaultPolicy _Policy;

		// Token: 0x04000015 RID: 21
		private bool disposedValue;
	}
}
