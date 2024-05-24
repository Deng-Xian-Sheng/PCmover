using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001B5 RID: 437
	[DataContract]
	public class AudioListenerCreatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06000CA6 RID: 3238 RVA: 0x00011C00 File Offset: 0x0000FE00
		// (set) Token: 0x06000CA7 RID: 3239 RVA: 0x00011C08 File Offset: 0x0000FE08
		[DataMember(Name = "listener", IsRequired = true)]
		public AudioListener Listener { get; private set; }
	}
}
