using System;
using System.ServiceModel;
using Laplink.Download.Contracts;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x02000024 RID: 36
	public interface IConnectToService
	{
		// Token: 0x060001C6 RID: 454
		IPcmoverControl ConnectToPcmoverControl(EndpointAddress endpointAddress, IPcmoverControlCallback callback);

		// Token: 0x060001C7 RID: 455
		IDownloadControl ConnectToDownloadControl(IDownloadControlCallback callback);
	}
}
