using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Debugger;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x0200015F RID: 351
	[DataContract]
	public class ConsoleProfileStartedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000A3A RID: 2618 RVA: 0x0000F63C File Offset: 0x0000D83C
		// (set) Token: 0x06000A3B RID: 2619 RVA: 0x0000F644 File Offset: 0x0000D844
		[DataMember(Name = "id", IsRequired = true)]
		public string Id { get; private set; }

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000A3C RID: 2620 RVA: 0x0000F64D File Offset: 0x0000D84D
		// (set) Token: 0x06000A3D RID: 2621 RVA: 0x0000F655 File Offset: 0x0000D855
		[DataMember(Name = "location", IsRequired = true)]
		public Location Location { get; private set; }

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000A3E RID: 2622 RVA: 0x0000F65E File Offset: 0x0000D85E
		// (set) Token: 0x06000A3F RID: 2623 RVA: 0x0000F666 File Offset: 0x0000D866
		[DataMember(Name = "title", IsRequired = false)]
		public string Title { get; private set; }
	}
}
