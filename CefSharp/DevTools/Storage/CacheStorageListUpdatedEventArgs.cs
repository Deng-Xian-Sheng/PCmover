using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x02000202 RID: 514
	[DataContract]
	public class CacheStorageListUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06000EBD RID: 3773 RVA: 0x00013BB3 File Offset: 0x00011DB3
		// (set) Token: 0x06000EBE RID: 3774 RVA: 0x00013BBB File Offset: 0x00011DBB
		[DataMember(Name = "origin", IsRequired = true)]
		public string Origin { get; private set; }
	}
}
