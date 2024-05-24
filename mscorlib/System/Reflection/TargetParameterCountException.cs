using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	// Token: 0x02000622 RID: 1570
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class TargetParameterCountException : ApplicationException
	{
		// Token: 0x060048B6 RID: 18614 RVA: 0x001078E3 File Offset: 0x00105AE3
		[__DynamicallyInvokable]
		public TargetParameterCountException() : base(Environment.GetResourceString("Arg_TargetParameterCountException"))
		{
			base.SetErrorCode(-2147352562);
		}

		// Token: 0x060048B7 RID: 18615 RVA: 0x00107900 File Offset: 0x00105B00
		[__DynamicallyInvokable]
		public TargetParameterCountException(string message) : base(message)
		{
			base.SetErrorCode(-2147352562);
		}

		// Token: 0x060048B8 RID: 18616 RVA: 0x00107914 File Offset: 0x00105B14
		[__DynamicallyInvokable]
		public TargetParameterCountException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2147352562);
		}

		// Token: 0x060048B9 RID: 18617 RVA: 0x00107929 File Offset: 0x00105B29
		internal TargetParameterCountException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
