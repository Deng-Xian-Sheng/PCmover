using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMDebugger
{
	// Token: 0x0200037B RID: 891
	[DataContract]
	public class GetEventListenersResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000957 RID: 2391
		// (get) Token: 0x06001A18 RID: 6680 RVA: 0x0001E842 File Offset: 0x0001CA42
		// (set) Token: 0x06001A19 RID: 6681 RVA: 0x0001E84A File Offset: 0x0001CA4A
		[DataMember]
		internal IList<EventListener> listeners { get; set; }

		// Token: 0x17000958 RID: 2392
		// (get) Token: 0x06001A1A RID: 6682 RVA: 0x0001E853 File Offset: 0x0001CA53
		public IList<EventListener> Listeners
		{
			get
			{
				return this.listeners;
			}
		}
	}
}
