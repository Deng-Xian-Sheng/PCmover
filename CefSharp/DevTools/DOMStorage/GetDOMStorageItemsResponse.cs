using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMStorage
{
	// Token: 0x02000368 RID: 872
	[DataContract]
	public class GetDOMStorageItemsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170008E9 RID: 2281
		// (get) Token: 0x0600191D RID: 6429 RVA: 0x0001DD70 File Offset: 0x0001BF70
		// (set) Token: 0x0600191E RID: 6430 RVA: 0x0001DD78 File Offset: 0x0001BF78
		[DataMember]
		internal string[] entries { get; set; }

		// Token: 0x170008EA RID: 2282
		// (get) Token: 0x0600191F RID: 6431 RVA: 0x0001DD81 File Offset: 0x0001BF81
		public string[] Entries
		{
			get
			{
				return this.entries;
			}
		}
	}
}
