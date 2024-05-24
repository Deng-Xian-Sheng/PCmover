using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Inspector
{
	// Token: 0x0200032D RID: 813
	[DataContract]
	public class DetachedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000873 RID: 2163
		// (get) Token: 0x060017D2 RID: 6098 RVA: 0x0001BD38 File Offset: 0x00019F38
		// (set) Token: 0x060017D3 RID: 6099 RVA: 0x0001BD40 File Offset: 0x00019F40
		[DataMember(Name = "reason", IsRequired = true)]
		public string Reason { get; private set; }
	}
}
