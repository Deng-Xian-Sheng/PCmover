using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Media
{
	// Token: 0x02000199 RID: 409
	[DataContract]
	public class PlayerPropertiesChangedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06000BEE RID: 3054 RVA: 0x00011259 File Offset: 0x0000F459
		// (set) Token: 0x06000BEF RID: 3055 RVA: 0x00011261 File Offset: 0x0000F461
		[DataMember(Name = "playerId", IsRequired = true)]
		public string PlayerId { get; private set; }

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x0001126A File Offset: 0x0000F46A
		// (set) Token: 0x06000BF1 RID: 3057 RVA: 0x00011272 File Offset: 0x0000F472
		[DataMember(Name = "properties", IsRequired = true)]
		public IList<PlayerProperty> Properties { get; private set; }
	}
}
