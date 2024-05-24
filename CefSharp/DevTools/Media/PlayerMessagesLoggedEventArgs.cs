using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Media
{
	// Token: 0x0200019B RID: 411
	[DataContract]
	public class PlayerMessagesLoggedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x06000BF8 RID: 3064 RVA: 0x000112AD File Offset: 0x0000F4AD
		// (set) Token: 0x06000BF9 RID: 3065 RVA: 0x000112B5 File Offset: 0x0000F4B5
		[DataMember(Name = "playerId", IsRequired = true)]
		public string PlayerId { get; private set; }

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06000BFA RID: 3066 RVA: 0x000112BE File Offset: 0x0000F4BE
		// (set) Token: 0x06000BFB RID: 3067 RVA: 0x000112C6 File Offset: 0x0000F4C6
		[DataMember(Name = "messages", IsRequired = true)]
		public IList<PlayerMessage> Messages { get; private set; }
	}
}
