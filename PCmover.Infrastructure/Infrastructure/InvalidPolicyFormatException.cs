using System;
using System.Runtime.Serialization;

namespace PCmover.Infrastructure
{
	// Token: 0x0200001A RID: 26
	[Serializable]
	public class InvalidPolicyFormatException : Exception
	{
		// Token: 0x06000162 RID: 354 RVA: 0x00004DC2 File Offset: 0x00002FC2
		public InvalidPolicyFormatException()
		{
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00004DCA File Offset: 0x00002FCA
		public InvalidPolicyFormatException(string message) : base(message)
		{
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00004DD3 File Offset: 0x00002FD3
		public InvalidPolicyFormatException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00004DC2 File Offset: 0x00002FC2
		protected InvalidPolicyFormatException(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}
	}
}
