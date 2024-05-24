using System;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x0200000A RID: 10
	[Serializable]
	public class PowerManagerException : Exception
	{
		// Token: 0x0600001E RID: 30 RVA: 0x000023F9 File Offset: 0x000005F9
		public PowerManagerException()
		{
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002404 File Offset: 0x00000604
		public PowerManagerException(string message) : base(message)
		{
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002410 File Offset: 0x00000610
		public PowerManagerException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000241D File Offset: 0x0000061D
		protected PowerManagerException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
