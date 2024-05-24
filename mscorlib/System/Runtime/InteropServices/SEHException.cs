using System;
using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000954 RID: 2388
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class SEHException : ExternalException
	{
		// Token: 0x060061B8 RID: 25016 RVA: 0x0014E580 File Offset: 0x0014C780
		[__DynamicallyInvokable]
		public SEHException()
		{
			base.SetErrorCode(-2147467259);
		}

		// Token: 0x060061B9 RID: 25017 RVA: 0x0014E593 File Offset: 0x0014C793
		[__DynamicallyInvokable]
		public SEHException(string message) : base(message)
		{
			base.SetErrorCode(-2147467259);
		}

		// Token: 0x060061BA RID: 25018 RVA: 0x0014E5A7 File Offset: 0x0014C7A7
		[__DynamicallyInvokable]
		public SEHException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2147467259);
		}

		// Token: 0x060061BB RID: 25019 RVA: 0x0014E5BC File Offset: 0x0014C7BC
		protected SEHException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x060061BC RID: 25020 RVA: 0x0014E5C6 File Offset: 0x0014C7C6
		[__DynamicallyInvokable]
		public virtual bool CanResume()
		{
			return false;
		}
	}
}
