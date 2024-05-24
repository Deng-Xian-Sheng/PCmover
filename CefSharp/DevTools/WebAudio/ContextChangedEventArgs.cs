using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001B4 RID: 436
	[DataContract]
	public class ContextChangedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x00011BE7 File Offset: 0x0000FDE7
		// (set) Token: 0x06000CA4 RID: 3236 RVA: 0x00011BEF File Offset: 0x0000FDEF
		[DataMember(Name = "context", IsRequired = true)]
		public BaseAudioContext Context { get; private set; }
	}
}
