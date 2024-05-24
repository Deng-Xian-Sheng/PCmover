using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Animation
{
	// Token: 0x02000436 RID: 1078
	[DataContract]
	public class KeyframesRule : DevToolsDomainEntityBase
	{
		// Token: 0x17000B80 RID: 2944
		// (get) Token: 0x06001F63 RID: 8035 RVA: 0x000236CF File Offset: 0x000218CF
		// (set) Token: 0x06001F64 RID: 8036 RVA: 0x000236D7 File Offset: 0x000218D7
		[DataMember(Name = "name", IsRequired = false)]
		public string Name { get; set; }

		// Token: 0x17000B81 RID: 2945
		// (get) Token: 0x06001F65 RID: 8037 RVA: 0x000236E0 File Offset: 0x000218E0
		// (set) Token: 0x06001F66 RID: 8038 RVA: 0x000236E8 File Offset: 0x000218E8
		[DataMember(Name = "keyframes", IsRequired = true)]
		public IList<KeyframeStyle> Keyframes { get; set; }
	}
}
