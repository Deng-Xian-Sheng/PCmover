using System;

namespace CefSharp.ModelBinding
{
	// Token: 0x020000BA RID: 186
	public interface IPropertyInterceptor
	{
		// Token: 0x06000591 RID: 1425
		object InterceptGet(Func<object> propertyGetter, string propertName);

		// Token: 0x06000592 RID: 1426
		void InterceptSet(Action<object> propertySetter, object parameter, string propertName);
	}
}
