using System;
using System.Threading.Tasks;

namespace CefSharp.ModelBinding
{
	// Token: 0x020000B7 RID: 183
	public interface IAsyncMethodInterceptor : IMethodInterceptor
	{
		// Token: 0x0600058E RID: 1422
		Task<object> InterceptAsync(Func<object[], object> method, object[] parameters, string methodName);
	}
}
