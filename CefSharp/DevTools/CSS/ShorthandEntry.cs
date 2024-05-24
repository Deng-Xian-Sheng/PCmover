using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003C7 RID: 967
	[DataContract]
	public class ShorthandEntry : DevToolsDomainEntityBase
	{
		// Token: 0x17000A30 RID: 2608
		// (get) Token: 0x06001C51 RID: 7249 RVA: 0x00020E65 File Offset: 0x0001F065
		// (set) Token: 0x06001C52 RID: 7250 RVA: 0x00020E6D File Offset: 0x0001F06D
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000A31 RID: 2609
		// (get) Token: 0x06001C53 RID: 7251 RVA: 0x00020E76 File Offset: 0x0001F076
		// (set) Token: 0x06001C54 RID: 7252 RVA: 0x00020E7E File Offset: 0x0001F07E
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }

		// Token: 0x17000A32 RID: 2610
		// (get) Token: 0x06001C55 RID: 7253 RVA: 0x00020E87 File Offset: 0x0001F087
		// (set) Token: 0x06001C56 RID: 7254 RVA: 0x00020E8F File Offset: 0x0001F08F
		[DataMember(Name = "important", IsRequired = false)]
		public bool? Important { get; set; }
	}
}
