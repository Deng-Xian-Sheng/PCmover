using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x02000329 RID: 809
	[DataContract]
	public class ProfileSnapshotResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700086D RID: 2157
		// (get) Token: 0x060017B8 RID: 6072 RVA: 0x0001BA0B File Offset: 0x00019C0B
		// (set) Token: 0x060017B9 RID: 6073 RVA: 0x0001BA13 File Offset: 0x00019C13
		[DataMember]
		internal double[] timings { get; set; }

		// Token: 0x1700086E RID: 2158
		// (get) Token: 0x060017BA RID: 6074 RVA: 0x0001BA1C File Offset: 0x00019C1C
		public double[] Timings
		{
			get
			{
				return this.timings;
			}
		}
	}
}
