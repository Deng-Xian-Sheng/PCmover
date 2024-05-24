using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools
{
	// Token: 0x0200011B RID: 283
	[Serializable]
	public class DevToolsClientException : Exception
	{
		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000852 RID: 2130 RVA: 0x0000D590 File Offset: 0x0000B790
		// (set) Token: 0x06000853 RID: 2131 RVA: 0x0000D598 File Offset: 0x0000B798
		public DevToolsDomainErrorResponse Response { get; private set; }

		// Token: 0x06000854 RID: 2132 RVA: 0x0000D5A1 File Offset: 0x0000B7A1
		public DevToolsClientException() : base("Error occurred whilst executing DevTools protocol method")
		{
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x0000D5AE File Offset: 0x0000B7AE
		public DevToolsClientException(string message) : base(message)
		{
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0000D5B7 File Offset: 0x0000B7B7
		public DevToolsClientException(string message, DevToolsDomainErrorResponse errorResponse) : base(message)
		{
			this.Response = errorResponse;
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x0000D5C7 File Offset: 0x0000B7C7
		public DevToolsClientException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x0000D5D1 File Offset: 0x0000B7D1
		protected DevToolsClientException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
		{
		}
	}
}
