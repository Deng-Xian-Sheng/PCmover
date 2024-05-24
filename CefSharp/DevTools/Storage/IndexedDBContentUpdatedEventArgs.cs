using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x02000203 RID: 515
	[DataContract]
	public class IndexedDBContentUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06000EC0 RID: 3776 RVA: 0x00013BCC File Offset: 0x00011DCC
		// (set) Token: 0x06000EC1 RID: 3777 RVA: 0x00013BD4 File Offset: 0x00011DD4
		[DataMember(Name = "origin", IsRequired = true)]
		public string Origin { get; private set; }

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06000EC2 RID: 3778 RVA: 0x00013BDD File Offset: 0x00011DDD
		// (set) Token: 0x06000EC3 RID: 3779 RVA: 0x00013BE5 File Offset: 0x00011DE5
		[DataMember(Name = "databaseName", IsRequired = true)]
		public string DatabaseName { get; private set; }

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06000EC4 RID: 3780 RVA: 0x00013BEE File Offset: 0x00011DEE
		// (set) Token: 0x06000EC5 RID: 3781 RVA: 0x00013BF6 File Offset: 0x00011DF6
		[DataMember(Name = "objectStoreName", IsRequired = true)]
		public string ObjectStoreName { get; private set; }
	}
}
