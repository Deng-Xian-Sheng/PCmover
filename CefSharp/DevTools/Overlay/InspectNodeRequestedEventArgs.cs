using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x0200029F RID: 671
	[DataContract]
	public class InspectNodeRequestedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x0600132F RID: 4911 RVA: 0x00017970 File Offset: 0x00015B70
		// (set) Token: 0x06001330 RID: 4912 RVA: 0x00017978 File Offset: 0x00015B78
		[DataMember(Name = "backendNodeId", IsRequired = true)]
		public int BackendNodeId { get; private set; }
	}
}
