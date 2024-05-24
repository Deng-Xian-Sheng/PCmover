using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Threading
{
	// Token: 0x02000511 RID: 1297
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class SynchronizationLockException : SystemException
	{
		// Token: 0x06003D0E RID: 15630 RVA: 0x000E6056 File Offset: 0x000E4256
		[__DynamicallyInvokable]
		public SynchronizationLockException() : base(Environment.GetResourceString("Arg_SynchronizationLockException"))
		{
			base.SetErrorCode(-2146233064);
		}

		// Token: 0x06003D0F RID: 15631 RVA: 0x000E6073 File Offset: 0x000E4273
		[__DynamicallyInvokable]
		public SynchronizationLockException(string message) : base(message)
		{
			base.SetErrorCode(-2146233064);
		}

		// Token: 0x06003D10 RID: 15632 RVA: 0x000E6087 File Offset: 0x000E4287
		[__DynamicallyInvokable]
		public SynchronizationLockException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2146233064);
		}

		// Token: 0x06003D11 RID: 15633 RVA: 0x000E609C File Offset: 0x000E429C
		protected SynchronizationLockException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
