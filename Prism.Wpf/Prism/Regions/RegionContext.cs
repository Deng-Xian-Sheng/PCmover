using System;
using System.Windows;
using Prism.Common;

namespace Prism.Regions
{
	// Token: 0x02000027 RID: 39
	public static class RegionContext
	{
		// Token: 0x060000F0 RID: 240 RVA: 0x00003748 File Offset: 0x00001948
		public static ObservableObject<object> GetObservableContext(DependencyObject view)
		{
			if (view == null)
			{
				throw new ArgumentNullException("view");
			}
			ObservableObject<object> observableObject = view.GetValue(RegionContext.ObservableRegionContextProperty) as ObservableObject<object>;
			if (observableObject == null)
			{
				observableObject = new ObservableObject<object>();
				view.SetValue(RegionContext.ObservableRegionContextProperty, observableObject);
			}
			return observableObject;
		}

		// Token: 0x04000022 RID: 34
		private static readonly DependencyProperty ObservableRegionContextProperty = DependencyProperty.RegisterAttached("ObservableRegionContext", typeof(ObservableObject<object>), typeof(RegionContext), null);
	}
}
