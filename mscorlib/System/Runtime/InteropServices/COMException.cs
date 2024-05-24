using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security;
using Microsoft.Win32;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000943 RID: 2371
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class COMException : ExternalException
	{
		// Token: 0x0600605F RID: 24671 RVA: 0x0014BEFD File Offset: 0x0014A0FD
		[__DynamicallyInvokable]
		public COMException() : base(Environment.GetResourceString("Arg_COMException"))
		{
			base.SetErrorCode(-2147467259);
		}

		// Token: 0x06006060 RID: 24672 RVA: 0x0014BF1A File Offset: 0x0014A11A
		[__DynamicallyInvokable]
		public COMException(string message) : base(message)
		{
			base.SetErrorCode(-2147467259);
		}

		// Token: 0x06006061 RID: 24673 RVA: 0x0014BF2E File Offset: 0x0014A12E
		[__DynamicallyInvokable]
		public COMException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2147467259);
		}

		// Token: 0x06006062 RID: 24674 RVA: 0x0014BF43 File Offset: 0x0014A143
		[__DynamicallyInvokable]
		public COMException(string message, int errorCode) : base(message)
		{
			base.SetErrorCode(errorCode);
		}

		// Token: 0x06006063 RID: 24675 RVA: 0x0014BF53 File Offset: 0x0014A153
		[SecuritySafeCritical]
		internal COMException(int hresult) : base(Win32Native.GetMessage(hresult))
		{
			base.SetErrorCode(hresult);
		}

		// Token: 0x06006064 RID: 24676 RVA: 0x0014BF68 File Offset: 0x0014A168
		internal COMException(string message, int hresult, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(hresult);
		}

		// Token: 0x06006065 RID: 24677 RVA: 0x0014BF79 File Offset: 0x0014A179
		protected COMException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x06006066 RID: 24678 RVA: 0x0014BF84 File Offset: 0x0014A184
		public override string ToString()
		{
			string message = this.Message;
			string str = base.GetType().ToString();
			string text = str + " (0x" + base.HResult.ToString("X8", CultureInfo.InvariantCulture) + ")";
			if (message != null && message.Length > 0)
			{
				text = text + ": " + message;
			}
			Exception innerException = base.InnerException;
			if (innerException != null)
			{
				text = text + " ---> " + innerException.ToString();
			}
			if (this.StackTrace != null)
			{
				text = text + Environment.NewLine + this.StackTrace;
			}
			return text;
		}
	}
}
