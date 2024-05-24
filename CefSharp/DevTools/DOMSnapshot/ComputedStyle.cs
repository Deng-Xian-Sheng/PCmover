using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x0200036D RID: 877
	[DataContract]
	public class ComputedStyle : DevToolsDomainEntityBase
	{
		// Token: 0x17000913 RID: 2323
		// (get) Token: 0x06001983 RID: 6531 RVA: 0x0001E279 File Offset: 0x0001C479
		// (set) Token: 0x06001984 RID: 6532 RVA: 0x0001E281 File Offset: 0x0001C481
		[DataMember(Name = "properties", IsRequired = true)]
		public IList<NameValue> Properties { get; set; }
	}
}
