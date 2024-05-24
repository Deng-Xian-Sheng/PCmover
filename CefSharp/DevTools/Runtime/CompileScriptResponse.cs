using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200014B RID: 331
	[DataContract]
	public class CompileScriptResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x0600098F RID: 2447 RVA: 0x0000E798 File Offset: 0x0000C998
		// (set) Token: 0x06000990 RID: 2448 RVA: 0x0000E7A0 File Offset: 0x0000C9A0
		[DataMember]
		internal string scriptId { get; set; }

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000991 RID: 2449 RVA: 0x0000E7A9 File Offset: 0x0000C9A9
		public string ScriptId
		{
			get
			{
				return this.scriptId;
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000992 RID: 2450 RVA: 0x0000E7B1 File Offset: 0x0000C9B1
		// (set) Token: 0x06000993 RID: 2451 RVA: 0x0000E7B9 File Offset: 0x0000C9B9
		[DataMember]
		internal ExceptionDetails exceptionDetails { get; set; }

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x0000E7C2 File Offset: 0x0000C9C2
		public ExceptionDetails ExceptionDetails
		{
			get
			{
				return this.exceptionDetails;
			}
		}
	}
}
