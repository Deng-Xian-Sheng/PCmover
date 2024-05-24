using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.IndexedDB
{
	// Token: 0x02000345 RID: 837
	[DataContract]
	public class RequestDataResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170008A3 RID: 2211
		// (get) Token: 0x06001856 RID: 6230 RVA: 0x0001CC07 File Offset: 0x0001AE07
		// (set) Token: 0x06001857 RID: 6231 RVA: 0x0001CC0F File Offset: 0x0001AE0F
		[DataMember]
		internal IList<DataEntry> objectStoreDataEntries { get; set; }

		// Token: 0x170008A4 RID: 2212
		// (get) Token: 0x06001858 RID: 6232 RVA: 0x0001CC18 File Offset: 0x0001AE18
		public IList<DataEntry> ObjectStoreDataEntries
		{
			get
			{
				return this.objectStoreDataEntries;
			}
		}

		// Token: 0x170008A5 RID: 2213
		// (get) Token: 0x06001859 RID: 6233 RVA: 0x0001CC20 File Offset: 0x0001AE20
		// (set) Token: 0x0600185A RID: 6234 RVA: 0x0001CC28 File Offset: 0x0001AE28
		[DataMember]
		internal bool hasMore { get; set; }

		// Token: 0x170008A6 RID: 2214
		// (get) Token: 0x0600185B RID: 6235 RVA: 0x0001CC31 File Offset: 0x0001AE31
		public bool HasMore
		{
			get
			{
				return this.hasMore;
			}
		}
	}
}
