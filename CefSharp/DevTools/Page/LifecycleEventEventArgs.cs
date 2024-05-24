using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200026A RID: 618
	[DataContract]
	public class LifecycleEventEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x0600117E RID: 4478 RVA: 0x00015D83 File Offset: 0x00013F83
		// (set) Token: 0x0600117F RID: 4479 RVA: 0x00015D8B File Offset: 0x00013F8B
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x06001180 RID: 4480 RVA: 0x00015D94 File Offset: 0x00013F94
		// (set) Token: 0x06001181 RID: 4481 RVA: 0x00015D9C File Offset: 0x00013F9C
		[DataMember(Name = "loaderId", IsRequired = true)]
		public string LoaderId { get; private set; }

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x06001182 RID: 4482 RVA: 0x00015DA5 File Offset: 0x00013FA5
		// (set) Token: 0x06001183 RID: 4483 RVA: 0x00015DAD File Offset: 0x00013FAD
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; private set; }

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x06001184 RID: 4484 RVA: 0x00015DB6 File Offset: 0x00013FB6
		// (set) Token: 0x06001185 RID: 4485 RVA: 0x00015DBE File Offset: 0x00013FBE
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }
	}
}
