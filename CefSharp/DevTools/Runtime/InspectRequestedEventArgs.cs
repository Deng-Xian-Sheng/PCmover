using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000148 RID: 328
	[DataContract]
	public class InspectRequestedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x0000E6E9 File Offset: 0x0000C8E9
		// (set) Token: 0x0600097B RID: 2427 RVA: 0x0000E6F1 File Offset: 0x0000C8F1
		[DataMember(Name = "object", IsRequired = true)]
		public RemoteObject Object { get; private set; }

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x0000E6FA File Offset: 0x0000C8FA
		// (set) Token: 0x0600097D RID: 2429 RVA: 0x0000E702 File Offset: 0x0000C902
		[DataMember(Name = "hints", IsRequired = true)]
		public object Hints { get; private set; }

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x0000E70B File Offset: 0x0000C90B
		// (set) Token: 0x0600097F RID: 2431 RVA: 0x0000E713 File Offset: 0x0000C913
		[DataMember(Name = "executionContextId", IsRequired = false)]
		public int? ExecutionContextId { get; private set; }
	}
}
