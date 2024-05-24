using System;
using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000951 RID: 2385
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class MarshalDirectiveException : SystemException
	{
		// Token: 0x060061A7 RID: 24999 RVA: 0x0014E448 File Offset: 0x0014C648
		[__DynamicallyInvokable]
		public MarshalDirectiveException() : base(Environment.GetResourceString("Arg_MarshalDirectiveException"))
		{
			base.SetErrorCode(-2146233035);
		}

		// Token: 0x060061A8 RID: 25000 RVA: 0x0014E465 File Offset: 0x0014C665
		[__DynamicallyInvokable]
		public MarshalDirectiveException(string message) : base(message)
		{
			base.SetErrorCode(-2146233035);
		}

		// Token: 0x060061A9 RID: 25001 RVA: 0x0014E479 File Offset: 0x0014C679
		[__DynamicallyInvokable]
		public MarshalDirectiveException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233035);
		}

		// Token: 0x060061AA RID: 25002 RVA: 0x0014E48E File Offset: 0x0014C68E
		protected MarshalDirectiveException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
