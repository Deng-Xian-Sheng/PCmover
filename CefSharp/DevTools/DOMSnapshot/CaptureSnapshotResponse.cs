using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x02000376 RID: 886
	[DataContract]
	public class CaptureSnapshotResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000949 RID: 2377
		// (get) Token: 0x060019F8 RID: 6648 RVA: 0x0001E657 File Offset: 0x0001C857
		// (set) Token: 0x060019F9 RID: 6649 RVA: 0x0001E65F File Offset: 0x0001C85F
		[DataMember]
		internal IList<DocumentSnapshot> documents { get; set; }

		// Token: 0x1700094A RID: 2378
		// (get) Token: 0x060019FA RID: 6650 RVA: 0x0001E668 File Offset: 0x0001C868
		public IList<DocumentSnapshot> Documents
		{
			get
			{
				return this.documents;
			}
		}

		// Token: 0x1700094B RID: 2379
		// (get) Token: 0x060019FB RID: 6651 RVA: 0x0001E670 File Offset: 0x0001C870
		// (set) Token: 0x060019FC RID: 6652 RVA: 0x0001E678 File Offset: 0x0001C878
		[DataMember]
		internal string[] strings { get; set; }

		// Token: 0x1700094C RID: 2380
		// (get) Token: 0x060019FD RID: 6653 RVA: 0x0001E681 File Offset: 0x0001C881
		public string[] Strings
		{
			get
			{
				return this.strings;
			}
		}
	}
}
