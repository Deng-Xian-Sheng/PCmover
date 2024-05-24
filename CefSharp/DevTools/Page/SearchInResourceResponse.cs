using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.Debugger;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000281 RID: 641
	[DataContract]
	public class SearchInResourceResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x06001216 RID: 4630 RVA: 0x00016287 File Offset: 0x00014487
		// (set) Token: 0x06001217 RID: 4631 RVA: 0x0001628F File Offset: 0x0001448F
		[DataMember]
		internal IList<SearchMatch> result { get; set; }

		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x06001218 RID: 4632 RVA: 0x00016298 File Offset: 0x00014498
		public IList<SearchMatch> Result
		{
			get
			{
				return this.result;
			}
		}
	}
}
