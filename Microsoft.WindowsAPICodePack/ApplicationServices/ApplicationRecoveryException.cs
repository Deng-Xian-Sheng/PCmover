using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x02000003 RID: 3
	[Serializable]
	public class ApplicationRecoveryException : ExternalException
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000021F7 File Offset: 0x000003F7
		public ApplicationRecoveryException()
		{
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002202 File Offset: 0x00000402
		public ApplicationRecoveryException(string message) : base(message)
		{
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000220E File Offset: 0x0000040E
		public ApplicationRecoveryException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000221B File Offset: 0x0000041B
		public ApplicationRecoveryException(string message, int errorCode) : base(message, errorCode)
		{
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002228 File Offset: 0x00000428
		protected ApplicationRecoveryException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
