using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Animation
{
	// Token: 0x02000439 RID: 1081
	[DataContract]
	public class AnimationCreatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000B85 RID: 2949
		// (get) Token: 0x06001F70 RID: 8048 RVA: 0x0002373C File Offset: 0x0002193C
		// (set) Token: 0x06001F71 RID: 8049 RVA: 0x00023744 File Offset: 0x00021944
		[DataMember(Name = "id", IsRequired = true)]
		public string Id { get; private set; }
	}
}
