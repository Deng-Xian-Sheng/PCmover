using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001B6 RID: 438
	[DataContract]
	public class AudioListenerWillBeDestroyedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x00011C19 File Offset: 0x0000FE19
		// (set) Token: 0x06000CAA RID: 3242 RVA: 0x00011C21 File Offset: 0x0000FE21
		[DataMember(Name = "contextId", IsRequired = true)]
		public string ContextId { get; private set; }

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06000CAB RID: 3243 RVA: 0x00011C2A File Offset: 0x0000FE2A
		// (set) Token: 0x06000CAC RID: 3244 RVA: 0x00011C32 File Offset: 0x0000FE32
		[DataMember(Name = "listenerId", IsRequired = true)]
		public string ListenerId { get; private set; }
	}
}
