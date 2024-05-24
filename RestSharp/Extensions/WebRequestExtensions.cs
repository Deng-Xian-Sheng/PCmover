using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace RestSharp.Extensions
{
	// Token: 0x0200004F RID: 79
	[NullableContext(1)]
	[Nullable(0)]
	public static class WebRequestExtensions
	{
		// Token: 0x060004F6 RID: 1270 RVA: 0x0000C68D File Offset: 0x0000A88D
		public static Task<Stream> GetRequestStreamAsync(this WebRequest webRequest, CancellationToken cancellationToken)
		{
			return Task.Run<Stream>(() => Task<Stream>.Factory.FromAsync((AsyncCallback callback, object state) => ((WebRequest)state).BeginGetRequestStream(callback, state), (IAsyncResult iar) => ((WebRequest)iar.AsyncState).EndGetRequestStream(iar), webRequest), cancellationToken);
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0000C6AC File Offset: 0x0000A8AC
		public static Task<WebResponse> GetResponseAsync(this WebRequest webRequest, CancellationToken cancellationToken)
		{
			return Task.Run<WebResponse>(() => Task<WebResponse>.Factory.FromAsync((AsyncCallback callback, object state) => ((WebRequest)state).BeginGetResponse(callback, state), (IAsyncResult iar) => ((WebRequest)iar.AsyncState).EndGetResponse(iar), webRequest), cancellationToken);
		}
	}
}
