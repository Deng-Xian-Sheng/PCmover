using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x02000023 RID: 35
	public class RestRequestAsyncHandle
	{
		// Token: 0x0600036B RID: 875 RVA: 0x00006BDC File Offset: 0x00004DDC
		public void Abort()
		{
			HttpWebRequest webRequest = this.WebRequest;
			if (webRequest == null)
			{
				return;
			}
			webRequest.Abort();
		}

		// Token: 0x040000BF RID: 191
		[Nullable(1)]
		public HttpWebRequest WebRequest;
	}
}
