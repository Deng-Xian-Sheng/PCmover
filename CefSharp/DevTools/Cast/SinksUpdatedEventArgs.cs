using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Cast
{
	// Token: 0x020003B1 RID: 945
	[DataContract]
	public class SinksUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170009EA RID: 2538
		// (get) Token: 0x06001BA6 RID: 7078 RVA: 0x000205C8 File Offset: 0x0001E7C8
		// (set) Token: 0x06001BA7 RID: 7079 RVA: 0x000205D0 File Offset: 0x0001E7D0
		[DataMember(Name = "sinks", IsRequired = true)]
		public IList<Sink> Sinks { get; private set; }
	}
}
