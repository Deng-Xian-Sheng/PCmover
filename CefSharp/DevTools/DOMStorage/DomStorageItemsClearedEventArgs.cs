using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMStorage
{
	// Token: 0x02000367 RID: 871
	[DataContract]
	public class DomStorageItemsClearedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170008E8 RID: 2280
		// (get) Token: 0x0600191A RID: 6426 RVA: 0x0001DD57 File Offset: 0x0001BF57
		// (set) Token: 0x0600191B RID: 6427 RVA: 0x0001DD5F File Offset: 0x0001BF5F
		[DataMember(Name = "storageId", IsRequired = true)]
		public StorageId StorageId { get; private set; }
	}
}
