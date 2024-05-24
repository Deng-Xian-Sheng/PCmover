using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Media
{
	// Token: 0x02000196 RID: 406
	[DataContract]
	public class PlayerEvent : DevToolsDomainEntityBase
	{
		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06000BE2 RID: 3042 RVA: 0x000111D6 File Offset: 0x0000F3D6
		// (set) Token: 0x06000BE3 RID: 3043 RVA: 0x000111DE File Offset: 0x0000F3DE
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; set; }

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x000111E7 File Offset: 0x0000F3E7
		// (set) Token: 0x06000BE5 RID: 3045 RVA: 0x000111EF File Offset: 0x0000F3EF
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }
	}
}
