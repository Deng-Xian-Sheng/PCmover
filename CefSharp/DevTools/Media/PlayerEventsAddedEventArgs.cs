using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Media
{
	// Token: 0x0200019A RID: 410
	[DataContract]
	public class PlayerEventsAddedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170003BF RID: 959
		// (get) Token: 0x06000BF3 RID: 3059 RVA: 0x00011283 File Offset: 0x0000F483
		// (set) Token: 0x06000BF4 RID: 3060 RVA: 0x0001128B File Offset: 0x0000F48B
		[DataMember(Name = "playerId", IsRequired = true)]
		public string PlayerId { get; private set; }

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x06000BF5 RID: 3061 RVA: 0x00011294 File Offset: 0x0000F494
		// (set) Token: 0x06000BF6 RID: 3062 RVA: 0x0001129C File Offset: 0x0000F49C
		[DataMember(Name = "events", IsRequired = true)]
		public IList<PlayerEvent> Events { get; private set; }
	}
}
