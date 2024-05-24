using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200039C RID: 924
	[DataContract]
	public class GetNodeForLocationResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009BB RID: 2491
		// (get) Token: 0x06001AFF RID: 6911 RVA: 0x0001F270 File Offset: 0x0001D470
		// (set) Token: 0x06001B00 RID: 6912 RVA: 0x0001F278 File Offset: 0x0001D478
		[DataMember]
		internal int backendNodeId { get; set; }

		// Token: 0x170009BC RID: 2492
		// (get) Token: 0x06001B01 RID: 6913 RVA: 0x0001F281 File Offset: 0x0001D481
		public int BackendNodeId
		{
			get
			{
				return this.backendNodeId;
			}
		}

		// Token: 0x170009BD RID: 2493
		// (get) Token: 0x06001B02 RID: 6914 RVA: 0x0001F289 File Offset: 0x0001D489
		// (set) Token: 0x06001B03 RID: 6915 RVA: 0x0001F291 File Offset: 0x0001D491
		[DataMember]
		internal string frameId { get; set; }

		// Token: 0x170009BE RID: 2494
		// (get) Token: 0x06001B04 RID: 6916 RVA: 0x0001F29A File Offset: 0x0001D49A
		public string FrameId
		{
			get
			{
				return this.frameId;
			}
		}

		// Token: 0x170009BF RID: 2495
		// (get) Token: 0x06001B05 RID: 6917 RVA: 0x0001F2A2 File Offset: 0x0001D4A2
		// (set) Token: 0x06001B06 RID: 6918 RVA: 0x0001F2AA File Offset: 0x0001D4AA
		[DataMember]
		internal int? nodeId { get; set; }

		// Token: 0x170009C0 RID: 2496
		// (get) Token: 0x06001B07 RID: 6919 RVA: 0x0001F2B3 File Offset: 0x0001D4B3
		public int? NodeId
		{
			get
			{
				return this.nodeId;
			}
		}
	}
}
