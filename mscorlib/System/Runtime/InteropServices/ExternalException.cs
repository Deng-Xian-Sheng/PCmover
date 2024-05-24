using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000945 RID: 2373
	[ComVisible(true)]
	[Serializable]
	public class ExternalException : SystemException
	{
		// Token: 0x06006073 RID: 24691 RVA: 0x0014C0E4 File Offset: 0x0014A2E4
		public ExternalException() : base(Environment.GetResourceString("Arg_ExternalException"))
		{
			base.SetErrorCode(-2147467259);
		}

		// Token: 0x06006074 RID: 24692 RVA: 0x0014C101 File Offset: 0x0014A301
		public ExternalException(string message) : base(message)
		{
			base.SetErrorCode(-2147467259);
		}

		// Token: 0x06006075 RID: 24693 RVA: 0x0014C115 File Offset: 0x0014A315
		public ExternalException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2147467259);
		}

		// Token: 0x06006076 RID: 24694 RVA: 0x0014C12A File Offset: 0x0014A32A
		public ExternalException(string message, int errorCode) : base(message)
		{
			base.SetErrorCode(errorCode);
		}

		// Token: 0x06006077 RID: 24695 RVA: 0x0014C13A File Offset: 0x0014A33A
		protected ExternalException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x170010F8 RID: 4344
		// (get) Token: 0x06006078 RID: 24696 RVA: 0x0014C144 File Offset: 0x0014A344
		public virtual int ErrorCode
		{
			get
			{
				return base.HResult;
			}
		}

		// Token: 0x06006079 RID: 24697 RVA: 0x0014C14C File Offset: 0x0014A34C
		public override string ToString()
		{
			string message = this.Message;
			string str = base.GetType().ToString();
			string text = str + " (0x" + base.HResult.ToString("X8", CultureInfo.InvariantCulture) + ")";
			if (!string.IsNullOrEmpty(message))
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
