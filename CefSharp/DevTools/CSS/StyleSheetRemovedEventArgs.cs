using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003DA RID: 986
	[DataContract]
	public class StyleSheetRemovedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000A75 RID: 2677
		// (get) Token: 0x06001CED RID: 7405 RVA: 0x000213C6 File Offset: 0x0001F5C6
		// (set) Token: 0x06001CEE RID: 7406 RVA: 0x000213CE File Offset: 0x0001F5CE
		[DataMember(Name = "styleSheetId", IsRequired = true)]
		public string StyleSheetId { get; private set; }
	}
}
