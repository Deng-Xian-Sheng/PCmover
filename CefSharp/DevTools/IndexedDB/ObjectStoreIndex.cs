using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.IndexedDB
{
	// Token: 0x0200033E RID: 830
	[DataContract]
	public class ObjectStoreIndex : DevToolsDomainEntityBase
	{
		// Token: 0x1700088E RID: 2190
		// (get) Token: 0x06001827 RID: 6183 RVA: 0x0001CA3E File Offset: 0x0001AC3E
		// (set) Token: 0x06001828 RID: 6184 RVA: 0x0001CA46 File Offset: 0x0001AC46
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x1700088F RID: 2191
		// (get) Token: 0x06001829 RID: 6185 RVA: 0x0001CA4F File Offset: 0x0001AC4F
		// (set) Token: 0x0600182A RID: 6186 RVA: 0x0001CA57 File Offset: 0x0001AC57
		[DataMember(Name = "keyPath", IsRequired = true)]
		public KeyPath KeyPath { get; set; }

		// Token: 0x17000890 RID: 2192
		// (get) Token: 0x0600182B RID: 6187 RVA: 0x0001CA60 File Offset: 0x0001AC60
		// (set) Token: 0x0600182C RID: 6188 RVA: 0x0001CA68 File Offset: 0x0001AC68
		[DataMember(Name = "unique", IsRequired = true)]
		public bool Unique { get; set; }

		// Token: 0x17000891 RID: 2193
		// (get) Token: 0x0600182D RID: 6189 RVA: 0x0001CA71 File Offset: 0x0001AC71
		// (set) Token: 0x0600182E RID: 6190 RVA: 0x0001CA79 File Offset: 0x0001AC79
		[DataMember(Name = "multiEntry", IsRequired = true)]
		public bool MultiEntry { get; set; }
	}
}
