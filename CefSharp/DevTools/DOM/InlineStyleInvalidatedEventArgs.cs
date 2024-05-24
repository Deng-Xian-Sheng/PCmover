using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200038E RID: 910
	[DataContract]
	public class InlineStyleInvalidatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170009A0 RID: 2464
		// (get) Token: 0x06001AC3 RID: 6851 RVA: 0x0001F07D File Offset: 0x0001D27D
		// (set) Token: 0x06001AC4 RID: 6852 RVA: 0x0001F085 File Offset: 0x0001D285
		[DataMember(Name = "nodeIds", IsRequired = true)]
		public int[] NodeIds { get; private set; }
	}
}
