using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x0200032B RID: 811
	[DataContract]
	public class SnapshotCommandLogResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000871 RID: 2161
		// (get) Token: 0x060017C0 RID: 6080 RVA: 0x0001BA4D File Offset: 0x00019C4D
		// (set) Token: 0x060017C1 RID: 6081 RVA: 0x0001BA55 File Offset: 0x00019C55
		[DataMember]
		internal IList<object> commandLog { get; set; }

		// Token: 0x17000872 RID: 2162
		// (get) Token: 0x060017C2 RID: 6082 RVA: 0x0001BA5E File Offset: 0x00019C5E
		public IList<object> CommandLog
		{
			get
			{
				return this.commandLog;
			}
		}
	}
}
