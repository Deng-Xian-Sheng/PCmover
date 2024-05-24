using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.IndexedDB
{
	// Token: 0x0200033C RID: 828
	[DataContract]
	public class DatabaseWithObjectStores : DevToolsDomainEntityBase
	{
		// Token: 0x17000887 RID: 2183
		// (get) Token: 0x06001817 RID: 6167 RVA: 0x0001C9B7 File Offset: 0x0001ABB7
		// (set) Token: 0x06001818 RID: 6168 RVA: 0x0001C9BF File Offset: 0x0001ABBF
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000888 RID: 2184
		// (get) Token: 0x06001819 RID: 6169 RVA: 0x0001C9C8 File Offset: 0x0001ABC8
		// (set) Token: 0x0600181A RID: 6170 RVA: 0x0001C9D0 File Offset: 0x0001ABD0
		[DataMember(Name = "version", IsRequired = true)]
		public double Version { get; set; }

		// Token: 0x17000889 RID: 2185
		// (get) Token: 0x0600181B RID: 6171 RVA: 0x0001C9D9 File Offset: 0x0001ABD9
		// (set) Token: 0x0600181C RID: 6172 RVA: 0x0001C9E1 File Offset: 0x0001ABE1
		[DataMember(Name = "objectStores", IsRequired = true)]
		public IList<ObjectStore> ObjectStores { get; set; }
	}
}
