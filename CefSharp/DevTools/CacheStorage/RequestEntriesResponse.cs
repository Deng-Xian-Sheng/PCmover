using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CacheStorage
{
	// Token: 0x020003BB RID: 955
	[DataContract]
	public class RequestEntriesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009FF RID: 2559
		// (get) Token: 0x06001BE1 RID: 7137 RVA: 0x000208EF File Offset: 0x0001EAEF
		// (set) Token: 0x06001BE2 RID: 7138 RVA: 0x000208F7 File Offset: 0x0001EAF7
		[DataMember]
		internal IList<DataEntry> cacheDataEntries { get; set; }

		// Token: 0x17000A00 RID: 2560
		// (get) Token: 0x06001BE3 RID: 7139 RVA: 0x00020900 File Offset: 0x0001EB00
		public IList<DataEntry> CacheDataEntries
		{
			get
			{
				return this.cacheDataEntries;
			}
		}

		// Token: 0x17000A01 RID: 2561
		// (get) Token: 0x06001BE4 RID: 7140 RVA: 0x00020908 File Offset: 0x0001EB08
		// (set) Token: 0x06001BE5 RID: 7141 RVA: 0x00020910 File Offset: 0x0001EB10
		[DataMember]
		internal double returnCount { get; set; }

		// Token: 0x17000A02 RID: 2562
		// (get) Token: 0x06001BE6 RID: 7142 RVA: 0x00020919 File Offset: 0x0001EB19
		public double ReturnCount
		{
			get
			{
				return this.returnCount;
			}
		}
	}
}
