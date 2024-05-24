using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Tracing
{
	// Token: 0x020001D4 RID: 468
	[DataContract]
	public class DataCollectedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06000D85 RID: 3461 RVA: 0x0001295E File Offset: 0x00010B5E
		// (set) Token: 0x06000D86 RID: 3462 RVA: 0x00012966 File Offset: 0x00010B66
		[DataMember(Name = "value", IsRequired = true)]
		public IList<object> Value { get; private set; }
	}
}
