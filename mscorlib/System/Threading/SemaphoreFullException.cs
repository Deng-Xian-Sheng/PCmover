using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Threading
{
	// Token: 0x02000510 RID: 1296
	[ComVisible(false)]
	[TypeForwardedFrom("System, Version=2.0.0.0, Culture=Neutral, PublicKeyToken=b77a5c561934e089")]
	[__DynamicallyInvokable]
	[Serializable]
	public class SemaphoreFullException : SystemException
	{
		// Token: 0x06003D0A RID: 15626 RVA: 0x000E6027 File Offset: 0x000E4227
		[__DynamicallyInvokable]
		public SemaphoreFullException() : base(Environment.GetResourceString("Threading_SemaphoreFullException"))
		{
		}

		// Token: 0x06003D0B RID: 15627 RVA: 0x000E6039 File Offset: 0x000E4239
		[__DynamicallyInvokable]
		public SemaphoreFullException(string message) : base(message)
		{
		}

		// Token: 0x06003D0C RID: 15628 RVA: 0x000E6042 File Offset: 0x000E4242
		[__DynamicallyInvokable]
		public SemaphoreFullException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06003D0D RID: 15629 RVA: 0x000E604C File Offset: 0x000E424C
		protected SemaphoreFullException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
