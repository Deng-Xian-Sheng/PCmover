using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting
{
	// Token: 0x020007C7 RID: 1991
	[ComVisible(true)]
	[Serializable]
	public class ServerException : SystemException
	{
		// Token: 0x06005612 RID: 22034 RVA: 0x001314E9 File Offset: 0x0012F6E9
		public ServerException() : base(ServerException._nullMessage)
		{
			base.SetErrorCode(-2146233074);
		}

		// Token: 0x06005613 RID: 22035 RVA: 0x00131501 File Offset: 0x0012F701
		public ServerException(string message) : base(message)
		{
			base.SetErrorCode(-2146233074);
		}

		// Token: 0x06005614 RID: 22036 RVA: 0x00131515 File Offset: 0x0012F715
		public ServerException(string message, Exception InnerException) : base(message, InnerException)
		{
			base.SetErrorCode(-2146233074);
		}

		// Token: 0x06005615 RID: 22037 RVA: 0x0013152A File Offset: 0x0012F72A
		internal ServerException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x04002788 RID: 10120
		private static string _nullMessage = Environment.GetResourceString("Remoting_Default");
	}
}
