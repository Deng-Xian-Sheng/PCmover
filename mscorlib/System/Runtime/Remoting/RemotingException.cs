using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting
{
	// Token: 0x020007C6 RID: 1990
	[ComVisible(true)]
	[Serializable]
	public class RemotingException : SystemException
	{
		// Token: 0x0600560D RID: 22029 RVA: 0x0013148D File Offset: 0x0012F68D
		public RemotingException() : base(RemotingException._nullMessage)
		{
			base.SetErrorCode(-2146233077);
		}

		// Token: 0x0600560E RID: 22030 RVA: 0x001314A5 File Offset: 0x0012F6A5
		public RemotingException(string message) : base(message)
		{
			base.SetErrorCode(-2146233077);
		}

		// Token: 0x0600560F RID: 22031 RVA: 0x001314B9 File Offset: 0x0012F6B9
		public RemotingException(string message, Exception InnerException) : base(message, InnerException)
		{
			base.SetErrorCode(-2146233077);
		}

		// Token: 0x06005610 RID: 22032 RVA: 0x001314CE File Offset: 0x0012F6CE
		protected RemotingException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x04002787 RID: 10119
		private static string _nullMessage = Environment.GetResourceString("Remoting_Default");
	}
}
