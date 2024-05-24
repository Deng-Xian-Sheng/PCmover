using System;

namespace Microsoft.Practices.ServiceLocation
{
	// Token: 0x02000002 RID: 2
	public static class ServiceLocatorExtensions
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static object TryResolve(this IServiceLocator locator, Type type)
		{
			if (locator == null)
			{
				throw new ArgumentNullException("locator");
			}
			object result;
			try
			{
				result = locator.GetInstance(type);
			}
			catch (ActivationException)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000208C File Offset: 0x0000028C
		public static T TryResolve<T>(this IServiceLocator locator) where T : class
		{
			return locator.TryResolve(typeof(T)) as T;
		}
	}
}
