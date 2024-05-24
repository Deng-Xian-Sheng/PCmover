using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002D6 RID: 726
	[DataContract]
	public class ConnectTiming : DevToolsDomainEntityBase
	{
		// Token: 0x1700075F RID: 1887
		// (get) Token: 0x060014FD RID: 5373 RVA: 0x000192C5 File Offset: 0x000174C5
		// (set) Token: 0x060014FE RID: 5374 RVA: 0x000192CD File Offset: 0x000174CD
		[DataMember(Name = "requestTime", IsRequired = true)]
		public double RequestTime { get; set; }
	}
}
