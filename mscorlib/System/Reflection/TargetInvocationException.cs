using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	// Token: 0x02000621 RID: 1569
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class TargetInvocationException : ApplicationException
	{
		// Token: 0x060048B1 RID: 18609 RVA: 0x00107875 File Offset: 0x00105A75
		private TargetInvocationException() : base(Environment.GetResourceString("Arg_TargetInvocationException"))
		{
			base.SetErrorCode(-2146232828);
		}

		// Token: 0x060048B2 RID: 18610 RVA: 0x00107892 File Offset: 0x00105A92
		private TargetInvocationException(string message) : base(message)
		{
			base.SetErrorCode(-2146232828);
		}

		// Token: 0x060048B3 RID: 18611 RVA: 0x001078A6 File Offset: 0x00105AA6
		[__DynamicallyInvokable]
		public TargetInvocationException(Exception inner) : base(Environment.GetResourceString("Arg_TargetInvocationException"), inner)
		{
			base.SetErrorCode(-2146232828);
		}

		// Token: 0x060048B4 RID: 18612 RVA: 0x001078C4 File Offset: 0x00105AC4
		[__DynamicallyInvokable]
		public TargetInvocationException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146232828);
		}

		// Token: 0x060048B5 RID: 18613 RVA: 0x001078D9 File Offset: 0x00105AD9
		internal TargetInvocationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
