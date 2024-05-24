using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x0200015D RID: 349
	[DataContract]
	public class ScriptTypeProfile : DevToolsDomainEntityBase
	{
		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000A2A RID: 2602 RVA: 0x0000F5B5 File Offset: 0x0000D7B5
		// (set) Token: 0x06000A2B RID: 2603 RVA: 0x0000F5BD File Offset: 0x0000D7BD
		[DataMember(Name = "scriptId", IsRequired = true)]
		public string ScriptId { get; set; }

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000A2C RID: 2604 RVA: 0x0000F5C6 File Offset: 0x0000D7C6
		// (set) Token: 0x06000A2D RID: 2605 RVA: 0x0000F5CE File Offset: 0x0000D7CE
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000A2E RID: 2606 RVA: 0x0000F5D7 File Offset: 0x0000D7D7
		// (set) Token: 0x06000A2F RID: 2607 RVA: 0x0000F5DF File Offset: 0x0000D7DF
		[DataMember(Name = "entries", IsRequired = true)]
		public IList<TypeProfileEntry> Entries { get; set; }
	}
}
