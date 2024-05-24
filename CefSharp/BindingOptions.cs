using System;
using CefSharp.ModelBinding;

namespace CefSharp
{
	// Token: 0x02000003 RID: 3
	public class BindingOptions
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000007 RID: 7 RVA: 0x0000218D File Offset: 0x0000038D
		public static BindingOptions DefaultBinder
		{
			get
			{
				return new BindingOptions
				{
					Binder = new DefaultBinder(null)
				};
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000021A0 File Offset: 0x000003A0
		// (set) Token: 0x06000009 RID: 9 RVA: 0x000021A8 File Offset: 0x000003A8
		public IBinder Binder { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000021B1 File Offset: 0x000003B1
		// (set) Token: 0x0600000B RID: 11 RVA: 0x000021B9 File Offset: 0x000003B9
		public IMethodInterceptor MethodInterceptor { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000021C2 File Offset: 0x000003C2
		// (set) Token: 0x0600000D RID: 13 RVA: 0x000021CA File Offset: 0x000003CA
		public IPropertyInterceptor PropertyInterceptor { get; set; }
	}
}
