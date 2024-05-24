using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000517 RID: 1303
	[ComVisible(true)]
	[Serializable]
	public sealed class ThreadAbortException : SystemException
	{
		// Token: 0x06003DB3 RID: 15795 RVA: 0x000E6CEF File Offset: 0x000E4EEF
		internal ThreadAbortException() : base(Exception.GetMessageFromNativeResources(Exception.ExceptionMessageKind.ThreadAbort))
		{
			base.SetErrorCode(-2146233040);
		}

		// Token: 0x06003DB4 RID: 15796 RVA: 0x000E6D08 File Offset: 0x000E4F08
		internal ThreadAbortException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x17000937 RID: 2359
		// (get) Token: 0x06003DB5 RID: 15797 RVA: 0x000E6D12 File Offset: 0x000E4F12
		public object ExceptionState
		{
			[SecuritySafeCritical]
			get
			{
				return Thread.CurrentThread.AbortReason;
			}
		}
	}
}
