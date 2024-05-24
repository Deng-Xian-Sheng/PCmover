using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000398 RID: 920
	[DataContract]
	public class GetBoxModelResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009B3 RID: 2483
		// (get) Token: 0x06001AEF RID: 6895 RVA: 0x0001F1EC File Offset: 0x0001D3EC
		// (set) Token: 0x06001AF0 RID: 6896 RVA: 0x0001F1F4 File Offset: 0x0001D3F4
		[DataMember]
		internal BoxModel model { get; set; }

		// Token: 0x170009B4 RID: 2484
		// (get) Token: 0x06001AF1 RID: 6897 RVA: 0x0001F1FD File Offset: 0x0001D3FD
		public BoxModel Model
		{
			get
			{
				return this.model;
			}
		}
	}
}
