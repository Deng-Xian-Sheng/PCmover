using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003DD RID: 989
	[DataContract]
	public class CreateStyleSheetResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000A7A RID: 2682
		// (get) Token: 0x06001CF8 RID: 7416 RVA: 0x00021421 File Offset: 0x0001F621
		// (set) Token: 0x06001CF9 RID: 7417 RVA: 0x00021429 File Offset: 0x0001F629
		[DataMember]
		internal string styleSheetId { get; set; }

		// Token: 0x17000A7B RID: 2683
		// (get) Token: 0x06001CFA RID: 7418 RVA: 0x00021432 File Offset: 0x0001F632
		public string StyleSheetId
		{
			get
			{
				return this.styleSheetId;
			}
		}
	}
}
