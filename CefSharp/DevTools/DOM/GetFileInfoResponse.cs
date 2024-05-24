using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003A9 RID: 937
	[DataContract]
	public class GetFileInfoResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009DB RID: 2523
		// (get) Token: 0x06001B3C RID: 6972 RVA: 0x0001F468 File Offset: 0x0001D668
		// (set) Token: 0x06001B3D RID: 6973 RVA: 0x0001F470 File Offset: 0x0001D670
		[DataMember]
		internal string path { get; set; }

		// Token: 0x170009DC RID: 2524
		// (get) Token: 0x06001B3E RID: 6974 RVA: 0x0001F479 File Offset: 0x0001D679
		public string Path
		{
			get
			{
				return this.path;
			}
		}
	}
}
