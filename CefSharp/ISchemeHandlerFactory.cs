using System;

namespace CefSharp
{
	// Token: 0x02000092 RID: 146
	public interface ISchemeHandlerFactory
	{
		// Token: 0x0600043C RID: 1084
		IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request);
	}
}
