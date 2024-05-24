using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Database
{
	// Token: 0x0200035F RID: 863
	[DataContract]
	public class AddDatabaseEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170008D4 RID: 2260
		// (get) Token: 0x060018E8 RID: 6376 RVA: 0x0001DB0C File Offset: 0x0001BD0C
		// (set) Token: 0x060018E9 RID: 6377 RVA: 0x0001DB14 File Offset: 0x0001BD14
		[DataMember(Name = "database", IsRequired = true)]
		public Database Database { get; private set; }
	}
}
