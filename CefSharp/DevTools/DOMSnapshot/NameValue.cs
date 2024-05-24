using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x0200036E RID: 878
	[DataContract]
	public class NameValue : DevToolsDomainEntityBase
	{
		// Token: 0x17000914 RID: 2324
		// (get) Token: 0x06001986 RID: 6534 RVA: 0x0001E292 File Offset: 0x0001C492
		// (set) Token: 0x06001987 RID: 6535 RVA: 0x0001E29A File Offset: 0x0001C49A
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000915 RID: 2325
		// (get) Token: 0x06001988 RID: 6536 RVA: 0x0001E2A3 File Offset: 0x0001C4A3
		// (set) Token: 0x06001989 RID: 6537 RVA: 0x0001E2AB File Offset: 0x0001C4AB
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }
	}
}
