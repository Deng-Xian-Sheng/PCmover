using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Threading
{
	// Token: 0x02000529 RID: 1321
	[ComVisible(true)]
	[Serializable]
	public class ThreadStateException : SystemException
	{
		// Token: 0x06003E23 RID: 15907 RVA: 0x000E7B3C File Offset: 0x000E5D3C
		public ThreadStateException() : base(Environment.GetResourceString("Arg_ThreadStateException"))
		{
			base.SetErrorCode(-2146233056);
		}

		// Token: 0x06003E24 RID: 15908 RVA: 0x000E7B59 File Offset: 0x000E5D59
		public ThreadStateException(string message) : base(message)
		{
			base.SetErrorCode(-2146233056);
		}

		// Token: 0x06003E25 RID: 15909 RVA: 0x000E7B6D File Offset: 0x000E5D6D
		public ThreadStateException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2146233056);
		}

		// Token: 0x06003E26 RID: 15910 RVA: 0x000E7B82 File Offset: 0x000E5D82
		protected ThreadStateException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
