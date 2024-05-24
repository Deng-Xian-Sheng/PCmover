using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003DF RID: 991
	[DataContract]
	public class GetComputedStyleForNodeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000A82 RID: 2690
		// (get) Token: 0x06001D06 RID: 7430 RVA: 0x00021495 File Offset: 0x0001F695
		// (set) Token: 0x06001D07 RID: 7431 RVA: 0x0002149D File Offset: 0x0001F69D
		[DataMember]
		internal IList<CSSComputedStyleProperty> computedStyle { get; set; }

		// Token: 0x17000A83 RID: 2691
		// (get) Token: 0x06001D08 RID: 7432 RVA: 0x000214A6 File Offset: 0x0001F6A6
		public IList<CSSComputedStyleProperty> ComputedStyle
		{
			get
			{
				return this.computedStyle;
			}
		}
	}
}
