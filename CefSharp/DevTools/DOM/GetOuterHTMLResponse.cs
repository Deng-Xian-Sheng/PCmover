using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200039D RID: 925
	[DataContract]
	public class GetOuterHTMLResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009C1 RID: 2497
		// (get) Token: 0x06001B09 RID: 6921 RVA: 0x0001F2C3 File Offset: 0x0001D4C3
		// (set) Token: 0x06001B0A RID: 6922 RVA: 0x0001F2CB File Offset: 0x0001D4CB
		[DataMember]
		internal string outerHTML { get; set; }

		// Token: 0x170009C2 RID: 2498
		// (get) Token: 0x06001B0B RID: 6923 RVA: 0x0001F2D4 File Offset: 0x0001D4D4
		public string OuterHTML
		{
			get
			{
				return this.outerHTML;
			}
		}
	}
}
