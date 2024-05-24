using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003EB RID: 1003
	[DataContract]
	public class SetStyleSheetTextResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000AA6 RID: 2726
		// (get) Token: 0x06001D48 RID: 7496 RVA: 0x000216B7 File Offset: 0x0001F8B7
		// (set) Token: 0x06001D49 RID: 7497 RVA: 0x000216BF File Offset: 0x0001F8BF
		[DataMember]
		internal string sourceMapURL { get; set; }

		// Token: 0x17000AA7 RID: 2727
		// (get) Token: 0x06001D4A RID: 7498 RVA: 0x000216C8 File Offset: 0x0001F8C8
		public string SourceMapURL
		{
			get
			{
				return this.sourceMapURL;
			}
		}
	}
}
