using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003D9 RID: 985
	[DataContract]
	public class StyleSheetChangedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000A74 RID: 2676
		// (get) Token: 0x06001CEA RID: 7402 RVA: 0x000213AD File Offset: 0x0001F5AD
		// (set) Token: 0x06001CEB RID: 7403 RVA: 0x000213B5 File Offset: 0x0001F5B5
		[DataMember(Name = "styleSheetId", IsRequired = true)]
		public string StyleSheetId { get; private set; }
	}
}
