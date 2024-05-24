using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Security.Cryptography
{
	// Token: 0x02000244 RID: 580
	[ComVisible(true)]
	[Serializable]
	public class CryptographicUnexpectedOperationException : CryptographicException
	{
		// Token: 0x060020B1 RID: 8369 RVA: 0x00072920 File Offset: 0x00070B20
		public CryptographicUnexpectedOperationException()
		{
			base.SetErrorCode(-2146233295);
		}

		// Token: 0x060020B2 RID: 8370 RVA: 0x00072933 File Offset: 0x00070B33
		public CryptographicUnexpectedOperationException(string message) : base(message)
		{
			base.SetErrorCode(-2146233295);
		}

		// Token: 0x060020B3 RID: 8371 RVA: 0x00072947 File Offset: 0x00070B47
		public CryptographicUnexpectedOperationException(string format, string insert) : base(string.Format(CultureInfo.CurrentCulture, format, insert))
		{
			base.SetErrorCode(-2146233295);
		}

		// Token: 0x060020B4 RID: 8372 RVA: 0x00072966 File Offset: 0x00070B66
		public CryptographicUnexpectedOperationException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233295);
		}

		// Token: 0x060020B5 RID: 8373 RVA: 0x0007297B File Offset: 0x00070B7B
		protected CryptographicUnexpectedOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
