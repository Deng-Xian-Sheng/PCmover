using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200014C RID: 332
	[DataContract]
	public class EvaluateResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000996 RID: 2454 RVA: 0x0000E7D2 File Offset: 0x0000C9D2
		// (set) Token: 0x06000997 RID: 2455 RVA: 0x0000E7DA File Offset: 0x0000C9DA
		[DataMember]
		internal RemoteObject result { get; set; }

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000998 RID: 2456 RVA: 0x0000E7E3 File Offset: 0x0000C9E3
		public RemoteObject Result
		{
			get
			{
				return this.result;
			}
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000999 RID: 2457 RVA: 0x0000E7EB File Offset: 0x0000C9EB
		// (set) Token: 0x0600099A RID: 2458 RVA: 0x0000E7F3 File Offset: 0x0000C9F3
		[DataMember]
		internal ExceptionDetails exceptionDetails { get; set; }

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x0600099B RID: 2459 RVA: 0x0000E7FC File Offset: 0x0000C9FC
		public ExceptionDetails ExceptionDetails
		{
			get
			{
				return this.exceptionDetails;
			}
		}
	}
}
