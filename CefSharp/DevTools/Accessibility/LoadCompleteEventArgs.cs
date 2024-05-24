using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x02000448 RID: 1096
	[DataContract]
	public class LoadCompleteEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000BAF RID: 2991
		// (get) Token: 0x06001FDC RID: 8156 RVA: 0x00023D3C File Offset: 0x00021F3C
		// (set) Token: 0x06001FDD RID: 8157 RVA: 0x00023D44 File Offset: 0x00021F44
		[DataMember(Name = "root", IsRequired = true)]
		public AXNode Root { get; private set; }
	}
}
