using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	// Token: 0x0200073E RID: 1854
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class SerializationException : SystemException
	{
		// Token: 0x060051CE RID: 20942 RVA: 0x0011FD5B File Offset: 0x0011DF5B
		[__DynamicallyInvokable]
		public SerializationException() : base(SerializationException._nullMessage)
		{
			base.SetErrorCode(-2146233076);
		}

		// Token: 0x060051CF RID: 20943 RVA: 0x0011FD73 File Offset: 0x0011DF73
		[__DynamicallyInvokable]
		public SerializationException(string message) : base(message)
		{
			base.SetErrorCode(-2146233076);
		}

		// Token: 0x060051D0 RID: 20944 RVA: 0x0011FD87 File Offset: 0x0011DF87
		[__DynamicallyInvokable]
		public SerializationException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2146233076);
		}

		// Token: 0x060051D1 RID: 20945 RVA: 0x0011FD9C File Offset: 0x0011DF9C
		protected SerializationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x0400243D RID: 9277
		private static string _nullMessage = Environment.GetResourceString("Arg_SerializationException");
	}
}
