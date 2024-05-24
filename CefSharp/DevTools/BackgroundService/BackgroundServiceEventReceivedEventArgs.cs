using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.BackgroundService
{
	// Token: 0x02000407 RID: 1031
	[DataContract]
	public class BackgroundServiceEventReceivedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000AEE RID: 2798
		// (get) Token: 0x06001E17 RID: 7703 RVA: 0x000227A8 File Offset: 0x000209A8
		// (set) Token: 0x06001E18 RID: 7704 RVA: 0x000227B0 File Offset: 0x000209B0
		[DataMember(Name = "backgroundServiceEvent", IsRequired = true)]
		public BackgroundServiceEvent BackgroundServiceEvent { get; private set; }
	}
}
