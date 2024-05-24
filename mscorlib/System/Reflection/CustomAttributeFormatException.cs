using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	// Token: 0x020005CD RID: 1485
	[ComVisible(true)]
	[Serializable]
	public class CustomAttributeFormatException : FormatException
	{
		// Token: 0x060044D6 RID: 17622 RVA: 0x000FD1D8 File Offset: 0x000FB3D8
		public CustomAttributeFormatException() : base(Environment.GetResourceString("Arg_CustomAttributeFormatException"))
		{
			base.SetErrorCode(-2146232827);
		}

		// Token: 0x060044D7 RID: 17623 RVA: 0x000FD1F5 File Offset: 0x000FB3F5
		public CustomAttributeFormatException(string message) : base(message)
		{
			base.SetErrorCode(-2146232827);
		}

		// Token: 0x060044D8 RID: 17624 RVA: 0x000FD209 File Offset: 0x000FB409
		public CustomAttributeFormatException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146232827);
		}

		// Token: 0x060044D9 RID: 17625 RVA: 0x000FD21E File Offset: 0x000FB41E
		protected CustomAttributeFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
