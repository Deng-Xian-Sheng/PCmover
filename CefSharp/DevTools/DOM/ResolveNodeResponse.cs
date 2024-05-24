using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003A7 RID: 935
	[DataContract]
	public class ResolveNodeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009D7 RID: 2519
		// (get) Token: 0x06001B34 RID: 6964 RVA: 0x0001F426 File Offset: 0x0001D626
		// (set) Token: 0x06001B35 RID: 6965 RVA: 0x0001F42E File Offset: 0x0001D62E
		[DataMember]
		internal RemoteObject @object { get; set; }

		// Token: 0x170009D8 RID: 2520
		// (get) Token: 0x06001B36 RID: 6966 RVA: 0x0001F437 File Offset: 0x0001D637
		public RemoteObject Object
		{
			get
			{
				return this.@object;
			}
		}
	}
}
