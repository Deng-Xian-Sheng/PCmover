using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001B2 RID: 434
	[DataContract]
	public class ContextCreatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06000C9D RID: 3229 RVA: 0x00011BB5 File Offset: 0x0000FDB5
		// (set) Token: 0x06000C9E RID: 3230 RVA: 0x00011BBD File Offset: 0x0000FDBD
		[DataMember(Name = "context", IsRequired = true)]
		public BaseAudioContext Context { get; private set; }
	}
}
