using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Threading
{
	// Token: 0x02000518 RID: 1304
	[ComVisible(true)]
	[Serializable]
	public class ThreadInterruptedException : SystemException
	{
		// Token: 0x06003DB6 RID: 15798 RVA: 0x000E6D1E File Offset: 0x000E4F1E
		public ThreadInterruptedException() : base(Exception.GetMessageFromNativeResources(Exception.ExceptionMessageKind.ThreadInterrupted))
		{
			base.SetErrorCode(-2146233063);
		}

		// Token: 0x06003DB7 RID: 15799 RVA: 0x000E6D37 File Offset: 0x000E4F37
		public ThreadInterruptedException(string message) : base(message)
		{
			base.SetErrorCode(-2146233063);
		}

		// Token: 0x06003DB8 RID: 15800 RVA: 0x000E6D4B File Offset: 0x000E4F4B
		public ThreadInterruptedException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2146233063);
		}

		// Token: 0x06003DB9 RID: 15801 RVA: 0x000E6D60 File Offset: 0x000E4F60
		protected ThreadInterruptedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
