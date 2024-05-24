using System;
using System.ServiceModel;

namespace Laplink.Download.Contracts
{
	// Token: 0x0200000D RID: 13
	[ServiceContract(Namespace = "http://laplink.com/services/downloadcontracts/v2.0056")]
	public interface IDownloadQuery
	{
		// Token: 0x06000038 RID: 56
		[OperationContract]
		Version GetDownloadVersion();

		// Token: 0x06000039 RID: 57
		[OperationContract]
		DownloadStatusInfo GetDownloadStatus();
	}
}
