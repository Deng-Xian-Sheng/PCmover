using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001B3 RID: 435
	[DataContract]
	public class ContextWillBeDestroyedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06000CA0 RID: 3232 RVA: 0x00011BCE File Offset: 0x0000FDCE
		// (set) Token: 0x06000CA1 RID: 3233 RVA: 0x00011BD6 File Offset: 0x0000FDD6
		[DataMember(Name = "contextId", IsRequired = true)]
		public string ContextId { get; private set; }
	}
}
