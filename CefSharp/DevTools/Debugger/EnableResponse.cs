using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000184 RID: 388
	[DataContract]
	public class EnableResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000B6C RID: 2924 RVA: 0x000105C8 File Offset: 0x0000E7C8
		// (set) Token: 0x06000B6D RID: 2925 RVA: 0x000105D0 File Offset: 0x0000E7D0
		[DataMember]
		internal string debuggerId { get; set; }

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000B6E RID: 2926 RVA: 0x000105D9 File Offset: 0x0000E7D9
		public string DebuggerId
		{
			get
			{
				return this.debuggerId;
			}
		}
	}
}
