using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000151 RID: 337
	[DataContract]
	public class QueryObjectsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170002EB RID: 747
		// (get) Token: 0x060009B9 RID: 2489 RVA: 0x0000E8F4 File Offset: 0x0000CAF4
		// (set) Token: 0x060009BA RID: 2490 RVA: 0x0000E8FC File Offset: 0x0000CAFC
		[DataMember]
		internal RemoteObject objects { get; set; }

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x060009BB RID: 2491 RVA: 0x0000E905 File Offset: 0x0000CB05
		public RemoteObject Objects
		{
			get
			{
				return this.objects;
			}
		}
	}
}
