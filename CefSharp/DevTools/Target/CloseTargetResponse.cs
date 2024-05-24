using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001E8 RID: 488
	[DataContract]
	public class CloseTargetResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06000DFA RID: 3578 RVA: 0x00012FFC File Offset: 0x000111FC
		// (set) Token: 0x06000DFB RID: 3579 RVA: 0x00013004 File Offset: 0x00011204
		[DataMember]
		internal bool success { get; set; }

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06000DFC RID: 3580 RVA: 0x0001300D File Offset: 0x0001120D
		public bool Success
		{
			get
			{
				return this.success;
			}
		}
	}
}
