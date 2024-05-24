using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001BE RID: 446
	[DataContract]
	public class NodeParamDisconnectedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06000CDF RID: 3295 RVA: 0x00011DE0 File Offset: 0x0000FFE0
		// (set) Token: 0x06000CE0 RID: 3296 RVA: 0x00011DE8 File Offset: 0x0000FFE8
		[DataMember(Name = "contextId", IsRequired = true)]
		public string ContextId { get; private set; }

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x00011DF1 File Offset: 0x0000FFF1
		// (set) Token: 0x06000CE2 RID: 3298 RVA: 0x00011DF9 File Offset: 0x0000FFF9
		[DataMember(Name = "sourceId", IsRequired = true)]
		public string SourceId { get; private set; }

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x00011E02 File Offset: 0x00010002
		// (set) Token: 0x06000CE4 RID: 3300 RVA: 0x00011E0A File Offset: 0x0001000A
		[DataMember(Name = "destinationId", IsRequired = true)]
		public string DestinationId { get; private set; }

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x00011E13 File Offset: 0x00010013
		// (set) Token: 0x06000CE6 RID: 3302 RVA: 0x00011E1B File Offset: 0x0001001B
		[DataMember(Name = "sourceOutputIndex", IsRequired = false)]
		public double? SourceOutputIndex { get; private set; }
	}
}
