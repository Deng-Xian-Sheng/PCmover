using System;
using System.Linq.Expressions;

namespace CefSharp.Internals
{
	// Token: 0x020000E8 RID: 232
	internal static class ReflectionUtils
	{
		// Token: 0x060006F1 RID: 1777 RVA: 0x0000B5E0 File Offset: 0x000097E0
		public static string GetMethodName<T>(Expression<Func<T, object>> expression)
		{
			MethodCallExpression methodCallExpression = (MethodCallExpression)expression.Body;
			return methodCallExpression.Method.Name;
		}
	}
}
