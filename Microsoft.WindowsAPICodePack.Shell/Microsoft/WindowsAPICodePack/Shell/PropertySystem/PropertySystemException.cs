using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x02000041 RID: 65
	[Serializable]
	public class PropertySystemException : ExternalException
	{
		// Token: 0x0600026F RID: 623 RVA: 0x0000AB04 File Offset: 0x00008D04
		public PropertySystemException()
		{
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000AB0F File Offset: 0x00008D0F
		public PropertySystemException(string message) : base(message)
		{
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000AB1B File Offset: 0x00008D1B
		public PropertySystemException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000AB28 File Offset: 0x00008D28
		public PropertySystemException(string message, int errorCode) : base(message, errorCode)
		{
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000AB35 File Offset: 0x00008D35
		protected PropertySystemException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
