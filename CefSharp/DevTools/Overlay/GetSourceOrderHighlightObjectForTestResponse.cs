using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x020002A4 RID: 676
	[DataContract]
	public class GetSourceOrderHighlightObjectForTestResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x06001340 RID: 4928 RVA: 0x000179FD File Offset: 0x00015BFD
		// (set) Token: 0x06001341 RID: 4929 RVA: 0x00017A05 File Offset: 0x00015C05
		[DataMember]
		internal object highlight { get; set; }

		// Token: 0x1700069F RID: 1695
		// (get) Token: 0x06001342 RID: 4930 RVA: 0x00017A0E File Offset: 0x00015C0E
		public object Highlight
		{
			get
			{
				return this.highlight;
			}
		}
	}
}
