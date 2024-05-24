using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001B7 RID: 439
	[DataContract]
	public class AudioNodeCreatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06000CAE RID: 3246 RVA: 0x00011C43 File Offset: 0x0000FE43
		// (set) Token: 0x06000CAF RID: 3247 RVA: 0x00011C4B File Offset: 0x0000FE4B
		[DataMember(Name = "node", IsRequired = true)]
		public AudioNode Node { get; private set; }
	}
}
