using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000389 RID: 905
	[DataContract]
	public class CharacterDataModifiedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000995 RID: 2453
		// (get) Token: 0x06001AA8 RID: 6824 RVA: 0x0001EF9A File Offset: 0x0001D19A
		// (set) Token: 0x06001AA9 RID: 6825 RVA: 0x0001EFA2 File Offset: 0x0001D1A2
		[DataMember(Name = "nodeId", IsRequired = true)]
		public int NodeId { get; private set; }

		// Token: 0x17000996 RID: 2454
		// (get) Token: 0x06001AAA RID: 6826 RVA: 0x0001EFAB File Offset: 0x0001D1AB
		// (set) Token: 0x06001AAB RID: 6827 RVA: 0x0001EFB3 File Offset: 0x0001D1B3
		[DataMember(Name = "characterData", IsRequired = true)]
		public string CharacterData { get; private set; }
	}
}
