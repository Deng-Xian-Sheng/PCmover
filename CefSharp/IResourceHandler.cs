using System;
using System.IO;
using CefSharp.Callback;

namespace CefSharp
{
	// Token: 0x02000061 RID: 97
	public interface IResourceHandler : IDisposable
	{
		// Token: 0x06000174 RID: 372
		bool Open(IRequest request, out bool handleRequest, ICallback callback);

		// Token: 0x06000175 RID: 373
		[Obsolete("This method is deprecated and will be removed in the next version. Use Open instead.")]
		bool ProcessRequest(IRequest request, ICallback callback);

		// Token: 0x06000176 RID: 374
		void GetResponseHeaders(IResponse response, out long responseLength, out string redirectUrl);

		// Token: 0x06000177 RID: 375
		bool Skip(long bytesToSkip, out long bytesSkipped, IResourceSkipCallback callback);

		// Token: 0x06000178 RID: 376
		bool Read(Stream dataOut, out int bytesRead, IResourceReadCallback callback);

		// Token: 0x06000179 RID: 377
		[Obsolete("This method is deprecated and will be removed in the next version. Use Skip and Read instead.")]
		bool ReadResponse(Stream dataOut, out int bytesRead, ICallback callback);

		// Token: 0x0600017A RID: 378
		void Cancel();
	}
}
