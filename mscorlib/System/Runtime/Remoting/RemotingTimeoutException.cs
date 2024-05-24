using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting
{
	// Token: 0x020007C8 RID: 1992
	[ComVisible(true)]
	[Serializable]
	public class RemotingTimeoutException : RemotingException
	{
		// Token: 0x06005617 RID: 22039 RVA: 0x00131545 File Offset: 0x0012F745
		public RemotingTimeoutException() : base(RemotingTimeoutException._nullMessage)
		{
		}

		// Token: 0x06005618 RID: 22040 RVA: 0x00131552 File Offset: 0x0012F752
		public RemotingTimeoutException(string message) : base(message)
		{
			base.SetErrorCode(-2146233077);
		}

		// Token: 0x06005619 RID: 22041 RVA: 0x00131566 File Offset: 0x0012F766
		public RemotingTimeoutException(string message, Exception InnerException) : base(message, InnerException)
		{
			base.SetErrorCode(-2146233077);
		}

		// Token: 0x0600561A RID: 22042 RVA: 0x0013157B File Offset: 0x0012F77B
		internal RemotingTimeoutException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x04002789 RID: 10121
		private static string _nullMessage = Environment.GetResourceString("Remoting_Default");
	}
}
