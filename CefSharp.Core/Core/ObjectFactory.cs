using System;

namespace CefSharp.Core
{
	// Token: 0x02000011 RID: 17
	public static class ObjectFactory
	{
		// Token: 0x0600013D RID: 317 RVA: 0x00003544 File Offset: 0x00001744
		public static IBrowserSettings CreateBrowserSettings(bool autoDispose)
		{
			return new BrowserSettings(autoDispose);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000354C File Offset: 0x0000174C
		public static IWindowInfo CreateWindowInfo()
		{
			return new WindowInfo();
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00003553 File Offset: 0x00001753
		public static IPostData CreatePostData()
		{
			return new PostData();
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000355A File Offset: 0x0000175A
		public static IPostDataElement CreatePostDataElement()
		{
			return new PostDataElement();
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00003561 File Offset: 0x00001761
		public static IRequest CreateRequest()
		{
			return new Request();
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00003568 File Offset: 0x00001768
		public static IUrlRequest CreateUrlRequest(IRequest request, IUrlRequestClient urlRequestClient)
		{
			return new UrlRequest(request, urlRequestClient);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00003571 File Offset: 0x00001771
		public static IUrlRequest CreateUrlRequest(IRequest request, IUrlRequestClient urlRequestClient, IRequestContext requestContext)
		{
			return new UrlRequest(request, urlRequestClient, requestContext);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000357B File Offset: 0x0000177B
		public static IDragData CreateDragData()
		{
			return DragData.Create();
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00003582 File Offset: 0x00001782
		public static RequestContextBuilder ConfigureRequestContext()
		{
			return new RequestContextBuilder();
		}

		// Token: 0x0400000E RID: 14
		public static readonly Type BrowserSetingsType = typeof(BrowserSettings);

		// Token: 0x0400000F RID: 15
		public static readonly Type RequestContextType = typeof(RequestContext);
	}
}
