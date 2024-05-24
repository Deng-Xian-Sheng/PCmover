using System;
using System.Threading;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000027 RID: 39
	public class ServiceNetworkTransferMethod : ServiceTransferMethod
	{
		// Token: 0x06000208 RID: 520 RVA: 0x0000F99C File Offset: 0x0000DB9C
		public override ConnectionMethod GetConnectionMethod()
		{
			return (ConnectionMethod)this.NetworkTransferMethod;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000F9A9 File Offset: 0x0000DBA9
		public override string GetPassword()
		{
			return this.Password;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0000F9B1 File Offset: 0x0000DBB1
		public override void Cancel()
		{
			CancellationTokenSource cancellationTokenSource = this.cts;
			if (cancellationTokenSource != null)
			{
				cancellationTokenSource.Cancel();
			}
			base.Cancel();
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000F9CA File Offset: 0x0000DBCA
		public override void InitCancellationToken()
		{
			this.cts = new CancellationTokenSource();
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600020C RID: 524 RVA: 0x0000F9D7 File Offset: 0x0000DBD7
		public override CancellationToken CancellationToken
		{
			get
			{
				if (this.cts != null)
				{
					return this.cts.Token;
				}
				return CancellationToken.None;
			}
		}

		// Token: 0x04000092 RID: 146
		public NetworkTransferMethod NetworkTransferMethod;

		// Token: 0x04000093 RID: 147
		public string Password;

		// Token: 0x04000094 RID: 148
		private CancellationTokenSource cts;
	}
}
