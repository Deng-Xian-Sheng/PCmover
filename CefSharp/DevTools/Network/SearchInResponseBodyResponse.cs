using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.Debugger;

namespace CefSharp.DevTools.Network
{
	// Token: 0x02000308 RID: 776
	[DataContract]
	public class SearchInResponseBodyResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x06001696 RID: 5782 RVA: 0x0001A23C File Offset: 0x0001843C
		// (set) Token: 0x06001697 RID: 5783 RVA: 0x0001A244 File Offset: 0x00018444
		[DataMember]
		internal IList<SearchMatch> result { get; set; }

		// Token: 0x1700081A RID: 2074
		// (get) Token: 0x06001698 RID: 5784 RVA: 0x0001A24D File Offset: 0x0001844D
		public IList<SearchMatch> Result
		{
			get
			{
				return this.result;
			}
		}
	}
}
