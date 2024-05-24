using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.SystemInfo
{
	// Token: 0x020001F9 RID: 505
	[DataContract]
	public class GetProcessInfoResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06000E87 RID: 3719 RVA: 0x00013998 File Offset: 0x00011B98
		// (set) Token: 0x06000E88 RID: 3720 RVA: 0x000139A0 File Offset: 0x00011BA0
		[DataMember]
		internal IList<ProcessInfo> processInfo { get; set; }

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06000E89 RID: 3721 RVA: 0x000139A9 File Offset: 0x00011BA9
		public IList<ProcessInfo> ProcessInfo
		{
			get
			{
				return this.processInfo;
			}
		}
	}
}
