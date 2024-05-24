using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.IndexedDB
{
	// Token: 0x0200033D RID: 829
	[DataContract]
	public class ObjectStore : DevToolsDomainEntityBase
	{
		// Token: 0x1700088A RID: 2186
		// (get) Token: 0x0600181E RID: 6174 RVA: 0x0001C9F2 File Offset: 0x0001ABF2
		// (set) Token: 0x0600181F RID: 6175 RVA: 0x0001C9FA File Offset: 0x0001ABFA
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x1700088B RID: 2187
		// (get) Token: 0x06001820 RID: 6176 RVA: 0x0001CA03 File Offset: 0x0001AC03
		// (set) Token: 0x06001821 RID: 6177 RVA: 0x0001CA0B File Offset: 0x0001AC0B
		[DataMember(Name = "keyPath", IsRequired = true)]
		public KeyPath KeyPath { get; set; }

		// Token: 0x1700088C RID: 2188
		// (get) Token: 0x06001822 RID: 6178 RVA: 0x0001CA14 File Offset: 0x0001AC14
		// (set) Token: 0x06001823 RID: 6179 RVA: 0x0001CA1C File Offset: 0x0001AC1C
		[DataMember(Name = "autoIncrement", IsRequired = true)]
		public bool AutoIncrement { get; set; }

		// Token: 0x1700088D RID: 2189
		// (get) Token: 0x06001824 RID: 6180 RVA: 0x0001CA25 File Offset: 0x0001AC25
		// (set) Token: 0x06001825 RID: 6181 RVA: 0x0001CA2D File Offset: 0x0001AC2D
		[DataMember(Name = "indexes", IsRequired = true)]
		public IList<ObjectStoreIndex> Indexes { get; set; }
	}
}
