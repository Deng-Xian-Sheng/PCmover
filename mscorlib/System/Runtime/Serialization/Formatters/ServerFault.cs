using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata;

namespace System.Runtime.Serialization.Formatters
{
	// Token: 0x02000766 RID: 1894
	[SoapType(Embedded = true)]
	[ComVisible(true)]
	[Serializable]
	public sealed class ServerFault
	{
		// Token: 0x06005328 RID: 21288 RVA: 0x00123E41 File Offset: 0x00122041
		internal ServerFault(Exception exception)
		{
			this.exception = exception;
		}

		// Token: 0x06005329 RID: 21289 RVA: 0x00123E50 File Offset: 0x00122050
		public ServerFault(string exceptionType, string message, string stackTrace)
		{
			this.exceptionType = exceptionType;
			this.message = message;
			this.stackTrace = stackTrace;
		}

		// Token: 0x17000DCA RID: 3530
		// (get) Token: 0x0600532A RID: 21290 RVA: 0x00123E6D File Offset: 0x0012206D
		// (set) Token: 0x0600532B RID: 21291 RVA: 0x00123E75 File Offset: 0x00122075
		public string ExceptionType
		{
			get
			{
				return this.exceptionType;
			}
			set
			{
				this.exceptionType = value;
			}
		}

		// Token: 0x17000DCB RID: 3531
		// (get) Token: 0x0600532C RID: 21292 RVA: 0x00123E7E File Offset: 0x0012207E
		// (set) Token: 0x0600532D RID: 21293 RVA: 0x00123E86 File Offset: 0x00122086
		public string ExceptionMessage
		{
			get
			{
				return this.message;
			}
			set
			{
				this.message = value;
			}
		}

		// Token: 0x17000DCC RID: 3532
		// (get) Token: 0x0600532E RID: 21294 RVA: 0x00123E8F File Offset: 0x0012208F
		// (set) Token: 0x0600532F RID: 21295 RVA: 0x00123E97 File Offset: 0x00122097
		public string StackTrace
		{
			get
			{
				return this.stackTrace;
			}
			set
			{
				this.stackTrace = value;
			}
		}

		// Token: 0x17000DCD RID: 3533
		// (get) Token: 0x06005330 RID: 21296 RVA: 0x00123EA0 File Offset: 0x001220A0
		internal Exception Exception
		{
			get
			{
				return this.exception;
			}
		}

		// Token: 0x040024D9 RID: 9433
		private string exceptionType;

		// Token: 0x040024DA RID: 9434
		private string message;

		// Token: 0x040024DB RID: 9435
		private string stackTrace;

		// Token: 0x040024DC RID: 9436
		private Exception exception;
	}
}
