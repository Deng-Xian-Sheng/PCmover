using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000149 RID: 329
	[DataContract]
	public class AwaitPromiseResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000981 RID: 2433 RVA: 0x0000E724 File Offset: 0x0000C924
		// (set) Token: 0x06000982 RID: 2434 RVA: 0x0000E72C File Offset: 0x0000C92C
		[DataMember]
		internal RemoteObject result { get; set; }

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000983 RID: 2435 RVA: 0x0000E735 File Offset: 0x0000C935
		public RemoteObject Result
		{
			get
			{
				return this.result;
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x0000E73D File Offset: 0x0000C93D
		// (set) Token: 0x06000985 RID: 2437 RVA: 0x0000E745 File Offset: 0x0000C945
		[DataMember]
		internal ExceptionDetails exceptionDetails { get; set; }

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x0000E74E File Offset: 0x0000C94E
		public ExceptionDetails ExceptionDetails
		{
			get
			{
				return this.exceptionDetails;
			}
		}
	}
}
