using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001BD RID: 445
	[DataContract]
	public class NodeParamConnectedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x06000CD6 RID: 3286 RVA: 0x00011D94 File Offset: 0x0000FF94
		// (set) Token: 0x06000CD7 RID: 3287 RVA: 0x00011D9C File Offset: 0x0000FF9C
		[DataMember(Name = "contextId", IsRequired = true)]
		public string ContextId { get; private set; }

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06000CD8 RID: 3288 RVA: 0x00011DA5 File Offset: 0x0000FFA5
		// (set) Token: 0x06000CD9 RID: 3289 RVA: 0x00011DAD File Offset: 0x0000FFAD
		[DataMember(Name = "sourceId", IsRequired = true)]
		public string SourceId { get; private set; }

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06000CDA RID: 3290 RVA: 0x00011DB6 File Offset: 0x0000FFB6
		// (set) Token: 0x06000CDB RID: 3291 RVA: 0x00011DBE File Offset: 0x0000FFBE
		[DataMember(Name = "destinationId", IsRequired = true)]
		public string DestinationId { get; private set; }

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06000CDC RID: 3292 RVA: 0x00011DC7 File Offset: 0x0000FFC7
		// (set) Token: 0x06000CDD RID: 3293 RVA: 0x00011DCF File Offset: 0x0000FFCF
		[DataMember(Name = "sourceOutputIndex", IsRequired = false)]
		public double? SourceOutputIndex { get; private set; }
	}
}
