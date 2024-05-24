using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Media
{
	// Token: 0x0200019D RID: 413
	[DataContract]
	public class PlayersCreatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06000C02 RID: 3074 RVA: 0x00011301 File Offset: 0x0000F501
		// (set) Token: 0x06000C03 RID: 3075 RVA: 0x00011309 File Offset: 0x0000F509
		[DataMember(Name = "players", IsRequired = true)]
		public string[] Players { get; private set; }
	}
}
