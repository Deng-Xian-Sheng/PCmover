using System;
using System.Windows;

namespace Prism.Common
{
	// Token: 0x0200007F RID: 127
	public static class MvvmHelpers
	{
		// Token: 0x060003A4 RID: 932 RVA: 0x0000957C File Offset: 0x0000777C
		public static void ViewAndViewModelAction<T>(object view, Action<T> action) where T : class
		{
			T t = view as T;
			if (t != null)
			{
				action(t);
			}
			FrameworkElement frameworkElement = view as FrameworkElement;
			if (frameworkElement != null)
			{
				T t2 = frameworkElement.DataContext as T;
				if (t2 != null)
				{
					action(t2);
				}
			}
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x000095D0 File Offset: 0x000077D0
		public static T GetImplementerFromViewOrViewModel<T>(object view) where T : class
		{
			T t = view as T;
			if (t != null)
			{
				return t;
			}
			FrameworkElement frameworkElement = view as FrameworkElement;
			if (frameworkElement != null)
			{
				return frameworkElement.DataContext as T;
			}
			return default(T);
		}
	}
}
