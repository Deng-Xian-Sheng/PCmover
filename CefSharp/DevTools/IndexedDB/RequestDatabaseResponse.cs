using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.IndexedDB
{
	// Token: 0x02000347 RID: 839
	[DataContract]
	public class RequestDatabaseResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170008AB RID: 2219
		// (get) Token: 0x06001864 RID: 6244 RVA: 0x0001CC7B File Offset: 0x0001AE7B
		// (set) Token: 0x06001865 RID: 6245 RVA: 0x0001CC83 File Offset: 0x0001AE83
		[DataMember]
		internal DatabaseWithObjectStores databaseWithObjectStores { get; set; }

		// Token: 0x170008AC RID: 2220
		// (get) Token: 0x06001866 RID: 6246 RVA: 0x0001CC8C File Offset: 0x0001AE8C
		public DatabaseWithObjectStores DatabaseWithObjectStores
		{
			get
			{
				return this.databaseWithObjectStores;
			}
		}
	}
}
