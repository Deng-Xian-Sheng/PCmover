using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Debugger;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x0200015E RID: 350
	[DataContract]
	public class ConsoleProfileFinishedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000A31 RID: 2609 RVA: 0x0000F5F0 File Offset: 0x0000D7F0
		// (set) Token: 0x06000A32 RID: 2610 RVA: 0x0000F5F8 File Offset: 0x0000D7F8
		[DataMember(Name = "id", IsRequired = true)]
		public string Id { get; private set; }

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000A33 RID: 2611 RVA: 0x0000F601 File Offset: 0x0000D801
		// (set) Token: 0x06000A34 RID: 2612 RVA: 0x0000F609 File Offset: 0x0000D809
		[DataMember(Name = "location", IsRequired = true)]
		public Location Location { get; private set; }

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06000A35 RID: 2613 RVA: 0x0000F612 File Offset: 0x0000D812
		// (set) Token: 0x06000A36 RID: 2614 RVA: 0x0000F61A File Offset: 0x0000D81A
		[DataMember(Name = "profile", IsRequired = true)]
		public Profile Profile { get; private set; }

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000A37 RID: 2615 RVA: 0x0000F623 File Offset: 0x0000D823
		// (set) Token: 0x06000A38 RID: 2616 RVA: 0x0000F62B File Offset: 0x0000D82B
		[DataMember(Name = "title", IsRequired = false)]
		public string Title { get; private set; }
	}
}
