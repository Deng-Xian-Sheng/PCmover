using System;
using System.Runtime.Serialization;

namespace System.Threading
{
	// Token: 0x0200052A RID: 1322
	[Serializable]
	public sealed class ThreadStartException : SystemException
	{
		// Token: 0x06003E27 RID: 15911 RVA: 0x000E7B8C File Offset: 0x000E5D8C
		private ThreadStartException() : base(Environment.GetResourceString("Arg_ThreadStartException"))
		{
			base.SetErrorCode(-2146233051);
		}

		// Token: 0x06003E28 RID: 15912 RVA: 0x000E7BA9 File Offset: 0x000E5DA9
		private ThreadStartException(Exception reason) : base(Environment.GetResourceString("Arg_ThreadStartException"), reason)
		{
			base.SetErrorCode(-2146233051);
		}

		// Token: 0x06003E29 RID: 15913 RVA: 0x000E7BC7 File Offset: 0x000E5DC7
		internal ThreadStartException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
