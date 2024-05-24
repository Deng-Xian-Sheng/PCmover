using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.ServiceWorker
{
	// Token: 0x02000211 RID: 529
	[DataContract]
	public class WorkerErrorReportedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06000F36 RID: 3894 RVA: 0x0001431D File Offset: 0x0001251D
		// (set) Token: 0x06000F37 RID: 3895 RVA: 0x00014325 File Offset: 0x00012525
		[DataMember(Name = "errorMessage", IsRequired = true)]
		public ServiceWorkerErrorMessage ErrorMessage { get; private set; }
	}
}
