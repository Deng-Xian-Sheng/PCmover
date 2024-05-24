using System;
using CefSharp.Core;

namespace CefSharp
{
	// Token: 0x0200000E RID: 14
	public class UrlRequest : IUrlRequest, IDisposable
	{
		// Token: 0x06000113 RID: 275 RVA: 0x000031C7 File Offset: 0x000013C7
		public UrlRequest(IRequest request, IUrlRequestClient urlRequestClient) : this(request, urlRequestClient, null)
		{
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000031D4 File Offset: 0x000013D4
		public UrlRequest(IRequest request, IUrlRequestClient urlRequestClient, IRequestContext requestContext)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}
			if (urlRequestClient == null)
			{
				throw new ArgumentNullException("urlRequestClient");
			}
			this.urlRequest = new UrlRequest(request.UnWrap(), urlRequestClient, (requestContext != null) ? requestContext.UnWrap() : null);
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00003221 File Offset: 0x00001421
		public bool ResponseWasCached
		{
			get
			{
				return this.urlRequest.ResponseWasCached;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000116 RID: 278 RVA: 0x0000322E File Offset: 0x0000142E
		public IResponse Response
		{
			get
			{
				return this.urlRequest.Response;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000117 RID: 279 RVA: 0x0000323B File Offset: 0x0000143B
		public UrlRequestStatus RequestStatus
		{
			get
			{
				return this.urlRequest.RequestStatus;
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00003248 File Offset: 0x00001448
		public void Dispose()
		{
			this.urlRequest.Dispose();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00003255 File Offset: 0x00001455
		public IUrlRequest Create(IRequest request, IUrlRequestClient urlRequestClient)
		{
			return new UrlRequest(request, urlRequestClient);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000325E File Offset: 0x0000145E
		public IUrlRequest Create(IRequest request, IUrlRequestClient urlRequestClient, IRequestContext requestContext)
		{
			return new UrlRequest(request, urlRequestClient, requestContext);
		}

		// Token: 0x0400000C RID: 12
		private UrlRequest urlRequest;
	}
}
