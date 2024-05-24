using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x02000370 RID: 880
	[DataContract]
	public class RareBooleanData : DevToolsDomainEntityBase
	{
		// Token: 0x17000918 RID: 2328
		// (get) Token: 0x06001990 RID: 6544 RVA: 0x0001E2E6 File Offset: 0x0001C4E6
		// (set) Token: 0x06001991 RID: 6545 RVA: 0x0001E2EE File Offset: 0x0001C4EE
		[DataMember(Name = "index", IsRequired = true)]
		public int[] Index { get; set; }
	}
}
