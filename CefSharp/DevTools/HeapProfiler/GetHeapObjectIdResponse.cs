using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.HeapProfiler
{
	// Token: 0x0200016E RID: 366
	[DataContract]
	public class GetHeapObjectIdResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000A99 RID: 2713 RVA: 0x0000FB38 File Offset: 0x0000DD38
		// (set) Token: 0x06000A9A RID: 2714 RVA: 0x0000FB40 File Offset: 0x0000DD40
		[DataMember]
		internal string heapSnapshotObjectId { get; set; }

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000A9B RID: 2715 RVA: 0x0000FB49 File Offset: 0x0000DD49
		public string HeapSnapshotObjectId
		{
			get
			{
				return this.heapSnapshotObjectId;
			}
		}
	}
}
