using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003DC RID: 988
	[DataContract]
	public class CollectClassNamesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000A78 RID: 2680
		// (get) Token: 0x06001CF4 RID: 7412 RVA: 0x00021400 File Offset: 0x0001F600
		// (set) Token: 0x06001CF5 RID: 7413 RVA: 0x00021408 File Offset: 0x0001F608
		[DataMember]
		internal string[] classNames { get; set; }

		// Token: 0x17000A79 RID: 2681
		// (get) Token: 0x06001CF6 RID: 7414 RVA: 0x00021411 File Offset: 0x0001F611
		public string[] ClassNames
		{
			get
			{
				return this.classNames;
			}
		}
	}
}
