using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Input
{
	// Token: 0x02000333 RID: 819
	[DataContract]
	public class DragData : DevToolsDomainEntityBase
	{
		// Token: 0x17000883 RID: 2179
		// (get) Token: 0x060017FE RID: 6142 RVA: 0x0001BF27 File Offset: 0x0001A127
		// (set) Token: 0x060017FF RID: 6143 RVA: 0x0001BF2F File Offset: 0x0001A12F
		[DataMember(Name = "items", IsRequired = true)]
		public IList<DragDataItem> Items { get; set; }

		// Token: 0x17000884 RID: 2180
		// (get) Token: 0x06001800 RID: 6144 RVA: 0x0001BF38 File Offset: 0x0001A138
		// (set) Token: 0x06001801 RID: 6145 RVA: 0x0001BF40 File Offset: 0x0001A140
		[DataMember(Name = "files", IsRequired = false)]
		public string[] Files { get; set; }

		// Token: 0x17000885 RID: 2181
		// (get) Token: 0x06001802 RID: 6146 RVA: 0x0001BF49 File Offset: 0x0001A149
		// (set) Token: 0x06001803 RID: 6147 RVA: 0x0001BF51 File Offset: 0x0001A151
		[DataMember(Name = "dragOperationsMask", IsRequired = true)]
		public int DragOperationsMask { get; set; }
	}
}
