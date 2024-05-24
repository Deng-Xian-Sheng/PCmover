using System;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000028 RID: 40
	public class ServiceUsbTransferMethod : ServiceTransferMethod
	{
		// Token: 0x0600020E RID: 526 RVA: 0x0000F9FA File Offset: 0x0000DBFA
		public override ConnectionMethod GetConnectionMethod()
		{
			return (ConnectionMethod)this.UsbTransferMethod;
		}

		// Token: 0x04000095 RID: 149
		public USBTransferMethod UsbTransferMethod;
	}
}
