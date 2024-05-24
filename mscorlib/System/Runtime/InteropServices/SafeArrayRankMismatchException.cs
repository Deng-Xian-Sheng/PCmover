using System;
using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000976 RID: 2422
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class SafeArrayRankMismatchException : SystemException
	{
		// Token: 0x06006259 RID: 25177 RVA: 0x00150EB2 File Offset: 0x0014F0B2
		[__DynamicallyInvokable]
		public SafeArrayRankMismatchException() : base(Environment.GetResourceString("Arg_SafeArrayRankMismatchException"))
		{
			base.SetErrorCode(-2146233032);
		}

		// Token: 0x0600625A RID: 25178 RVA: 0x00150ECF File Offset: 0x0014F0CF
		[__DynamicallyInvokable]
		public SafeArrayRankMismatchException(string message) : base(message)
		{
			base.SetErrorCode(-2146233032);
		}

		// Token: 0x0600625B RID: 25179 RVA: 0x00150EE3 File Offset: 0x0014F0E3
		[__DynamicallyInvokable]
		public SafeArrayRankMismatchException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233032);
		}

		// Token: 0x0600625C RID: 25180 RVA: 0x00150EF8 File Offset: 0x0014F0F8
		protected SafeArrayRankMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
