using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x020002A2 RID: 674
	[DataContract]
	public class GetHighlightObjectForTestResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700069A RID: 1690
		// (get) Token: 0x06001338 RID: 4920 RVA: 0x000179BB File Offset: 0x00015BBB
		// (set) Token: 0x06001339 RID: 4921 RVA: 0x000179C3 File Offset: 0x00015BC3
		[DataMember]
		internal object highlight { get; set; }

		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x0600133A RID: 4922 RVA: 0x000179CC File Offset: 0x00015BCC
		public object Highlight
		{
			get
			{
				return this.highlight;
			}
		}
	}
}
