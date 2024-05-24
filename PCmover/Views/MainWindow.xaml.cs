using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using WizardModule.Views.Controls;

namespace PCmover.Views
{
	// Token: 0x02000009 RID: 9
	public partial class MainWindow : Window
	{
		// Token: 0x06000062 RID: 98 RVA: 0x00002D44 File Offset: 0x00000F44
		public MainWindow()
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			base.Closing += this.MainWindow_Closing;
			base.PreviewKeyDown += this.MainWindow_PreviewKeyDown;
			if (SystemParameters.PrimaryScreenHeight <= 768.0)
			{
				base.WindowState = WindowState.Maximized;
				return;
			}
			base.Height = Math.Min(base.Height, SystemParameters.PrimaryScreenHeight * 0.8);
			base.Width = Math.Min(base.Width, SystemParameters.PrimaryScreenWidth * 0.8);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002DF4 File Offset: 0x00000FF4
		private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Home || e.Key == Key.End)
			{
				e.Handled = true;
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002E11 File Offset: 0x00001011
		private void MainWindow_Closing(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
		}
	}
}
