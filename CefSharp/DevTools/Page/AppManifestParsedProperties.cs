using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000246 RID: 582
	[DataContract]
	public class AppManifestParsedProperties : DevToolsDomainEntityBase
	{
		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x060010B3 RID: 4275 RVA: 0x000155A7 File Offset: 0x000137A7
		// (set) Token: 0x060010B4 RID: 4276 RVA: 0x000155AF File Offset: 0x000137AF
		[DataMember(Name = "scope", IsRequired = true)]
		public string Scope { get; set; }
	}
}
