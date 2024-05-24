using System;
using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000967 RID: 2407
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class InvalidComObjectException : SystemException
	{
		// Token: 0x06006223 RID: 25123 RVA: 0x0014F68D File Offset: 0x0014D88D
		[__DynamicallyInvokable]
		public InvalidComObjectException() : base(Environment.GetResourceString("Arg_InvalidComObjectException"))
		{
			base.SetErrorCode(-2146233049);
		}

		// Token: 0x06006224 RID: 25124 RVA: 0x0014F6AA File Offset: 0x0014D8AA
		[__DynamicallyInvokable]
		public InvalidComObjectException(string message) : base(message)
		{
			base.SetErrorCode(-2146233049);
		}

		// Token: 0x06006225 RID: 25125 RVA: 0x0014F6BE File Offset: 0x0014D8BE
		[__DynamicallyInvokable]
		public InvalidComObjectException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233049);
		}

		// Token: 0x06006226 RID: 25126 RVA: 0x0014F6D3 File Offset: 0x0014D8D3
		protected InvalidComObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
