using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMStorage
{
	// Token: 0x02000366 RID: 870
	[DataContract]
	public class DomStorageItemUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170008E4 RID: 2276
		// (get) Token: 0x06001911 RID: 6417 RVA: 0x0001DD0B File Offset: 0x0001BF0B
		// (set) Token: 0x06001912 RID: 6418 RVA: 0x0001DD13 File Offset: 0x0001BF13
		[DataMember(Name = "storageId", IsRequired = true)]
		public StorageId StorageId { get; private set; }

		// Token: 0x170008E5 RID: 2277
		// (get) Token: 0x06001913 RID: 6419 RVA: 0x0001DD1C File Offset: 0x0001BF1C
		// (set) Token: 0x06001914 RID: 6420 RVA: 0x0001DD24 File Offset: 0x0001BF24
		[DataMember(Name = "key", IsRequired = true)]
		public string Key { get; private set; }

		// Token: 0x170008E6 RID: 2278
		// (get) Token: 0x06001915 RID: 6421 RVA: 0x0001DD2D File Offset: 0x0001BF2D
		// (set) Token: 0x06001916 RID: 6422 RVA: 0x0001DD35 File Offset: 0x0001BF35
		[DataMember(Name = "oldValue", IsRequired = true)]
		public string OldValue { get; private set; }

		// Token: 0x170008E7 RID: 2279
		// (get) Token: 0x06001917 RID: 6423 RVA: 0x0001DD3E File Offset: 0x0001BF3E
		// (set) Token: 0x06001918 RID: 6424 RVA: 0x0001DD46 File Offset: 0x0001BF46
		[DataMember(Name = "newValue", IsRequired = true)]
		public string NewValue { get; private set; }
	}
}
