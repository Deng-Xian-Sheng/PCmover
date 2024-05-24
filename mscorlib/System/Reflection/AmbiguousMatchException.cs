using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	// Token: 0x020005AE RID: 1454
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class AmbiguousMatchException : SystemException
	{
		// Token: 0x06004365 RID: 17253 RVA: 0x000FA6B1 File Offset: 0x000F88B1
		[__DynamicallyInvokable]
		public AmbiguousMatchException() : base(Environment.GetResourceString("RFLCT.Ambiguous"))
		{
			base.SetErrorCode(-2147475171);
		}

		// Token: 0x06004366 RID: 17254 RVA: 0x000FA6CE File Offset: 0x000F88CE
		[__DynamicallyInvokable]
		public AmbiguousMatchException(string message) : base(message)
		{
			base.SetErrorCode(-2147475171);
		}

		// Token: 0x06004367 RID: 17255 RVA: 0x000FA6E2 File Offset: 0x000F88E2
		[__DynamicallyInvokable]
		public AmbiguousMatchException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2147475171);
		}

		// Token: 0x06004368 RID: 17256 RVA: 0x000FA6F7 File Offset: 0x000F88F7
		internal AmbiguousMatchException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
