using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003E8 RID: 1000
	[DataContract]
	public class SetContainerQueryTextResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000AA0 RID: 2720
		// (get) Token: 0x06001D3C RID: 7484 RVA: 0x00021654 File Offset: 0x0001F854
		// (set) Token: 0x06001D3D RID: 7485 RVA: 0x0002165C File Offset: 0x0001F85C
		[DataMember]
		internal CSSContainerQuery containerQuery { get; set; }

		// Token: 0x17000AA1 RID: 2721
		// (get) Token: 0x06001D3E RID: 7486 RVA: 0x00021665 File Offset: 0x0001F865
		public CSSContainerQuery ContainerQuery
		{
			get
			{
				return this.containerQuery;
			}
		}
	}
}
