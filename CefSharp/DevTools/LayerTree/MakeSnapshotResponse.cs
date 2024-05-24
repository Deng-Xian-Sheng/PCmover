using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x02000328 RID: 808
	[DataContract]
	public class MakeSnapshotResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700086B RID: 2155
		// (get) Token: 0x060017B4 RID: 6068 RVA: 0x0001B9EA File Offset: 0x00019BEA
		// (set) Token: 0x060017B5 RID: 6069 RVA: 0x0001B9F2 File Offset: 0x00019BF2
		[DataMember]
		internal string snapshotId { get; set; }

		// Token: 0x1700086C RID: 2156
		// (get) Token: 0x060017B6 RID: 6070 RVA: 0x0001B9FB File Offset: 0x00019BFB
		public string SnapshotId
		{
			get
			{
				return this.snapshotId;
			}
		}
	}
}
