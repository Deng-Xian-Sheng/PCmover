using System;
using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200094C RID: 2380
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class InvalidOleVariantTypeException : SystemException
	{
		// Token: 0x060060B8 RID: 24760 RVA: 0x0014C9A5 File Offset: 0x0014ABA5
		[__DynamicallyInvokable]
		public InvalidOleVariantTypeException() : base(Environment.GetResourceString("Arg_InvalidOleVariantTypeException"))
		{
			base.SetErrorCode(-2146233039);
		}

		// Token: 0x060060B9 RID: 24761 RVA: 0x0014C9C2 File Offset: 0x0014ABC2
		[__DynamicallyInvokable]
		public InvalidOleVariantTypeException(string message) : base(message)
		{
			base.SetErrorCode(-2146233039);
		}

		// Token: 0x060060BA RID: 24762 RVA: 0x0014C9D6 File Offset: 0x0014ABD6
		[__DynamicallyInvokable]
		public InvalidOleVariantTypeException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233039);
		}

		// Token: 0x060060BB RID: 24763 RVA: 0x0014C9EB File Offset: 0x0014ABEB
		protected InvalidOleVariantTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
