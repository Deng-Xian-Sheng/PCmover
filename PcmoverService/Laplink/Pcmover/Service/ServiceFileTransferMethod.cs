using System;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200002B RID: 43
	public class ServiceFileTransferMethod : ServiceTransferMethod
	{
		// Token: 0x06000212 RID: 530 RVA: 0x0000FA0F File Offset: 0x0000DC0F
		public override TransferMethod GetTransferMethod()
		{
			return (TransferMethod)this.FileTransferMethod;
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000213 RID: 531 RVA: 0x0000FA1C File Offset: 0x0000DC1C
		// (set) Token: 0x06000214 RID: 532 RVA: 0x0000FA37 File Offset: 0x0000DC37
		public string AnyMachineName
		{
			get
			{
				if (string.IsNullOrEmpty(this._anyMachineName))
				{
					return "Any";
				}
				return this._anyMachineName;
			}
			set
			{
				this._anyMachineName = value;
			}
		}

		// Token: 0x04000098 RID: 152
		public FileTransferMethod FileTransferMethod;

		// Token: 0x04000099 RID: 153
		private string _anyMachineName;
	}
}
