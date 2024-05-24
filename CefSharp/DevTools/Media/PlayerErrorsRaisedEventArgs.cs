using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Media
{
	// Token: 0x0200019C RID: 412
	[DataContract]
	public class PlayerErrorsRaisedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06000BFD RID: 3069 RVA: 0x000112D7 File Offset: 0x0000F4D7
		// (set) Token: 0x06000BFE RID: 3070 RVA: 0x000112DF File Offset: 0x0000F4DF
		[DataMember(Name = "playerId", IsRequired = true)]
		public string PlayerId { get; private set; }

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06000BFF RID: 3071 RVA: 0x000112E8 File Offset: 0x0000F4E8
		// (set) Token: 0x06000C00 RID: 3072 RVA: 0x000112F0 File Offset: 0x0000F4F0
		[DataMember(Name = "errors", IsRequired = true)]
		public IList<PlayerError> Errors { get; private set; }
	}
}
