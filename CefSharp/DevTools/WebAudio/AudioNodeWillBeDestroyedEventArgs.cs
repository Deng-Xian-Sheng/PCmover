using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001B8 RID: 440
	[DataContract]
	public class AudioNodeWillBeDestroyedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x00011C5C File Offset: 0x0000FE5C
		// (set) Token: 0x06000CB2 RID: 3250 RVA: 0x00011C64 File Offset: 0x0000FE64
		[DataMember(Name = "contextId", IsRequired = true)]
		public string ContextId { get; private set; }

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06000CB3 RID: 3251 RVA: 0x00011C6D File Offset: 0x0000FE6D
		// (set) Token: 0x06000CB4 RID: 3252 RVA: 0x00011C75 File Offset: 0x0000FE75
		[DataMember(Name = "nodeId", IsRequired = true)]
		public string NodeId { get; private set; }
	}
}
