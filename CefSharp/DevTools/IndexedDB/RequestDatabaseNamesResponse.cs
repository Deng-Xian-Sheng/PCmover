using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.IndexedDB
{
	// Token: 0x02000348 RID: 840
	[DataContract]
	public class RequestDatabaseNamesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170008AD RID: 2221
		// (get) Token: 0x06001868 RID: 6248 RVA: 0x0001CC9C File Offset: 0x0001AE9C
		// (set) Token: 0x06001869 RID: 6249 RVA: 0x0001CCA4 File Offset: 0x0001AEA4
		[DataMember]
		internal string[] databaseNames { get; set; }

		// Token: 0x170008AE RID: 2222
		// (get) Token: 0x0600186A RID: 6250 RVA: 0x0001CCAD File Offset: 0x0001AEAD
		public string[] DatabaseNames
		{
			get
			{
				return this.databaseNames;
			}
		}
	}
}
