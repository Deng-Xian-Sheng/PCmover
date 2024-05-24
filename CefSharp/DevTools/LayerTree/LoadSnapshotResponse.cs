using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x02000327 RID: 807
	[DataContract]
	public class LoadSnapshotResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000869 RID: 2153
		// (get) Token: 0x060017B0 RID: 6064 RVA: 0x0001B9C9 File Offset: 0x00019BC9
		// (set) Token: 0x060017B1 RID: 6065 RVA: 0x0001B9D1 File Offset: 0x00019BD1
		[DataMember]
		internal string snapshotId { get; set; }

		// Token: 0x1700086A RID: 2154
		// (get) Token: 0x060017B2 RID: 6066 RVA: 0x0001B9DA File Offset: 0x00019BDA
		public string SnapshotId
		{
			get
			{
				return this.snapshotId;
			}
		}
	}
}
