using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Animation
{
	// Token: 0x0200043A RID: 1082
	[DataContract]
	public class AnimationStartedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000B86 RID: 2950
		// (get) Token: 0x06001F73 RID: 8051 RVA: 0x00023755 File Offset: 0x00021955
		// (set) Token: 0x06001F74 RID: 8052 RVA: 0x0002375D File Offset: 0x0002195D
		[DataMember(Name = "animation", IsRequired = true)]
		public Animation Animation { get; private set; }
	}
}
