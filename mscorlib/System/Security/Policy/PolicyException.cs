using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Security.Policy
{
	// Token: 0x02000362 RID: 866
	[ComVisible(true)]
	[Serializable]
	public class PolicyException : SystemException
	{
		// Token: 0x06002ACD RID: 10957 RVA: 0x0009E7FF File Offset: 0x0009C9FF
		public PolicyException() : base(Environment.GetResourceString("Policy_Default"))
		{
			base.HResult = -2146233322;
		}

		// Token: 0x06002ACE RID: 10958 RVA: 0x0009E81C File Offset: 0x0009CA1C
		public PolicyException(string message) : base(message)
		{
			base.HResult = -2146233322;
		}

		// Token: 0x06002ACF RID: 10959 RVA: 0x0009E830 File Offset: 0x0009CA30
		public PolicyException(string message, Exception exception) : base(message, exception)
		{
			base.HResult = -2146233322;
		}

		// Token: 0x06002AD0 RID: 10960 RVA: 0x0009E845 File Offset: 0x0009CA45
		protected PolicyException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x06002AD1 RID: 10961 RVA: 0x0009E84F File Offset: 0x0009CA4F
		internal PolicyException(string message, int hresult) : base(message)
		{
			base.HResult = hresult;
		}

		// Token: 0x06002AD2 RID: 10962 RVA: 0x0009E85F File Offset: 0x0009CA5F
		internal PolicyException(string message, int hresult, Exception exception) : base(message, exception)
		{
			base.HResult = hresult;
		}
	}
}
