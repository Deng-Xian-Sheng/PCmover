using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000189 RID: 393
	[DataContract]
	public class SearchInContentResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06000B86 RID: 2950 RVA: 0x000106A5 File Offset: 0x0000E8A5
		// (set) Token: 0x06000B87 RID: 2951 RVA: 0x000106AD File Offset: 0x0000E8AD
		[DataMember]
		internal IList<SearchMatch> result { get; set; }

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000B88 RID: 2952 RVA: 0x000106B6 File Offset: 0x0000E8B6
		public IList<SearchMatch> Result
		{
			get
			{
				return this.result;
			}
		}
	}
}
