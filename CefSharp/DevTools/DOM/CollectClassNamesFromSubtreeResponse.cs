using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000394 RID: 916
	[DataContract]
	public class CollectClassNamesFromSubtreeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009AB RID: 2475
		// (get) Token: 0x06001ADF RID: 6879 RVA: 0x0001F168 File Offset: 0x0001D368
		// (set) Token: 0x06001AE0 RID: 6880 RVA: 0x0001F170 File Offset: 0x0001D370
		[DataMember]
		internal string[] classNames { get; set; }

		// Token: 0x170009AC RID: 2476
		// (get) Token: 0x06001AE1 RID: 6881 RVA: 0x0001F179 File Offset: 0x0001D379
		public string[] ClassNames
		{
			get
			{
				return this.classNames;
			}
		}
	}
}
