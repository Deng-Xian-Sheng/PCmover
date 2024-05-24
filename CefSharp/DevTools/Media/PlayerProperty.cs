using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Media
{
	// Token: 0x02000195 RID: 405
	[DataContract]
	public class PlayerProperty : DevToolsDomainEntityBase
	{
		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x06000BDD RID: 3037 RVA: 0x000111AC File Offset: 0x0000F3AC
		// (set) Token: 0x06000BDE RID: 3038 RVA: 0x000111B4 File Offset: 0x0000F3B4
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x06000BDF RID: 3039 RVA: 0x000111BD File Offset: 0x0000F3BD
		// (set) Token: 0x06000BE0 RID: 3040 RVA: 0x000111C5 File Offset: 0x0000F3C5
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }
	}
}
