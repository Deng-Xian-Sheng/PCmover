using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.ServiceWorker
{
	// Token: 0x02000213 RID: 531
	[DataContract]
	public class WorkerVersionUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x06000F3C RID: 3900 RVA: 0x0001434F File Offset: 0x0001254F
		// (set) Token: 0x06000F3D RID: 3901 RVA: 0x00014357 File Offset: 0x00012557
		[DataMember(Name = "versions", IsRequired = true)]
		public IList<ServiceWorkerVersion> Versions { get; private set; }
	}
}
