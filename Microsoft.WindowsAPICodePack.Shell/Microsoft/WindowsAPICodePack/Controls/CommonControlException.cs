using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x02000025 RID: 37
	[Serializable]
	public class CommonControlException : COMException
	{
		// Token: 0x06000134 RID: 308 RVA: 0x0000675B File Offset: 0x0000495B
		public CommonControlException()
		{
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00006766 File Offset: 0x00004966
		public CommonControlException(string message) : base(message)
		{
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00006772 File Offset: 0x00004972
		public CommonControlException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000677F File Offset: 0x0000497F
		public CommonControlException(string message, int errorCode) : base(message, errorCode)
		{
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000678C File Offset: 0x0000498C
		internal CommonControlException(string message, HResult errorCode) : this(message, (int)errorCode)
		{
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00006799 File Offset: 0x00004999
		protected CommonControlException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
