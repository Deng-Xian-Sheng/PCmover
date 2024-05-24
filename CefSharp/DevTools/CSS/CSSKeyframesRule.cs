using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003D4 RID: 980
	[DataContract]
	public class CSSKeyframesRule : DevToolsDomainEntityBase
	{
		// Token: 0x17000A68 RID: 2664
		// (get) Token: 0x06001CCD RID: 7373 RVA: 0x0002129B File Offset: 0x0001F49B
		// (set) Token: 0x06001CCE RID: 7374 RVA: 0x000212A3 File Offset: 0x0001F4A3
		[DataMember(Name = "animationName", IsRequired = true)]
		public Value AnimationName { get; set; }

		// Token: 0x17000A69 RID: 2665
		// (get) Token: 0x06001CCF RID: 7375 RVA: 0x000212AC File Offset: 0x0001F4AC
		// (set) Token: 0x06001CD0 RID: 7376 RVA: 0x000212B4 File Offset: 0x0001F4B4
		[DataMember(Name = "keyframes", IsRequired = true)]
		public IList<CSSKeyframeRule> Keyframes { get; set; }
	}
}
