using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x0200015C RID: 348
	[DataContract]
	public class TypeProfileEntry : DevToolsDomainEntityBase
	{
		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000A25 RID: 2597 RVA: 0x0000F58B File Offset: 0x0000D78B
		// (set) Token: 0x06000A26 RID: 2598 RVA: 0x0000F593 File Offset: 0x0000D793
		[DataMember(Name = "offset", IsRequired = true)]
		public int Offset { get; set; }

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000A27 RID: 2599 RVA: 0x0000F59C File Offset: 0x0000D79C
		// (set) Token: 0x06000A28 RID: 2600 RVA: 0x0000F5A4 File Offset: 0x0000D7A4
		[DataMember(Name = "types", IsRequired = true)]
		public IList<TypeObject> Types { get; set; }
	}
}
