using System;
using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000977 RID: 2423
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class SafeArrayTypeMismatchException : SystemException
	{
		// Token: 0x0600625D RID: 25181 RVA: 0x00150F02 File Offset: 0x0014F102
		[__DynamicallyInvokable]
		public SafeArrayTypeMismatchException() : base(Environment.GetResourceString("Arg_SafeArrayTypeMismatchException"))
		{
			base.SetErrorCode(-2146233037);
		}

		// Token: 0x0600625E RID: 25182 RVA: 0x00150F1F File Offset: 0x0014F11F
		[__DynamicallyInvokable]
		public SafeArrayTypeMismatchException(string message) : base(message)
		{
			base.SetErrorCode(-2146233037);
		}

		// Token: 0x0600625F RID: 25183 RVA: 0x00150F33 File Offset: 0x0014F133
		[__DynamicallyInvokable]
		public SafeArrayTypeMismatchException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233037);
		}

		// Token: 0x06006260 RID: 25184 RVA: 0x00150F48 File Offset: 0x0014F148
		protected SafeArrayTypeMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
