using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001ED RID: 493
	[DataContract]
	public class GetTargetsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06000E0E RID: 3598 RVA: 0x000130A1 File Offset: 0x000112A1
		// (set) Token: 0x06000E0F RID: 3599 RVA: 0x000130A9 File Offset: 0x000112A9
		[DataMember]
		internal IList<TargetInfo> targetInfos { get; set; }

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06000E10 RID: 3600 RVA: 0x000130B2 File Offset: 0x000112B2
		public IList<TargetInfo> TargetInfos
		{
			get
			{
				return this.targetInfos;
			}
		}
	}
}
