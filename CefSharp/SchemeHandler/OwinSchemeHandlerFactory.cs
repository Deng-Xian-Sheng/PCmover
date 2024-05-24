using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.SchemeHandler
{
	// Token: 0x020000AE RID: 174
	public class OwinSchemeHandlerFactory : ISchemeHandlerFactory
	{
		// Token: 0x0600055E RID: 1374 RVA: 0x000088D7 File Offset: 0x00006AD7
		public OwinSchemeHandlerFactory(Func<IDictionary<string, object>, Task> appFunc)
		{
			this.appFunc = appFunc;
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x000088E6 File Offset: 0x00006AE6
		public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
		{
			return new OwinResourceHandler(this.appFunc);
		}

		// Token: 0x0400030F RID: 783
		private readonly Func<IDictionary<string, object>, Task> appFunc;
	}
}
