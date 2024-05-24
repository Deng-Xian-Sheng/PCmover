using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000392 RID: 914
	[DataContract]
	public class ShadowRootPoppedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170009A7 RID: 2471
		// (get) Token: 0x06001AD5 RID: 6869 RVA: 0x0001F114 File Offset: 0x0001D314
		// (set) Token: 0x06001AD6 RID: 6870 RVA: 0x0001F11C File Offset: 0x0001D31C
		[DataMember(Name = "hostId", IsRequired = true)]
		public int HostId { get; private set; }

		// Token: 0x170009A8 RID: 2472
		// (get) Token: 0x06001AD7 RID: 6871 RVA: 0x0001F125 File Offset: 0x0001D325
		// (set) Token: 0x06001AD8 RID: 6872 RVA: 0x0001F12D File Offset: 0x0001D32D
		[DataMember(Name = "rootId", IsRequired = true)]
		public int RootId { get; private set; }
	}
}
