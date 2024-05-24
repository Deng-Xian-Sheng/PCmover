using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.HeapProfiler
{
	// Token: 0x0200016A RID: 362
	[DataContract]
	public class AddHeapSnapshotChunkEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000A87 RID: 2695 RVA: 0x0000FAA1 File Offset: 0x0000DCA1
		// (set) Token: 0x06000A88 RID: 2696 RVA: 0x0000FAA9 File Offset: 0x0000DCA9
		[DataMember(Name = "chunk", IsRequired = true)]
		public string Chunk { get; private set; }
	}
}
