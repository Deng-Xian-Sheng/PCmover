using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Emulation
{
	// Token: 0x02000353 RID: 851
	[DataContract]
	public class MediaFeature : DevToolsDomainEntityBase
	{
		// Token: 0x170008BE RID: 2238
		// (get) Token: 0x0600189B RID: 6299 RVA: 0x0001D193 File Offset: 0x0001B393
		// (set) Token: 0x0600189C RID: 6300 RVA: 0x0001D19B File Offset: 0x0001B39B
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x170008BF RID: 2239
		// (get) Token: 0x0600189D RID: 6301 RVA: 0x0001D1A4 File Offset: 0x0001B3A4
		// (set) Token: 0x0600189E RID: 6302 RVA: 0x0001D1AC File Offset: 0x0001B3AC
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }
	}
}
