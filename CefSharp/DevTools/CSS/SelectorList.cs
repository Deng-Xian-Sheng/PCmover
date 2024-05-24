using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003C2 RID: 962
	[DataContract]
	public class SelectorList : DevToolsDomainEntityBase
	{
		// Token: 0x17000A0C RID: 2572
		// (get) Token: 0x06001C04 RID: 7172 RVA: 0x00020B9D File Offset: 0x0001ED9D
		// (set) Token: 0x06001C05 RID: 7173 RVA: 0x00020BA5 File Offset: 0x0001EDA5
		[DataMember(Name = "selectors", IsRequired = true)]
		public IList<Value> Selectors { get; set; }

		// Token: 0x17000A0D RID: 2573
		// (get) Token: 0x06001C06 RID: 7174 RVA: 0x00020BAE File Offset: 0x0001EDAE
		// (set) Token: 0x06001C07 RID: 7175 RVA: 0x00020BB6 File Offset: 0x0001EDB6
		[DataMember(Name = "text", IsRequired = true)]
		public string Text { get; set; }
	}
}
