using System;
using CefSharp.Enums;

namespace CefSharp
{
	// Token: 0x0200007C RID: 124
	public interface ISchemeRegistrar
	{
		// Token: 0x0600033F RID: 831
		bool AddCustomScheme(string schemeName, SchemeOptions schemeOptions);
	}
}
