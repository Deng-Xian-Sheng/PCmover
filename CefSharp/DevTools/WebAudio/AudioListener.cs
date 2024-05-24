using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001AF RID: 431
	[DataContract]
	public class AudioListener : DevToolsDomainEntityBase
	{
		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06000C70 RID: 3184 RVA: 0x000119DE File Offset: 0x0000FBDE
		// (set) Token: 0x06000C71 RID: 3185 RVA: 0x000119E6 File Offset: 0x0000FBE6
		[DataMember(Name = "listenerId", IsRequired = true)]
		public string ListenerId { get; set; }

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06000C72 RID: 3186 RVA: 0x000119EF File Offset: 0x0000FBEF
		// (set) Token: 0x06000C73 RID: 3187 RVA: 0x000119F7 File Offset: 0x0000FBF7
		[DataMember(Name = "contextId", IsRequired = true)]
		public string ContextId { get; set; }
	}
}
