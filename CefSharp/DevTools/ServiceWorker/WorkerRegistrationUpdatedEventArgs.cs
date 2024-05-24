using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.ServiceWorker
{
	// Token: 0x02000212 RID: 530
	[DataContract]
	public class WorkerRegistrationUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06000F39 RID: 3897 RVA: 0x00014336 File Offset: 0x00012536
		// (set) Token: 0x06000F3A RID: 3898 RVA: 0x0001433E File Offset: 0x0001253E
		[DataMember(Name = "registrations", IsRequired = true)]
		public IList<ServiceWorkerRegistration> Registrations { get; private set; }
	}
}
