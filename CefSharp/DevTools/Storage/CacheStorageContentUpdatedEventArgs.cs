using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x02000201 RID: 513
	[DataContract]
	public class CacheStorageContentUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x06000EB8 RID: 3768 RVA: 0x00013B89 File Offset: 0x00011D89
		// (set) Token: 0x06000EB9 RID: 3769 RVA: 0x00013B91 File Offset: 0x00011D91
		[DataMember(Name = "origin", IsRequired = true)]
		public string Origin { get; private set; }

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06000EBA RID: 3770 RVA: 0x00013B9A File Offset: 0x00011D9A
		// (set) Token: 0x06000EBB RID: 3771 RVA: 0x00013BA2 File Offset: 0x00011DA2
		[DataMember(Name = "cacheName", IsRequired = true)]
		public string CacheName { get; private set; }
	}
}
