using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Animation
{
	// Token: 0x02000438 RID: 1080
	[DataContract]
	public class AnimationCanceledEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000B84 RID: 2948
		// (get) Token: 0x06001F6D RID: 8045 RVA: 0x00023723 File Offset: 0x00021923
		// (set) Token: 0x06001F6E RID: 8046 RVA: 0x0002372B File Offset: 0x0002192B
		[DataMember(Name = "id", IsRequired = true)]
		public string Id { get; private set; }
	}
}
