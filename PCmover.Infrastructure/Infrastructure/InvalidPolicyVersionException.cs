using System;
using System.Runtime.Serialization;

namespace PCmover.Infrastructure
{
	// Token: 0x02000019 RID: 25
	[Serializable]
	public class InvalidPolicyVersionException : Exception
	{
		// Token: 0x0600015E RID: 350 RVA: 0x00004DC2 File Offset: 0x00002FC2
		public InvalidPolicyVersionException()
		{
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00004DCA File Offset: 0x00002FCA
		public InvalidPolicyVersionException(string message) : base(message)
		{
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00004DD3 File Offset: 0x00002FD3
		public InvalidPolicyVersionException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00004DC2 File Offset: 0x00002FC2
		protected InvalidPolicyVersionException(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}
	}
}
