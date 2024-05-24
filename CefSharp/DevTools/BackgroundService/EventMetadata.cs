using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.BackgroundService
{
	// Token: 0x02000404 RID: 1028
	[DataContract]
	public class EventMetadata : DevToolsDomainEntityBase
	{
		// Token: 0x17000AE1 RID: 2785
		// (get) Token: 0x06001DFA RID: 7674 RVA: 0x00022677 File Offset: 0x00020877
		// (set) Token: 0x06001DFB RID: 7675 RVA: 0x0002267F File Offset: 0x0002087F
		[DataMember(Name = "key", IsRequired = true)]
		public string Key { get; set; }

		// Token: 0x17000AE2 RID: 2786
		// (get) Token: 0x06001DFC RID: 7676 RVA: 0x00022688 File Offset: 0x00020888
		// (set) Token: 0x06001DFD RID: 7677 RVA: 0x00022690 File Offset: 0x00020890
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }
	}
}
