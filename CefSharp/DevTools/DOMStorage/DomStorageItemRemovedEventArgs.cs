using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMStorage
{
	// Token: 0x02000365 RID: 869
	[DataContract]
	public class DomStorageItemRemovedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170008E2 RID: 2274
		// (get) Token: 0x0600190C RID: 6412 RVA: 0x0001DCE1 File Offset: 0x0001BEE1
		// (set) Token: 0x0600190D RID: 6413 RVA: 0x0001DCE9 File Offset: 0x0001BEE9
		[DataMember(Name = "storageId", IsRequired = true)]
		public StorageId StorageId { get; private set; }

		// Token: 0x170008E3 RID: 2275
		// (get) Token: 0x0600190E RID: 6414 RVA: 0x0001DCF2 File Offset: 0x0001BEF2
		// (set) Token: 0x0600190F RID: 6415 RVA: 0x0001DCFA File Offset: 0x0001BEFA
		[DataMember(Name = "key", IsRequired = true)]
		public string Key { get; private set; }
	}
}
