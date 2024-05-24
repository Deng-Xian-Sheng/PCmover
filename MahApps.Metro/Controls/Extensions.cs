using System;
using System.Windows.Threading;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200002E RID: 46
	public static class Extensions
	{
		// Token: 0x06000161 RID: 353 RVA: 0x00006F58 File Offset: 0x00005158
		public static T Invoke<T>(this DispatcherObject dispatcherObject, Func<T> func)
		{
			if (dispatcherObject == null)
			{
				throw new ArgumentNullException("dispatcherObject");
			}
			if (func == null)
			{
				throw new ArgumentNullException("func");
			}
			if (dispatcherObject.Dispatcher.CheckAccess())
			{
				return func();
			}
			return dispatcherObject.Dispatcher.Invoke<T>(new Func<T>(func.Invoke));
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00006FAC File Offset: 0x000051AC
		public static void Invoke(this DispatcherObject dispatcherObject, Action invokeAction)
		{
			if (dispatcherObject == null)
			{
				throw new ArgumentNullException("dispatcherObject");
			}
			if (invokeAction == null)
			{
				throw new ArgumentNullException("invokeAction");
			}
			if (dispatcherObject.Dispatcher.CheckAccess())
			{
				invokeAction();
				return;
			}
			dispatcherObject.Dispatcher.Invoke(invokeAction);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00006FEA File Offset: 0x000051EA
		public static void BeginInvoke(this DispatcherObject dispatcherObject, Action invokeAction, DispatcherPriority priority = DispatcherPriority.Background)
		{
			if (dispatcherObject == null)
			{
				throw new ArgumentNullException("dispatcherObject");
			}
			if (invokeAction == null)
			{
				throw new ArgumentNullException("invokeAction");
			}
			dispatcherObject.Dispatcher.BeginInvoke(priority, invokeAction);
		}
	}
}
