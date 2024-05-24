using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000137 RID: 311
	[DataContract]
	public class EntryPreview : DevToolsDomainEntityBase
	{
		// Token: 0x17000289 RID: 649
		// (get) Token: 0x060008EC RID: 2284 RVA: 0x0000E21C File Offset: 0x0000C41C
		// (set) Token: 0x060008ED RID: 2285 RVA: 0x0000E224 File Offset: 0x0000C424
		[DataMember(Name = "key", IsRequired = false)]
		public ObjectPreview Key { get; set; }

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x060008EE RID: 2286 RVA: 0x0000E22D File Offset: 0x0000C42D
		// (set) Token: 0x060008EF RID: 2287 RVA: 0x0000E235 File Offset: 0x0000C435
		[DataMember(Name = "value", IsRequired = true)]
		public ObjectPreview Value { get; set; }
	}
}
