using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001BB RID: 443
	[DataContract]
	public class NodesConnectedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06000CC0 RID: 3264 RVA: 0x00011CDA File Offset: 0x0000FEDA
		// (set) Token: 0x06000CC1 RID: 3265 RVA: 0x00011CE2 File Offset: 0x0000FEE2
		[DataMember(Name = "contextId", IsRequired = true)]
		public string ContextId { get; private set; }

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06000CC2 RID: 3266 RVA: 0x00011CEB File Offset: 0x0000FEEB
		// (set) Token: 0x06000CC3 RID: 3267 RVA: 0x00011CF3 File Offset: 0x0000FEF3
		[DataMember(Name = "sourceId", IsRequired = true)]
		public string SourceId { get; private set; }

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x06000CC4 RID: 3268 RVA: 0x00011CFC File Offset: 0x0000FEFC
		// (set) Token: 0x06000CC5 RID: 3269 RVA: 0x00011D04 File Offset: 0x0000FF04
		[DataMember(Name = "destinationId", IsRequired = true)]
		public string DestinationId { get; private set; }

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06000CC6 RID: 3270 RVA: 0x00011D0D File Offset: 0x0000FF0D
		// (set) Token: 0x06000CC7 RID: 3271 RVA: 0x00011D15 File Offset: 0x0000FF15
		[DataMember(Name = "sourceOutputIndex", IsRequired = false)]
		public double? SourceOutputIndex { get; private set; }

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06000CC8 RID: 3272 RVA: 0x00011D1E File Offset: 0x0000FF1E
		// (set) Token: 0x06000CC9 RID: 3273 RVA: 0x00011D26 File Offset: 0x0000FF26
		[DataMember(Name = "destinationInputIndex", IsRequired = false)]
		public double? DestinationInputIndex { get; private set; }
	}
}
