using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200014D RID: 333
	[DataContract]
	public class GetIsolateIdResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170002DB RID: 731
		// (get) Token: 0x0600099D RID: 2461 RVA: 0x0000E80C File Offset: 0x0000CA0C
		// (set) Token: 0x0600099E RID: 2462 RVA: 0x0000E814 File Offset: 0x0000CA14
		[DataMember]
		internal string id { get; set; }

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x0600099F RID: 2463 RVA: 0x0000E81D File Offset: 0x0000CA1D
		public string Id
		{
			get
			{
				return this.id;
			}
		}
	}
}
