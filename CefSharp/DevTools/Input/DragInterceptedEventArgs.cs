using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Input
{
	// Token: 0x02000334 RID: 820
	[DataContract]
	public class DragInterceptedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000886 RID: 2182
		// (get) Token: 0x06001805 RID: 6149 RVA: 0x0001BF62 File Offset: 0x0001A162
		// (set) Token: 0x06001806 RID: 6150 RVA: 0x0001BF6A File Offset: 0x0001A16A
		[DataMember(Name = "data", IsRequired = true)]
		public DragData Data { get; private set; }
	}
}
