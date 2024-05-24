using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using MahApps.Metro.Controls;

namespace ThankYou.Views
{
	// Token: 0x0200000F RID: 15
	public partial class MainWindow : Window
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00002800 File Offset: 0x00000A00
		public MainWindow()
		{
			this.InitializeComponent();
			if (SystemParameters.PrimaryScreenHeight <= 768.0)
			{
				base.Height = Math.Min(base.Height, SystemParameters.PrimaryScreenHeight * 0.9);
				base.Width = Math.Min(base.Width, SystemParameters.PrimaryScreenWidth * 0.9);
			}
		}
	}
}
