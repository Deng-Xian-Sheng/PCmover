using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001BC RID: 444
	[DataContract]
	public class NodesDisconnectedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06000CCB RID: 3275 RVA: 0x00011D37 File Offset: 0x0000FF37
		// (set) Token: 0x06000CCC RID: 3276 RVA: 0x00011D3F File Offset: 0x0000FF3F
		[DataMember(Name = "contextId", IsRequired = true)]
		public string ContextId { get; private set; }

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06000CCD RID: 3277 RVA: 0x00011D48 File Offset: 0x0000FF48
		// (set) Token: 0x06000CCE RID: 3278 RVA: 0x00011D50 File Offset: 0x0000FF50
		[DataMember(Name = "sourceId", IsRequired = true)]
		public string SourceId { get; private set; }

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06000CCF RID: 3279 RVA: 0x00011D59 File Offset: 0x0000FF59
		// (set) Token: 0x06000CD0 RID: 3280 RVA: 0x00011D61 File Offset: 0x0000FF61
		[DataMember(Name = "destinationId", IsRequired = true)]
		public string DestinationId { get; private set; }

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x00011D6A File Offset: 0x0000FF6A
		// (set) Token: 0x06000CD2 RID: 3282 RVA: 0x00011D72 File Offset: 0x0000FF72
		[DataMember(Name = "sourceOutputIndex", IsRequired = false)]
		public double? SourceOutputIndex { get; private set; }

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06000CD3 RID: 3283 RVA: 0x00011D7B File Offset: 0x0000FF7B
		// (set) Token: 0x06000CD4 RID: 3284 RVA: 0x00011D83 File Offset: 0x0000FF83
		[DataMember(Name = "destinationInputIndex", IsRequired = false)]
		public double? DestinationInputIndex { get; private set; }
	}
}
