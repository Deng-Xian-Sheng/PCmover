using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Threading
{
	// Token: 0x02000534 RID: 1332
	[ComVisible(false)]
	[__DynamicallyInvokable]
	[Serializable]
	public class WaitHandleCannotBeOpenedException : ApplicationException
	{
		// Token: 0x06003EA2 RID: 16034 RVA: 0x000E91DD File Offset: 0x000E73DD
		[__DynamicallyInvokable]
		public WaitHandleCannotBeOpenedException() : base(Environment.GetResourceString("Threading.WaitHandleCannotBeOpenedException"))
		{
			base.SetErrorCode(-2146233044);
		}

		// Token: 0x06003EA3 RID: 16035 RVA: 0x000E91FA File Offset: 0x000E73FA
		[__DynamicallyInvokable]
		public WaitHandleCannotBeOpenedException(string message) : base(message)
		{
			base.SetErrorCode(-2146233044);
		}

		// Token: 0x06003EA4 RID: 16036 RVA: 0x000E920E File Offset: 0x000E740E
		[__DynamicallyInvokable]
		public WaitHandleCannotBeOpenedException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2146233044);
		}

		// Token: 0x06003EA5 RID: 16037 RVA: 0x000E9223 File Offset: 0x000E7423
		protected WaitHandleCannotBeOpenedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
