using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x02000204 RID: 516
	[DataContract]
	public class IndexedDBListUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06000EC7 RID: 3783 RVA: 0x00013C07 File Offset: 0x00011E07
		// (set) Token: 0x06000EC8 RID: 3784 RVA: 0x00013C0F File Offset: 0x00011E0F
		[DataMember(Name = "origin", IsRequired = true)]
		public string Origin { get; private set; }
	}
}
