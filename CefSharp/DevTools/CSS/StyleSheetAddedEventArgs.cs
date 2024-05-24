using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003D8 RID: 984
	[DataContract]
	public class StyleSheetAddedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000A73 RID: 2675
		// (get) Token: 0x06001CE7 RID: 7399 RVA: 0x00021394 File Offset: 0x0001F594
		// (set) Token: 0x06001CE8 RID: 7400 RVA: 0x0002139C File Offset: 0x0001F59C
		[DataMember(Name = "header", IsRequired = true)]
		public CSSStyleSheetHeader Header { get; private set; }
	}
}
