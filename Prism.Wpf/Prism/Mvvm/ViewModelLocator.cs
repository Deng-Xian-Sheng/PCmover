using System;
using System.Windows;

namespace Prism.Mvvm
{
	// Token: 0x02000046 RID: 70
	public static class ViewModelLocator
	{
		// Token: 0x0600021B RID: 539 RVA: 0x00006509 File Offset: 0x00004709
		public static bool GetAutoWireViewModel(DependencyObject obj)
		{
			return (bool)obj.GetValue(ViewModelLocator.AutoWireViewModelProperty);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000651B File Offset: 0x0000471B
		public static void SetAutoWireViewModel(DependencyObject obj, bool value)
		{
			obj.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000652E File Offset: 0x0000472E
		private static void AutoWireViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if ((bool)e.NewValue)
			{
				ViewModelLocationProvider.AutoWireViewModelChanged(d, new Action<object, object>(ViewModelLocator.Bind));
			}
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00006550 File Offset: 0x00004750
		private static void Bind(object view, object viewModel)
		{
			FrameworkElement frameworkElement = view as FrameworkElement;
			if (frameworkElement != null)
			{
				frameworkElement.DataContext = viewModel;
			}
		}

		// Token: 0x04000063 RID: 99
		public static DependencyProperty AutoWireViewModelProperty = DependencyProperty.RegisterAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(false, new PropertyChangedCallback(ViewModelLocator.AutoWireViewModelChanged)));
	}
}
