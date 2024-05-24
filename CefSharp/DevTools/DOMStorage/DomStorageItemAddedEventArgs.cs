using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMStorage
{
	// Token: 0x02000364 RID: 868
	[DataContract]
	public class DomStorageItemAddedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170008DF RID: 2271
		// (get) Token: 0x06001905 RID: 6405 RVA: 0x0001DCA6 File Offset: 0x0001BEA6
		// (set) Token: 0x06001906 RID: 6406 RVA: 0x0001DCAE File Offset: 0x0001BEAE
		[DataMember(Name = "storageId", IsRequired = true)]
		public StorageId StorageId { get; private set; }

		// Token: 0x170008E0 RID: 2272
		// (get) Token: 0x06001907 RID: 6407 RVA: 0x0001DCB7 File Offset: 0x0001BEB7
		// (set) Token: 0x06001908 RID: 6408 RVA: 0x0001DCBF File Offset: 0x0001BEBF
		[DataMember(Name = "key", IsRequired = true)]
		public string Key { get; private set; }

		// Token: 0x170008E1 RID: 2273
		// (get) Token: 0x06001909 RID: 6409 RVA: 0x0001DCC8 File Offset: 0x0001BEC8
		// (set) Token: 0x0600190A RID: 6410 RVA: 0x0001DCD0 File Offset: 0x0001BED0
		[DataMember(Name = "newValue", IsRequired = true)]
		public string NewValue { get; private set; }
	}
}
