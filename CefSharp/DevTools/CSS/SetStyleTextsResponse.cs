using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003EC RID: 1004
	[DataContract]
	public class SetStyleTextsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000AA8 RID: 2728
		// (get) Token: 0x06001D4C RID: 7500 RVA: 0x000216D8 File Offset: 0x0001F8D8
		// (set) Token: 0x06001D4D RID: 7501 RVA: 0x000216E0 File Offset: 0x0001F8E0
		[DataMember]
		internal IList<CSSStyle> styles { get; set; }

		// Token: 0x17000AA9 RID: 2729
		// (get) Token: 0x06001D4E RID: 7502 RVA: 0x000216E9 File Offset: 0x0001F8E9
		public IList<CSSStyle> Styles
		{
			get
			{
				return this.styles;
			}
		}
	}
}
