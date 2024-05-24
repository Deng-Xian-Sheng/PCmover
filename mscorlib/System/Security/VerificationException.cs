using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Security
{
	// Token: 0x020001F6 RID: 502
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class VerificationException : SystemException
	{
		// Token: 0x06001E3B RID: 7739 RVA: 0x00069AEA File Offset: 0x00067CEA
		[__DynamicallyInvokable]
		public VerificationException() : base(Environment.GetResourceString("Verification_Exception"))
		{
			base.SetErrorCode(-2146233075);
		}

		// Token: 0x06001E3C RID: 7740 RVA: 0x00069B07 File Offset: 0x00067D07
		[__DynamicallyInvokable]
		public VerificationException(string message) : base(message)
		{
			base.SetErrorCode(-2146233075);
		}

		// Token: 0x06001E3D RID: 7741 RVA: 0x00069B1B File Offset: 0x00067D1B
		[__DynamicallyInvokable]
		public VerificationException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2146233075);
		}

		// Token: 0x06001E3E RID: 7742 RVA: 0x00069B30 File Offset: 0x00067D30
		protected VerificationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
