using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x020002A3 RID: 675
	[DataContract]
	public class GetGridHighlightObjectsForTestResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x0600133C RID: 4924 RVA: 0x000179DC File Offset: 0x00015BDC
		// (set) Token: 0x0600133D RID: 4925 RVA: 0x000179E4 File Offset: 0x00015BE4
		[DataMember]
		internal object highlights { get; set; }

		// Token: 0x1700069D RID: 1693
		// (get) Token: 0x0600133E RID: 4926 RVA: 0x000179ED File Offset: 0x00015BED
		public object Highlights
		{
			get
			{
				return this.highlights;
			}
		}
	}
}
