using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Collections.Generic
{
	// Token: 0x020004D9 RID: 1241
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class KeyNotFoundException : SystemException, ISerializable
	{
		// Token: 0x06003ADE RID: 15070 RVA: 0x000DF990 File Offset: 0x000DDB90
		[__DynamicallyInvokable]
		public KeyNotFoundException() : base(Environment.GetResourceString("Arg_KeyNotFound"))
		{
			base.SetErrorCode(-2146232969);
		}

		// Token: 0x06003ADF RID: 15071 RVA: 0x000DF9AD File Offset: 0x000DDBAD
		[__DynamicallyInvokable]
		public KeyNotFoundException(string message) : base(message)
		{
			base.SetErrorCode(-2146232969);
		}

		// Token: 0x06003AE0 RID: 15072 RVA: 0x000DF9C1 File Offset: 0x000DDBC1
		[__DynamicallyInvokable]
		public KeyNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2146232969);
		}

		// Token: 0x06003AE1 RID: 15073 RVA: 0x000DF9D6 File Offset: 0x000DDBD6
		protected KeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
