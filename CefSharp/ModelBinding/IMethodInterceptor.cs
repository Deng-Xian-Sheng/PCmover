using System;

namespace CefSharp.ModelBinding
{
	// Token: 0x020000B9 RID: 185
	public interface IMethodInterceptor
	{
		// Token: 0x06000590 RID: 1424
		object Intercept(Func<object[], object> method, object[] parameters, string methodName);
	}
}
