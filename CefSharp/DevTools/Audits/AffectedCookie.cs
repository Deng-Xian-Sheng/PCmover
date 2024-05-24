using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000409 RID: 1033
	[DataContract]
	public class AffectedCookie : DevToolsDomainEntityBase
	{
		// Token: 0x17000AEF RID: 2799
		// (get) Token: 0x06001E23 RID: 7715 RVA: 0x0002291F File Offset: 0x00020B1F
		// (set) Token: 0x06001E24 RID: 7716 RVA: 0x00022927 File Offset: 0x00020B27
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000AF0 RID: 2800
		// (get) Token: 0x06001E25 RID: 7717 RVA: 0x00022930 File Offset: 0x00020B30
		// (set) Token: 0x06001E26 RID: 7718 RVA: 0x00022938 File Offset: 0x00020B38
		[DataMember(Name = "path", IsRequired = true)]
		public string Path { get; set; }

		// Token: 0x17000AF1 RID: 2801
		// (get) Token: 0x06001E27 RID: 7719 RVA: 0x00022941 File Offset: 0x00020B41
		// (set) Token: 0x06001E28 RID: 7720 RVA: 0x00022949 File Offset: 0x00020B49
		[DataMember(Name = "domain", IsRequired = true)]
		public string Domain { get; set; }
	}
}
