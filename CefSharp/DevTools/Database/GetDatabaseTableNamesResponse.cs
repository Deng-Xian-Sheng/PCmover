using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Database
{
	// Token: 0x02000361 RID: 865
	[DataContract]
	public class GetDatabaseTableNamesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170008DB RID: 2267
		// (get) Token: 0x060018F5 RID: 6389 RVA: 0x0001DB78 File Offset: 0x0001BD78
		// (set) Token: 0x060018F6 RID: 6390 RVA: 0x0001DB80 File Offset: 0x0001BD80
		[DataMember]
		internal string[] tableNames { get; set; }

		// Token: 0x170008DC RID: 2268
		// (get) Token: 0x060018F7 RID: 6391 RVA: 0x0001DB89 File Offset: 0x0001BD89
		public string[] TableNames
		{
			get
			{
				return this.tableNames;
			}
		}
	}
}
