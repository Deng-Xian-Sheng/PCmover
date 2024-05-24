using System;
using System.Threading;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000026 RID: 38
	public class ServiceTransferMethod : TransferMethodData
	{
		// Token: 0x06000201 RID: 513 RVA: 0x00003181 File Offset: 0x00001381
		public virtual ConnectionMethod GetConnectionMethod()
		{
			return null;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000F95A File Offset: 0x0000DB5A
		public virtual TransferMethod GetTransferMethod()
		{
			return (TransferMethod)this.GetConnectionMethod();
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000F967 File Offset: 0x0000DB67
		public virtual string GetPassword()
		{
			return "";
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000204 RID: 516 RVA: 0x0000F96E File Offset: 0x0000DB6E
		public virtual CancellationToken CancellationToken
		{
			get
			{
				return CancellationToken.None;
			}
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0000F975 File Offset: 0x0000DB75
		public virtual void Cancel()
		{
			ConnectionMethod connectionMethod = this.GetConnectionMethod();
			if (connectionMethod != null)
			{
				connectionMethod.Cancel();
			}
			if (connectionMethod == null)
			{
				return;
			}
			connectionMethod.CloseConnection();
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00003A90 File Offset: 0x00001C90
		public virtual void InitCancellationToken()
		{
		}
	}
}
