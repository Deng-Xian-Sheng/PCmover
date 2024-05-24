using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003E9 RID: 1001
	[DataContract]
	public class SetSupportsTextResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000AA2 RID: 2722
		// (get) Token: 0x06001D40 RID: 7488 RVA: 0x00021675 File Offset: 0x0001F875
		// (set) Token: 0x06001D41 RID: 7489 RVA: 0x0002167D File Offset: 0x0001F87D
		[DataMember]
		internal CSSSupports supports { get; set; }

		// Token: 0x17000AA3 RID: 2723
		// (get) Token: 0x06001D42 RID: 7490 RVA: 0x00021686 File Offset: 0x0001F886
		public CSSSupports Supports
		{
			get
			{
				return this.supports;
			}
		}
	}
}
