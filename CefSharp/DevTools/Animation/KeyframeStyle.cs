using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Animation
{
	// Token: 0x02000437 RID: 1079
	[DataContract]
	public class KeyframeStyle : DevToolsDomainEntityBase
	{
		// Token: 0x17000B82 RID: 2946
		// (get) Token: 0x06001F68 RID: 8040 RVA: 0x000236F9 File Offset: 0x000218F9
		// (set) Token: 0x06001F69 RID: 8041 RVA: 0x00023701 File Offset: 0x00021901
		[DataMember(Name = "offset", IsRequired = true)]
		public string Offset { get; set; }

		// Token: 0x17000B83 RID: 2947
		// (get) Token: 0x06001F6A RID: 8042 RVA: 0x0002370A File Offset: 0x0002190A
		// (set) Token: 0x06001F6B RID: 8043 RVA: 0x00023712 File Offset: 0x00021912
		[DataMember(Name = "easing", IsRequired = true)]
		public string Easing { get; set; }
	}
}
