using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200024F RID: 591
	[DataContract]
	public class InstallabilityErrorArgument : DevToolsDomainEntityBase
	{
		// Token: 0x170005B6 RID: 1462
		// (get) Token: 0x060010F4 RID: 4340 RVA: 0x000157CC File Offset: 0x000139CC
		// (set) Token: 0x060010F5 RID: 4341 RVA: 0x000157D4 File Offset: 0x000139D4
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x060010F6 RID: 4342 RVA: 0x000157DD File Offset: 0x000139DD
		// (set) Token: 0x060010F7 RID: 4343 RVA: 0x000157E5 File Offset: 0x000139E5
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }
	}
}
