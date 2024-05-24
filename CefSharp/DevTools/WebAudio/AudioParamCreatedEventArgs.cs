using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001B9 RID: 441
	[DataContract]
	public class AudioParamCreatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06000CB6 RID: 3254 RVA: 0x00011C86 File Offset: 0x0000FE86
		// (set) Token: 0x06000CB7 RID: 3255 RVA: 0x00011C8E File Offset: 0x0000FE8E
		[DataMember(Name = "param", IsRequired = true)]
		public AudioParam Param { get; private set; }
	}
}
